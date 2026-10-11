using System;
using System.Drawing;
using System.Windows.Forms;
using MatthewDumasProject1.Model;

namespace MatthewDumasProject1
{
    public partial class CarLotForm : Form
    {
        private readonly CarLot carLot;
        private Shopper? shopper;

        private readonly ListBox lstInventory;
        private readonly Label lblShopperName;
        private readonly Label lblMoneyAvailable;

        private readonly Button btnCreateShopper;
        private readonly Button btnPurchaseCar;
        private readonly Button btnInventoryDetails;

        private readonly MenuStrip menuStrip;

        public CarLotForm()
        {
            InitializeComponent();

            carLot = new CarLot();
            shopper = null;

            Text = "Car Lot Management";
            ClientSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;

            // Main menu
            menuStrip = new MenuStrip();

            ToolStripMenuItem inventoryMenu =
                new ToolStripMenuItem("Inventory");

            ToolStripMenuItem addCarItem =
                new ToolStripMenuItem("Add Car");
            
            addCarItem.Click += AddCarItem_Click;

            ToolStripMenuItem detailsItem =
                new ToolStripMenuItem("Inventory Details");

            inventoryMenu.DropDownItems.Add(addCarItem);
            inventoryMenu.DropDownItems.Add(detailsItem);

            menuStrip.Items.Add(inventoryMenu);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            // Inventory heading
            Label lblInventory = new Label
            {
                Text = "Available Vehicles",
                Location = new Point(30, 55),
                AutoSize = true,
                Font = new Font("Segoe UI", 14, FontStyle.Bold)
            };

            Controls.Add(lblInventory);

            // Inventory list
            lstInventory = new ListBox
            {
                Location = new Point(30, 95),
                Size = new Size(830, 260),
                Font = new Font("Consolas", 11)
            };

            Controls.Add(lstInventory);

            // Shopper information
            lblShopperName = new Label
            {
                Text = "Shopper: Not Created",
                Location = new Point(30, 380),
                AutoSize = true,
                Font = new Font("Segoe UI", 11)
            };

            Controls.Add(lblShopperName);

            lblMoneyAvailable = new Label
            {
                Text = "Money Available: $0.00",
                Location = new Point(30, 410),
                AutoSize = true,
                Font = new Font("Segoe UI", 11)
            };

            Controls.Add(lblMoneyAvailable);

            // Create shopper button
            btnCreateShopper = new Button
            {
                Text = "Create Shopper",
                Location = new Point(30, 470),
                Size = new Size(180, 45)
            };

            Controls.Add(btnCreateShopper);

            btnCreateShopper.Click += BtnCreateShopper_Click;

            // Purchase car button
            btnPurchaseCar = new Button
            {
                Text = "Purchase Car",
                Location = new Point(230, 470),
                Size = new Size(180, 45)
            };

            Controls.Add(btnPurchaseCar);

            // Inventory details button
            btnInventoryDetails = new Button
            {
                Text = "Inventory Details",
                Location = new Point(430, 470),
                Size = new Size(180, 45)
            };

            Controls.Add(btnInventoryDetails);

            // Load default inventory
            RefreshInventory();
        }

        private void RefreshInventory()
        {
            lstInventory.Items.Clear();

            foreach (Car car in carLot.Inventory)
            {
                string display =
                    $"{car.Make} {car.Model} " +
                    $"{car.Price:C2} {car.Mpg:F1}mpg";

                lstInventory.Items.Add(display);
            }
        }
        private void AddCarItem_Click(object? sender, EventArgs e)
        {
            using AddCarForm addCarForm = new AddCarForm();

            if (addCarForm.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    carLot.AddCar(
                        addCarForm.CarMake,
                        addCarForm.CarModel,
                        addCarForm.CarMpg,
                        addCarForm.CarPrice);

                    RefreshInventory();

                    MessageBox.Show(
                        "Car successfully added to inventory!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Invalid Car",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnCreateShopper_Click(
            object? sender, EventArgs e)
        {
            using CreateShopperForm shopperForm =
                new CreateShopperForm();

            if (shopperForm.ShowDialog(this) == DialogResult.OK)
            {
                Shopper? newShopper = shopperForm.CreatedShopper;

                if (newShopper != null)
                {
                    shopper = newShopper;

                    lblShopperName.Text =
                        $"Shopper: {shopper.Name}";

                    lblMoneyAvailable.Text =
                        $"Money Available: {shopper.MoneyAvailable:C2}";

                    MessageBox.Show(
                        $"Shopper {shopper.Name} created successfully!",
                        "Shopper Created",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
    }
}
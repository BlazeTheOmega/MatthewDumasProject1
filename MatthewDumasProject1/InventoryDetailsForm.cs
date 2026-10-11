using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MatthewDumasProject1.Model;

namespace MatthewDumasProject1
{
    public class InventoryDetailsForm : Form
    {
        private readonly CarLot carLot;

        public InventoryDetailsForm(CarLot lot)
        {
            carLot = lot;

            Text = "Inventory Details";
            ClientSize = new Size(700, 600);
            StartPosition = FormStartPosition.CenterParent;
            MinimumSize = new Size(550, 450);

            Label lblTitle = new Label
            {
                Text = "Car Lot Inventory Details",
                Location = new Point(25, 20),
                AutoSize = true,
                Font = new Font(
                    "Segoe UI",
                    16,
                    FontStyle.Bold)
            };

            Controls.Add(lblTitle);

            TextBox txtDetails = new TextBox
            {
                Location = new Point(25, 65),
                Size = new Size(650, 450),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new Font("Consolas", 11),
                Anchor = AnchorStyles.Top |
                         AnchorStyles.Bottom |
                         AnchorStyles.Left |
                         AnchorStyles.Right
            };

            Controls.Add(txtDetails);

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(575, 535),
                Size = new Size(100, 35),
                Anchor = AnchorStyles.Bottom |
                         AnchorStyles.Right
            };

            btnClose.Click += (sender, e) => Close();

            Controls.Add(btnClose);

            txtDetails.Text = BuildInventoryDetails();
        }

        private string BuildInventoryDetails()
        {
            StringBuilder details = new StringBuilder();

            details.AppendLine("CAR LOT INVENTORY");
            details.AppendLine(
                "========================================");

            details.AppendLine(
                $"Total Vehicles: {carLot.Count}");

            details.AppendLine();

            if (carLot.Count == 0)
            {
                details.AppendLine(
                    "There are currently no cars in inventory.");

                return details.ToString();
            }

            details.AppendLine("AVAILABLE VEHICLES");
            details.AppendLine(
                "----------------------------------------");

            foreach (Car car in carLot.Inventory)
            {
                details.AppendLine(
                    $"{car.Make} {car.Model}");

                details.AppendLine(
                    $"  Price: {car.Price:C2}");

                details.AppendLine(
                    $"  MPG:   {car.Mpg:F1}");

                details.AppendLine();
            }

            details.AppendLine(
                "========================================");

            details.AppendLine("INVENTORY STATISTICS");
            details.AppendLine();

            Car? leastExpensive =
                carLot.FindLeastExpensiveCar();

            Car? mostExpensive =
                carLot.FindMostExpensiveCar();

            Car? bestMpg =
                carLot.FindBestMPGCar();

            Car? worstMpg =
                carLot.FindWorstMPG();

            if (leastExpensive != null)
            {
                details.AppendLine("LEAST EXPENSIVE CAR");

                details.AppendLine(
                    $"{leastExpensive.Make} " +
                    $"{leastExpensive.Model}");

                details.AppendLine(
                    $"Price: {leastExpensive.Price:C2}");

                details.AppendLine();
            }

            if (mostExpensive != null)
            {
                details.AppendLine("MOST EXPENSIVE CAR");

                details.AppendLine(
                    $"{mostExpensive.Make} " +
                    $"{mostExpensive.Model}");

                details.AppendLine(
                    $"Price: {mostExpensive.Price:C2}");

                details.AppendLine();
            }

            if (bestMpg != null)
            {
                details.AppendLine("BEST MPG CAR");

                details.AppendLine(
                    $"{bestMpg.Make} {bestMpg.Model}");

                details.AppendLine(
                    $"MPG: {bestMpg.Mpg:F1}");

                details.AppendLine();
            }

            if (worstMpg != null)
            {
                details.AppendLine("WORST MPG CAR");

                details.AppendLine(
                    $"{worstMpg.Make} {worstMpg.Model}");

                details.AppendLine(
                    $"MPG: {worstMpg.Mpg:F1}");

                details.AppendLine();
            }

            return details.ToString();
        }
    }
}
using System;
using System.Drawing;
using System.Windows.Forms;
using MatthewDumasProject1.Model;

namespace MatthewDumasProject1
{
    public class CreateShopperForm : Form
    {
        private readonly TextBox txtName;
        private readonly TextBox txtMoney;

        public Shopper? CreatedShopper { get; private set; }

        public CreateShopperForm()
        {
            Text = "Create Shopper";
            ClientSize = new Size(420, 230);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // Shopper name label
            Label lblName = new Label
            {
                Text = "Shopper Name:",
                Location = new Point(30, 35),
                AutoSize = true
            };

            Controls.Add(lblName);

            // Shopper name textbox
            txtName = new TextBox
            {
                Location = new Point(160, 30),
                Size = new Size(220, 25)
            };

            Controls.Add(txtName);

            // Money available label
            Label lblMoney = new Label
            {
                Text = "Money Available:",
                Location = new Point(30, 85),
                AutoSize = true
            };

            Controls.Add(lblMoney);

            // Money available textbox
            txtMoney = new TextBox
            {
                Location = new Point(160, 80),
                Size = new Size(220, 25)
            };

            Controls.Add(txtMoney);

            // Save button
            Button btnSave = new Button
            {
                Text = "Create Shopper",
                Location = new Point(140, 150),
                Size = new Size(120, 40)
            };

            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);

            // Cancel button
            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(275, 150),
                Size = new Size(100, 40),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(btnCancel);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // Validate shopper name
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(
                    "Please enter a shopper name.",
                    "Invalid Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validate available money
            if (!decimal.TryParse(txtMoney.Text,
                out decimal moneyAvailable) ||
                moneyAvailable < 0)
            {
                MessageBox.Show(
                    "Please enter a valid non-negative amount.",
                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                CreatedShopper = new Shopper(
                    txtName.Text.Trim(),
                    moneyAvailable);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Invalid Shopper",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
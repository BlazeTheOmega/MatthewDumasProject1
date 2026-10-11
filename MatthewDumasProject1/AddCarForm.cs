using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatthewDumasProject1
{
    public class AddCarForm : Form
    {
        private readonly TextBox txtMake;
        private readonly TextBox txtModel;
        private readonly TextBox txtMpg;
        private readonly TextBox txtPrice;

        public string CarMake => txtMake.Text.Trim();
        public string CarModel => txtModel.Text.Trim();
        public double CarMpg { get; private set; }
        public decimal CarPrice { get; private set; }

        public AddCarForm()
        {
            Text = "Add New Car";
            ClientSize = new Size(400, 330);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(new Label
            {
                Text = "Make:",
                Location = new Point(30, 30),
                AutoSize = true
            });

            txtMake = new TextBox
            {
                Location = new Point(140, 25),
                Width = 210
            };
            Controls.Add(txtMake);

            Controls.Add(new Label
            {
                Text = "Model:",
                Location = new Point(30, 80),
                AutoSize = true
            });

            txtModel = new TextBox
            {
                Location = new Point(140, 75),
                Width = 210
            };
            Controls.Add(txtModel);

            Controls.Add(new Label
            {
                Text = "MPG:",
                Location = new Point(30, 130),
                AutoSize = true
            });

            txtMpg = new TextBox
            {
                Location = new Point(140, 125),
                Width = 210
            };
            Controls.Add(txtMpg);

            Controls.Add(new Label
            {
                Text = "Price:",
                Location = new Point(30, 180),
                AutoSize = true
            });

            txtPrice = new TextBox
            {
                Location = new Point(140, 175),
                Width = 210
            };
            Controls.Add(txtPrice);

            Button btnSave = new Button
            {
                Text = "Save Car",
                Location = new Point(140, 245),
                Size = new Size(100, 40)
            };

            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(250, 245),
                Size = new Size(100, 40),
                DialogResult = DialogResult.Cancel
            };

            Controls.Add(btnCancel);
            CancelButton = btnCancel;
            AcceptButton = btnSave;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CarMake) ||
                string.IsNullOrWhiteSpace(CarModel))
            {
                MessageBox.Show(
                    "Make and Model cannot be empty.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtMpg.Text, out double mpg) ||
                !double.IsFinite(mpg) || mpg <= 0)
            {
                MessageBox.Show(
                    "Enter a valid MPG greater than zero.",
                    "Invalid MPG",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price) ||
                price < 0)
            {
                MessageBox.Show(
                    "Enter a valid non-negative price.",
                    "Invalid Price",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CarMpg = mpg;
            CarPrice = price;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
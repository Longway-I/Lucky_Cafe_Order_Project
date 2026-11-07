using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LuckyCafeOrder
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        // ---------------- Calculate Order ----------------
        private void btnCalculate_Click_1(object sender, EventArgs e)
        {
            // Customer name must not be empty
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the customer name.", "Error");
                return;
            }

            // Quantity must be a number and at least 1
            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 1)
            {
                MessageBox.Show("Quantity must be a number of 1 or more.", "Error");
                return;
            }

            // Get drink name and price
            string drinkName;
            double price;

            if (rdoTea.Checked)
            {
                drinkName = "Tea";
                price = 1;
            }
            else if (rdoCoffee.Checked)
            {
                drinkName = "Coffee";
                price = 2;
            }
            else if (rdoJuice.Checked)
            {
                drinkName = "Juice";
                price = 3;
            }
            else
            {
                MessageBox.Show("Please select a drink.", "Error");
                return;
            }

            // Clear the ListBox first
            lstOrder.Items.Clear();

            bool gotPrize = false;

            // Loop from 1 to Quantity
            for (int i = 1; i <= quantity; i++)
            {
                int lucky = rnd.Next(1, 51); // 1 to 50

                lstOrder.Items.Add(i + ") " + txtName.Text.Trim() + " - " + drinkName +
                                   " - Lucky: " + lucky + " - $" + price.ToString("0.00"));

                if (lucky == 7 || lucky == 17)
                {
                    gotPrize = true;
                }
            }

            // Total = drink price x quantity
            double total = price * quantity;

            // 10% student discount
            if (chkStudent.Checked)
            {
                total = total * 0.90;
            }

            lblTotalPrice.Text = "Total Price: $" + total.ToString("0.00");

            // Lucky rule
            if (gotPrize)
            {
                lblLuckyMessage.Text = "Lucky Message: You got a Free Cookie!";
            }
            else
            {
                lblLuckyMessage.Text = "Lucky Message: No prize this time.";
            }
        }

        // ---------------- Save to File ----------------
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (lstOrder.Items.Count == 0)
            {
                MessageBox.Show("No order to save.");
                return;
            }

            StreamWriter writer = File.AppendText("ListOrder.txt");

            for (int i = 0; i < lstOrder.Items.Count; i++)
            {
                writer.WriteLine(lstOrder.Items[i].ToString());
            }

            writer.WriteLine(lblTotalPrice.Text);
            writer.WriteLine(lblLuckyMessage.Text);

            writer.Close();

            MessageBox.Show("Order saved.");
        }

        // ---------------- Load from File ----------------
        private void btnLoad_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists("ListOrder.txt"))
            {
                MessageBox.Show("No file found.");
                return;
            }

            lstOrder.Items.Clear();

            StreamReader reader = File.OpenText("ListOrder.txt");

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                lstOrder.Items.Add(line);
            }

            reader.Close();
        }

        // ---------------- Clear ----------------
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtName.Clear();
            txtQuantity.Clear();
            lstOrder.Items.Clear();
            lblTotalPrice.Text = "Total Price: ";
            lblLuckyMessage.Text = "Lucky Message: ";
            chkStudent.Checked = false;
            rdoTea.Checked = false;
            rdoCoffee.Checked = false;
            rdoJuice.Checked = false;

        }
    }
}
    

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb; // For connecting to Access databases
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // For handling file and memory streams
using System.Drawing.Imaging;
using System.Drawing.Text; // For working with images and saving them in different formats

namespace Hebrews_Coffee
{
    public partial class Dinein : Form
    {
        private OleDbConnection connection;


        public Dinein()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");
            LoadProduct();

            // Initialize DataGridView for the cart
        }

        private void Dinein_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hebrewsDataSet55.Oder' table. You can move, or remove it, as needed.
            this.oderTableAdapter4.Fill(this.hebrewsDataSet55.Oder);
            // TODO: This line of code loads data into the 'hebrewsDataSet53.Oder' table. You can move, or remove it, as needed.
            this.oderTableAdapter3.Fill(this.hebrewsDataSet53.Oder);


        }

        private DataTable cartTable;  // Table to hold cart items

        private void LoadProduct()
        {
            try
            {
                connection.Open();
                string query = "SELECT Product_name, Price, Photo, Category FROM Product";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                OleDbDataReader reader = cmd.ExecuteReader();

                // Create a DataTable for the cart items if it doesn't exist
                if (cartTable == null)
                {
                    cartTable = new DataTable();
                    cartTable.Columns.Add("ProductName");
                    cartTable.Columns.Add("Price");
                    cartTable.Columns.Add("Quantity", typeof(int));
                }

                dgvcart.DataSource = cartTable;

                while (reader.Read())
                {
                    // Create a panel to display product details
                    Panel productPanel = new Panel
                    {
                        Width = 200,
                        Height = 300, // Increased height to accommodate the category label
                        BorderStyle = BorderStyle.FixedSingle
                    };

                    // Product Name, Price, Category, and Image
                    string productName = reader["Product_name"].ToString();
                    decimal price = Convert.ToDecimal(reader["Price"]);
                    string category = reader["Category"].ToString();

                    Label lblName = new Label
                    {
                        Text = productName,
                        Location = new Point(75, 160),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true
                    };

                    Label lblPrice = new Label
                    {
                        Text = "Price: $" + price.ToString(),
                        Location = new Point(60, 220),
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true
                    };

                    Label lblCategory = new Label
                    {
                        Text = " " + category,
                        Location = new Point(61, 190),
                        Font = new Font("Arial", 10, FontStyle.Regular),
                        AutoSize = true
                    };

                    PictureBox picImage = new PictureBox
                    {
                        Location = new Point(7, -25),
                        Size = new Size(170, 170),
                        BorderStyle = BorderStyle.None,
                        SizeMode = PictureBoxSizeMode.Zoom
                    };

                    if (reader["Photo"] != DBNull.Value)
                    {
                        byte[] imageData = (byte[])reader["Photo"];
                        MemoryStream ms = new MemoryStream(imageData);
                        picImage.Image = Image.FromStream(ms);
                    }

                    // Add controls to the panel
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(lblPrice);
                    productPanel.Controls.Add(lblCategory);
                    productPanel.Controls.Add(picImage);

                    Button btnAddToOrder = new Button
                    {
                        Text = "Add to Order",
                        Size = new Size(100, 30),
                        Location = new Point((productPanel.Width - 100) / 2, lblCategory.Bottom + 50),
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.Black,
                        BackColor = Color.White
                    };

                    btnAddToOrder.Click += (s, e) =>
                    {
                        // Add or update item in the cart
                        DataRow[] existingRows = cartTable.Select("ProductName = '" + productName + "'");

                        if (existingRows.Length > 0)
                        {
                            existingRows[0]["Quantity"] = (int)existingRows[0]["Quantity"] + 1;
                        }
                        else
                        {
                            cartTable.Rows.Add(productName, price, 1);
                        }

                        // Update total price
                        UpdateTotalPrice();
                    };

                    Button btnMinusFromOrder = new Button
                    {
                        Text = " —",
                        Size = new Size(30, 30),
                        Font = new Font("Arial", 6, FontStyle.Bold),
                        Location = new Point((productPanel.Width - 100) / 2 - 35, lblCategory.Bottom + 50),
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.Black,
                        BackColor = Color.White

                    };

                    btnMinusFromOrder.Click += (s, e) =>
                    {
                        // Find the existing item in the cart
                        DataRow[] existingRows = cartTable.Select("ProductName = '" + productName + "'");

                        if (existingRows.Length > 0)
                        {
                            int currentQuantity = (int)existingRows[0]["Quantity"];

                            // Decrease quantity if more than 1, or remove the item if quantity reaches 0
                            if (currentQuantity > 1)
                            {
                                existingRows[0]["Quantity"] = currentQuantity - 1;
                            }
                            else
                            {
                                cartTable.Rows.Remove(existingRows[0]);
                            }

                            // Update total price
                            UpdateTotalPrice();
                        }
                    };

                    // Add the Add and Minus buttons to the panel
                    productPanel.Controls.Add(btnAddToOrder);
                    productPanel.Controls.Add(btnMinusFromOrder);

                    flowLayoutPanel1.Controls.Add(productPanel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0.0m;

            // Check if the cartTable is not null and has rows
            if (cartTable != null && cartTable.Rows.Count > 0)
            {
                // Loop through each row in the cart table
                foreach (DataRow row in cartTable.Rows)
                {
                    // Use safe conversion methods to avoid exceptions
                    decimal price = Convert.ToDecimal(row["Price"] ?? 0.0m);
                    int quantity = Convert.ToInt32(row["Quantity"] ?? 0);

                    // Add the total cost of each item to the running total
                    total += price * quantity;
                }
            }

            // Update the textbox with the calculated total
            txtTotalPrice.Text = "Total:                                ₱ " + total.ToString("N2");  // N2 ensures two decimal places
            }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            // Check if the cart is empty
            if (cartTable == null || cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty. Please add items to your cart before proceeding.",
                                "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Exit the method and prevent further code execution
            }

            // Create a string to store product names and their respective prices
            StringBuilder productList = new StringBuilder();
            decimal total = 0.0m;

            // Generate a random receipt number
            Random random = new Random();
            int receiptNumber = random.Next(100000, 999999);  // Generates a random 6-digit number

            // Loop through each row in the cart table
            foreach (DataRow row in cartTable.Rows)
            {
                string productName = row["ProductName"].ToString();
                decimal price = Convert.ToDecimal(row["Price"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal productTotal = price * quantity;

                // Append product details to the string
                productList.AppendLine($"{productName} - {quantity} x ₱{price.ToString("N2")} = ₱{productTotal.ToString("N2")}");
                total += productTotal; // Add to the running total
            }

            // Show the products and total in the first message box (Order Summary) with Yes/No options
            string orderSummary = "Products in your cart: Dine-In\n\n" + productList.ToString() + "\nTotal Price: ₱" + total.ToString("N2");
            DialogResult result = MessageBox.Show(orderSummary + "\n\nDo you want to proceed with the order?", "Order Summary", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Show the random receipt number
                MessageBox.Show("Receipt No: " + receiptNumber.ToString(), "Receipt Number");

                // Clear the order list after confirming the receipt number
                cartTable.Clear();  // Clear all rows in the cartTable
                txtTotalPrice.Text = "Total: ₱0.00"; // Reset the total price text to 0.00
            }
            else
            {
                // If the user clicked "No", cancel the order
                MessageBox.Show("Your order has been cancelled.", "Order Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cartTable.Clear();  // Reset the cartTable
                txtTotalPrice.Text = "Total: ₱0.00"; // Reset the total price text to 0.00
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Hide();
        }
    }
}
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
using System.Drawing.Imaging; // For working with images and saving them in different formats

namespace Hebrews_Coffee
{
    public partial class Product : Form
    {

        OleDbConnection conn;// OleDbConnection: Manages database connection.
        OleDbCommand cmd; // OleDbCommand: Executes SQL commands (e.g., INSERT, UPDATE).
        OleDbDataAdapter adapter;// OleDbDataAdapter: Connects database and DataTable, retrieves and updates data.
        DataTable dt; // DataTable: Stores data in-memory, can be bound to controls like DataGridView.
        private bool isImageUploaded = false;


        public Product()
        {
            InitializeComponent();
            GetUsers();
        }

        // Simplified GetUsers method
        void GetUsers()
        {
            // Establish the connection string to connect to the Access database
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");
            // Initialize the DataTable to hold user data
            dt = new DataTable();
            // Set up an adapter to run the query and fetch the user data
            adapter = new OleDbDataAdapter("SELECT * FROM Product", conn);
            // Open the connection
            conn.Open();
            // Fill the DataTable with the result of the query
            adapter.Fill(dt);
            // Bind the DataTable to the DataGridView to display user information
            dgvUser.DataSource = dt;
            // Close the database connection
            conn.Close();
        }

        private void tbs_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Product WHERE Product_name LIKE @fn";
            using (adapter = new OleDbDataAdapter(searchQuery, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@fn", tbs.Text + "%");
                dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvUser.DataSource = dt;
                conn.Close();
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(tbpro.Text) ||
                string.IsNullOrWhiteSpace(tbprice.Text) ||
                pbImage.Image == null || // Check if an image is selected
                comboBox1.SelectedItem == null) // Check if category is selected
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

        

            string query = "INSERT INTO Product (Product_name, Price, Category, Photo) VALUES (@fn, @ln, @categoryId, @i)";
            using (cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@fn", tbpro.Text);
                cmd.Parameters.AddWithValue("@ln", tbprice.Text);
                cmd.Parameters.AddWithValue("@categoryId", comboBox1.Text);

                // Handle the image parameter (convert the image in PictureBox to byte array)
                using (MemoryStream ms = new MemoryStream())
                {
                    pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                    cmd.Parameters.AddWithValue("@i", ms.ToArray());
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Inserted Successfully");
                conn.Close();
            }

            GetUsers(); // Refresh DataGridView to show the newly inserted product
        }

        private void btnup_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jfif;*.jpeg;*.png;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = new Bitmap(openFileDialog.FileName);
                isImageUploaded = true;
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(tbpro.Text) ||
                string.IsNullOrWhiteSpace(tbprice.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text))

            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Determine SQL query based on whether an image is uploaded
            string query = isImageUploaded
                ? "UPDATE Product SET Product_name=@fn, Category=@ln, Price=@bd, Photo=@i WHERE ID=@id"
                : "UPDATE Product SET Product_name=@fn, Category=@ln, Price=@bd WHERE ID=@id";

            // Create and configure the command
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@fn", tbpro.Text);
                cmd.Parameters.AddWithValue("@ln", comboBox1.Text);
                cmd.Parameters.AddWithValue("@bd", tbprice.Text);



                // Add image parameter if uploaded
                if (isImageUploaded && pbImage.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pbImage.Image.Save(ms, pbImage.Image.RawFormat);
                        cmd.Parameters.AddWithValue("@i", ms.ToArray());
                    }
                }

                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbID.Text));

                // Execute the update command
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show(rowsAffected > 0 ? "User Updated Successfully" : "No user found with the provided ID.");
            }

            // Reset flag and refresh DataGridView
            isImageUploaded = false;
            GetUsers();
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Show();
            }
        }

        private void dgvUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes and controls with data from the currently selected row
            tbID.Text = dgvUser.CurrentRow.Cells[0].Value.ToString(); //  ID
            tbpro.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();
            tbprice.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();


            // Check if the 'Photo' column contains an image
            if (dgvUser.CurrentRow.Cells["Photo"].Value != DBNull.Value)
            {
                // Convert the byte array from the 'Photo' column to an image and display it
                byte[] imgData = (byte[])dgvUser.CurrentRow.Cells["Photo"].Value;
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    pbImage.Image = Image.FromStream(ms); // Load the image from the memory stream
                }
            }
            else
            {
                // If the 'Photo' column is null, clear the PictureBox
                pbImage.Image = null;
            }
        }

        private void Product_Load(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog with Yes and No buttons
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Only proceed with the deletion if the user clicked 'Yes'
            if (result == DialogResult.Yes)
            {
                // SQL query to delete a product based on its ID
                string query = "DELETE FROM Product WHERE ID = @i";

                // Create a new OleDbCommand with the query and the database connection
                cmd = new OleDbCommand(query, conn);

                // Add the product ID parameter to the command
                cmd.Parameters.AddWithValue("@i", Convert.ToInt32(tbID.Text)); // Convert the ID from the textbox to an integer

                try
                {
                    // Open the connection, execute the command, and close the connection
                    conn.Open(); // Open the connection to the database
                    cmd.ExecuteNonQuery(); // Execute the delete query
                    MessageBox.Show("Product Deleted"); // Show a success message
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {
                    conn.Close(); // Ensure the connection is always closed
                }

                // Refresh the DataGridView to reflect changes
                GetUsers();
            }
            else
            {
                // If the user clicked 'No', you can choose to show a message or do nothing
                MessageBox.Show("Delete action was cancelled.");
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            tbpro.Clear();   
            tbprice.Clear();   
            comboBox1.SelectedIndex = -1;

            // Clear the PictureBox
            pbImage.Image = null;
        }
    }
}


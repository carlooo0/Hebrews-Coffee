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
    public partial class category : Form
    {
        OleDbConnection conn;// OleDbConnection: Manages database connection.
        OleDbCommand cmd; // OleDbCommand: Executes SQL commands (e.g., INSERT, UPDATE).
        OleDbDataAdapter adapter;// OleDbDataAdapter: Connects database and DataTable, retrieves and updates data.
        DataTable dt; // DataTable: Stores data in-memory, can be bound to controls like DataGridView.
        private bool isImageUploaded = false;

        public category()
        {
            InitializeComponent();
            GetUsers();
        }
        void GetUsers()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT * FROM Category WHERE IsDelete = 0", conn);
            conn.Open();
            adapter.Fill(dt);
            dgvUser.DataSource = dt;
            conn.Close();


        }

        

        private void category_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hebrewsDataSet50.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter4.Fill(this.hebrewsDataSet50.Category);
            // TODO: This line of code loads data into the 'hebrewsDataSet30.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter3.Fill(this.hebrewsDataSet30.Category);
            // TODO: This line of code loads data into the 'hebrewsDataSet29.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter2.Fill(this.hebrewsDataSet29.Category);
            // TODO: This line of code loads data into the 'hebrewsDataSet28.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter1.Fill(this.hebrewsDataSet28.Category);
            // TODO: This line of code loads data into the 'hebrewsDataSet7.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.hebrewsDataSet7.Category);

        }
        
        private void btndel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string query = "DELETE FROM Category WHERE ID = @id";
            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgvUser.CurrentRow.Cells[0].Value));

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Are you sure you want to delete?");
            conn.Close();
            GetUsers();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Show();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbs_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = "SELECT * FROM Category WHERE Name LIKE @n";
            using (adapter = new OleDbDataAdapter(searchQuery, conn))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@n", tbs.Text + "%");
                dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                dgvUser.DataSource = dt;
                conn.Close();
            }
        }

        private void btnedit_Click_1(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Show();
            }
        }

        private void btndel_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (string.IsNullOrWhiteSpace(tbID.Text))
            {
                MessageBox.Show("Please select a Category to delete.");
                return;
            }

            string query = "UPDATE Category SET IsDelete = 1 WHERE ID = @id";

            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", tbID.Text);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category successfully deleted!");
                GetUsers(); // Refresh the active records
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
                
            }
            
        }

        private void btnarchive_Click(object sender, EventArgs e)
        {
            catArchive catArchive = new catArchive();
            catArchive.Show();
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(tbname.Text))   // Product name


            {
                MessageBox.Show("Please fill in all fields."); // Display a message if any field is empty
                return; // Exit the method if any field is missing
            }

            // SQL query to insert a new user into the 'useracc' table
            string query = "INSERT INTO Category (Name) VALUES " + "(@n)";

            // Create the command to execute the query
            cmd = new OleDbCommand(query, conn);

            // Add values from textboxes and other controls to the command parameters
            cmd.Parameters.AddWithValue("@n", tbname.Text); // Product Name



            // Handle the image parameter (convert the image in PictureBox to byte array)
            using (MemoryStream ms = new MemoryStream())
            {

            }
            isImageUploaded = false;
            // Open the connection, execute the command, and close the connection
            conn.Open(); // Open the connection to the database
            cmd.ExecuteNonQuery(); // Execute the insert query
            MessageBox.Show("User Inserted Successfully"); // Show success message
            conn.Close(); // Close the connection to the database

            // Refresh DataGridView to show the newly inserted user
            GetUsers();
        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            // Check if all required fields are filled

            if (string.IsNullOrWhiteSpace(tbname.Text))    // Prodeuct Name


            {

                MessageBox.Show("Please fill in all fields.");
                return;
            }


            // Determine SQL query based on whether an image is uploaded
            string query = isImageUploaded
                ? "UPDATE Category SET Name=@n WHERE ID=@id"
                : "UPDATE Category SET Name=@n WHERE ID=@id";

            // Create and configure the command
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@n", tbname.Text);
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

        private void btnclaer_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            tbname.Clear(); // Clear the  Name
        }

       

        private void dgvUser_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes and controls with data from the currently selected row
            tbID.Text = dgvUser.CurrentRow.Cells[0].Value.ToString(); // Product ID
            tbname.Text = dgvUser.CurrentRow.Cells[1].Value.ToString(); // Product Name
        }

        private void btnclose_Click_1(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void dgvUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

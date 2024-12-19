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
    public partial class stocks : Form
    {
        OleDbConnection conn;// OleDbConnection: Manages database connection.
        OleDbCommand cmd; // OleDbCommand: Executes SQL commands (e.g., INSERT, UPDATE).
        OleDbDataAdapter adapter;// OleDbDataAdapter: Connects database and DataTable, retrieves and updates data.
        DataTable dt; // DataTable: Stores data in-memory, can be bound to controls like DataGridView.
        private bool isImageUploaded = false;

        public stocks()
        {
            InitializeComponent();
            GetUsers();
        }
        void GetUsers()
        {
            // Establish the connection string to connect to the Access database
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");
            // Initialize the DataTable to hold user data
            dt = new DataTable();
            // Set up an adapter to run the query and fetch the user data
            adapter = new OleDbDataAdapter("SELECT * FROM stocks", conn);
            // Open the connection
            conn.Open();
            // Fill the DataTable with the result of the query
            adapter.Fill(dt);
            // Bind the DataTable to the DataGridView to display user information
            dgvUser.DataSource = dt;
            // Close the database connection
            conn.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (!panel1.Visible)
            {
                panel1.Show();
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(tbname.Text) ||    
                string.IsNullOrWhiteSpace(cbpv.Text) ||    
                string.IsNullOrWhiteSpace(cbsize.Text) ||     
                string.IsNullOrWhiteSpace(cbst.Text))    
                
            {
                MessageBox.Show("Please fill in all fields."); // Display a message if any field is empty
                return; // Exit the method if any field is missing
            }
           
            // SQL query to insert a new user into the 'useracc' table
            string query = "INSERT INTO stocks (Product_Name, Product_Variety, Product_Size, Stocks) VALUES " +
                "(@fn,@ln,@bd,@u)";
            // Create the command to execute the query
            cmd = new OleDbCommand(query, conn);

            // Add values from textboxes and other controls to the command parameters
            cmd.Parameters.AddWithValue("@fn",tbname.Text); 
            cmd.Parameters.AddWithValue("@ln", cbpv.Text);
            cmd.Parameters.AddWithValue("@bd", cbsize.Text); 
            cmd.Parameters.AddWithValue("@u", cbst.Text);   
           

           

            // Open the connection, execute the command, and close the connection
            conn.Open(); // Open the connection to the database
            cmd.ExecuteNonQuery(); // Execute the insert query
            MessageBox.Show("User Inserted Successfully"); // Show success message
            conn.Close(); // Close the connection to the database

            // Refresh DataGridView to show the newly inserted user
            GetUsers();


        }   

        private void btnarchive_Click(object sender, EventArgs e)
        {
            stockArchive stockArchive = new stockArchive();
            stockArchive.Show();
        }
        
    

        private void btndel_Click(object sender, EventArgs e)
        {
            // SQL query to delete a user based on their ID
            string query = "DELETE FROM stocks WHERE ID = @id";

            // Create a new OleDbCommand with the query and the database connection
            cmd = new OleDbCommand(query, conn);

            // Add the user ID parameter to the command
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(tbID.Text)); // Convert the ID from the textbox to an integer

            // Open the connection, execute the command, and close the connection
            conn.Open(); // Open the connection to the database
            cmd.ExecuteNonQuery(); // Execute the delete query
            MessageBox.Show("Customer Deleted"); // Show a success message
            conn.Close(); // Close the connection to the database

            // Refresh the DataGridView to reflect changes
            GetUsers();


        }



        private void stocks_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hebrewsDataSet60.stocks' table. You can move, or remove it, as needed.
            this.stocksTableAdapter4.Fill(this.hebrewsDataSet60.stocks);


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(tbname.Text) ||    // First Name
                string.IsNullOrWhiteSpace(cbpv.Text) ||    // Last Name
                string.IsNullOrWhiteSpace(cbsize.Text) ||     // Username
                string.IsNullOrWhiteSpace(cbst.Text))       // Password
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Determine SQL query based on whether an image is uploaded
            string query = isImageUploaded
                ? "UPDATE stocks SET Product_Name=@fn, Product_Variety=@ln, Product_Size=@bd, Stocks=@u WHERE ID=@id"
                : "UPDATE stocks SET Product_Name=@fn, Product_Variety=@ln, Product_Size=@bd, Stocks=@u WHERE ID=@id";

            // Create and configure the command
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@fn", tbname.Text);
                cmd.Parameters.AddWithValue("@ln", cbpv.Text);
                cmd.Parameters.AddWithValue("@u", cbsize.Text);
                cmd.Parameters.AddWithValue("@p", cbst.Text);
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

    private void btnclear_Click(object sender, EventArgs e)
        {
            // Clear all textboxes
            tbname.Clear();  // Clear the First Name textbox
            cbpv.SelectedIndex = -1;  // Clear the ComboBox by setting the selected item to none
            cbsize.SelectedIndex = -1;  // Clear the ComboBox by setting the selected item to none
            cbst.SelectedIndex = -1;  // Clear the ComboBox by setting the selected item to none
        }
        private void dgvUser_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes and controls with data from the currently selected row
            tbID.Text = dgvUser.CurrentRow.Cells[0].Value.ToString(); // User ID
            tbname.Text = dgvUser.CurrentRow.Cells[1].Value.ToString(); // First Name
           // cbpv.Text = dgvUser.CurrentRow.Cells[2].Value.ToString(); // Last Name
           //  cbsize.Text = dgvUser.CurrentRow.Cells[3].Value.ToString(); // Birthdate
           //  cbst.Text = dgvUser.CurrentRow.Cells[4].Value.ToString();   // Username
        }
    }
}


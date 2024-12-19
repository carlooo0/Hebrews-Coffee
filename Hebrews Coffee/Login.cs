using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Linq;
using Guna.UI2.WinForms;

namespace Hebrews_Coffee
{
    public partial class Login : Form
    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        private int loginAttempts = 0; // Counter for login attempts


        public Login()
        {
            InitializeComponent();
        }

        private void btnsign_Click(object sender, EventArgs e)
        {
            // Establish the connection string to connect to the Access database
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");

            // SQL query to check if the username and password match and retrieve the user type
            string query = "SELECT [Type] FROM Login WHERE Username = @username AND [Password] = @password";

            // Create and configure the command
            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", tbUsername.Text);
            cmd.Parameters.AddWithValue("@password", tbPassword.Text);
            

            try
            {
                // Open the connection
                conn.Open();

                // Execute the query and get the result
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // The user exists, and we have retrieved the Type
                    string userType = result.ToString();

                    // Check the user type and open the corresponding form
                    this.Hide();

                    if (userType == "Admin")
                    {
                        Adminside form2 = new Adminside();  // Admin Form
                        form2.Show();
                    }
                    else if (userType == "Staff")
                    {
                        StaffView form3 = new StaffView();  // Student Form
                        form3.Show();
                    }           
                }
                else
                {
                    // Increment the login attempts and show an error message
                    loginAttempts++;
                    MessageBox.Show("Invalid password or user type.");

                    if (loginAttempts >= 3)
                    {
                        // Close the application if 3 failed login attempts
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Close the connection
                conn.Close();
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            // x for login

            this.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabel1.Text == "Show")
            {
                tbPassword.PasswordChar = '\0';
                linkLabel1.Text = "Hide";
            }
            else
            {
                tbPassword.PasswordChar = '●';
                linkLabel1.Text = "Show";
            }
        }
    }
}

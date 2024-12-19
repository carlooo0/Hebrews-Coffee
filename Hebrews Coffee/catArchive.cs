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

namespace Hebrews_Coffee
{
    public partial class catArchive : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataTable dt;
        OleDbCommand cmd;

        public catArchive()
        {
            InitializeComponent();
           
            GetUsers();
        }
        void GetUsers()
        {

            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\User\\OneDrive\\Documents\\Hebrews.accdb");
            dt = new DataTable();
            adapter = new OleDbDataAdapter("SELECT * FROM Category WHERE IsDelete = 1", conn);
            
            try
            {
                conn.Open();
                adapter.Fill(dt);
                dgvarchive.DataSource = dt;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void catArchive_Load(object sender, EventArgs e)
        {

        }

        private void btnarchive_Click(object sender, EventArgs e)
        {
            // Check if a product is selected
           
            if (dgvarchive.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a Product to restore.");
                return;
            }

            // Ask for confirmation before restoring the product
            DialogResult result = MessageBox.Show("Are you sure you want to restore this Item?", "Confirm Restore", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string id = dgvarchive.SelectedRows[0].Cells["ID"].Value.ToString();
                string query = "UPDATE Category SET IsDelete = 0 WHERE ID = @id";

                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Item successfully restored!");

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
            else
            {
                MessageBox.Show("Restore operation cancelled.");

            }
            GetUsers(); // Refresh the active records
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
            GetUsers();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hebrews_Coffee
{
    public partial class StaffView : Form
    {
        public StaffView()
        {
            InitializeComponent();
        }

        public void AddControls(Form f)
        {
            centerpanel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            centerpanel.Controls.Add(f);
            f.Show();
        }
        

        private void btnhome_Click(object sender, EventArgs e)
        {
            AddControls(new home());
        }

        private void btnstocks_Click(object sender, EventArgs e)
        {
            AddControls(new stocks());
        }
        private void btnproduct_Click_1(object sender, EventArgs e)
        {
            AddControls(new Product());
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Display confirmation dialog
            var result = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks "Yes"
            if (result == DialogResult.Yes)
            {
                new Login().Show(); // Show the login form
                this.Close();         // Hide the current form
            }
        }
    }
}

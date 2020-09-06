using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FS2020_Tree_Size_Editor
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("WARNING: You are about to reset all saved location settings! You will be asked again upon launch of this program to set your game path. Upon completion of resetting this data the program will close. Continue?", "Reset Saved Locations", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Application.Exit();
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtFolderPath.Text = Properties.Settings.Default.installLocation;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.installLocation = txtFolderPath.Text;
            Close();
        }
    }
}

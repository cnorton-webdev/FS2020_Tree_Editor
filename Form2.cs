﻿using System;
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
    public partial class Form2 : Form
    {
        public static Form1 Form;
        public Form2()
        {
            InitializeComponent();
            this.Focus();
        }

        private void OpenXML_FileOk(object sender, CancelEventArgs e)
        {
            Properties.Settings.Default.xmlFile = openXML.FileName;
            Properties.Settings.Default.Save();
            MessageBox.Show("File location saved! Please restart the program for file location to take affect.", "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openXML.ShowDialog();
        }
    }
}

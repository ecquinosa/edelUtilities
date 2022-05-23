using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class GetFolderFilesInDirectory : Form
    {
        public GetFolderFilesInDirectory()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
            fbd = null;
        }

        private void RTBLog(string desc)
        {
            rtb.AppendText(desc + "\r");
            rtb.ScrollToCaret();
            Application.DoEvents();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDirectory.Text == "") return;
            if (!System.IO.Directory.Exists(txtDirectory.Text)) return;
            foreach (string folder in System.IO.Directory.GetDirectories(txtDirectory.Text))
            {
                RTBLog(folder);
            }
            foreach (string file in System.IO.Directory.GetFiles(txtDirectory.Text))
            {
                RTBLog(file);
            }
            Utilities.ShowInfoMessageBox("Done!");
        }
    }
}

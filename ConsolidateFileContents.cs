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
    public partial class ConsolidateFileContents : Form
    {
        public ConsolidateFileContents()
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
            StringBuilder sb = new StringBuilder();
            StringBuilder sbData = new StringBuilder();
            int total = 0;
            foreach (string f in System.IO.Directory.GetFiles(txtDirectory.Text))
            {
                int count = System.IO.File.ReadAllLines(f).Count();                
                sbData.Append(System.IO.File.ReadAllText(f));
                if (count == 1) sbData.Append("\r");
                string lineCount = count.ToString();
                sb.Append(f + "|" + lineCount + "\r");
                total += count;
            }

            sb.Append("total : " + total.ToString() + "\r");
            System.IO.File.WriteAllText(string.Concat(Application.StartupPath, @"\consofileSummary.txt"), sb.ToString());
            System.IO.File.WriteAllText(string.Concat(Application.StartupPath, @"\consofileContent.txt"), sbData.ToString());

            RTBLog(sb.ToString());
        }
    }
}

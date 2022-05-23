using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class FindStringInFiles : Form
    {
        public FindStringInFiles()
        {
            InitializeComponent();
        }

        private DataTable dt = new DataTable();

        private void FindStringInFiles_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Path", typeof(string));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDirectory.Text = fbd.SelectedPath;
            }
            fbd = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            btnSubmit.Enabled = false;
            dt.Clear();

            delSearchDirectories searchDir = new delSearchDirectories(SearchDirectories);
            searchDir.Invoke(txtDirectory.Text);            
            //SearchDirectories(txtDirectory.Text);

            grid.DataSource = dt;

            //GetInstanceFromFile();

            MessageBox.Show("Done!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Cursor = Cursors.Default;
            btnSubmit.Enabled = true;
        }
        
        private delegate void delSearchDirectories(string dir);
        private void SearchDirectories(string dir)
        {
            //search directories
            foreach (var d in Directory.GetDirectories(dir))
            {
                if (Directory.GetDirectories(d).Length > 0) SearchDirectories(d);
                else SearchFiles(d);
            }

            //search files
            SearchFiles(dir);
        }

        private void SearchFiles(string dir)
        {
            foreach (var f in Directory.GetFiles(dir))
            {
                var data = System.IO.File.ReadAllText(f);
                if (data.Contains(txtValue.Text))
                {
                    DataRow rw = dt.NewRow();
                    rw[0] = f;
                    dt.Rows.Add(rw);                   
                    Application.DoEvents();
                }
            }
        }

        private void grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("notepad.exe", grid.CurrentCell.Value.ToString());
            }
            catch
            {
                System.Diagnostics.Process.Start("notepad.exe", grid.CurrentCell.Value.ToString());
            }
        }

        private void GetInstanceFromFile()
        {
            string destiFile = @"D:\umidcard.txt";
            StringBuilder sb = new StringBuilder();
            foreach (DataRow rw in dt.Rows)
            {
                var data = System.IO.File.ReadAllText(rw["Path"].ToString());
                foreach (string line in data.Split('\r')) if (line.Contains(txtValue.Text)) sb.Append(line.Trim() + '\r');

                if (sb.ToString() != "") System.IO.File.WriteAllText(destiFile, sb.ToString());
            }
        }
     
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EdelUtilities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEmptyDirectories();

            //return;
            //foreach (string file in Directory.GetFiles(textBox1.Text))
            //{
            //    string createDateFolder = new FileInfo(file).CreationTime.ToString("yyyy-MM-dd");
            //    if (!Directory.Exists(string.Format(@"{0}\{1}", textBox1.Text, createDateFolder))) Directory.CreateDirectory(string.Format(@"{0}\{1}", textBox1.Text, createDateFolder));
            //    try
            //    {
            //        File.Move(file, string.Format(@"{0}\{1}\{2}", textBox1.Text, createDateFolder, Path.GetFileName(file)));
            //    }
            //    catch
            //    {
            //    }

            //}
            //MessageBox.Show("Done!");
        }

        private void DeleteEmptyDirectories()
        {
            if (!System.IO.Directory.Exists(textBox1.Text)) return;

            button1.Enabled = false;

            foreach (string subDir in Directory.GetDirectories(textBox1.Text))
            {
                bool bln = true;
                if (Directory.GetFiles(subDir).Length > 0) bln = false;
                else if (Directory.GetDirectories(subDir).Length > 0) bln = false;

                if (bln) Directory.Delete(subDir);
            }

            button1.Enabled = true;

            MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
            fbd.Dispose();
            fbd = null;
        }
    }
}

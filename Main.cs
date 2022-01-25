using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void uBPDAOEncryptdecryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ubpDAO_EncryptDecrypt uc = new ubpDAO_EncryptDecrypt();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void removeEmptyFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }

        private void singleDoubleQuoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddSingleDoubleQuote().ShowDialog();
        }
    }
}

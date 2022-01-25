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
    public partial class AddSingleDoubleQuote : Form
    {
        public AddSingleDoubleQuote()
        {
            InitializeComponent();
        }

        private void chkSingle_CheckedChanged(object sender, EventArgs e)
        {
            chkDouble.Checked = !chkSingle.Checked;
        }

        private void chkDouble_CheckedChanged(object sender, EventArgs e)
        {
            chkSingle.Checked = !chkDouble.Checked;
        }

        private void chkAddComma_CheckedChanged(object sender, EventArgs e)
        {
            chkRemoveCommaLast.Checked = chkAddComma.Checked;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (rtb1.Text == "") return;
            btnProcess.Enabled = false;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var line in rtb1.Lines)
            {
                if (line.Trim() != "")
                {
                    stringBuilder.AppendLine(string.Concat(SingleDoubleQuote(), line.Trim(), SingleDoubleQuote(), chkAddComma.Checked ? "," : ""));
                }
            }
            if(!chkRemoveCommaLast.Checked) rtb2.Text = stringBuilder.ToString();
            else rtb2.Text = stringBuilder.ToString().Substring(0, stringBuilder.ToString().Length - 3);

            btnProcess.Enabled = true;
            MessageBox.Show("Done!",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Information); 
        }

        private string SingleDoubleQuote()
        {
            if (chkSingle.Checked) return "'";
            else if (chkDouble.Checked) return "\"";
            else return "";
        }

        private void AddSingleDoubleQuote_Load(object sender, EventArgs e)
        {

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (rtb2.Text == "") return;
            System.Windows.Forms.Clipboard.SetText(rtb2.Text);
        }
    }
}

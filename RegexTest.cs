using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace EdelUtilities
{
    public partial class RegexTest : Form
    {
        public RegexTest()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            txtData2.Text = IsAlphaNum(txtData1.Text);
        }

        public string IsAlphaNum(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";

            StringBuilder sb = new StringBuilder();

            Regex r = new Regex(String.Concat("^[a-zA-Z0-9",txtRegex.Text,"]*$"));

            for (int i = 0; i < str.Length; i++)
            {               
                if (r.IsMatch(str[i].ToString())) sb.Append(str[i]);
                else sb.Append("");                
            }

            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

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

        private void Main_Load(object sender, EventArgs e)
        {
            //string mac = GetMACAddress();
            //Utilities.ShowInfoMessageBox("My mac address is "  + mac);
        }

        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    // only return MAC Address from first card
                    if (System.Convert.ToBoolean(mo["IPEnabled"]) == true)
                        MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            // Dim MACAddress As String = [String].Empty
            // Dim nics() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces()
            // MACAddress = nics(0).GetPhysicalAddress.ToString
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }

        private void pagIbigAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PagIbigApi().ShowDialog();
        }

        private void regexTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegexTest().ShowDialog();
        }

        private void pagIbigDatabaseDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PagIbigBankDbase().ShowDialog();
        }
    }
}

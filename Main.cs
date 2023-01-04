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

        #region Menu Events

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

        private void findStringInFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FindStringInFiles().ShowDialog();
        }

        private void getMACAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mac = GetMACAddress();
            Utilities.ShowInfoMessageBox("My mac address is " + mac);
        }

        private void uBPDAOAPILogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new UBP_DAO_API_Logs().ShowDialog();
        }

        private void getBankAccountNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GetAccountNo().ShowDialog();
        }

        private void getDirectoryFilesAndFoldersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GetFolderFilesInDirectory().ShowDialog();
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

        private void consolidateMultipleToOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConsolidateFileContents().ShowDialog();
        }

        private void editDeleteMIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EditDeleteMID().ShowDialog();
        }

        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            
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

        private void button1_Click(object sender, EventArgs e)
        {
            string appDir = @"H:\My Drive\PAGIBIG\Sql Scripts\member contact info";
            string permBrgyCode = "061914049";
            string permCityCode = "061914000";
            string permProvCode = "061900000";
            string permRegionCode = "060000000";
            string permRegionDesc = "REGION VI (WESTERN VISAYAS)";
            string presBrgyCode = "061914049";
            string presCityCode = "061914000";
            string presProvCode = "061900000";
            string presRegionCode = "060000000";
            string presRegionDesc = "REGION VI (WESTERN VISAYAS)";

            Lab.GenerateMemberContactInformationLocalDb(appDir, 
                                                        permBrgyCode, permCityCode, permProvCode, permRegionCode,permRegionDesc,
                                                        presBrgyCode,presCityCode,presProvCode,presRegionCode,presRegionDesc);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EdelUtilities
{
    public partial class UBP_DAO_API_Logs : Form
    {
        public UBP_DAO_API_Logs()
        {
            InitializeComponent();
            txtYear.Text = DateTime.Now.Year.ToString();
            txtMonth.Text = System.DateTime.Now.Month.ToString().PadLeft(2, '0');
            txtDay.Text = System.DateTime.Now.Day.ToString().PadLeft(2, '0');
        }

        string clientFolder = "";
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMID.Text == "") return;
            if (txtPath.Text == "") return;

            string midFolderSource = "";
            string midFolderDestination = "";
            string requestFolder = "";
            string responseFolder = "";
            clientFolder = "";
            string sourceDirectory = Path.Combine(txtPath.Text, txtYear.Text, txtMonth.Text, txtDay.Text);
            foreach (var d in Directory.GetDirectories(Path.Combine(sourceDirectory)))
            {
                midFolderSource = Path.Combine(d,txtMID.Text);
                if (Directory.Exists(midFolderSource)) break;
            }

            if (Directory.Exists(midFolderSource))
            {
                string destinationFolder = Path.Combine(Application.StartupPath, "Data");
                if (!Directory.Exists(destinationFolder)) Directory.CreateDirectory(destinationFolder);

                midFolderDestination = Path.Combine(destinationFolder, txtMID.Text);
                if (!Directory.Exists(midFolderDestination)) Directory.CreateDirectory(midFolderDestination);

                requestFolder = Path.Combine(midFolderDestination, "request");
                responseFolder = Path.Combine(midFolderDestination, "response");
                clientFolder = Path.Combine(midFolderDestination, txtMID.Text);
                if (!Directory.Exists(requestFolder)) Directory.CreateDirectory(requestFolder);
                if (!Directory.Exists(responseFolder)) Directory.CreateDirectory(responseFolder);
                if (!Directory.Exists(clientFolder)) Directory.CreateDirectory(clientFolder);

                Copy(midFolderSource, requestFolder);
                Copy(midFolderSource.Replace(@"\dao\", @"\response\"), responseFolder);

                Utilities.ShowInfoMessageBox("Done!");

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                {
                    FileName = responseFolder,
                    UseShellExecute = true,
                    Verb = "open"
                });

            }
            else Utilities.ShowInfoMessageBox("Done. No record found.");


        }

        private void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            string sourceFile = "";
            string destiFile = "";
            string destiFolderClient = "";
            string destiFileClient = "";

            // Copy each file into the new directory.           
            foreach (FileInfo fi in source.GetFiles())
            {
                sourceFile = Path.Combine(fi.FullName);
                destiFile = Path.Combine(target.FullName, fi.Name);
                destiFolderClient = target.FullName;
                destiFileClient = fi.Name;
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);                
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                if (fi.FullName.Contains(@"\dao\"))
                {
                    if (sourceFile.Contains("update.json")) fi.CopyTo(Path.Combine(target.FullName.Replace("request", txtMID.Text), "request-" + fi.Name), true);
                }
                if (fi.FullName.Contains(@"\response\"))
                {
                    if (sourceFile.Contains("account-create.json")) fi.CopyTo(Path.Combine(target.FullName.Replace("response", txtMID.Text), "response-" + fi.Name), true);
                }               
            }            

            if(sourceFile.Contains("response")) File.Copy(sourceFile, Path.Combine(destiFolderClient.Replace("response", txtMID.Text), "response-" + destiFileClient), true);           

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}

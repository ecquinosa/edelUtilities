using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdelUtilities
{
    class Lab
    {
        public static void InsertToSFTP(string dir)
        {
            DAL.MsSql dal = new DAL.MsSql("Server=10.88.77.71;Database=LCDB_01;User=allcard;Password=MarlboroLights#;");
            //string sourceDir = @"D:\WORK\Projects\edelUtilities\bin\Debug\add sftp\edelUtilities";
            string sourceDir = System.IO.Path.Combine(dir, "txt");
            string sourceData = System.IO.Path.Combine(sourceDir, "source");
            foreach (string f in System.IO.Directory.GetFiles(sourceData))
            {
                string data = System.IO.File.ReadAllText(f);

                string dateDir = "";
                string mid = "";
                DateTime sftpDate;
                string remark = "";
                int total = 0;

                foreach (string line in data.Split('\r'))
                {
                    if (line.Contains("Directory")) dateDir = line.Substring(line.LastIndexOf("\\") + 1).Trim();
                    else if (line.Contains(".zip"))
                    {
                        mid = line.Split(' ')[15].Trim().Replace(".zip","");
                        remark = string.Concat("/",dateDir);
                        sftpDate = Convert.ToDateTime(string.Concat(line.Split(' ')[0].Trim(), " ", line.Split(' ')[2].Trim(), " ", line.Split(' ')[3].Trim()));

                        if(dal.AddSFTP(mid, sftpDate, remark)) System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir, "log.txt"), string.Concat(dateDir, " ", mid, " success") + Environment.NewLine);
                        else System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir, "log.txt"), string.Concat(dateDir, " ", mid, " failed ",dal.ErrorMessage) + Environment.NewLine);

                        total += 1;
                    }
                }

                System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir,"summaryFile.txt"), string.Concat(dateDir, " ", total.ToString("N0")) + Environment.NewLine);
            }

            System.Windows.Forms.MessageBox.Show("Done!");
            //dal.AddSFTP("",DateTime.Now,"")
        }
    }
}

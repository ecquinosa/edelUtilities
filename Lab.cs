using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                        mid = line.Split(' ')[15].Trim().Replace(".zip", "");
                        remark = string.Concat("/", dateDir);
                        sftpDate = Convert.ToDateTime(string.Concat(line.Split(' ')[0].Trim(), " ", line.Split(' ')[2].Trim(), " ", line.Split(' ')[3].Trim()));

                        if (dal.AddSFTP(mid, sftpDate, remark)) System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir, "log.txt"), string.Concat(dateDir, " ", mid, " success") + Environment.NewLine);
                        else System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir, "log.txt"), string.Concat(dateDir, " ", mid, " failed ", dal.ErrorMessage) + Environment.NewLine);

                        total += 1;
                    }
                }

                System.IO.File.AppendAllText(System.IO.Path.Combine(sourceDir, "summaryFile.txt"), string.Concat(dateDir, " ", total.ToString("N0")) + Environment.NewLine);
            }

            System.Windows.Forms.MessageBox.Show("Done!");
            //dal.AddSFTP("",DateTime.Now,"")
        }

        public static string GetCode(string value)
        {
            return value.Substring(value.IndexOf("+") + 1).Replace(")", "");
        }

        public static bool PingHost(string host)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply result = ping.Send(host);
            return result.Status == System.Net.NetworkInformation.IPStatus.Success;
        }

        public static bool PingHost2(string nameOrAddress, ref string error)
        {
            bool pingable = false;
            System.Net.NetworkInformation.Ping pinger = null;

            try
            {
                pinger = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply reply = pinger.Send(nameOrAddress, 3000);
                pingable = reply.Status == System.Net.NetworkInformation.IPStatus.Success;
                error = reply.Status.ToString();
            }
            catch (System.Net.NetworkInformation.PingException ex)
            {
                // Discard PingExceptions and return false;
                error = ex.Message;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }

        public static bool PingHost3(string nameOrAddress, ref string error)
        {
            var url = nameOrAddress;

            try
            {
                var myRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                var response = (System.Net.HttpWebResponse)myRequest.GetResponse();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //  it's at least in some way responsive
                    //  but may be internally broken
                    //  as you could find out if you called one of the methods for real
                    error = string.Format("{0} Available", url);
                    return true;
                }
                else
                {
                    //  well, at least it returned...
                    error = string.Format("{0} Returned, but with status: {1}", url, response.StatusDescription);
                    return false;
                }
            }
            catch (Exception ex)
            {
                //  not available at all, for some reason
                error = string.Format("{0} unavailable: {1}", url, ex.Message);
                return false;
            }
        }

        public static bool TestDelete(ref string err)
        {
            try
            {
                System.IO.File.Delete("D:\\ttt.txt");
                System.IO.Directory.Delete("D:\\ttt", true);
                System.IO.Directory.Delete("D:\\ttt3", true);
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
        }

        public static void GenerateSSSUMIDData()
        {
            string outputFolder = @"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\output";
            string l = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}{8}", "CSN", "CRN", "SSS", "FIRST", "MIDDLE", "LAST", "GENDER", "DOB", Environment.NewLine);
            if (!System.IO.Directory.Exists(outputFolder)) System.IO.Directory.CreateDirectory(outputFolder);
            System.IO.File.AppendAllText(string.Format(@"{0}\list.txt", outputFolder), l);

            //for (int i = 1; i <= 20; i++)            
            //{
            //    CreateTestData(i);            
            //}

            int i = 1;
            string[] lines = System.IO.File.ReadAllLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\sssList.txt");

            foreach (string line in lines)
            {
                CreateTestDatav2(i, line.Split('|')[0], line.Split('|')[1], line.Split('|')[2], line.Split('|')[4]);
                i += 1;
            }
        }

        public static void CreateTestData(int cntr)
        {
            string templateFolder = @"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\template";

            string templateXML = string.Format(@"{0}\csn.xml", templateFolder);
            string templateData = System.IO.File.ReadAllText(templateXML);
            string[] female_firstList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\female_first.txt").ToArray();
            string[] male_firstList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\male_first.txt").ToArray();
            string[] lastList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\last.txt").ToArray();
            string[] cityList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\city.txt").ToArray();

            string[] gender = new string[] { "M", "F" };

            Random rn = new Random();
            DateTime dob = DateTime.Now.AddDays(-7280).AddDays(-rn.Next(1, 10920));
            string _1F = gender[rn.Next(0, 1)];

            string _29 = "01";
            string _2B = "C6ID0";

            string _2A = DateTime.Now.ToString("yyyy-MM-dd");
            string _2C = string.Format("0{0}", cntr.ToString().PadLeft(4, '0'));
            string _10 = string.Format("00{0}{1}", rn.Next(100000, 999999), cntr.ToString().PadLeft(4, '0'));

            string csn = string.Concat(_29, _2A.Replace("-", ""), _2B, _2C);

            string _11 = string.Format("{0}", (_1F == "M") ? male_firstList[rn.Next(0, male_firstList.Length - 1)] : female_firstList[rn.Next(0, female_firstList.Length - 1)]);
            string _12 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _13 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _18 = string.Format("{0}", cityList[rn.Next(0, cityList.Length - 1)]);
            string _20 = string.Format("{0}", dob.ToString("yyyyMMdd"));
            string _21 = string.Format("{0}", _18);
            string _30 = string.Format("{0}", male_firstList[rn.Next(0, male_firstList.Length - 1)]);
            string _31 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _32 = string.Format("{0}", _13);
            string _40 = string.Format("{0}", female_firstList[rn.Next(0, female_firstList.Length - 1)]);
            string _41 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _42 = string.Format("{0}", _12);
            string _103 = string.Format("{0}{1}", rn.Next(11111, 39999), rn.Next(11111, 39999));

            templateData = templateData.Replace("@29", _29.ToUpper());
            templateData = templateData.Replace("@2B", _2B.ToUpper());

            templateData = templateData.Replace("@2A", _2A.ToUpper());
            templateData = templateData.Replace("@2C", _2C.ToUpper());
            templateData = templateData.Replace("@10", _10.ToUpper());
            templateData = templateData.Replace("@11", _11.ToUpper());
            templateData = templateData.Replace("@12", _12.ToUpper());
            templateData = templateData.Replace("@13", _13.ToUpper());
            templateData = templateData.Replace("@18", _18.ToUpper());
            templateData = templateData.Replace("@20", _20.ToUpper());
            templateData = templateData.Replace("@21", _21.ToUpper());
            templateData = templateData.Replace("@30", _30.ToUpper());
            templateData = templateData.Replace("@31", _31.ToUpper());
            templateData = templateData.Replace("@32", _32.ToUpper());
            templateData = templateData.Replace("@40", _40.ToUpper());
            templateData = templateData.Replace("@41", _41.ToUpper());
            templateData = templateData.Replace("@42", _42.ToUpper());
            templateData = templateData.Replace("@ssnum", _103);

            templateData = templateData.Replace("@19", "PUEBLO");
            templateData = templateData.Replace("@1A", "");
            templateData = templateData.Replace("@1B", "");
            templateData = templateData.Replace("@1C", "222");

            string outputFolder = @"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\output";
            string csnFolder = System.IO.Path.Combine(outputFolder, csn);

            if (!System.IO.Directory.Exists(csnFolder)) System.IO.Directory.CreateDirectory(csnFolder);

            //generate test data            
            foreach (var f in System.IO.Directory.GetFiles(templateFolder))
            {
                if (System.IO.Path.GetExtension(f).ToUpper() == ".XML") System.IO.File.WriteAllText(string.Format(@"{0}\{1}.xml", csnFolder, csn), templateData);
                else System.IO.File.Copy(f, string.Format(@"{0}\{1}", csnFolder, System.IO.Path.GetFileName(f)).Replace("csn", csn), true);
            }

            string l = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}{8}", csn.ToUpper(), _10.ToUpper(), _103.ToUpper(), _11.ToUpper(), _12.ToUpper(), _13.ToUpper(), _1F.ToUpper(), dob.ToString("yyyy-MM-dd"), Environment.NewLine);
            System.IO.File.AppendAllText(string.Format(@"{0}\list.txt", outputFolder), l);
        }

        public static void CreateTestDatav2(int cntr, string fname, string mname, string lname, string sourceFolder)
        {
            string templateFolder = @"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\template";

            string templateXML = string.Format(@"{0}\csn.xml", templateFolder);
            string templateData = System.IO.File.ReadAllText(templateXML);
            string[] female_firstList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\female_first.txt").ToArray();
            string[] male_firstList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\male_first.txt").ToArray();
            string[] lastList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\last.txt").ToArray();
            string[] cityList = System.IO.File.ReadLines(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\city.txt").ToArray();

            string[] gender = new string[] { "M", "F" };

            Random rn = new Random();
            DateTime dob = DateTime.Now.AddDays(-7280).AddDays(-rn.Next(1, 10920));

            string _1F = gender[rn.Next(0, 1)];

            switch (fname)
            {
                case "YOLLIE":
                case "ERICA":
                case "MARILYN":
                    _1F = "F";
                    break;
                default:
                    _1F = "M";
                    break;
            }

            string _29 = "01";
            string _2B = "C6ID0";

            string _2A = DateTime.Now.ToString("yyyy-MM-dd");
            string _2C = string.Format("0{0}", cntr.ToString().PadLeft(4, '0'));
            string _10 = string.Format("00{0}{1}", rn.Next(100000, 999999), cntr.ToString().PadLeft(4, '0'));

            string csn = string.Concat(_29, _2A.Replace("-", ""), _2B, _2C);

            string _11 = string.Format("{0}", fname);
            string _12 = string.Format("{0}", mname);
            string _13 = string.Format("{0}", lname);
            string _18 = string.Format("{0}", cityList[rn.Next(0, cityList.Length - 1)]);
            string _20 = string.Format("{0}", dob.ToString("yyyyMMdd"));
            string _21 = string.Format("{0}", _18);
            string _30 = string.Format("{0}", male_firstList[rn.Next(0, male_firstList.Length - 1)]);
            string _31 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _32 = string.Format("{0}", _13);
            string _40 = string.Format("{0}", female_firstList[rn.Next(0, female_firstList.Length - 1)]);
            string _41 = string.Format("{0}", lastList[rn.Next(0, lastList.Length - 1)]);
            string _42 = string.Format("{0}", _12);
            string _103 = string.Format("{0}{1}", rn.Next(11111, 39999), rn.Next(11111, 39999));

            templateData = templateData.Replace("@29", _29.ToUpper());
            templateData = templateData.Replace("@2B", _2B.ToUpper());

            templateData = templateData.Replace("@2A", _2A.ToUpper());
            templateData = templateData.Replace("@2C", _2C.ToUpper());
            templateData = templateData.Replace("@10", _10.ToUpper());
            templateData = templateData.Replace("@11", _11.ToUpper());
            templateData = templateData.Replace("@12", _12.ToUpper());
            templateData = templateData.Replace("@13", _13.ToUpper());
            templateData = templateData.Replace("@18", _18.ToUpper());
            templateData = templateData.Replace("@20", _20.ToUpper());
            templateData = templateData.Replace("@21", _21.ToUpper());
            templateData = templateData.Replace("@30", _30.ToUpper());
            templateData = templateData.Replace("@31", _31.ToUpper());
            templateData = templateData.Replace("@32", _32.ToUpper());
            templateData = templateData.Replace("@40", _40.ToUpper());
            templateData = templateData.Replace("@41", _41.ToUpper());
            templateData = templateData.Replace("@42", _42.ToUpper());
            templateData = templateData.Replace("@ssnum", _103);

            templateData = templateData.Replace("@19", "PUEBLO");
            templateData = templateData.Replace("@1A", "");
            templateData = templateData.Replace("@1B", "");
            templateData = templateData.Replace("@1C", "222");

            string outputFolder = @"H:\My Drive\SSS\SSS UMID PROJECT 2022\TEST DATA\template\output";
            string csnFolder = System.IO.Path.Combine(outputFolder, csn);

            if (!System.IO.Directory.Exists(csnFolder)) System.IO.Directory.CreateDirectory(csnFolder);

            string sssSourceFolder = string.Format(@"H:\My Drive\SSS\SSS UMID PROJECT 2022\Capturing\{0}", sourceFolder);

            //generate test data            
            foreach (var f in System.IO.Directory.GetFiles(templateFolder))
            {
                if (System.IO.Path.GetExtension(f).ToUpper() == ".XML") System.IO.File.WriteAllText(string.Format(@"{0}\{1}.xml", csnFolder, csn), templateData);
                else if (System.IO.Path.GetExtension(f).ToUpper() == ".JPG") System.IO.File.Copy(f, string.Format(@"{0}\{1}_Photo.jpg", csnFolder, csn), true);
                else if (System.IO.Path.GetExtension(f).ToUpper() == ".TIFF") System.IO.File.Copy(f, string.Format(@"{0}\{1}_Signature.tiff", csnFolder, csn), true);
            }

            foreach (var f in System.IO.Directory.GetFiles(sssSourceFolder))
            {
                if (System.IO.Path.GetExtension(f).ToUpper() == ".ANSI-FMR")
                {
                    if (System.IO.Path.GetFileName(f).Contains("_Lbackup.ansi-fmr")) System.IO.File.Copy(f, string.Format(@"{0}\{1}_Lbackup.ansi-fmr", csnFolder, csn), true);
                    if (System.IO.Path.GetFileName(f).Contains("_Lprimary.ansi-fmr")) System.IO.File.Copy(f, string.Format(@"{0}\{1}_Lprimary.ansi-fmr", csnFolder, csn), true);
                    if (System.IO.Path.GetFileName(f).Contains("_Rbackup.ansi-fmr")) System.IO.File.Copy(f, string.Format(@"{0}\{1}_Rbackup.ansi-fmr", csnFolder, csn), true);
                    if (System.IO.Path.GetFileName(f).Contains("_Rprimary.ansi-fmr")) System.IO.File.Copy(f, string.Format(@"{0}\{1}_Rprimary.ansi-fmr", csnFolder, csn), true);
                }
            }

            string l = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}{8}", csn.ToUpper(), _10.ToUpper(), _103.ToUpper(), _11.ToUpper(), _12.ToUpper(), _13.ToUpper(), _1F.ToUpper(), dob.ToString("yyyy-MM-dd"), Environment.NewLine);
            System.IO.File.AppendAllText(string.Format(@"{0}\list.txt", outputFolder), l);
        }

        public static void GenerateMemberContactInformationLocalDb_Insert(string appDir, string sourceFile, 
                                                            string permBrgyCode, string permCityCode, string permProvCode, string permRegionCode, string permRegionDesc,
                                                            string presBrgyCode, string presCityCode, string presProvCode, string presRegionCode, string presRegionDesc)
        {
            string template = string.Format(@"{0}\contactInfo_insert_template.sql", appDir);
            //string sourceData = string.Format(@"{0}\Member Contact Information.txt", appDir);
            //string sourceData = string.Format(@"{0}\Member Contact Information.txt", @"C:\Users\Edel\Downloads\Contact info");
            string sourceData = sourceFile;
            string output = "";

            string refNum = "";
            string mid = "";
            StringBuilder sb = new StringBuilder();
            string[] arrData = System.IO.File.ReadAllText(sourceData).Split('|');

            for (int i = 0; i < arrData.Length - 1; i++)
            {
                string val = arrData[i];                

                if (sb.ToString() != "") sb.Append(",");

                if (i == 0) sb.Append(string.Format("@refNum"));
                else sb.Append(string.Format("'{0}'", val));

                //get mid from refnum
                if (i == 0)
                {
                    refNum = val;
                    mid = val.Substring(10, 12);

                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", mid));

                    output = string.Format(@"{0}\Member Contact Information_Insert_LocalDb_{1}.sql", appDir, mid);
                }

                //get permanent brgy code
                else if (i == 9)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", permBrgyCode));
                }

                //get permanent city code
                else if (i == 10)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", permCityCode));
                }

                //get permanent province code
                else if (i == 11)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", permProvCode));                                     

                    if (sb.ToString() != "") sb.Append(",");                    
                    sb.Append(string.Format("'{0}'", permRegionDesc));

                    //get permanent region code
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", permRegionCode));
                }

                //get present brgy code
                else if (i == 21)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", presBrgyCode));
                }

                //get present city code
                else if (i == 22)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", presCityCode));
                }

                //get present province code
                else if (i == 23)
                {
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", presProvCode));                                        

                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", presRegionDesc));

                    //get present region code
                    if (sb.ToString() != "") sb.Append(",");
                    sb.Append(string.Format("'{0}'", presRegionCode));
                }
            }

            System.IO.File.WriteAllText(output, System.IO.File.ReadAllText(template).Trim().Replace("?refNum", refNum).Replace("@data", sb.ToString()));
        }

        public static void GenerateMemberContactInformationLocalDb_Update(string appDir, string sourceFile,
                                                            string permBrgyCode, string permCityCode, string permProvCode, string permRegionCode,
                                                            string permBrgyDesc, string permCityDesc, string permProvDesc, string permRegionDesc,
                                                            string presBrgyCode, string presCityCode, string presProvCode, string presRegionCode,
                                                            string presBrgyDesc, string presCityDesc, string presProvDesc, string presRegionDesc,
                                                            string permZipCode, string presZipCode)
        {
            string template = string.Format(@"{0}\contactInfo_update_template.sql", appDir);
            
            string sourceData = sourceFile;
            string output = "";
            
            string data = System.IO.File.ReadAllText(sourceData);
            string templateData = System.IO.File.ReadAllText(template);

            string refNum = data.Split('|')[0];
            string mid = refNum.Substring(10, 12);
            output = string.Format(@"{0}\Member Contact Information_Update_LocalDb_{1}.sql", appDir, mid);

            templateData = templateData.Replace("?refNum", refNum);

            templateData = templateData.Replace("@A1", permBrgyCode);
            templateData = templateData.Replace("@A2", permBrgyDesc);
            templateData = templateData.Replace("@A3", permCityCode);
            templateData = templateData.Replace("@A4", permCityDesc);
            templateData = templateData.Replace("@A5", permProvCode);
            templateData = templateData.Replace("@A6", permProvDesc);
            templateData = templateData.Replace("@A7", permRegionCode);
            templateData = templateData.Replace("@A8", permRegionDesc);
            templateData = templateData.Replace("@A9", permZipCode);

            templateData = templateData.Replace("@B1", presBrgyCode);
            templateData = templateData.Replace("@B2", presBrgyDesc);
            templateData = templateData.Replace("@B3", presCityCode);
            templateData = templateData.Replace("@B4", presCityDesc);
            templateData = templateData.Replace("@B5", presProvCode);
            templateData = templateData.Replace("@B6", presProvDesc);
            templateData = templateData.Replace("@B7", presRegionCode);
            templateData = templateData.Replace("@B8", presRegionDesc);
            templateData = templateData.Replace("@B9", presZipCode);

            System.IO.File.WriteAllText(output, templateData);
        }

        public static string GetExpirationDate()
        {
            var Expiry = "2030-10";

            var expYear = Convert.ToInt32(Expiry.Substring(0, 4));
            var exPmonth = Convert.ToInt32(Expiry.Substring(5, 2));
            var cardExpirationDate = new DateTime(expYear, exPmonth, 1, 23, 59, 59).AddMonths(1).AddDays(-1);

            return cardExpirationDate.ToString();
        }

        public static string ValidateNumber(string value)
        {
            var isNumeric = long.TryParse(value, out _);
            if (!isNumeric)
            {                
                return "Failed";
            }

            return "Success";
        }

        public static string GetRamUsage()
        {
            Process c = Process.GetCurrentProcess();
            long memory = (c.VirtualMemorySize64 / 1024) / 1024;
            return string.Format("Memory used: {0}", memory);
        }

     

    }
}

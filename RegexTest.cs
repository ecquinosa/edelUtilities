using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;

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

            Regex r = new Regex(String.Concat("^[a-zA-Z0-9", txtRegex.Text, "]*$"));

            for (int i = 0; i < str.Length; i++)
            {
                if (r.IsMatch(str[i].ToString())) sb.Append(str[i]);
                else sb.Append("");
            }

            return sb.ToString();
        }       

        public bool RBANK_CheckHeartBeat(string log)
        {
            System.Net.WebRequest Request;
            System.Net.WebResponse Response;
            System.IO.Stream DataStream;
            System.IO.StreamReader Reader;
            string SoapStr = "";
            bool pSuccess = true;
            //var RBANK_API_LINK = My.Settings.RBANK_BasedURL;
            //var RBANK_API_KEY = My.Settings.RBANK_APIKey;
            string API_Method = "GET";
            //var checkHeartBeatURL = RBANK_API_LINK + "/api/heartbeat?my-key=" + RBANK_API_KEY;
            var checkHeartBeatURL = "https://3rdprod.api.robinsonsbank.com.ph/api/heartbeat?my-key=becec727-c8fe-4e9c-9d73-080d81caa8c1";
            int retry = 3;

        Retry:
            
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Request = System.Net.WebRequest.Create(checkHeartBeatURL);
                Request.Method = "GET";
                // Request.Timeout = My.Settings.RBANK_TIMEOUT * 3000

                Response = Request.GetResponse();
                DataStream = Response.GetResponseStream();
                Reader = new System.IO.StreamReader(DataStream);

                var heartbeatResponse = Reader.ReadToEnd();

                DataStream.Close();
                Reader.Close();
                Response.Close();

                System.IO.File.WriteAllText(log, heartbeatResponse);

                return true;
            }
            catch (TimeoutException TimeoutEx)
            {
                System.IO.File.WriteAllText(log, TimeoutEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(log, ex.Message);
                if (retry > 0)
                {
                    retry = retry - 1;
                    goto Retry;
                }
                return false;
            }
            finally
            { MessageBox.Show("Done"); }
        }

        public bool RBANK_CheckHeartBeat2(string log)
        {
            System.Net.WebRequest Request;
            System.Net.WebResponse Response;
            System.IO.Stream DataStream;
            System.IO.StreamReader Reader;
            string SoapStr = "";
            bool pSuccess = true;
            //var RBANK_API_LINK = My.Settings.RBANK_BasedURL;
            //var RBANK_API_KEY = My.Settings.RBANK_APIKey;
            string API_Method = "GET";
            //var checkHeartBeatURL = RBANK_API_LINK + "/api/heartbeat?my-key=" + RBANK_API_KEY;
            var checkHeartBeatURL = "https://3rdprod.api.robinsonsbank.com.ph/api/heartbeat?my-key=becec727-c8fe-4e9c-9d73-080d81caa8c1";
            int retry = 3;

        Retry:

            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                Request = System.Net.WebRequest.Create(checkHeartBeatURL);
                Request.Method = "GET";
                // Request.Timeout = My.Settings.RBANK_TIMEOUT * 3000

                Response = Request.GetResponse();
                DataStream = Response.GetResponseStream();
                Reader = new System.IO.StreamReader(DataStream);

                var heartbeatResponse = Reader.ReadToEnd();

                DataStream.Close();
                Reader.Close();
                Response.Close();

                System.IO.File.WriteAllText(log, heartbeatResponse);               

                return true;
            }
            catch (TimeoutException TimeoutEx)
            {
                System.IO.File.WriteAllText(log, TimeoutEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(log, ex.Message);
                if (retry > 0)
                {
                    retry = retry - 1;
                    goto Retry;
                }
                return false;
            }
            finally
                { MessageBox.Show("Done"); }
        }

        public bool RBANK_CheckHeartBeat3(string log)
        {
            System.Net.WebRequest Request;
            System.Net.WebResponse Response;
            System.IO.Stream DataStream;
            System.IO.StreamReader Reader;
            string SoapStr = "";
            bool pSuccess = true;
            //var RBANK_API_LINK = My.Settings.RBANK_BasedURL;
            //var RBANK_API_KEY = My.Settings.RBANK_APIKey;
            string API_Method = "GET";
            //var checkHeartBeatURL = RBANK_API_LINK + "/api/heartbeat?my-key=" + RBANK_API_KEY;
            var checkHeartBeatURL = "https://3rdprod.api.robinsonsbank.com.ph/api/heartbeat?my-key=becec727-c8fe-4e9c-9d73-080d81caa8c1";
            int retry = 3;

        Retry:

            try
            {
              
                Request = System.Net.WebRequest.Create(checkHeartBeatURL);
                Request.Method = "GET";

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                       | SecurityProtocolType.Tls11
                       | SecurityProtocolType.Tls12
                       | SecurityProtocolType.Ssl3;

                // Request.Timeout = My.Settings.RBANK_TIMEOUT * 3000

                Response = Request.GetResponse();
                DataStream = Response.GetResponseStream();
                Reader = new System.IO.StreamReader(DataStream);

                var heartbeatResponse = Reader.ReadToEnd();

                DataStream.Close();
                Reader.Close();
                Response.Close();

                System.IO.File.WriteAllText(log, heartbeatResponse);

                return true;
            }
            catch (TimeoutException TimeoutEx)
            {
                System.IO.File.WriteAllText(log, TimeoutEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(log, ex.Message);
                if (retry > 0)
                {
                    retry = retry - 1;
                    goto Retry;
                }
                return false;
            }
            finally
            { MessageBox.Show("Done"); }
        }

        public bool RBANK_CheckHeartBeat4(string log)
        {
            System.Net.WebRequest Request;
            System.Net.WebResponse Response;
            System.IO.Stream DataStream;
            System.IO.StreamReader Reader;
            string SoapStr = "";
            bool pSuccess = true;
            //var RBANK_API_LINK = My.Settings.RBANK_BasedURL;
            //var RBANK_API_KEY = My.Settings.RBANK_APIKey;
            string API_Method = "GET";
            //var checkHeartBeatURL = RBANK_API_LINK + "/api/heartbeat?my-key=" + RBANK_API_KEY;
            var checkHeartBeatURL = "https://3rdprod.api.robinsonsbank.com.ph/api/heartbeat?my-key=becec727-c8fe-4e9c-9d73-080d81caa8c1";
            int retry = 3;

        Retry:

            try
            {

                Request = System.Net.WebRequest.Create(checkHeartBeatURL);
                Request.Method = "GET";

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                // Request.Timeout = My.Settings.RBANK_TIMEOUT * 3000

                Response = Request.GetResponse();
                DataStream = Response.GetResponseStream();
                Reader = new System.IO.StreamReader(DataStream);

                var heartbeatResponse = Reader.ReadToEnd();

                DataStream.Close();
                Reader.Close();
                Response.Close();

                System.IO.File.WriteAllText(log, heartbeatResponse);

                return true;
            }
            catch (TimeoutException TimeoutEx)
            {
                System.IO.File.WriteAllText(log, TimeoutEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(log, ex.Message);
                if (retry > 0)
                {
                    retry = retry - 1;
                    goto Retry;
                }
                return false;
            }
            finally
            { MessageBox.Show("Done"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RBANK_CheckHeartBeat(String.Format("{0}\\heartbeat1_{1}.txt", Application.StartupPath, DateTime.Now.ToString("hhmmss")));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RBANK_CheckHeartBeat2(String.Format("{0}\\heartbeat2_{1}.txt", Application.StartupPath, DateTime.Now.ToString("hhmmss")));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RBANK_CheckHeartBeat3(String.Format("{0}\\heartbeat3_{1}.txt", Application.StartupPath, DateTime.Now.ToString("hhmmss")));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RBANK_CheckHeartBeat4(String.Format("{0}\\heartbeat4_{1}.txt", Application.StartupPath, DateTime.Now.ToString("hhmmss")));
        }
    }
}

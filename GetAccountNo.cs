using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class GetAccountNo : Form
    {
        public GetAccountNo()
        {
            InitializeComponent();

            raUBP.wsUser = "ulilangkawayan";
            raUBP.wsPass = "ragMANOK2kx";
            raUBP.KioskID = "user";
            raUBP.User = 0;

            raAUB.wsUser = "ulilangkawayan";
            raAUB.wsPass = "ragMANOK2kx";
            raAUB_PreProd.wsUser = "ulilangkawayan";
            raAUB_PreProd.wsPass = "ragMANOK2kx";
            raAUB_SIT_OLD.wsUser = "ulilangkawayan";
            raAUB_SIT_OLD.wsPass = "ragMANOK2kx";
            raAUB.KioskID = "user";
            raAUB.User = 0;

            raUBP_SIT_OLD.wsUser = "ulilangkawayan";
            raUBP_SIT_OLD.wsPass = "ragMANOK2kx";            


            cboBank.SelectedIndex = 0;
            cboApi.SelectedIndex = 0;
        }

        private ubpWS.ACC_MS_WEBSERVICE ubpWS = new ubpWS.ACC_MS_WEBSERVICE();
        private aubWS_PreProd.ACC_MS_WEBSERVICE aubWS_PreProd = new aubWS_PreProd.ACC_MS_WEBSERVICE();

        //private aubWS.ACC_MS_WEBSERVICE aubWS = new aubWS.ACC_MS_WEBSERVICE();
        //private aubWS.RequestAuth raAUB = new aubWS.RequestAuth();

        private aubProd_VPN.ACC_MS_WEBSERVICE aubWS = new aubProd_VPN.ACC_MS_WEBSERVICE();
        private aubProd_VPN.RequestAuth raAUB = new aubProd_VPN.RequestAuth();

        private aubWS_SIT_OLD.ACC_MS_WEBSERVICE aubWS_SIT_OLD = new aubWS_SIT_OLD.ACC_MS_WEBSERVICE();
        private ubpWS_SIT.ACC_MS_WEBSERVICE ubpWS_SIT_OLD = new ubpWS_SIT.ACC_MS_WEBSERVICE();
        private rbankSIT_WS.ACC_MS_WEBSERVICE rbankSIT_WS = new rbankSIT_WS.ACC_MS_WEBSERVICE();
        private ubpWS.RequestAuth raUBP = new ubpWS.RequestAuth();
       
        private aubWS_PreProd.RequestAuth raAUB_PreProd = new aubWS_PreProd.RequestAuth();
        private aubWS_SIT_OLD.RequestAuth raAUB_SIT_OLD = new aubWS_SIT_OLD.RequestAuth();
        private ubpWS_SIT.RequestAuth raUBP_SIT_OLD = new ubpWS_SIT.RequestAuth();
        private rbankSIT_WS.RequestAuth raSIT_RBANK = new rbankSIT_WS.RequestAuth();

        private void RunTemp()
        {
            string sourceFile = @"D:\1538\list.txt";
            if (System.IO.File.Exists(sourceFile))
            {
                foreach (var line in System.IO.File.ReadAllLines(sourceFile))
                {
                    txtMID.Text = line.Trim();
                    btnSubmit.PerformClick();
                }
            }          
        }

        private void SaveDataToTxt(aubWS.SubmitResult sr)
        {
            string line = string.Concat(sr.SearchResult.MemberInfo.MemberID, "|",sr.SearchResult.MemberInfo.MemberName.FirstName, "|", sr.SearchResult.MemberInfo.MemberName.MiddleName,"|", sr.SearchResult.MemberInfo.MemberName.LastName, "|", sr.SearchResult.MemberInfo.PresentAddress.Barangay, "|", sr.SearchResult.MemberInfo.PresentAddress.CityMunicipality, "|", sr.SearchResult.MemberInfo.PresentAddress.Province, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerName, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.Barangay, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.CityMunicipality, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.Province);
            string destiFile = @"D:\1538\details.txt";
            using (var sw = new System.IO.StreamWriter(destiFile, true))
            {
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RunTemp();
            //GetCardNo_AUB_prod();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMID.Text == "") return;

            rtb.Clear();

            try
            {
                switch (cboApi.Text)
                {
                    case "ActiveCardInfo":
                        ActiveCardInfo();
                        break;
                    case "GetMemberInfo":
                        GetMemberInfo();
                        break;
                    case "GetCardNo_AUB":
                        string err = "";
                        if (cboBank.Text == "AUB")
                        {
                            switch (cboEnvironment.Text)
                            {
                                case "SIT":
                                    break;
                                case "PRE-PROD":
                                    GetCardNo_AUB_preprod(txtMID.Text, txtFirst.Text, txtMiddle.Text, txtLast.Text, txtDOB.Text);
                                    break;
                                case "PROD":
                                    GetCardNo_AUB_prod(txtMID.Text, txtFirst.Text, txtMiddle.Text, txtLast.Text, txtDOB.Text);
                                    break;
                            }                            
                        }
                        else GetCardNo_UBP_prod(txtMID.Text, ref err);
                        break;
                    default:
                        GetMemberMCRecord();
                        break;
                }
            }
            catch (Exception ex)
            {
                rtb.Text = ex.Message;
            }
        }

        private string GetMID()
        {
            return txtMID.Text.Replace(" ", "").Replace("-", "");
        }

        private void ActiveCardInfo()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.GetActiveCardInfo(raUBP, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 1:
                    var response2 = aubWS.GetActiveCardInfo(raAUB, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.GetActiveCardInfo(raSIT_RBANK, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }
        }        

        private void GetMemberInfo()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.is_MID_RTN_Exist(raUBP, GetMID());                   
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 1:
                    ////var response2 = aubWS.Is_MID_RTN_Exist(raAUB, GetMID());
                    //var response2 = aubProd_VPN.(raAUB, GetMID());
                    //SaveDataToTxt(response2);
                    //rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.is_MID_RTN_Exist(raSIT_RBANK, GetMID());
                    //SaveDataToTxt(response3);
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }            
           
        }

        private void GetMemberMCRecord()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.Is_Member_Active(raUBP, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                   
                    break;
                case 1:
                    var response2 = aubWS.Is_Member_Active(raAUB, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.Is_Member_Active(raSIT_RBANK, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }
        }

        //private void GetCardNo_AUB()
        //{
        //    var name = new aubWS_SIT_OLD.name();
        //    name.firstName = "ROSALIE";            
        //    name.middleName = "HERNANE";
        //    name.lastName = "LORENZANA";
        //    var inq = new aubWS_SIT_OLD.inquiry();
        //    inq.idNo = "121051869550";
        //    inq.name = name;
        //    inq.birthdate = "1982-08-14";
        //    var getCard = new aubWS_SIT_OLD.AUBGetCardNoRequest();
        //    getCard.inquiry = inq;
        //    getCard.aud = "cashcard";
        //    getCard.jti = Guid.NewGuid().ToString();

        //    var response2 = aubWS_SIT_OLD.GetCardNo_AUB(raAUB_SIT_OLD, getCard);
        //    System.IO.File.WriteAllText(Application.StartupPath + "\\getCard.txt", Newtonsoft.Json.JsonConvert.SerializeObject(getCard));
        //    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
        //}

        public void GetCardNo_AUB_preprod(string mid, string firstName, string middleName, string lastName, string dob)
        {
            txtMID.Text = mid;
            var name = new aubWS_PreProd.name();
            name.firstName = firstName;
            name.middleName = middleName;
            name.lastName = lastName;
            var inq = new aubWS_PreProd.inquiry();
            inq.idNo = mid;
            inq.name = name;
            inq.birthdate = dob;
            var getCard = new aubWS_PreProd.AUBGetCardNoRequest();
            getCard.inquiry = inq;
            getCard.aud = "cashcard";
            getCard.jti = Guid.NewGuid().ToString();

            var response2 = aubWS_PreProd.GetCardNo_AUB(raAUB_PreProd, getCard);
            System.IO.File.WriteAllText(Application.StartupPath + "\\getCard.txt", Newtonsoft.Json.JsonConvert.SerializeObject(getCard));
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
        }

        public void GetCardNo_AUB_prod(string mid, string firstName, string middleName, string lastName, string dob)
        {
            txtMID.Text = mid;
            //var name = new aubWS.name();
            var name = new aubProd_VPN.name();
            name.firstName = firstName;
            name.middleName = middleName;
            name.lastName = lastName;
            //var inq = new aubWS.inquiry();
            var inq = new aubProd_VPN.inquiry();
            inq.idNo = mid;
            inq.name = name;
            inq.birthdate = dob;
            //var getCard = new aubWS.AUBGetCardNoRequest();
            var getCard = new aubProd_VPN.AUBGetCardNoRequest();
            getCard.inquiry = inq;
            getCard.aud = "cashcard";
            getCard.jti = Guid.NewGuid().ToString();

            var response2 = aubWS.GetCardNo_AUB(raAUB, getCard);
            System.IO.File.WriteAllText(Application.StartupPath + "\\getCard.txt", Newtonsoft.Json.JsonConvert.SerializeObject(getCard));
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
        }

        private void GetAccountNo_Load(object sender, EventArgs e)
        {
            cboApi.SelectedIndex = 3;
            txtDOB.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        class ubpGetAcctNo
        {

            public branchKiosk Kiosk { get; set; }
            public class branchKiosk
            {
                public string Pagibig_ID { get; set; }
            }

            public class ubpGetAcctNoResponse
            {
                public bool success { get; set; }
                public string message { get; set; }
                public DateTime stamp { get; set; }
                public string data { get; set; }
            }
        }

        public void GetCardNo_UBP_prod(string mid, ref string msg)
        {
            ubpGetAcctNo ubpGetAcctNo = new ubpGetAcctNo();
            ubpGetAcctNo.branchKiosk Kiosk = new ubpGetAcctNo.branchKiosk();
            Kiosk.Pagibig_ID = mid;
            ubpGetAcctNo.Kiosk = Kiosk;          
            string soapResponse = "";
            string err = "";
            string soapStr = Newtonsoft.Json.JsonConvert.SerializeObject(ubpGetAcctNo);
           
            string url1 = "http://10.88.87.67:8600/api/dao/oldcardnumber";
            string url2 = "http://ubp.allcard.com.ph:8500/api/dao/oldcardnumber";

            string url = url1;
            if (cboEnvironment.Text == "PROD") url = url2;
            bool response = ExecuteApiRequest(url, soapStr, ref soapResponse, ref err);
            var ubpGetAcctNoResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ubpGetAcctNo.ubpGetAcctNoResponse>(soapResponse);
            if (response)
            {               
                rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(ubpGetAcctNoResponse, Newtonsoft.Json.Formatting.Indented);
            }
            else
            {
                rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(soapResponse, Newtonsoft.Json.Formatting.Indented);
            }
        }

        public static bool ExecuteApiRequest(string url, string soapStr, ref string soapResponse, ref string err)
        {           
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            try
            {
                var uri = new Uri(url);
                string baseUrl = string.Format("http://{0}", uri.Authority);
                if (url.Contains("https://")) baseUrl = string.Format("https://{0}", uri.Authority);
                string otherUrl = uri.LocalPath;

                client.BaseAddress = new Uri(baseUrl);
              
                var buffer = System.Text.Encoding.UTF8.GetBytes(soapStr);
                var byteContent = new System.Net.Http.ByteArrayContent(buffer);
                byteContent.Headers.Clear();
                byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                byteContent.Headers.TryAddWithoutValidation("X-Secret", "d3lVMDE2SFBPSkZOeFJHaGJrbmkzUT09");
                byteContent.Headers.TryAddWithoutValidation("X-Kiosk", "");              
                byteContent.Headers.ContentLength = buffer.Length;

                System.Net.Http.HttpResponseMessage response = client.PostAsync(otherUrl, byteContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    soapResponse = response.Content.ReadAsStringAsync().Result;
                    return true;
                }
                else
                {
                    err = string.Format("{0} {1}", response.StatusCode, response.Content.ReadAsStringAsync().Result.ToString()); //response.ReasonPhrase);
                    return false;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("One or more errors occurred.")) err = "Unable to reach cbs api.";
                else err = string.Concat("CBS api error. ", ex.Message);
                return false;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}

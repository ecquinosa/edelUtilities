using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class InsertContactInfoAddress_DCS : Form
    {
        public InsertContactInfoAddress_DCS()
        {
            InitializeComponent();
        }

        private string ubpConStr = "Server=10.88.77.68;Database=LCDB_01;User=allcard;Password=MalboroLights#;";
        private string aubConStr = "Server=10.88.77.71;Database=LCDB_01;User=allcard;Password=MarlboroLights#;";
        DAL.MsSql dal = null;
        private DataTable dtDbase = null;

        private string permBrgyCode = "";
        private string permCityCode = "";
        private string permProvCode = "";
        private string permRegionCode = "";
        private string permZipCode = "";

        private string permBrgyDesc = "";
        private string permCityDesc = "";
        private string permProvDesc = "";
        private string permRegionDesc = "";

        private string presBrgyCode = "";
        private string presCityCode = "";
        private string presProvCode = "";
        private string presRegionCode = "";
        private string presZipCode = "";

        private string presBrgyDesc = "";
        private string presCityDesc = "";
        private string presProvDesc = "";
        private string presRegionDesc = "";



        private void InsertContactInfoAddress_DCS_Load(object sender, EventArgs e)
        {
            cboBank.SelectedIndex = 0;
        }

        private void BindCodesAndDesc(bool searchBrgy)
        {
            dal = null;
            string conStr = "";
            if(cboBank.Text=="UBP") conStr = ubpConStr;
            else if (cboBank.Text == "AUB") conStr = aubConStr;
            dal = new DAL.MsSql(conStr);

            StringBuilder sb = new StringBuilder();
            sb.Append("select b.psgc_barangay_code,b.psgc_barangay_desc,b.ZIP_CODE, ");
            sb.Append("c.psgc_city_mun_code, c.psgc_city_mun_desc, p.psgc_province_code,p.psgc_province_desc, r.psgc_region_code,r.psgc_region_desc ");
            sb.Append("from tbl_Ref_Barangay_Zipcode b left outer join ");
            sb.Append("tbl_Ref_City_Municipality c on b.psgc_city_mun_code = c.psgc_city_mun_code left outer join ");
            sb.Append("tbl_Ref_Province p on c.psgc_province_code = p.psgc_province_code left outer join ");
            sb.Append("tbl_Ref_Region r on p.psgc_region_code = r.psgc_region_code ");

            if (searchBrgy) sb.Append(string.Format("where b.psgc_barangay_desc like '%{0}%' ", txtBrgy.Text));
            else sb.Append(string.Format("where c.psgc_city_mun_desc like '%{0}%' ", txtCity.Text));

            if (dal.SelectQuery(sb.ToString())) dtDbase = dal.TableResult;            
            dal.Dispose();
            grid.DataSource = dtDbase;
        }

        private void ResetVariables(short v)
        {
            if (v==1 | v == 3)
            {
                permBrgyCode = "";
                permCityCode = "";
                permProvCode = "";
                permRegionCode = "";
                permZipCode = "";

                permBrgyDesc = "";
                permCityDesc = "";
                permProvDesc = "";
                permRegionDesc = "";
            }

            if (v == 2 | v == 3)
            {
                presBrgyCode = "";
                presCityCode = "";
                presProvCode = "";
                presRegionCode = "";
                presZipCode = "";

                presBrgyDesc = "";
                presCityDesc = "";
                presProvDesc = "";
                presRegionDesc = "";
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string appDir = txtOutput.Text;
            permBrgyCode = txtPerBrgy.Text;
            permCityCode = txtPerCity.Text;
            permProvCode = txtPerProvince.Text;
            permRegionCode = txtPerRegion.Text;
            permRegionDesc = txtPerRegionDesc.Text;

            presBrgyCode = txtPerBrgy.Text;
            presCityCode = txtPerCity.Text;
            presProvCode = txtPerProvince.Text;
            presRegionCode = txtPerRegion.Text;
            presRegionDesc = txtPerRegionDesc.Text;
            
            Lab.GenerateMemberContactInformationLocalDb_Insert(appDir, txtContactInfoFile.Text,
                                                        permBrgyCode, permCityCode, permProvCode, permRegionCode, permRegionDesc,
                                                        presBrgyCode, presCityCode, presProvCode, presRegionCode, presRegionDesc);

            Utilities.ShowInfoMessageBox("Done!");
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //label2.Text = grid.CurrentRow.Cells["psgc_barangay_code"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtContactInfoFile.Text)) return;
            else if (txtBrgy.Text == "" && txtCity.Text=="") return;
            BindCodesAndDesc(true);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtContactInfoFile.Text = ofd.FileName;

                BindBrgyAndCity();
            }
            ofd.Dispose();
            ofd = null;
        }

        private void BindBrgyAndCity()
        {
            if (System.IO.File.Exists(txtContactInfoFile.Text))
            {
                var data = System.IO.File.ReadAllText(txtContactInfoFile.Text).Split('|');
                if (chkPermanent.Checked)
                {
                    txtBrgy.Text = data[7];
                    txtCity.Text = data[10];
                }
                else
                {
                    txtBrgy.Text = data[19];
                    txtCity.Text = data[22];
                }
            }
        }

        private void btnPerGetValues_Click(object sender, EventArgs e)
        {
            try
            {
                ResetVariables(1);

                txtPerBrgy.Text = grid.CurrentRow.Cells["psgc_barangay_code"].Value.ToString();
                permBrgyDesc = grid.CurrentRow.Cells["psgc_barangay_desc"].Value.ToString();

                txtPerCity.Text = grid.CurrentRow.Cells["psgc_city_mun_code"].Value.ToString();
                permCityDesc = grid.CurrentRow.Cells["psgc_city_mun_desc"].Value.ToString();

                txtPerProvince.Text = grid.CurrentRow.Cells["psgc_province_code"].Value.ToString();
                permProvDesc = grid.CurrentRow.Cells["psgc_province_desc"].Value.ToString();

                txtPerRegion.Text = grid.CurrentRow.Cells["psgc_region_code"].Value.ToString();
                txtPerRegionDesc.Text = grid.CurrentRow.Cells["psgc_region_desc"].Value.ToString();                

                permZipCode = grid.CurrentRow.Cells["ZIP_CODE"].Value.ToString();

                txtPreBrgy.Text = grid.CurrentRow.Cells["psgc_barangay_code"].Value.ToString();
                presBrgyDesc = grid.CurrentRow.Cells["psgc_barangay_desc"].Value.ToString();

                txtPreCity.Text = grid.CurrentRow.Cells["psgc_city_mun_code"].Value.ToString();
                presCityDesc = grid.CurrentRow.Cells["psgc_city_mun_desc"].Value.ToString();

                txtPreProvince.Text = grid.CurrentRow.Cells["psgc_province_code"].Value.ToString();
                presProvDesc = grid.CurrentRow.Cells["psgc_province_desc"].Value.ToString();

                txtPreRegion.Text = grid.CurrentRow.Cells["psgc_region_code"].Value.ToString();
                txtPreRegionDesc.Text = grid.CurrentRow.Cells["psgc_region_desc"].Value.ToString();

                presZipCode = grid.CurrentRow.Cells["ZIP_CODE"].Value.ToString();
            }
            catch { }
            
        }

        private void btnPreGetValues_Click(object sender, EventArgs e)
        {
            try
            {
                ResetVariables(2);

                txtPreBrgy.Text = grid.CurrentRow.Cells["psgc_barangay_code"].Value.ToString();
                presBrgyDesc = grid.CurrentRow.Cells["psgc_barangay_desc"].Value.ToString();

                txtPreCity.Text = grid.CurrentRow.Cells["psgc_city_mun_code"].Value.ToString();
                presCityDesc = grid.CurrentRow.Cells["psgc_city_mun_desc"].Value.ToString();

                txtPreProvince.Text = grid.CurrentRow.Cells["psgc_province_code"].Value.ToString();
                presProvDesc = grid.CurrentRow.Cells["psgc_province_desc"].Value.ToString();

                txtPreRegion.Text = grid.CurrentRow.Cells["psgc_region_code"].Value.ToString();
                txtPreRegionDesc.Text = grid.CurrentRow.Cells["psgc_region_desc"].Value.ToString();

                presZipCode = grid.CurrentRow.Cells["ZIP_CODE"].Value.ToString();
            }
            catch { }
        }

        private void btnSearchCity_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtContactInfoFile.Text)) return;
            else if (txtBrgy.Text == "" && txtCity.Text == "") return;
            BindCodesAndDesc(false);
        }

        private void chkPermanent_CheckedChanged(object sender, EventArgs e)
        {
            BindBrgyAndCity();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string appDir = txtOutput.Text;
            permBrgyCode = txtPerBrgy.Text;
            permCityCode = txtPerCity.Text;
            permProvCode = txtPerProvince.Text;
            permRegionCode = txtPerRegion.Text;
            permRegionDesc = txtPerRegionDesc.Text;

            presBrgyCode = txtPerBrgy.Text;
            presCityCode = txtPerCity.Text;
            presProvCode = txtPerProvince.Text;
            presRegionCode = txtPerRegion.Text;
            presRegionDesc = txtPerRegionDesc.Text;

            Lab.GenerateMemberContactInformationLocalDb_Update(appDir, txtContactInfoFile.Text,
                                                        permBrgyCode, permCityCode, permProvCode, permRegionCode,
                                                        permBrgyDesc, permCityDesc, permProvDesc, permRegionDesc,
                                                        presBrgyCode, presCityCode, presProvCode, presRegionCode,
                                                        presBrgyDesc, presCityDesc, presProvDesc, presRegionDesc,
                                                        permZipCode,presZipCode);

            Utilities.ShowInfoMessageBox("Done!");
        }
    }
}

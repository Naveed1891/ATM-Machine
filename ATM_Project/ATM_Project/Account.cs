using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WinDAL;
using System.Configuration;

namespace ATM_Project
{
    public partial class Account : Form
    {
        private void Account_Load(object sender, EventArgs e)
        {
            FillEducationLisBox();
        }
        private DBAccess dBAccess;
        public Account()
        {
            InitializeComponent();
            dBAccess = DBAccess.GetInstance;
        }


        private void btnSubmitAccount_Click(object sender, EventArgs e)
        {

            int bal = 0;
            if (txtAccLName.Text == "" || txtAccName.Text == "" || txtAccLName.Text == "" || txtAccPhone.Text == "" || txtAccAddress.Text == "" || txtAccOccupation.Text == "" || txtAccPin.Text == "")
            {
                MessageBox.Show("Missing Information!!");
            }
            else
            {
                try
                {
                    bool valid = ValidateAccountData();
                    if (valid)
                    {
                        persistUserAccount();
                    }
                    Login log = new Login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void persistUserAccount()
        {
            string CNIC = txtCNIC.Text;
            string Account = txtAccNum.Text;
            string Name = txtAccName.Text;
            string LastName = txtAccLName.Text;
            string Address = txtAccAddress.Text;
            string Phone = txtAccPhone.Text;
            string PIN = txtAccPin.Text;
            string Education = cbAccEducation.Text;
            string Occupation = txtAccOccupation.Text;
            string DOB = dobdate.Text;
            DOB = "1968-01-01";
            string UserID = lblU_ID.Text;
            string EducationID = cbAccEducation.SelectedValue.ToString();

            try
            {
                SqlCommand cmd = new SqlCommand("persistUserAccount");
                cmd.Parameters.Add("@pUserID", SqlDbType.Int).Value = int.Parse(UserID);
                cmd.Parameters.Add("@pU_CNIC", SqlDbType.VarChar, 15).Value = CNIC;
                cmd.Parameters.Add("@pACT_NO", SqlDbType.VarChar, 10).Value = Account;
                cmd.Parameters.Add("@pU_FName", SqlDbType.VarChar, 50).Value = Name;
                cmd.Parameters.Add("@pU_LName", SqlDbType.VarChar, 50).Value = LastName;
                cmd.Parameters.Add("@pU_Address", SqlDbType.VarChar, 255).Value = Address;
                cmd.Parameters.Add("@pU_Phone", SqlDbType.VarChar, 15).Value = Phone;
                cmd.Parameters.Add("@pACT_PIN", SqlDbType.VarChar, 10).Value = PIN;
                cmd.Parameters.Add("@pU_Occupation", SqlDbType.VarChar, 50).Value = Occupation;
                cmd.Parameters.Add("@pU_DOB", SqlDbType.Date).Value = DOB;
                cmd.Parameters.Add("@pEducationID", SqlDbType.Int).Value = int.Parse(EducationID);
                cmd.Parameters.Add("@pUserIdOp", SqlDbType.Int);
                cmd.Parameters["@pUserIdOp"].Direction = ParameterDirection.Output;

                int i = dBAccess.ExecuteNonQuery(ref cmd);

                UserID = cmd.Parameters["@pUserIdOp"].Value.ToString();

            }
            catch (SqlException SqlEx)
            {

                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private bool ValidateAccountData()
        {
            bool ans = true;

            return ans;
        }

        private void lblLogoutAccount_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void lblEndLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void FillEducationLisBox()
        {
            cbAccEducation.Items.Clear();


            try
            {
                SqlCommand cmd = new SqlCommand("luEducation");

                DataTable dt = dBAccess.ExecuteDatatable(cmd);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cbAccEducation.DataSource = dt;
                    cbAccEducation.DisplayMember = "EducationDesc";
                    cbAccEducation.ValueMember = "EducationID";

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDAL;
using System.Configuration;
using System.Data.SqlClient;

namespace ATM_Project
{
    public partial class ChangePIN : Form
    {
        private DBAccess dBAccess;
        public ChangePIN()
        {
            InitializeComponent();
            dBAccess = DBAccess.GetInstance;
        }

        private void lblLogoutAccount_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void lblEndLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void ChangePIN_Load(object sender, EventArgs e)
        {
            lblAccNumCP.Text = "Account Number: " + Login.AccNumber;
        }



        public static string AccChangePin;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("ValidateOldPin");
            cmd.Parameters.Add("@pPIN", SqlDbType.VarChar, 15).Value = textBox3.Text;
            try
            {

                dt = dBAccess.ExecuteDatatable(cmd);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    AccChangePin = textBox3.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Old Pin Code!!");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            string c = textBox1.Text;
            string v = textBox2.Text;
            if (c == v)
            {
              //  private void persistUserAccount()
                {
                    string newPin = textBox1.Text;
                 //   SqlCommand cmd = new SqlCommand("persistUserAccount");
                    cmd.Parameters.Add("@pACT_PIN", SqlDbType.VarChar, 10).Value = newPin;

                }

            }
            else
            {
                MessageBox.Show("New Password not same!!");
            }
        }
    } 
}
    

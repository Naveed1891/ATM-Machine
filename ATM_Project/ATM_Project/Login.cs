using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinDAL;
namespace ATM_Project
{
    public partial class Login : Form
    {
        private DBAccess dBAccess;
        public Login()
        {
            InitializeComponent();
            dBAccess = DBAccess.GetInstance;
        }
        private void lblSignup_Click(object sender, EventArgs e)
        {
            Account acc = new Account();
            acc.Show();
            this.Hide();
        }
        public static string AccNumber;
        private void btnLogin_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand("ValidateUserAccount");
            cmd.Parameters.Add("@pAccount", SqlDbType.VarChar, 10).Value = txtAccNums.Text;
            cmd.Parameters.Add("@pPIN", SqlDbType.VarChar, 15).Value = txtAccPins.Text;
            try
            {

                dt = dBAccess.ExecuteDatatable(cmd);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    AccNumber = txtAccNums.Text;
                }
                else
                {
                    MessageBox.Show("Invalid Account Number or Pin Code!!");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            Home home = new Home();
            home.Show();
            this.Hide();



}

private void lblEndLogin_Click(object sender, EventArgs e)
{
    this.Close();
}


private void lblEndLogin_MouseHover(object sender, EventArgs e)
{
    lblEndLogin.BackColor = Color.Red;

}

private void lblEndLogin_MouseLeave(object sender, EventArgs e)
{
    lblEndLogin.BackColor = Color.Green;
}

private void Login_Load(object sender, EventArgs e)
{

}
    }
}

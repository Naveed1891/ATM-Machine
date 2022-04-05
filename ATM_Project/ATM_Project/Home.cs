using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

      
        private void lblLogoutHome_Click(object sender, EventArgs e)
        {
            Login log=new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Balance bal=new Balance();
            bal.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePIN cp=new ChangePIN();
            cp.Show();
            this.Hide();
        }

        private void btnFastCash_Click(object sender, EventArgs e)
        {
            FastCash fs =new FastCash();
            fs.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MiniStatement ms =new MiniStatement();
            ms.Show();
            this.Hide();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            Withdraw wd =new Withdraw();
            wd.Show();
            this.Hide();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            Deposit deposit = new Deposit();
            deposit.Show();
            this.Hide();
        }

        private void lblEndHome_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            lblAccNumber.Text = "Account Number: " + Login.AccNumber;
        }
    }
}

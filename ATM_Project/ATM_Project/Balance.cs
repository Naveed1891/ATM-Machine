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
    public partial class Balance : Form
    {
        public Balance()
        {
            InitializeComponent();
        }

        private void lblEndLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblLogoutAccount_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void Balance_Load(object sender, EventArgs e)
        {
            lblAccountNum.Text = Login.AccNumber;
        }
    }
}

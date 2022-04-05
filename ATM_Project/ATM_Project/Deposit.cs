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
    public partial class Deposit : Form
    {
        public Deposit()
        {
            InitializeComponent();
        }

        private void lblLogoutAccount_Click(object sender, EventArgs e)
        {
            Home home=new Home();
            home.Show();
            this.Close();
        }

        private void lblEndLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

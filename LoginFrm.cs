using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HuyangReservation
{
    public partial class frmLogin : Form
    {
        private readonly string cookieString;

        public frmLogin()
        {
            InitializeComponent();

            IList<string> _cookie = HttpManager.GetCoockie();
            cookieString = _cookie[0] + "," + _cookie[1].Replace("Path=/", "") + _cookie[2];
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HttpManager.Login(textBox1.Text, textBox2.Text, cookieString);

            string _cookie = HttpManager.GetMain(cookieString);
            //new ReservationFrm(cookieString).Show();
        }
    }
}
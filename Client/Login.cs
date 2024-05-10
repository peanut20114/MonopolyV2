using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Client
{
    public partial class Login : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "RupkJmOpqVD7u65mZo31WEtDRqKWpkN2Oj6UtbNT",
            BasePath = "https://monopoly-8058b-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        public Login()
        {
            client = new FireSharp.FirebaseClient(config);
            InitializeComponent();
            
        }

        private async void continueBtn_Click(object sender, EventArgs e)
        {
            FirebaseResponse res = await client.GetAsync("USER/");
            dynamic IDs = res.ResultAs<dynamic>();
            bool LoginFlag = false;

            foreach (var id in IDs)
            {
                string userID = id.Name;
                FirebaseResponse userRes = await client.GetAsync("USER/" + userID);
                User userdata = userRes.ResultAs<User>();
                string userName = userdata.username;
                string userEmail = userdata.email;
                string userPassword = userdata.password;

                if ((userName == AccountInput.Text || userEmail == AccountInput.Text) && userPassword == PasswordInput.Text)
                {
                    LoginFlag = true;
                    Program.UserID = userID;
                    break;
                }
            }
            if (LoginFlag)
            {
                HomePage menu = new HomePage();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi đăng nhập", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordInput_TextChanged(object sender, EventArgs e)
        {
            PasswordInput.UseSystemPasswordChar = true;
            PasswordInput.PasswordChar = '●';
        }

        private void ForgotLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotPassword form = new ForgotPassword();
            form.Show();
        }
    }
}

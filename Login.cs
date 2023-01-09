using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_Syatem
{
    public partial class Login : Form
    {
        public int logAttempt = 0;
        public Login()
        {
            InitializeComponent();
            Init_Data();
        }

        private void checkBoxShow_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShow.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';

            }
        }
        public void Reset()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }
        private void Init_Data()
        {
            if (Properties.Settings.Default.UserName != string.Empty)
            {
                if (Properties.Settings.Default.remme == "yes")
                {
                    txtUsername.Text = Properties.Settings.Default.UserName;
                    txtPassword.Text = Properties.Settings.Default.Password;
                    checkBoxRemember.Checked = true;
                }
                else
                {
                    txtUsername.Text = Properties.Settings.Default.UserName;


                }
            }
        }
        private void Save_Data()
        {
            if (checkBoxRemember.Checked)
            {

                Properties.Settings.Default.UserName = txtUsername.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.remme = "yes";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.UserName = txtUsername.Text;
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.remme = "no";
                Properties.Settings.Default.Save();
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * FROM mst_user Where user_name = '" + txtUsername.Text + " ' and password = '" + txtPassword.Text + " '");
            if (ds == null ||
                ds.Tables.Count <= 0 ||
                ds.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Reset();

                //txtUserName.Text = "";
                //txtPassword.Text = "";
                txtUsername.Focus();
                logAttempt += 1;
                if (logAttempt == 3)
                {
                    MessageBox.Show("You have exceeded the maximum number of login attempts", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtUsername.Enabled = false;
                    txtPassword.Enabled = false;
                    btnSignIn.Enabled = false;
                }


            }
            else
            {
                Save_Data();
                this.Hide();
                GeneralFunction.mdiForm = new Dashboard();
                GeneralFunction.mdiForm.Show();


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm frm = new SignUpForm();
            frm.Show();
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            VerifyForm frm = new VerifyForm();
            frm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
    }


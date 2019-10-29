using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBadBolts_Assign4
{
    public partial class Form2 : Form
    {
        public User loggedInUser { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(userNameTextBox.TextLength == 0)
            {
                MessageBox.Show("Please enter a user name");
                return;
            }
            if(passwordTextBox.TextLength == 0)
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            User loginAttemptUser = null;
            bool foundName = false;
            foreach(User user in Reddit.myUsers)
            {
                if (user.Name == userNameTextBox.Text)
                {
                    foundName = true;
                    loginAttemptUser = user;
                    break;
                }
            }

            if (foundName == false)
            {
                MessageBox.Show("The user name you have enterd does not exist");
                return;
            }

            string hashCode = loginAttemptUser.PasswordHash.ToString(); //the hashpassword from the user.txt file
            string inputPassword = passwordTextBox.Text.GetHashCode().ToString("X"); //the hash password that the user inputs

            if (hashCode == inputPassword)
            {
                MessageBox.Show("YAYAYAY");
                this.loggedInUser = loginAttemptUser;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            if (hashCode != inputPassword)
            {
                MessageBox.Show("The password does not match the user name. Try again.");
                return;
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

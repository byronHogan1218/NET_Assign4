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
        public User loggedInUser { get; set; } //used to send data back to the original form
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        /**
         * This function is used to handle when the login button is clicked.
         * It checks to make sure input is valid with feedback if it is not valid
         * And ultimately logs in the correct user
         */
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(userNameTextBox.TextLength == 0)//Makes sure a user name is entered in the box
            {
                MessageBox.Show("Please enter a user name");
                return;
            }
            if(passwordTextBox.TextLength == 0) //makes sure a passsword is entered in the box
            {
                MessageBox.Show("Please enter a password");
                return;
            }

            User loginAttemptUser = null;
            bool foundName = false;

            foreach(User user in Reddit.myUsers) //run through all the users and check to see if the one entered exists
            {
                if (user.Name == userNameTextBox.Text)//found the entered user
                {
                    foundName = true;
                    loginAttemptUser = user;
                    break;
                }
            }

            if (foundName == false) //if we did not find the user, stop the search
            {
                MessageBox.Show("The user name you have enterd does not exist");
                return;
            }

            string hashCode = loginAttemptUser.PasswordHash.ToString(); //the hashpassword from the user.txt file
            string inputPassword = passwordTextBox.Text.GetHashCode().ToString("X"); //the hash password that the user inputs

            //check to see if the pasword matches the found user
            if (hashCode == inputPassword) //the password is correct
            {
                this.loggedInUser = loginAttemptUser; //set the loggedInUser as the one found
                this.DialogResult = DialogResult.OK; //tell the original form we are good
                this.Close(); 
            }

            if (hashCode != inputPassword) //The password does not match what is stored on file
            {
                MessageBox.Show("The password does not match the user name. Try again.");
                return;
            }

        }

        /**
         * This function handles the cancel button
         * It simply closes the form without saving anything
         */
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

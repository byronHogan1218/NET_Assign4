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
    public partial class Reddit : Form
    {
        static public SortedSet<Post> myPosts = new SortedSet<Post>();
        static public SortedSet<Comment> myComments = new SortedSet<Comment>();
        static public SortedSet<Subreddit> mySubReddits = new SortedSet<Subreddit>();
        static public SortedSet<User> myUsers = new SortedSet<User>();
        static public User currentUser = null;

        public Reddit()
        {
            InitializeComponent();
            HelperFunctions.getFileInput();
            LoadPosts("all");
            PopulateSubComboBox();
            SubbredditComboBox.SelectedIndex = 0;
        }

        private void PopulateSubComboBox()
        {
            SubbredditComboBox.Items.Add("All Subbreddits");
            foreach(Subreddit subreddit in mySubReddits)
            {
                if(subreddit.Name != "all")
                  SubbredditComboBox.Items.Add(subreddit.Name);
            }
        }

        private void LoadPosts(string subredditName)
        {
            if(subredditName == "all") // load all the posts
            {
                foreach (Post p in myPosts)
                {
                    RichTextBox rtb = new RichTextBox();

                    int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                    rtb.Location = new System.Drawing.Point(10, 70 * count);
                    rtb.Size = new Size(935, 50);
                    rtb.Name = "txt_" + (count + 1);

                    rtb.Text = p.ToString();

                    mainPanel.Controls.Add(rtb);


                }
            }
            else //load selected subreddits posts
            {

            }
        }

        private void Reddit_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            Button login = sender as Button;

            if (login.Text == "Login") //this is to login
            {
                Form2 f = new Form2();
                var result = f.ShowDialog();
                if (result == DialogResult.Cancel)//we did not log in
                {
                    //do nothing
                    return;
                }
                if (result == DialogResult.OK) //We succesfully logged in
                {
                    currentUser = f.loggedInUser; //Get the user from the login form
                    login.AutoSize = true;
                    login.Text = "Logout from " + currentUser.Name;

                }
     
            }
            else //This is to log out
            {
                ////Reset everything to a logged out state
                loginBtn.Text = "Login";
                currentUser = null;
            }
        }
    }
}

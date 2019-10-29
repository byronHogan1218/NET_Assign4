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
            foreach (Post p in myPosts)
            {
                Label label = new Label();
                label.BorderStyle = BorderStyle.FixedSingle;
                int count = mainPanel.Controls.OfType<Label>().ToList().Count;
                label.Location = new System.Drawing.Point(10, 70 * count);
                label.AutoSize = true;
                label.Name = "txt_" + (count + 1);
                string postText = p.ToString();
                int newlineSpot = 0;
                bool skip =true;
                for (int i = 0; i < postText.Length; ++i)
                {
                    if (i % 100 == 0)
                    {
                        if (!skip)
                        {
                            try
                            {
                                while (postText[i + newlineSpot] != ' ' && i + newlineSpot < postText.Length - 1)
                                {
                                    newlineSpot++;
                                    if (i + newlineSpot > postText.Length - 3)
                                    {
                                        newlineSpot = 0;
                                        break;
                                    }
                                }
                            }
                            catch (IndexOutOfRangeException ex)
                            {

                            }
                            if ((i + newlineSpot) > postText.Length - 1)
                                newlineSpot = 0;
                            i += newlineSpot;
                            StringBuilder sb = new StringBuilder(postText);
                            sb[i] = '\n';
                            postText = sb.ToString();
                        }
                        else
                        {
                            skip = !skip;
                        }
                    }
                }
                label.Text = postText;
               // string line = "---------------------------------------------------";
               // label.Text += "\n" + "\n" + line + "\n";
                mainPanel.Controls.Add(label);

                //Label newLabel = new Label();
                //newLabel.Text = p.ToString();
                //newLabel.Parent = mainPanel;
                //mainPanel.Controls.Add(newLabel);
                //mainPanel.Container.Add(p);
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
                loginBtn.Text = "Login";
                currentUser = null;
                ////Reset everything to a logged out state
                //systemOutListBox.Items.Add("Goodbye " + userListBox.SelectedItem);
                //currentUserID = null;
                //superuser = false;
                //moderator = false;
                //lockPostBtn.Visible = false;
                //userListBox.Enabled = true;
                //login.Text = "Login";
                //postListBox.Items.Clear();
                //commentListBox.Items.Clear();
                //addReplyBtn.Enabled = false;
                //addReplyTextBox.Text = "";
                //addReplyTextBox.Enabled = false;
                //ToggleSubLabels(false);
                //subredditListBox.ClearSelected();
                //deleteCommentBtn.Enabled = false;
                //deletePostBtn.Enabled = false;
            }
        }
    }
}

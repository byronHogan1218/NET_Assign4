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
                if (result == DialogResult.OK)
                {
                    User currentUser = f.loggedInUser;            //values preserved after close
                    //Do something here with these values

                }
                //foreach (User user in myUsers)
                //{
                //    //Get rid of any extra info in the name
                //    string curUser = (string)userListBox.SelectedItem;
                //    curUser = curUser.Split(' ')[0];
                //    if ((string)userListBox.SelectedItem == user.Name || curUser == user.Name)//found the user we are trying to log in as
                //    {
                //        //converts the selected user name to a string
                //        string selectedName = userListBox.SelectedItem.ToString();
                //        selectedName = selectedName.Split(' ')[0];

                //        bool loginSuccess = false; //used to prompt password is correct or not

                //        string hashCode = user.PasswordHash.ToString(); //the hashpassword from the user.txt file
                //        string inputPassword = passwordTextBox.Text.GetHashCode().ToString("X"); //the hash password that the user inputs

                //        if (hashCode == inputPassword)
                //        {
                //            loginSuccess = true;
                //        }

                //        if (hashCode != inputPassword)
                //        {
                //            loginSuccess = false;
                //        }

                //        if (loginSuccess) //if the password was correct, log in
                //        {
                //            if (user.Type == 2)//Super user, must implement enumeration on this
                //            {
                //                superuser = true;
                //            }
                //            if (user.Type == 1)//Moderator, must implement enumeration on this
                //            {
                //                moderator = true;
                //            }

                //            currentUserID = user.Id;
                //            //Load the things written by the logged in user
                //            postListBox.Items.Clear();
                //            commentListBox.Items.Clear();
                //            foreach (Post userPost in myPosts)
                //            {
                //                if (userPost.PostAuthorId == currentUserID)
                //                {
                //                    postListBox.Items.Add(userPost.ToString());
                //                }

                //            }
                //            if (postListBox.Items.Count == 0)
                //            {
                //                postListBox.Items.Add("There are no posts by this user.");
                //                postListBox.Enabled = false;
                //            }
                //            else
                //            {
                //                postListBox.Enabled = true;
                //            }
                //            foreach (Comment userComment in myComments)
                //            {
                //                if (userComment.CommentAuthorId == currentUserID)
                //                {
                //                    commentListBox.Items.Add(userComment.ToString());
                //                }
                //            }
                //            if (commentListBox.Items.Count == 0)
                //            {
                //                commentListBox.Items.Add("There are no comments by this user.");
                //                commentListBox.Enabled = false;
                //            }
                //            else
                //            {
                //                commentListBox.Enabled = true;
                //            }
                //            //Done loading things written by the user

                //            systemOutListBox.Items.Add("We are logged in as user: " + userListBox.SelectedItem);
                //            systemOutListBox.Items.Add("Getting all posts and comments by " + userListBox.SelectedItem);
                //            login.Text = "Logout";
                //            userListBox.Enabled = false;
                //        }

                //        if (!loginSuccess) //login not a success, prompt to try again
                //        {
                //            systemOutListBox.Items.Add("The password is not right, please try again.");
                //            userListBox.Enabled = true;
                //        }

                //        passwordTextBox.Text = String.Empty; //clears the password textbox
                //        break;
                //    }
                //}
            }
            else //This is to log out
            {
                loginBtn.Text = "Login";
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
        //test
    }
}

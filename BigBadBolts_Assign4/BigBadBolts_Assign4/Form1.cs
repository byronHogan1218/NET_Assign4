using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            SubbredditComboBox.Items.Add("Home");
            foreach(Subreddit subreddit in mySubReddits)
            {
                if(subreddit.Name != "all")
                  SubbredditComboBox.Items.Add(subreddit.Name);
            }
        }

        private void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }

        private string TimeFrameAgo(DateTime obj)
        {
            //            Less than an hour old from NOW, in which we're measuring minutes since posting
            //              Less than a day from NOW, in which we're measuring hours since posting
            //              Less than a month from NOW, in which we're measuring days since posting
            //              Less than a year from NOW, in which we're measuring months since posting
            //              More than a year from NOW, in which we're measuring years since posting

            int daysSincePost = 0;
            if (DateTime.Now.Month + 1 == obj.Month || DateTime.Now.Month == 12 && obj.Month == 1)
                daysSincePost = DateTime.Now.Day + 30 - obj.Day;
            else
                daysSincePost = DateTime.Now.Day - obj.Day;
            if (DateTime.Now.Hour - obj.Hour < 1)//posted less than an hour ago
            {
                return (DateTime.Now.Minute - obj.Minute).ToString();
            }
            else if (DateTime.Now.Hour - obj.Hour < 24)//posted less than a day ago
            {
                return (DateTime.Now.Hour - obj.Hour).ToString();
            }
            else if (daysSincePost < 30)//posted less than a month
            {
                return (DateTime.Now.Minute - obj.Minute).ToString();
            }

            return "";
        }

        private void LoadPosts(string subredditName)
        {
            ClearPanel();
            if(subredditName == "all") // load all the posts
            {
                foreach (Post p in myPosts)
                {
                    PictureBox upVote = new PictureBox();
                    PictureBox downVote = new PictureBox();
                    Label scoreLabel = new Label();
                    RichTextBox rtb = new RichTextBox();

                    bool upGrey = false;
                    bool downGrey = false;

                    int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;

                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                    upVote.Width = 23;
                    upVote.Height = 23;
                    mainPanel.Controls.Add(upVote);
                    upGrey = true;

                    scoreLabel.Text = p.Score.ToString();
                    scoreLabel.Location = new System.Drawing.Point(2, (70 * count) + 25);
                    scoreLabel.AutoSize = true;
                    mainPanel.Controls.Add(scoreLabel);

                    int origScore = Convert.ToInt32(scoreLabel.Text);

                    upVote.MouseDown += upVote_MouseDown;

                    void upVote_MouseDown(object sender, MouseEventArgs e)
                    {
                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                        {
                            if (upGrey)
                            {
                                upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = origScore;
                                score++;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = false;
                                downGrey = true;
                            }

                            else if (!downGrey)
                            {
                                upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score += 2;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = false;
                                downGrey = true;
                            }

                            else //!upGrey
                            {
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score--;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = true;
                                downGrey = true;
                            }
                        }
                    }

                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                    downVote.Width = 23;
                    downVote.Height = 23;
                    mainPanel.Controls.Add(downVote);
                    downGrey = true;

                    downVote.MouseDown += downVote_MouseDown;

                    void downVote_MouseDown(object sender, MouseEventArgs e)
                    {
                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                        {
                            if (downGrey)
                            {
                                downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = origScore;
                                score--;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = false;
                            }

                            else if (!upGrey)
                            {
                                downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score -= 2;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = false;
                            }

                            else
                            {
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score++;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, 70 * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = true;
                            }
                        }
                    }

                    rtb.Location = new System.Drawing.Point(50, 70 * count);
                    rtb.Size = new Size(920, 60);
                    rtb.Name = "txt_" + (count + 1);

                    //r / SUBREDDIT_HOME | Posted by u/ AUTHOR_NAME TIME_FRAME ago
                    rtb.Text = "r/";
                    foreach(Subreddit sub in mySubReddits)
                    {
                        if(p.SubHome == sub.Id)
                        {
                            rtb.Text += sub.Name;
                            break;
                        }
                    }
                    rtb.Text += " | Posted by u/";
                    foreach (User user in myUsers)
                    {
                        if (p.PostAuthorId == user.Id)
                        {
                            rtb.Text += user.Name;
                            break;
                        }
                    }
                    rtb.Text += " " + TimeFrameAgo(p.TimeStamp) + " ago\n";

                    rtb.Text = p.PostContent;

                    mainPanel.Controls.Add(rtb);


                }
            }
            else //load selected subreddits posts
            {
                Subreddit selectedSub = null;
                foreach(Subreddit sub in mySubReddits) //search for slected subreddit
                {
                    if(sub.Name == subredditName)//found the subreddit
                    {
                        selectedSub = sub;
                        break;
                    }
                }

                bool empty = true;
                foreach (Post p in myPosts)
                {
                    if (p.SubHome == selectedSub.Id)
                    {
                        if(empty == true)
                        {
                            empty = false;
                        }
                        RichTextBox rtb = new RichTextBox();

                        int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                        rtb.Location = new System.Drawing.Point(10, 70 * count);
                        rtb.Size = new Size(935, 50);
                        rtb.Name = "txt_" + (count + 1);

                        rtb.Text = p.ToString();

                        mainPanel.Controls.Add(rtb);

                    }
                }
                if(empty == true)
                {
                    RichTextBox rtb = new RichTextBox();

                    int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                    rtb.Location = new System.Drawing.Point(10, 70 * count);
                    rtb.Size = new Size(935, 50);
                    rtb.Name = "txt_" + (count + 1);

                    rtb.Text = "There are no posts to load.";

                    mainPanel.Controls.Add(rtb);
                }
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

        private void SubbredditComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(SubbredditComboBox.SelectedIndex == 0)//this is all
            {
                LoadPosts("all");
            }
            else //load the individual subbreddits
            {
                LoadPosts(SubbredditComboBox.SelectedItem.ToString());
            }
        }
        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            if(searchTextBox.Text == "Search")
            {
                searchTextBox.Text = "";
                searchTextBox.ForeColor = Color.Black;
            }
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                LoadPostsSearch("all", searchTextBox.Text);
            }
        }

        private void SearchTextBox_Leave(object sender, EventArgs e)
        {
            if(searchTextBox.Text == "")
            {
                searchTextBox.Text = "Search";
                searchTextBox.ForeColor = Color.DimGray;
            }

        }

        private void LoadPostsSearch(string subredditName, string inputText)
        {
            ClearPanel();
           // MessageBox.Show(inputText);

            if (subredditName == "all") // load all the post
            {
                foreach (Post p in myPosts)
                {
                    if (p.ToString().Contains(inputText))
                    {
                        PictureBox upVote = new PictureBox();
                        PictureBox downVote = new PictureBox();
                        Label scoreLabel = new Label();
                        RichTextBox rtb = new RichTextBox();

                        bool upGrey = false;
                        bool downGrey = false;

                        int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;

                        upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                        upVote.Location = new System.Drawing.Point(5, 70 * count);
                        upVote.Width = 23;
                        upVote.Height = 23;
                        mainPanel.Controls.Add(upVote);
                        upGrey = true;

                        scoreLabel.Text = p.Score.ToString();
                        scoreLabel.Location = new System.Drawing.Point(2, (70 * count) + 25);
                        scoreLabel.AutoSize = true;
                        mainPanel.Controls.Add(scoreLabel);

                        int origScore = Convert.ToInt32(scoreLabel.Text);

                        upVote.MouseDown += upVote_MouseDown;

                        void upVote_MouseDown(object sender, MouseEventArgs e)
                        {
                            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                            {
                                if (upGrey)
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = origScore;
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else if (!downGrey)
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score += 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else //!upGrey
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }

                        downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                        downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                        downVote.Width = 23;
                        downVote.Height = 23;
                        mainPanel.Controls.Add(downVote);
                        downGrey = true;

                        downVote.MouseDown += downVote_MouseDown;

                        void downVote_MouseDown(object sender, MouseEventArgs e)
                        {
                            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                            {
                                if (downGrey)
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = origScore;
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else if (!upGrey)
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score -= 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (70 * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, 70 * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }

                        rtb.Location = new System.Drawing.Point(50, 70 * count);
                        rtb.Size = new Size(920, 60);
                        rtb.Name = "txt_" + (count + 1);
                        
                        //r / SUBREDDIT_HOME | Posted by u/ AUTHOR_NAME TIME_FRAME ago
                        rtb.Text = "r/";
                        foreach (Subreddit sub in mySubReddits)
                        {
                            if (p.ToString().Contains(inputText))
                            {
                                if (p.SubHome == sub.Id)
                                {
                                    rtb.Text += sub.Name;
                                    break;
                                }
                            }

                        }

                        rtb.Text += " | Posted by u/";
                        foreach (User user in myUsers)
                        {
                            if (p.ToString().Contains(inputText))
                            {
                                if (p.PostAuthorId == user.Id)
                                {
                                    rtb.Text += user.Name;
                                    break;
                                }
                            }

                        }

                        rtb.Text += " " + TimeFrameAgo(p.TimeStamp) + " ago\n";

                        rtb.Text = p.PostContent;

                        mainPanel.Controls.Add(rtb);

                    }
                }

            }

                else //load selected subreddits posts
                {
                    Subreddit selectedSub = null;
                    foreach (Subreddit sub in mySubReddits) //search for slected subreddit
                    {
                        if (sub.ToString().Contains(inputText))
                        {
                            if (sub.Name == subredditName)//found the subreddit
                            {
                                selectedSub = sub;
                                break;
                            }
                        }
                    }

            bool empty = true;

                foreach (Post p in myPosts)
                {
                    if (p.ToString().Contains(inputText))
                    {
                        if (p.SubHome == selectedSub.Id)
                        {
                            if (empty == true)
                            {
                                empty = false;
                            }

                            RichTextBox rtb = new RichTextBox();

                            int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                            rtb.Location = new System.Drawing.Point(10, 70 * count);
                            rtb.Size = new Size(935, 50);
                            rtb.Name = "txt_" + (count + 1);

                            rtb.Text = p.ToString();

                            mainPanel.Controls.Add(rtb);

                        }
                    }

                }

            }

        }

    }

}

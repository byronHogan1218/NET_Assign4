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

///*******************************************************************
//*                                                                  *
//*  CSCI 473-1/504-1       Assignment 4                Fall   2019  *
//*                                                                  *
//*                                                                  *
//*  Program Name:  Reddit                                           *
//*                                                                  *
//*  Programmer:    Byron Hogan,  z1825194                           *
//*                 Margaret Higginbotham, z1793581                  *
//*                                                                  *
//*******************************************************************/
/*
 * holds the main bulk of the program, posts, subreddits, search, comments, etc
 */
namespace BigBadBolts_Assign4
{
    public partial class Reddit : Form
    {
        static public SortedSet<Post> myPosts = new SortedSet<Post>();
        static public SortedSet<Comment> myComments = new SortedSet<Comment>();
        static public SortedSet<Subreddit> mySubReddits = new SortedSet<Subreddit>();
        static public SortedSet<User> myUsers = new SortedSet<User>();
        static public User currentUser = null;
        static public bool loadComments = false;
        static public bool loadReplies = false;
        static public int POST_HEIGHT = 95;//times by count

        public Reddit()
        {
            InitializeComponent();
            HelperFunctions.getFileInput();
            LoadPosts("all");
            PopulateSubComboBox();
            SubbredditComboBox.SelectedIndex = 0;
        }

        /**
         * This function populates the subbreddit drop box with the ones from the file
         * Note:The first one is hardcoded to be "Home" which is all the subreddits
         */
        private void PopulateSubComboBox()
        {
            SubbredditComboBox.Items.Add("Home");//Hardcode home into the dropdown
            foreach(Subreddit subreddit in mySubReddits)//add all the rest of the subreddits except all
            {
                if(subreddit.Name != "all")
                  SubbredditComboBox.Items.Add(subreddit.Name);
            }
        }

        /**
         * This function is used to clear the panel of all things in it
         */
        private void ClearPanel()
        {
            mainPanel.Controls.Clear();
        }

        /**
         * This function is used to calculate how long ago something was posted
         * It retuns a string of the timeframe it was posted ago
         * it takes a date time parameter to use to determine the date ago
         */
        private string TimeFrameAgo(DateTime obj)
        { 
            int daysSincePost = 0;
            //Calculate how many days have passed
            if (DateTime.Now.Month + 1 == obj.Month || DateTime.Now.Month == 12 && obj.Month == 1)
                daysSincePost = DateTime.Now.Day + 30 - obj.Day;
            else
                daysSincePost = DateTime.Now.Day - obj.Day;


            if (DateTime.Now.Hour - obj.Hour < 1 && daysSincePost== 0)//posted less than an hour ago
            {
                return (DateTime.Now.Minute - obj.Minute).ToString() + " minutes";
            }
            else if (DateTime.Now.Hour - obj.Hour < 24 && daysSincePost == 0)//posted less than a day ago
            {
                return (DateTime.Now.Hour - obj.Hour).ToString() +" hours";
            }
            else if (daysSincePost < 30)//posted less than a month
            {
                return (daysSincePost.ToString() + " days");
            }
            else if (daysSincePost > 30 && daysSincePost < 365)//less than a year ago
            {
                return (DateTime.Now.Month - obj.Month).ToString() + " months";
            }
            else //more than a year
            {
                return (DateTime.Now.Year - obj.Year).ToString() + " years";
            }
        }

        /**
         * This monstrous function is used to load the post for a given subbreddit. 
         * it also checks to see if a user is logged in, if they are, it loads the comments
         * Parmeters: subbredditName is the name of the subbreddit to load the posts from. 
         * Note the name "all" will load all of the posts
         */
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
                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                    upVote.Width = 23;
                    upVote.Height = 23;
                    mainPanel.Controls.Add(upVote);
                    upGrey = true;

                    scoreLabel.Text = p.Score.ToString();
                    scoreLabel.Location = new System.Drawing.Point(2, (POST_HEIGHT * count) + 25);
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
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = origScore;
                                score++;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = false;
                                downGrey = true;
                            }

                            else if (!downGrey)
                            {
                                upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score += 2;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = false;
                                downGrey = true;
                            }

                            else //!upGrey
                            {
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score--;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                upGrey = true;
                                downGrey = true;
                            }
                        }
                    }

                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
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
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = origScore;
                                score--;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = false;
                            }

                            else if (!upGrey)
                            {
                                downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score -= 2;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = false;
                            }

                            else
                            {
                                downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                downVote.Width = 23;
                                downVote.Height = 23;
                                mainPanel.Controls.Add(downVote);
                                int score = Convert.ToInt32(scoreLabel.Text);
                                score++;
                                scoreLabel.Text = score.ToString();
                                mainPanel.Controls.Add(scoreLabel);
                                upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                upVote.Width = 23;
                                upVote.Height = 23;
                                mainPanel.Controls.Add(upVote);
                                upGrey = true;
                                downGrey = true;
                            }
                        }
                    }

                    //the score and up and down arrows have been added


                    rtb.Location = new System.Drawing.Point(50, POST_HEIGHT * count);
                    rtb.Size = new Size(920, 60);
                    rtb.Name = "txt_" + (count + 1);

                    //r / SUBREDDIT_HOME | Posted by u/ AUTHOR_NAME TIME_FRAME ago
                    rtb.Text = "r/";
                    foreach(Subreddit sub in mySubReddits)//Get the name of the subbreddit
                    {
                        if(p.SubHome == sub.Id)//got the sub name
                        {
                            rtb.Text += sub.Name;
                            break;
                        }
                    }
                    rtb.Text += " | Posted by u/";
                    foreach (User user in myUsers)//get the user name
                    {
                        if (p.PostAuthorId == user.Id)//got the user
                        {
                            rtb.Text += user.Name;
                            break;
                        }
                    }
                    rtb.Text += " " + TimeFrameAgo(p.TimeStamp) + " ago\n";

                    rtb.Text += p.PostContent;

                    mainPanel.Controls.Add(rtb);//add the rich text field to the panel

                    ////////////////////////////////////////////////////////////////////////
                    ///

                    //Load REPLIES

                    ///////////////////////////////////////////////////////////////////

                    if (loadReplies) //checks to see if they can be loaded
                    {
                        foreach(Comment reply in myComments)
                        {
                            if (p.PostID == reply.ParentID)
                            {
                                PictureBox replyUpVote = new PictureBox();
                                PictureBox replyDownVote = new PictureBox();
                                PictureBox replyReply = new PictureBox();

                                Label replyScoreLabel = new Label();

                                bool replyUpGrey = false;
                                bool replyDownGrey = false;
                                
                                int replyCount = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                                //the next chunk is for the up and down votes and the score
                                replyUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                replyUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * replyCount);
                                replyUpVote.Width = 23;
                                replyUpVote.Height = 23;
                                mainPanel.Controls.Add(replyUpVote);
                                replyUpGrey = true;

                                replyScoreLabel.Text = reply.Score.ToString();
                                replyScoreLabel.Location = new System.Drawing.Point(12, (POST_HEIGHT * replyCount) + 25);
                                replyScoreLabel.AutoSize = true;
                                mainPanel.Controls.Add(replyScoreLabel);

                                int CommentorigScore = Convert.ToInt32(replyScoreLabel.Text);

                                replyUpVote.MouseDown += ReplyUpVote_MouseDown;
                                //these are the conditions on what the color should be depending on its previous state
                                void ReplyUpVote_MouseDown(object sender, MouseEventArgs e)
                                {
                                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                    {
                                        if (replyUpGrey)
                                        {
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                            replyUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * replyCount);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            int replyScore = CommentorigScore;
                                            replyScore++;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            replyDownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            replyUpGrey = false;
                                            replyDownGrey = true;
                                        }

                                        else if (!replyDownGrey)
                                        {
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                            replyUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * replyCount);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            int replyScore = Convert.ToInt32(replyScoreLabel.Text);
                                            replyScore += 2;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            replyDownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            replyUpGrey = false;
                                            replyDownGrey = true;
                                        }

                                        else //!upGrey
                                        {
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            replyUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * replyCount);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            int replyScore = Convert.ToInt32(replyScoreLabel.Text);
                                            replyScore--;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            replyDownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            replyUpGrey = true;
                                            replyDownGrey = true;
                                        }
                                    }
                                }
                                //down grey arrow
                                replyDownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                replyDownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * replyCount) + 40);
                                replyDownVote.Width = 23;
                                replyDownVote.Height = 23;
                                mainPanel.Controls.Add(replyDownVote);
                                replyDownGrey = true;

                                replyDownVote.MouseDown += ReplyDownVote_MouseDown;
                                
                                void ReplyDownVote_MouseDown(object sender, MouseEventArgs e)
                                {
                                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                    {
                                        if (replyDownGrey)
                                        {
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                            replyDownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            int replyScore = CommentorigScore;
                                            replyScore--;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            replyUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * replyCount);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            replyUpGrey = true;
                                            replyDownGrey = false;
                                        }

                                        else if (!replyUpGrey)
                                        {
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                            replyDownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            int replyScore = Convert.ToInt32(replyScoreLabel.Text);
                                            replyScore -= 2;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            replyUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * count);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            replyUpGrey = true;
                                            replyDownGrey = false;
                                        }

                                        else
                                        {
                                            replyDownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            replyDownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * replyCount) + 40);
                                            replyDownVote.Width = 23;
                                            replyDownVote.Height = 23;
                                            mainPanel.Controls.Add(replyDownVote);
                                            int replyScore = Convert.ToInt32(replyScoreLabel.Text);
                                            replyScore++;
                                            replyScoreLabel.Text = replyScore.ToString();
                                            mainPanel.Controls.Add(replyScoreLabel);
                                            replyUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            replyUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * replyCount);
                                            replyUpVote.Width = 23;
                                            replyUpVote.Height = 23;
                                            mainPanel.Controls.Add(replyUpVote);
                                            replyUpGrey = true;
                                            replyDownGrey = true;
                                        }
                                    }
                                }

                                //Score and arrows are added to the panel

                                RichTextBox Reply_rtb = new RichTextBox();
                                Reply_rtb.Location = new System.Drawing.Point(80, POST_HEIGHT * replyCount);
                                Reply_rtb.Size = new Size(890, 60);
                                Reply_rtb.Name = "comment_txt_" + (replyCount + 1);

                                //AUTHOR_NAME | COMMENT_SCORE TIME_FRAME ago
                                foreach (User user in myUsers)//search users for auhtor
                                {
                                    if (reply.CommentAuthorId == user.Id) //found user
                                    {
                                        Reply_rtb.Text = user.Name;
                                        break;
                                    }
                                }
                                Reply_rtb.Text += " | " + reply.Score.ToString();
                                Reply_rtb.Text += " " + TimeFrameAgo(reply.TimeStamp) + " ago\n";


                                Reply_rtb.Text += reply.Content;

                                mainPanel.Controls.Add(Reply_rtb);
                            }
                        }
                    }

                    ////////////////////////////////////////////////////////////////////////
                    ///

                    //Load COMMENTs

                    ///////////////////////////////////////////////////////////////////
                    if (loadComments)//checks to see if comments should be loaded, will load if user is logged in
                    {
                        foreach (Comment comment in myComments)//go through comments to load them
                        {
                            if (p.PostID == comment.ParentID)//found a comment belong to post 'p'
                            {
                                PictureBox commentUpVote = new PictureBox();
                                PictureBox CommentdownVote = new PictureBox();
                                PictureBox CommentReply = new PictureBox();

                                Label Comment_scoreLabel = new Label();

                                bool CommentupGrey = false;
                                bool CommentdownGrey = false;

                                int Commentcount = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;

                                commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                commentUpVote.Width = 23;
                                commentUpVote.Height = 23;
                                mainPanel.Controls.Add(commentUpVote);
                                CommentupGrey = true;

                                Comment_scoreLabel.Text = comment.Score.ToString();
                                Comment_scoreLabel.Location = new System.Drawing.Point(12, (POST_HEIGHT * Commentcount) + 25);
                                Comment_scoreLabel.AutoSize = true;
                                mainPanel.Controls.Add(Comment_scoreLabel);

                                int CommentorigScore = Convert.ToInt32(Comment_scoreLabel.Text);

                                commentUpVote.MouseDown += commentUpVote_MouseDown;

                                void commentUpVote_MouseDown(object sender, MouseEventArgs e)
                                {
                                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                    {
                                        if (CommentupGrey)
                                        {
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                            commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            int Commentscore = CommentorigScore;
                                            Commentscore++;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            CommentupGrey = false;
                                            CommentdownGrey = true;
                                        }

                                        else if (!CommentdownGrey)
                                        {
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                            commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                            Commentscore += 2;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            CommentupGrey = false;
                                            CommentdownGrey = true;
                                        }

                                        else //!upGrey
                                        {
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                            Commentscore--;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            CommentupGrey = true;
                                            CommentdownGrey = true;
                                        }
                                    }
                                }

                                CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                CommentdownVote.Width = 23;
                                CommentdownVote.Height = 23;
                                mainPanel.Controls.Add(CommentdownVote);
                                CommentdownGrey = true;

                                CommentdownVote.MouseDown += CommentdownVote_MouseDown;

                                void CommentdownVote_MouseDown(object sender, MouseEventArgs e)
                                {
                                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                    {
                                        if (CommentdownGrey)
                                        {
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                            CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            int Commentscore = CommentorigScore;
                                            Commentscore--;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            CommentupGrey = true;
                                            CommentdownGrey = false;
                                        }

                                        else if (!CommentupGrey)
                                        {
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                            CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                            Commentscore -= 2;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * count);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            CommentupGrey = true;
                                            CommentdownGrey = false;
                                        }

                                        else
                                        {
                                            CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                            CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                            CommentdownVote.Width = 23;
                                            CommentdownVote.Height = 23;
                                            mainPanel.Controls.Add(CommentdownVote);
                                            int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                            Commentscore++;
                                            Comment_scoreLabel.Text = Commentscore.ToString();
                                            mainPanel.Controls.Add(Comment_scoreLabel);
                                            commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                            commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                            commentUpVote.Width = 23;
                                            commentUpVote.Height = 23;
                                            mainPanel.Controls.Add(commentUpVote);
                                            CommentupGrey = true;
                                            CommentdownGrey = true;
                                        }
                                    }
                                }

                                //Score and arrows are added to the panel

                                RichTextBox Comment_rtb = new RichTextBox();
                                Comment_rtb.Location = new System.Drawing.Point(80, POST_HEIGHT * Commentcount);
                                Comment_rtb.Size = new Size(890, 60);
                                Comment_rtb.Name = "comment_txt_" + (Commentcount + 1);

                                //AUTHOR_NAME | COMMENT_SCORE TIME_FRAME ago
                                foreach (User user in myUsers)//search users for auhtor
                                {
                                    if (comment.CommentAuthorId == user.Id) //found user
                                    {
                                        Comment_rtb.Text = user.Name;
                                        break;
                                    }
                                }
                                Comment_rtb.Text += " | " + comment.Score.ToString();
                                Comment_rtb.Text += " " + TimeFrameAgo(comment.TimeStamp) + " ago\n";


                                Comment_rtb.Text += comment.Content;

                                mainPanel.Controls.Add(Comment_rtb);

                                //add reply button thing
                                CommentReply.Image = Image.FromFile("../../reply_icon.png");
                                CommentReply.Location = new System.Drawing.Point(80, (POST_HEIGHT * Commentcount)+64);
                                CommentReply.Width = 67;
                                CommentReply.Height = 26;

                                mainPanel.Controls.Add(CommentReply);
                            }//end if comment bleongs to parent
                        }//end comment foreach loop
                    }//end load comments

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
                foreach (Post p in myPosts)//go through posts to ouput them
                {
                    if (p.SubHome == selectedSub.Id)//found a post belonging to this subbreddit
                    {
                        if(empty == true)//we found one entry so its not empty
                        {
                            empty = false;
                        }

                        PictureBox upVote = new PictureBox();
                        PictureBox downVote = new PictureBox();
                        Label scoreLabel = new Label();
                        RichTextBox rtb = new RichTextBox();

                        bool upGrey = false;
                        bool downGrey = false;

                        int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;

                        upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                        upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                        upVote.Width = 23;
                        upVote.Height = 23;
                        mainPanel.Controls.Add(upVote);
                        upGrey = true;

                        scoreLabel.Text = p.Score.ToString();
                        scoreLabel.Location = new System.Drawing.Point(2, (POST_HEIGHT * count) + 25);
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
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = origScore;
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else if (!downGrey)
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score += 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else //!upGrey
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }

                        downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                        downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
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
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = origScore;
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else if (!upGrey)
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score -= 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }
                        //Score and arrows added

                        rtb.Location = new System.Drawing.Point(50, POST_HEIGHT * count);
                        rtb.Size = new Size(920, 60);
                        rtb.Name = "txt_" + (count + 1);

                        //r / SUBREDDIT_HOME | Posted by u/ AUTHOR_NAME TIME_FRAME ago
                        rtb.Text = "r/";
                        foreach (Subreddit sub in mySubReddits)//search sub for name of sub
                        {
                            if (p.SubHome == sub.Id)//found the name
                            {
                                rtb.Text += sub.Name;
                                break;
                            }
                        }
                        rtb.Text += " | Posted by u/";
                        foreach (User user in myUsers)//search user for author
                        {
                            if (p.PostAuthorId == user.Id)//found author
                            {
                                rtb.Text += user.Name;
                                break;
                            }
                        }
                        rtb.Text += " " + TimeFrameAgo(p.TimeStamp) + " ago\n";

                        rtb.Text += p.PostContent;

                        mainPanel.Controls.Add(rtb);

                        ////////////////////////////////////////////////////////////////////////
                        ///

                        //Load COMMENTs

                        ///////////////////////////////////////////////////////////////////
                        if (loadComments)//only do  this if user is logged in
                        {
                            foreach (Comment comment in myComments)//go through comments
                            {
                                if (p.PostID == comment.ParentID)//only load comment belonging to this post
                                {
                                    PictureBox commentUpVote = new PictureBox();
                                    PictureBox CommentdownVote = new PictureBox();
                                    PictureBox CommentReply = new PictureBox();

                                    Label Comment_scoreLabel = new Label();

                                    bool CommentupGrey = false;
                                    bool CommentdownGrey = false;

                                    int Commentcount = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;

                                    commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                    commentUpVote.Width = 23;
                                    commentUpVote.Height = 23;
                                    mainPanel.Controls.Add(commentUpVote);
                                    CommentupGrey = true;

                                    Comment_scoreLabel.Text = comment.Score.ToString();
                                    Comment_scoreLabel.Location = new System.Drawing.Point(12, (POST_HEIGHT * Commentcount) + 25);
                                    Comment_scoreLabel.AutoSize = true;
                                    mainPanel.Controls.Add(Comment_scoreLabel);

                                    int CommentorigScore = Convert.ToInt32(Comment_scoreLabel.Text);

                                    commentUpVote.MouseDown += commentUpVote_MouseDown;

                                    void commentUpVote_MouseDown(object sender, MouseEventArgs e)
                                    {
                                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                        {
                                            if (CommentupGrey)
                                            {
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                                commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                int Commentscore = CommentorigScore;
                                                Commentscore++;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                                CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                CommentupGrey = false;
                                                CommentdownGrey = true;
                                            }

                                            else if (!CommentdownGrey)
                                            {
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_red.png");
                                                commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                                Commentscore += 2;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                                CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                CommentupGrey = false;
                                                CommentdownGrey = true;
                                            }

                                            else //!upGrey
                                            {
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                                commentUpVote.Location = new System.Drawing.Point(5, POST_HEIGHT * Commentcount);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                                Commentscore--;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                                CommentdownVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                CommentupGrey = true;
                                                CommentdownGrey = true;
                                            }
                                        }
                                    }

                                    CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                    CommentdownVote.Width = 23;
                                    CommentdownVote.Height = 23;
                                    mainPanel.Controls.Add(CommentdownVote);
                                    CommentdownGrey = true;

                                    CommentdownVote.MouseDown += CommentdownVote_MouseDown;

                                    void CommentdownVote_MouseDown(object sender, MouseEventArgs e)
                                    {
                                        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                                        {
                                            if (CommentdownGrey)
                                            {
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                                CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                int Commentscore = CommentorigScore;
                                                Commentscore--;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                                commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                CommentupGrey = true;
                                                CommentdownGrey = false;
                                            }

                                            else if (!CommentupGrey)
                                            {
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                                CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                                Commentscore -= 2;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                                commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * count);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                CommentupGrey = true;
                                                CommentdownGrey = false;
                                            }

                                            else
                                            {
                                                CommentdownVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                                CommentdownVote.Location = new System.Drawing.Point(15, (POST_HEIGHT * Commentcount) + 40);
                                                CommentdownVote.Width = 23;
                                                CommentdownVote.Height = 23;
                                                mainPanel.Controls.Add(CommentdownVote);
                                                int Commentscore = Convert.ToInt32(Comment_scoreLabel.Text);
                                                Commentscore++;
                                                Comment_scoreLabel.Text = Commentscore.ToString();
                                                mainPanel.Controls.Add(Comment_scoreLabel);
                                                commentUpVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                                commentUpVote.Location = new System.Drawing.Point(15, POST_HEIGHT * Commentcount);
                                                commentUpVote.Width = 23;
                                                commentUpVote.Height = 23;
                                                mainPanel.Controls.Add(commentUpVote);
                                                CommentupGrey = true;
                                                CommentdownGrey = true;
                                            }
                                        }
                                    }

                                    RichTextBox Comment_rtb = new RichTextBox();
                                    Comment_rtb.Location = new System.Drawing.Point(80, POST_HEIGHT * Commentcount);
                                    Comment_rtb.Size = new Size(890, 60);
                                    Comment_rtb.Name = "comment_txt_" + (Commentcount + 1);

                                    //AUTHOR_NAME | COMMENT_SCORE TIME_FRAME ago
                                    foreach (User user in myUsers)
                                    {
                                        if (comment.CommentAuthorId == user.Id)
                                        {
                                            Comment_rtb.Text = user.Name;
                                            break;
                                        }
                                    }
                                    Comment_rtb.Text += " | " + comment.Score.ToString();
                                    Comment_rtb.Text += " " + TimeFrameAgo(comment.TimeStamp) + " ago\n";


                                    Comment_rtb.Text += comment.Content;

                                    mainPanel.Controls.Add(Comment_rtb);

                                }//end if comment bleongs to parent
                            }//end comment foreach loop
                        }//end load comments


                    }
                }
                if(empty == true)//did not find a post to display for the subbreddit
                {
                    RichTextBox rtb = new RichTextBox();

                    int count = mainPanel.Controls.OfType<RichTextBox>().ToList().Count;
                    rtb.Location = new System.Drawing.Point(10, POST_HEIGHT * count);
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

        //mouse click event for comment replies
        public void CommentReply_MouseClick(object sender, EventArgs e)
        {
            if (loggedIn)
            {
                mainPanel.Height = 150;
            }
        }

        public Comment comment;
        RichTextBox Reply_rtb = new RichTextBox();
        
        //mouse click events to submit a reply
        public void ReplyButton_MouseClick(object sender, EventArgs e)
        {
            string commentReply = Reply_rtb.Text;
            Comment newReply = new Comment(commentReply, currentUser.Id, comment.CommentID);
            //mainPanel.Controls.Add(newReply, newReply.CommentID, newReply);
            Reply_rtb.Text = "";
            mainPanel.Height = Height;

        }
        
        //mouse click event for cancelling making a reply
        public void CancelReply_MouseClick(object sender, EventArgs e)
        {
            //replyBox.Text = "";
        }

        /**
         * This function handles the log in for a user and will be th elogout button too
         */

        bool loggedIn = false;

        private void LoginBtn_Click(object sender, EventArgs e)
        {

            Button login = sender as Button;

            if (login.Text == "Login") //this is to login
            {
                Form2 f = new Form2();//launch form to handle the log in
                var result = f.ShowDialog();
                if (result == DialogResult.Cancel)//we did not log in
                {
                    loggedIn = false;
                    //do nothing
                    return;
                }
                if (result == DialogResult.OK) //We succesfully logged in
                {
                    loggedIn = true;
                    currentUser = f.loggedInUser; //Get the user from the login form
                    login.AutoSize = true;
                    login.Text = "Logout from " + currentUser.Name;
                    loadComments = true;

                    if (SubbredditComboBox.SelectedIndex == 0)//this is all
                    {
                        LoadPosts("all");
                    }
                    else //load the individual subbreddits
                    {
                        LoadPosts(SubbredditComboBox.SelectedItem.ToString());
                    }

                }
     
            }
            else //This is to log out
            {
                ////Reset everything to a logged out state
                loginBtn.Text = "Login";
                currentUser = null;
                loadComments = false;
                if (SubbredditComboBox.SelectedIndex == 0)//this is all
                {
                    LoadPosts("all");
                }
                else //load the individual subbreddits
                {
                    LoadPosts(SubbredditComboBox.SelectedItem.ToString());
                }
            }
        }


        /**
         * This function is to tell when the selected subbreddit to view changes
         */
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

        private void CommentReplyButton_Click(object sender, EventArgs e)
        {

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
        //this section adds the up down arrows to the search results
        private void LoadPostsSearch(string subredditName, string inputText)
        {
            ClearPanel();
           // MessageBox.Show(inputText);
           ////////////////////////////////////////////////////////////////////////////////
           //NOTE TO PARTNER HERE
           //I changed a lot of code for loading a post. idk if this will continue to work now but it should
           //please update it with the code in the current load posts so it formats the things correctly.
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
                        upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                        upVote.Width = 23;
                        upVote.Height = 23;
                        mainPanel.Controls.Add(upVote);
                        upGrey = true;

                        scoreLabel.Text = p.Score.ToString();
                        scoreLabel.Location = new System.Drawing.Point(2, (POST_HEIGHT * count) + 25);
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
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = origScore;
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else if (!downGrey)
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_red.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score += 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = false;
                                    downGrey = true;
                                }

                                else //!upGrey
                                {
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }

                        downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                        downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
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
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = origScore;
                                    score--;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else if (!upGrey)
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_blue.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score -= 2;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = false;
                                }

                                else
                                {
                                    downVote.Image = Image.FromFile("..//..//downVote_grey.png");
                                    downVote.Location = new System.Drawing.Point(5, (POST_HEIGHT * count) + 40);
                                    downVote.Width = 23;
                                    downVote.Height = 23;
                                    mainPanel.Controls.Add(downVote);
                                    int score = Convert.ToInt32(scoreLabel.Text);
                                    score++;
                                    scoreLabel.Text = score.ToString();
                                    mainPanel.Controls.Add(scoreLabel);
                                    upVote.Image = Image.FromFile("..//..//upVote_grey.png");
                                    upVote.Location = new System.Drawing.Point(5, POST_HEIGHT * count);
                                    upVote.Width = 23;
                                    upVote.Height = 23;
                                    mainPanel.Controls.Add(upVote);
                                    upGrey = true;
                                    downGrey = true;
                                }
                            }
                        }

                        rtb.Location = new System.Drawing.Point(50, POST_HEIGHT * count);
                        rtb.Size = new Size(920, 60);
                        rtb.Name = "txt_" + (count + 1);

                        //r / SUBREDDIT_HOME | Posted by u/ AUTHOR_NAME TIME_FRAME ago
                        rtb.Text = "r/";
                        foreach (Subreddit sub in mySubReddits)//Get the name of the subbreddit
                        {
                            if (p.SubHome == sub.Id)//got the sub name
                            {
                                rtb.Text += sub.Name;
                                break;
                            }
                        }
                        rtb.Text += " | Posted by u/";
                        foreach (User user in myUsers)//get the user name
                        {
                            if (p.PostAuthorId == user.Id)//got the user
                            {
                                rtb.Text += user.Name;
                                break;
                            }
                        }
                        rtb.Text += " " + TimeFrameAgo(p.TimeStamp) + " ago\n";

                        rtb.Text += p.PostContent;

                        mainPanel.Controls.Add(rtb);//add the rich text field to the panel

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
                            rtb.Location = new System.Drawing.Point(10, POST_HEIGHT * count);
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

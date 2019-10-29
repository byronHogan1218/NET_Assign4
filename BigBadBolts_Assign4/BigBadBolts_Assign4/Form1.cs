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
    }
}

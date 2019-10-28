using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

///*******************************************************************
//*                                                                  *
//*  CSCI 473-1/504-1       Assignment 3                Fall   2019  *
//*                                                                  *
//*                                                                  *
//*  Program Name:  Reddit                                           *
//*                                                                  *
//*  Programmer:    Byron Hogan,  z1825194                           *
//*                 Margaret Higginbotham, z1793581                  *
//*                                                                  *
//*******************************************************************/
/**
 * Pupose : This provides logic fo rthe reddit queries form
 */
namespace BigBadBolts_Assign3
{
    public partial class RedditQueries : Form
    {
        static public SortedSet<Post> myPosts = new SortedSet<Post>();
        static public SortedSet<Comment> myComments = new SortedSet<Comment>();
        static public SortedSet<Subreddit> mySubReddits = new SortedSet<Subreddit>();
        static public SortedSet<User> myUsers = new SortedSet<User>();

        public RedditQueries()
        {
            InitializeComponent();
            HelperFunctions.getFileInput();
            PopulateDropDowns();

        }

        /**
         * This function populates the dropdowns used on the form
         */
        private void PopulateDropDowns()
        {
            foreach (Subreddit s in mySubReddits) //populate the subreddit award combo box
            {
                if (s.Name == "all")
                {
                }
                else
                {
                    subbredditAwardComboBox.Items.Add(s);
                }
            }
            foreach (User u in myUsers)
            {
                userComboBox.Items.Add(u);
            }
        }

        /**
         * This function handles the event of the query search by date is clicked
         * parameters: none that we care about
         */
        private void DateBtn_Click(object sender, EventArgs e)
        {
            OutputBox.Text = ""; //clears the output box
            DateTime theDate = dateTimePicker1.Value;

            OutputBox.Text += "All Posts From " + theDate.Month + "/" + theDate.Day + "/" + theDate.Year + "\n";
            OutputBox.Text += "-----------------------------------------------------";

            var dateQuery =
                from M in mySubReddits
                from N in M.SubPosts
                where N.TimeStamp.Year == theDate.Year
                where N.TimeStamp.Month == theDate.Month
                where N.TimeStamp.Day == theDate.Day
                select N;

            if (dateQuery.Count() == 0) //if the selected date has no posts
            {
                OutputBox.Text += "\n" + "Wow, such empty!";
            }

            else //if there are posts
            {
                foreach (Post post in dateQuery)
                {
                    string output = "";
                    if (post.TimeStamp.Month == theDate.Month && post.TimeStamp.Day == theDate.Day)
                    {

                        if (output != post.ToString("str")) //ensures no duplicates
                        {
                            OutputBox.Text += "\n" + post.ToString("str");
                            OutputBox.Text += "\n\n";
                            PrintEndQuery();
                            return;
                        }

                        output = post.ToString("str");
                    }

                    else
                    {
                        OutputBox.Text += "\n";
                    }

                }

                OutputBox.Text += '\n';
                PrintEndQuery();
            }

        }

        /**
         * This function handles the event of the query search for posts score within each subreddit
         * parameters: none that we care about
         */
        private void PostSubBtn_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            int selected = 3;
            //which option is selected
            if (lowRadio.Checked)
                selected = 0;
            else if (highRadio.Checked)
                selected = 1;
            else if (avgRadio.Checked)
                selected = 2;

            if (selected == 3)
            {
                OutputBox.Text += "\n" + "Please select an option";
                return;
            }

            var postQuery = //query search
                from M in mySubReddits
                from N in M.SubPosts
                group N by N.SubId into postGroup
                select new
                {
                    curId = postGroup.Key,
                    min = postGroup.Min(x => x.Score),
                    max = postGroup.Max(x => x.Score),
                    avg = postGroup.Average(x => x.Score),
                };

            string[] chosen = { "Lowest ", "Highest ", "Average " };
            OutputBox.Text += chosen[selected] + "Scored Posts For Each Subreddit:\n";
            OutputBox.Text += "-----------------------------------------------------";

            foreach (Subreddit sub in mySubReddits) //in order to get access to the names of the subreddits
            {
                foreach (var posts in postQuery)
                {
                    if (sub.Id == posts.curId) //used to match score with subreddit
                    {//formats output so everything is justified
                        OutputBox.Text += "\n";
                        OutputBox.Text += String.Format("{0, 20}", sub.Name) + " --- ";
                        switch (selected)
                        {
                            case 0:
                                OutputBox.Text += String.Format("{0, 10}", posts.min);
                                break;
                            case 1:
                                OutputBox.Text += String.Format("{0, 10}", posts.max);
                                break;
                            case 2:
                                OutputBox.Text += String.Format("{0, 10:#.00}", posts.avg);
                                break;
                        }

                    }

                }

            }
            OutputBox.Text += "\n\n";
            PrintEndQuery();
        }

        /**
        * This function handles the event of the query search for post score by each user
        * parameters: none that we care about
        */
        private void PostUserBtn_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";
            int selected = 3;
            //which radio button is selected
            if (lowRadioU.Checked)
                selected = 0;
            else if (highRadioU.Checked)
                selected = 1;
            else if (avgRadioU.Checked)
                selected = 2;

            if (selected == 3)
            {
                OutputBox.Text += "\n" + "Please select an option";
                return;
            }

            var postQueryU = //query search
                from M in mySubReddits
                from N in M.SubPosts
                group N by N.PostAuthorId into postGroup
                select new
                {
                    curId = postGroup.Key,
                    min = postGroup.Min(x => x.Score),
                    max = postGroup.Max(x => x.Score),
                    avg = postGroup.Average(x => x.Score),
                };

            string[] chosen = { "Lowest ", "Highest ", "Average " };
            OutputBox.Text += chosen[selected] + "Scored Posts For Each User:\n";
            OutputBox.Text += "-----------------------------------------------------";

            foreach (User user in myUsers) //used to get user name
            {
                foreach (var posts in postQueryU)
                {
                    if (user.Id == posts.curId) //if id matches user id
                    { //formats output
                        OutputBox.Text += "\n";
                        OutputBox.Text += String.Format("{0, 20}", user.Name) + " --- ";
                        switch (selected)
                        {
                            case 0:
                                OutputBox.Text += String.Format("{0, 10}", posts.min);
                                break;
                            case 1:
                                OutputBox.Text += String.Format("{0, 10}", posts.max);
                                break;
                            case 2:
                                OutputBox.Text += String.Format("{0, 10:#.00}", posts.avg);
                                break;

                        }

                    }

                }

            }

            OutputBox.Text += "\n\n";
            PrintEndQuery();
        }


        /**
         * This function handles the case of the user query button
         */
        private void UserSubbredditBtn_Click(object sender, EventArgs e)
        {
            if (userComboBox.SelectedIndex < 0)//nothing is selected
            {
                MessageBox.Show("Please select a user to view");
                return;
            }
            OutputBox.Text = "";
            User selectedUser = null;
            foreach (User user in myUsers)//search the users for the selected one
            {
                if (user.Name == userComboBox.GetItemText(userComboBox.SelectedItem))//found the selected one
                {
                    selectedUser = user;
                    break;
                }
            }

            OutputBox.Text += "SubReddits posted to by '" + userComboBox.GetItemText(userComboBox.SelectedItem) + "':\n\n";

            var User_Query =
                from N in mySubReddits
                from M in myPosts
                where N.Id == M.SubHome
                where M.PostAuthorId == selectedUser.Id
                select N;

            List<string> subNames = new List<string>();

            foreach (Subreddit sub in User_Query)//run through the subreddits to print the ones posted in
            {
                if (!subNames.Contains(sub.Name))//makes sure there are no repeats
                {
                    OutputBox.Text += '\t' + sub.Name + '\n';
                    subNames.Add(sub.Name);
                }
            }
            OutputBox.Text += '\n';
            PrintEndQuery();
        }

        /**
         * This function handles the even of the subreddit reward button being clicked
         * parameters: none that we care about
         * 
         */
        private void SubAwardBtn_Click(object sender, EventArgs e)
        {

            if (subbredditAwardComboBox.SelectedIndex == -1) //no item selected from dropdown
            {
                MessageBox.Show("Please select a SubReddit to view.");
                return;
            }
            OutputBox.Text = "";//reset the output box
            if (!silverCheckBox.Checked && !goldCheckBox.Checked && !platinumCheckBox.Checked) //nothing is checked
            {
                OutputBox.Text += "No award is checked.\n\n";
                return;
            }


            //Determine which title to print
            if (silverCheckBox.Checked && !goldCheckBox.Checked && !platinumCheckBox.Checked)
            {
                OutputBox.Text += "Silver ";
            }
            else if (silverCheckBox.Checked && goldCheckBox.Checked && !platinumCheckBox.Checked)
            {
                OutputBox.Text += "Silver and Gold";
            }
            else if (silverCheckBox.Checked && goldCheckBox.Checked && platinumCheckBox.Checked)
            {
                OutputBox.Text += "Silver,Gold,and Platinum ";
            }
            else if (silverCheckBox.Checked && !goldCheckBox.Checked && platinumCheckBox.Checked)
            {
                OutputBox.Text += "Silver and Platinum";
            }
            else if (!silverCheckBox.Checked && goldCheckBox.Checked && !platinumCheckBox.Checked)
            {
                OutputBox.Text += "Gold ";
            }
            else if (!silverCheckBox.Checked && goldCheckBox.Checked && platinumCheckBox.Checked)
            {
                OutputBox.Text += "Gold and Platinum ";
            }
            else //if just platinum is checked
            {
                OutputBox.Text += "Platinum ";

            }

            //print the rest of the title
            OutputBox.Text += " Awards for '" + subbredditAwardComboBox.GetItemText(subbredditAwardComboBox.SelectedItem) + "' Subbreddit:\n\n";

            if (silverCheckBox.Checked) //Silver is checked
            {
                AwardOutput("Silver");
            }
            if (goldCheckBox.Checked) //gold is checked
            {
                AwardOutput("Gold");
            }
            if (platinumCheckBox.Checked) //platinum is checked
            {
                AwardOutput("Platinum");
            }




            PrintEndQuery();



        }

        /**
         * This function gets the awards for posts, comments, and replies. it toals and then 
         * outputs them
         * Parameters: award-the string of silver,gold,or platinum to search for.
         */
        private void AwardOutput(string award)
        {
            bool silver, gold, platinum, replySearch;
            silver = gold = platinum = replySearch = false;

            uint postAwards, topCommentAwards, replyAwards;
            postAwards = topCommentAwards = replyAwards = 0;

            List<uint> postIDList = new List<uint>();
            List<uint> commentIDList = new List<uint>();
            List<uint> replyIDList = new List<uint>();
            List<uint> replyIDSearchList = new List<uint>();


            Subreddit selectedSub = null;

            foreach (Subreddit sub in mySubReddits)//Find the selected subbreddit
            {
                if (sub.Name == subbredditAwardComboBox.GetItemText(subbredditAwardComboBox.SelectedItem))//Found the seleceted subbreddit
                {
                    selectedSub = sub;
                    break;
                }
            }


            if (award == "Silver")//We are looking for silver
            {
                var Post_Query =
                  from N in myPosts
                  where N.SubId == selectedSub.Id
                  select N;

                foreach (Post post in Post_Query)//get the post awrds totaled
                {
                    postAwards += post.Silver;
                    postIDList.Add(post.PostID);
                }

                var Comment_Query =
                    from N in myComments
                    where postIDList.Contains(N.ParentID)
                    select N;

                foreach (Comment comment in Comment_Query)//get the top comments awards totaled
                {
                    topCommentAwards += comment.Silver;
                    commentIDList.Add(comment.CommentID);
                }

                var Reply_Query =
                     from N in myComments
                     where commentIDList.Contains(N.ParentID)
                     select N;

                foreach (Comment comment in Reply_Query) //Get the replies awards totaled
                {
                    replyAwards += comment.Silver;
                    replyIDList.Add(comment.CommentID);
                }

                if (replyIDList.Count > 0) //Do not search for replies if there are none
                {
                    replySearch = true;
                    while (replySearch)
                    {
                        replySearch = false;
                        foreach (Comment comment in myComments)//search for comments to count the awards
                        {
                            foreach (uint ID in replyIDList)//compare each ID to the comment
                            {
                                if (ID == comment.CommentID)//If the id matches the comment
                                {
                                    replyAwards += comment.Silver;//add the award to the total
                                    replySearch = true;
                                    foreach (Comment search in myComments)//go through the comments and find any replies
                                    {
                                        if (search.ParentID == ID)//add the items to be searched again
                                        {
                                            replyIDSearchList.Add(search.CommentID);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        replyIDList.Clear();
                        replyIDList = replyIDSearchList;
                        replyIDSearchList.Clear();
                    }
                }
            }
            if (award == "Gold")
            {
                var Post_Query =
                  from N in myPosts
                  where N.SubId == selectedSub.Id
                  select N;

                foreach (Post post in Post_Query)//get the post awrds totaled
                {
                    postAwards += post.Gold;
                    postIDList.Add(post.PostID);
                }

                var Comment_Query =
                    from N in myComments
                    where postIDList.Contains(N.ParentID)
                    select N;

                foreach (Comment comment in Comment_Query)//get the top comments awards totaled
                {
                    topCommentAwards += comment.Gold;
                    commentIDList.Add(comment.CommentID);
                }

                var Reply_Query =
                     from N in myComments
                     where commentIDList.Contains(N.ParentID)
                     select N;

                foreach (Comment comment in Reply_Query) //Get the replies awards totaled
                {
                    replyAwards += comment.Gold;
                    replyIDList.Add(comment.CommentID);
                }

                if (replyIDList.Count > 0) //Do not search for replies if there are none
                {
                    replySearch = true;
                    while (replySearch)
                    {
                        replySearch = false;
                        foreach (Comment comment in myComments)//search for comments to count the awards
                        {
                            foreach (uint ID in replyIDList)//compare each ID to the comment
                            {
                                if (ID == comment.CommentID)//If the id matches the comment
                                {
                                    replyAwards += comment.Gold;//add the award to the total
                                    replySearch = true;
                                    foreach (Comment search in myComments)//go through the comments and find any replies
                                    {
                                        if (search.ParentID == ID)//add the items to be searched again
                                        {
                                            replyIDSearchList.Add(search.CommentID);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        replyIDList.Clear();
                        replyIDList = replyIDSearchList;
                        replyIDSearchList.Clear();
                    }
                }
            }
            if (award == "Platinum")
            {
                var Post_Query =
                  from N in myPosts
                  where N.SubId == selectedSub.Id
                  select N;

                foreach (Post post in Post_Query)//get the post awrds totaled
                {
                    postAwards += post.Platinum;
                    postIDList.Add(post.PostID);
                }

                var Comment_Query =
                    from N in myComments
                    where postIDList.Contains(N.ParentID)
                    select N;

                foreach (Comment comment in Comment_Query)//get the top comments awards totaled
                {
                    topCommentAwards += comment.Platinum;
                    commentIDList.Add(comment.CommentID);
                }

                var Reply_Query =
                     from N in myComments
                     where commentIDList.Contains(N.ParentID)
                     select N;

                foreach (Comment comment in Reply_Query) //Get the replies awards totaled
                {
                    replyAwards += comment.Platinum;
                    replyIDList.Add(comment.CommentID);
                }

                if (replyIDList.Count > 0) //Do not search for replies if there are none
                {
                    replySearch = true;
                    while (replySearch)
                    {
                        replySearch = false;
                        foreach (Comment comment in myComments)//search for comments to count the awards
                        {
                            foreach (uint ID in replyIDList)//compare each ID to the comment
                            {
                                if (ID == comment.CommentID)//If the id matches the comment
                                {
                                    replyAwards += comment.Platinum;//add the award to the total
                                    replySearch = true;
                                    foreach (Comment search in myComments)//go through the comments and find any replies
                                    {
                                        if (search.ParentID == ID)//add the items to be searched again
                                        {
                                            replyIDSearchList.Add(search.CommentID);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        replyIDList.Clear();
                        replyIDList = replyIDSearchList;
                        replyIDSearchList.Clear();
                    }
                }
            }

            OutputBox.Text += '\t' + award + "Awards for Posts are: " + postAwards.ToString() + '\n';
            OutputBox.Text += '\t' + award + "Awards for Top Comments are: " + topCommentAwards.ToString() + '\n';
            OutputBox.Text += '\t' + award + "Awards for Replies are: " + replyAwards.ToString() + "\n\n";


        }

        /**
         * This function just prints ending stamp of the query results
         */
        private void PrintEndQuery()
        {
            OutputBox.Text += "*******End of Query Results*******";
        }

        /**
         * this function handles th elogic for when the threshold query is selected
         */
        private void ThresholdBtn_Click(object sender, EventArgs e)
        {
            int compareValue = (int)thresholdNumericUpDown.Value;
            List<uint> postIDList = new List<uint>();
            List<uint> commentIDList = new List<uint>();
            List<uint> replyIDList = new List<uint>();
            List<uint> replyIDSearchList = new List<uint>();

            OutputBox.Text = "";



            if (lessThanRadioButton.Checked)//we are doing less than
            {
                OutputBox.Text += "List of post/comments with a Score Less Than or Equal to " + compareValue + "\n\n";
                var Post_Query =
                  from N in myPosts
                  where N.Score <= compareValue
                  select N;

                OutputBox.Text += "\tPosts-\n";

                foreach (Post post in Post_Query)//print the posts found
                {
                    OutputBox.Text += "\t\t";
                    if (post.Title.Length < 25)
                    {
                        OutputBox.Text += post.Title;
                        for (int i = post.Title.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += post.Title[i];
                        }
                    }
                    OutputBox.Text += " --   " + post.Score + '\n';
                    postIDList.Add(post.PostID);
                }

                var Comment_Query =
                    from N in myComments
                    where postIDList.Contains(N.ParentID)
                    where N.Score <= compareValue
                    select N;


                OutputBox.Text += "\tComments-\n";


                foreach (Comment comment in Comment_Query)//print the top level comments found
                {
                    OutputBox.Text += "\t\t";
                    if (comment.Content.Length < 25)
                    {
                        OutputBox.Text += comment.Content;
                        for (int i = comment.Content.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += comment.Content[i];
                        }
                    }
                    OutputBox.Text += " --   " + comment.Score + '\n';
                    commentIDList.Add(comment.CommentID);
                }

                var Reply_Query =
                     from N in myComments
                     where commentIDList.Contains(N.ParentID)
                     where N.Score <= compareValue
                     select N;

                OutputBox.Text += "\tReplies-\n";


                foreach (Comment comment in Reply_Query) //print the replies
                {
                    OutputBox.Text += "\t\t";
                    if (comment.Content.Length < 25)
                    {
                        OutputBox.Text += comment.Content;
                        for (int i = comment.Content.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += comment.Content[i];
                        }
                    }
                    OutputBox.Text += " --   " + comment.Score + '\n';
                    commentIDList.Add(comment.CommentID);
                    replyIDList.Add(comment.CommentID);
                }
                bool replySearch = false;
                if (replyIDList.Count > 0) //Do not search for replies if there are none
                {
                    replySearch = true;
                    while (replySearch)
                    {
                        replySearch = false;
                        foreach (Comment comment in myComments)//search for comments to count the awards
                        {
                            foreach (uint ID in replyIDList)//compare each ID to the comment
                            {
                                if (ID == comment.CommentID)//If the id matches the comment
                                {
                                    OutputBox.Text += "\t\t";
                                    if (comment.Content.Length < 25)
                                    {
                                        OutputBox.Text += comment.Content;
                                        for (int i = comment.Content.Length; i < 25; ++i)
                                            OutputBox.Text += " ";
                                    }
                                    else
                                    {
                                        for (int i = 0; i < 25; ++i)
                                        {
                                            OutputBox.Text += comment.Content[i];
                                        }
                                    }
                                    OutputBox.Text += " --   " + comment.Score + '\n';
                                    commentIDList.Add(comment.CommentID);
                                    replySearch = true;
                                    foreach (Comment search in myComments)//go through the comments and find any replies
                                    {
                                        if (search.ParentID == ID)//add the items to be searched again
                                        {
                                            replyIDSearchList.Add(search.CommentID);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        replyIDList.Clear();
                        replyIDList = replyIDSearchList;
                        replyIDSearchList.Clear();
                    }
                }
            }
            else //we are doing greater than
            {
                OutputBox.Text += "List of post/comments with a Score Greater Than or Equal to " + compareValue + "\n\n";

                var Post_Query =
                   from N in myPosts
                   where N.Score >= compareValue
                   select N;

                OutputBox.Text += "\tPosts-\n";

                foreach (Post post in Post_Query)//print the posts found
                {
                    OutputBox.Text += "\t\t";
                    if (post.Title.Length < 25)
                    {
                        OutputBox.Text += post.Title;
                        for (int i = post.Title.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += post.Title[i];
                        }
                    }
                    OutputBox.Text += " --   " + post.Score + '\n';
                    postIDList.Add(post.PostID);
                }

                var Comment_Query =
                    from N in myComments
                    where postIDList.Contains(N.ParentID)
                    where N.Score >= compareValue
                    select N;


                OutputBox.Text += "\tComments-\n";


                foreach (Comment comment in Comment_Query)//print the top level comments found
                {
                    OutputBox.Text += "\t\t";
                    if (comment.Content.Length < 25)
                    {
                        OutputBox.Text += comment.Content;
                        for (int i = comment.Content.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += comment.Content[i];
                        }
                    }
                    OutputBox.Text += " --   " + comment.Score + '\n';
                    commentIDList.Add(comment.CommentID);
                }

                var Reply_Query =
                     from N in myComments
                     where commentIDList.Contains(N.ParentID)
                     where N.Score >= compareValue
                     select N;

                OutputBox.Text += "\tReplies-\n";


                foreach (Comment comment in Reply_Query) //print the replies
                {
                    OutputBox.Text += "\t\t";
                    if (comment.Content.Length < 25)
                    {
                        OutputBox.Text += comment.Content;
                        for (int i = comment.Content.Length; i < 25; ++i)
                            OutputBox.Text += " ";
                    }
                    else
                    {
                        for (int i = 0; i < 25; ++i)
                        {
                            OutputBox.Text += comment.Content[i];
                        }
                    }
                    OutputBox.Text += " --   " + comment.Score + '\n';
                    commentIDList.Add(comment.CommentID);
                    replyIDList.Add(comment.CommentID);
                }
                bool replySearch = false;
                if (replyIDList.Count > 0) //Do not search for replies if there are none
                {
                    replySearch = true;
                    while (replySearch)
                    {
                        replySearch = false;
                        foreach (Comment comment in myComments)//search for comments to count the awards
                        {
                            foreach (uint ID in replyIDList)//compare each ID to the comment
                            {
                                if (ID == comment.CommentID)//If the id matches the comment
                                {
                                    OutputBox.Text += "\t\t";
                                    if (comment.Content.Length < 25)
                                    {
                                        OutputBox.Text += comment.Content;
                                        for (int i = comment.Content.Length; i < 25; ++i)
                                            OutputBox.Text += " ";
                                    }
                                    else
                                    {
                                        for (int i = 0; i < 25; ++i)
                                        {
                                            OutputBox.Text += comment.Content[i];
                                        }
                                    }
                                    OutputBox.Text += " --   " + comment.Score + '\n';
                                    commentIDList.Add(comment.CommentID);
                                    replySearch = true;
                                    foreach (Comment search in myComments)//go through the comments and find any replies
                                    {
                                        if (search.ParentID == ID)//add the items to be searched again
                                        {
                                            replyIDSearchList.Add(search.CommentID);
                                        }
                                    }
                                    break;
                                }
                            }
                        }
                        replyIDList.Clear();
                        replyIDList = replyIDSearchList;
                        replyIDSearchList.Clear();
                    }
                }
            }
            OutputBox.Text += '\n';
            PrintEndQuery();
        }

    }
}

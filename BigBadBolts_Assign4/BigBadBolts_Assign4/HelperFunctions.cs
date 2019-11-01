using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

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
/**
 * Pupose : This provides reusable functions for the program
 */

namespace BigBadBolts_Assign4
{
    static class HelperFunctions
    {
        static public List<string> BANNED_WORDS = new List<string>()
        {
            "fudge","shoot","baddie","butthead"
        };

        /**
         * This is the definition of the foul language exception
         * 
         * returns:  A string indicationg that a FLE occured
         */
        public class FoulLanguageException : Exception
        {
            public override string ToString()
            {
                return "You seem to have included a bad word in your message. Please avoid doing this in the future";
            }
        }

        /**
         * This is a helper function that can be called to check for profanity.
         * Parameters: This takes a string and will check the entire thing for profanity somewhere in it
         * Returns:   This will return true if profanity has been found.
         */
        static public bool vulgarityChecker(string s)
        {
            foreach (string badWord in BANNED_WORDS) // Check each word in the bad words if they appear in the passed string
            {
                if (s.ToLower().Contains(badWord))
                { //Found a bad word!
                    return true;
                }
            }
            // The string is clean of bad words,return false
            return false;
        }

         /**
         * This is a helper function that can be called to get a string between two different points.
         * Parameters: This takes a string as a source, and the two things to look for in that string
         * Returns:   This will return the string located between the two strings
         */
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))//Makes sure the string contains the delimiters
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                //"getBetween error");
                return "";
            }
        }


        /**
         * This function gets and reads input from files provided to us. 
         * Parameters: myPosts- a SortedSet of post objects to fill with post info
         *             myComments - a SortedSet of Comment objects to fill with comment info
         *             mySubreddits - Sorted set of Subreddit objects
         *             myUsers - Sorted set of user objects
         */
        static public void getFileInput()
        {
            string currentLine;
            string[] tokens;

            //This will read the post file and build the objects from there
            using (StreamReader inFile = new StreamReader("..//..//posts.txt"))
            {
                bool Locked;
                currentLine = inFile.ReadLine(); //prime the read
                while (currentLine != null)
                {
                    tokens = currentLine.Split('\t');

                    if ( tokens[0] == "0")
                    {
                        Locked = false;
                    }
                    else
                    {
                        Locked = true;
                    }
                    //File structure
                    //Posts: Locked | ID | AuthorID | Title | Content | SubredditID | UpVotes | DownVotes | Weight | Year | Month | Day | Hour | Min | Sec | silver | gold | plstinum

                    string dateString = tokens[9] + '-' + tokens[10] + '-' + tokens[11] + ' ' + tokens[12] + ':' + tokens[13] + ':' + tokens[14];
                    DateTime temp;
                    if (DateTime.TryParse(dateString, out temp))//Makes sure the date converted successfully
                    {
                        Post postToAdd = new Post(//build the post to add
                            Locked,//locked
                            UInt32.Parse(tokens[1]),//postId
                            UInt32.Parse(tokens[2]),//authorID
                            tokens[3],//title
                            tokens[4],//postContent
                            UInt32.Parse(tokens[5]),//subHome
                            UInt32.Parse(tokens[6]),//upvotes
                            UInt32.Parse(tokens[7]),//downVotes
                            UInt32.Parse(tokens[8]),//weight
                            temp,//dateTime,
                            UInt32.Parse(tokens[15]),//Silver
                            UInt32.Parse(tokens[16]),//Gold
                            UInt32.Parse(tokens[17])//platinum
                            );

                        Reddit.myPosts.Add(postToAdd);
                    }
                    else //We failed to conver the date
                    {
                        Console.WriteLine("We didn't conver the date properly! QUIT (Handle this better)");
                        return;
                    }
                    currentLine = inFile.ReadLine(); //get the next line
                }
            }

            //This will read the comment file and build the objects from there
            using (StreamReader inFile = new StreamReader("..//..//comments.txt"))
            {
                currentLine = inFile.ReadLine(); //prime the read
                while (currentLine != null)
                {
                    tokens = currentLine.Split('\t');
              
                    string dateString = tokens[6] + '-' + tokens[7] + '-' + tokens[8] + ' ' + tokens[9] + ':' + tokens[10] + ':' + tokens[11];
                    DateTime temp;
                    if (DateTime.TryParse(dateString, out temp))//Make sure the date converted successfully
                    {
                        Comment commentToAdd = new Comment(//build the comment to add
                            UInt32.Parse(tokens[0]),//commentId
                            UInt32.Parse(tokens[1]),//authorID
                            tokens[2],//content
                            UInt32.Parse(tokens[3]),//parentID
                            UInt32.Parse(tokens[4]),//upvotes
                            UInt32.Parse(tokens[5]),//downVotes
                            temp,//dateTime
                            UInt32.Parse(tokens[12]),//Silver
                            UInt32.Parse(tokens[13]),//Gold
                            UInt32.Parse(tokens[14])//platinum
                            );

                        Reddit.myComments.Add(commentToAdd);
                    }
                    else
                    {
                        Console.WriteLine("We didn't convert the date properly! QUIT (Handle this better)");
                        return;
                    }
                    currentLine = inFile.ReadLine(); //get the next line
                }
            }

            //This will read the the subreddit file and build the objects from them
            using (StreamReader inFile = new StreamReader("..//..//subreddits.txt"))
            {
                currentLine = inFile.ReadLine(); //prime the read
                while (currentLine != null)
                {
                    tokens = currentLine.Split('\t');

                    Subreddit newSub = new Subreddit(//build the subreddit
                      UInt32.Parse(tokens[0]),//id
                      tokens[1],//name
                      UInt32.Parse(tokens[2]), //Members
                      UInt32.Parse(tokens[3]) //Active
                    );

                    Reddit.mySubReddits.Add(newSub);

                    currentLine = inFile.ReadLine(); //get the next line
                }
            }

            //This will get the user information and store it in the user object
            using (StreamReader inFile = new StreamReader("..//..//users.txt"))
            {
            //Users: ID | UserType | Name | PasswordHash | PostScore | CommentScore | ModeratingSubs *
            currentLine = inFile.ReadLine(); //prime the read
                while (currentLine != null)
                {
                    tokens = currentLine.Split('\t');

                    List<string> moderating = new List<string>();

                    for (int i = 6; i < tokens.Length; ++i)
                    {
                        moderating.Add(tokens[i]);
                    }

                    User newUser = new User(//build the user
                      UInt32.Parse(tokens[0]),//id
                      Int32.Parse(tokens[1]),//user type
                      tokens[2],//name
                      tokens[3],//password hash
                      Int32.Parse(tokens[4]), //postScore
                      Int32.Parse(tokens[5]), //commentScore
                      moderating //list of the moderating subs names
                    );

                    Reddit.myUsers.Add(newUser);
                    
                    currentLine = inFile.ReadLine(); //get the next line
                }
            }

        }

    }
}

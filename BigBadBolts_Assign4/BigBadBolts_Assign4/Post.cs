using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
 * Pupose : This provides a definition of the Post class
 */
namespace BigBadBolts_Assign4
{
    /**
    * This is the class definition for the Post class. 
    * Created by Byron. 
    */
    public class Post : IComparable
    { //Posts: Locked | ID | AuthorID | Title | Content | SubredditID | UpVotes | DownVotes | Weight | Year | Month | Day | Hour | Min | Sec
        private bool locked;
        private readonly uint postID;
        private string title;
        private readonly uint authorID;
        private string postContent;
        private readonly uint subHome;
        private uint upVotes;
        private uint downVotes;
        private uint weight;
        private readonly DateTime timeStamp;
        private uint silver;
        private uint gold;
        private uint platinum;
        private SortedSet<Comment> postComments;

        /////////CONSTRUCTOR ZONE////////////////////////////////////////////////////////
        public Post() //DEFAULT CONSTRUCTOR....may need some tweaks
        {
            locked = false;
            postID = (uint)Reddit.myPosts.Count + 1;
            title = "";
            authorID = 0;
            postContent = "";
            subHome = 0;
            upVotes = 0;
            downVotes = 0;
            weight = 0;
            timeStamp = DateTime.Now;
            silver = 0;
            gold = 0;
            platinum = 0;
            postComments = Reddit.myComments;
        }
        //This is used to create a new post
        public Post(bool _locked, uint _postID, uint _authorID, string _title, string _postContent, uint _subHome, uint _upVotes, uint _downVotes, uint _weight, DateTime _timeStamp, uint _silver, uint _gold, uint _platinum)
        {
            locked = _locked;
            postID = _postID;
            title = _title;
            authorID = _authorID;
            postContent = _postContent;
            subHome = _subHome;
            upVotes = _upVotes;
            downVotes = _downVotes;
            weight = _weight;
            timeStamp = _timeStamp;
            silver = _silver;
            gold = _gold;
            platinum = _platinum;
            postComments = Reddit.myComments;
        }
        public Post(string _title, uint _authorID, string _postContent, uint _subHome)
        {
            postID = (uint)Reddit.myPosts.Count + 1;
            title = _title;
            authorID = _authorID;
            PostContent = _postContent;
            subHome = _subHome;
            upVotes = 1;
            downVotes = 0;
            weight = 0;
            timeStamp = DateTime.Now;
            silver = 0;
            gold = 0;
            platinum = 0;
            postComments = Reddit.myComments;
        }
        ////////////////END CONSTREUCTOR ZONE///////////////////////////////////////////

        //Lots of accessers follow
        public uint PostAuthorId
        {
            get { return authorID; }
        }

        public DateTime TimeStamp
        {
            get { return timeStamp; }
        }
        public uint SubHome
        {
            get { return subHome; }
        }


        public SortedSet<Comment> PostComments
        {
            get
            {
                return postComments;
            }
        }

        public uint PostID
        {
            get { return postID; }
        }

        public uint Silver
        {
            get { return silver; }
        }
        public uint Gold
        {
            get { return gold; }
        }
        public uint Platinum
        {
            get { return platinum; }
        }


        public bool Locked
        {
            set { locked = value; }
            get { return locked; }
        }

        public int Score
        {
            get { return (int)upVotes - (int)downVotes; }
        }

        public uint SubId
        {
            get { return subHome; }
        }

        public int PostRating
        {
            get
            {
                if (weight == 0)
                {
                    return Score;
                }
                else if (weight == 1)
                {
                    double returnValue = (double)Score * .66;
                    return (int)returnValue;
                }
                else
                {
                    return 0;
                }
            }
        }

        public string PostContent
        {
            get { return postContent; }
            set
            {
                if (value.Length >= 1 && value.Length <= 1000)
                {
                    try
                    {
                        if (HelperFunctions.vulgarityChecker(value))//If true, found profanity
                        {
                            throw new HelperFunctions.FoulLanguageException();
                        }
                        else //did not find profanity
                        {
                            postContent = value;
                        }
                    }
                    catch (HelperFunctions.FoulLanguageException fle)
                    {
                        Console.WriteLine(fle.ToString());
                        return;//THIS MIGHT TAKE US BACK TO THE MAIN LOOP.HAVE TO TEST
                    }
                }
            }
        }

        public string Title //This is my property for a post title
        {
            get { return title; }
            set
            {
                if (value.Length >= 1 && value.Length <= 100)
                {
                    try
                    {
                        if (HelperFunctions.vulgarityChecker(value))//If true, found profanity
                        {
                            throw new HelperFunctions.FoulLanguageException();
                        }
                        else //did not find profanity
                        {
                            title = value;
                        }
                    }
                    catch (HelperFunctions.FoulLanguageException fle)
                    {
                        Console.WriteLine(fle.ToString());
                        return; //BE SUSPIPCIOUS HERE
                    }
                }
            }
        }//end title property

        public int CompareTo(Object aplha)
        {
            if (aplha == null)
                throw new ArgumentNullException();

            Post rightOp = aplha as Post;

            if (rightOp != null)
            {
                return rightOp.PostRating.CompareTo(PostRating); //This might have to be switched around
            }
            else
            {
                throw new ArgumentException("[Post]:CompareTo argument is not a Post Object.");
            }
        }

        public string ToString(string s)
        {
            if (s.Equals("str"))
            {

                string authorName = "";
                string titleCut;
                foreach (User item in Reddit.myUsers)
                {
                    if (item.Id == this.authorID)
                        authorName = item.Name;
                }
                if (authorName.Length == 0)
                    authorName = this.authorID.ToString();

                string commentsOnPost = "\n";


                foreach (Comment postComments in Reddit.myComments)
                {
                    if (postComments.CommentID == this.PostID)
                    {
                        commentsOnPost = commentsOnPost + postComments.ToString() + '\n';
                    }
                }

                string subName = "";
                foreach (Subreddit sub in Reddit.mySubReddits)
                {
                    if (this.subHome == sub.Id)
                    {
                        subName = sub.Name;
                    }
                }

                if (Title.Length > 35)
                {
                    titleCut = Title.Substring(0, 35) + "...";
                }

                else
                {
                    titleCut = Title;
                }

                return "<" + this.PostID + "> [" + subName + "] (" + this.Score + ") " + titleCut + " " + " - " + authorName + "|" + this.timeStamp.ToString() + "|";
            }

            else
                return ToString();
        }

        public override string ToString()
        {

            string authorName = "";
            foreach (User item in Reddit.myUsers)
            {
                if (item.Id == this.authorID)
                    authorName = item.Name;
            }
            if (authorName.Length == 0)
                authorName = this.authorID.ToString();

            string commentsOnPost = "\n";


            foreach (Comment postComments in Reddit.myComments)
            {
                if (postComments.CommentID == this.PostID)
                {
                    commentsOnPost = commentsOnPost + postComments.ToString() + '\n';
                }
            }

            return "<" + this.PostID + "> [" + this.subHome + "] (" + this.Score + ") " + this.Title + " " + this.postContent + " - " + authorName + "|" + this.timeStamp.ToString() + "|" + commentsOnPost;
        }

    }//End post class

    /** Collection of Post objects. This class
      * implements IEnumerable so that it can be used
      * with ForEach syntax. 
      */
    public class Posts : IEnumerable
    {
        private Post[] _post;
        public Posts(Post[] pArray)
        {
            _post = new Post[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _post[i] = pArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PostEnum GetEnumerator()
        {
            return new PostEnum(_post);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class PostEnum : IEnumerator
    {
        public Post[] _post;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PostEnum(Post[] list)
        {
            _post = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _post.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Post Current
        {
            get
            {
                try
                {
                    return _post[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }


}

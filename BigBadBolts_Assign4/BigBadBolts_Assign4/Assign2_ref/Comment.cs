using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///*******************************************************************
//*                                                                  *
//*  CSCI 473-1/504-1       Assignment 2                Fall   2019  *
//*                                                                  *
//*                                                                  *
//*  Program Name:  Reddit                                           *
//*                                                                  *
//*  Programmer:    Byron Hogan,  z1825194                           *
//*                 Margaret Higginbotham, z1793581                  *
//*                                                                  *
//*******************************************************************/
/**
 * Pupose : This provides a definition of the Comment class
 */

namespace BigBadBolts_Assign2
{
    /**
         * This is the definition for the Comment class
         * Created by Byron Hogan
         */
    public class Comment : IComparable
    {
        private readonly uint commentID;
        private readonly uint authorID;
        private string content;
        private readonly uint parentID;
        private uint upVotes;
        private uint downVotes;
        private readonly DateTime timeStamp;
        private uint indentLevel;


        public uint CommentID
        {
            get { return commentID; }
        }


        public uint up
        {
            get { return upVotes; }
        }
        public uint down
        {
            get { return downVotes; }
        }
        public DateTime time
        {
            get { return timeStamp; }
        }

        public uint indent
        {
            get { return indentLevel; }
        }



        public uint ParentID
        {
            get { return parentID; }
        }
        public string Content
        {
            get { return this.content; }
        }
        public uint CommentAuthorId
        {
            get { return authorID; }
        }
        public uint Score
        {
            get { return upVotes - downVotes; }
        }

        /////////CONSTRUCTOR ZONE////////////////////////////////////////////////////////
        public Comment() //DEFAULT CONSTRUCTOR....may need some tweaks
        {
            commentID = (uint)RedditForm.myComments.Count + 1;
            authorID = 0;
            content = "";
            parentID = 0;
            upVotes = 0;
            downVotes = 0;
            timeStamp = DateTime.Now;
   
            indentLevel = 0;
            foreach (Comment tabs in RedditForm.myComments)
            {
                if (tabs.CommentID == this.parentID)
                {
                    indentLevel = tabs.indentLevel + 1;
                }
            }
        }
        //This is used to create a new post from file.
        public Comment(uint _commentID, uint _authorID, string _content, uint _parentID, uint _upVotes, uint _downVotes, DateTime _timeStamp)
        {
            commentID = _commentID;
            content = _content;
            authorID = _authorID;
            parentID = _parentID;
            upVotes = _upVotes;
            downVotes = _downVotes;
            timeStamp = _timeStamp;
            indentLevel = 0;
            foreach (Comment tabs in RedditForm.myComments)
            {
                if (tabs.CommentID == this.parentID)
                {
                    indentLevel = tabs.indentLevel + 1;
                }
            }

        }
        //this is used to create a new comment from passed in info
        public Comment(string _content, uint _authorID, uint _parentID)
        {
            commentID = ((uint)RedditForm.myComments.Count() + 1);
            content = _content;
            authorID = _authorID;
            parentID = _parentID;
            upVotes = 1;
            downVotes = 0;
            timeStamp = DateTime.Now;
            indentLevel = 0;
            foreach (Comment tabs in RedditForm.myComments)
            {
                if (tabs.CommentID == this.parentID)
                {
                    indentLevel = tabs.indentLevel + 1;
                }
            }
        }
        ////////////////END CONSTREUCTOR ZONE///////////////////////////////////////////

    
   
        public int CompareTo(Object aplha)
        {
            if (aplha == null)
                throw new ArgumentNullException();

            Comment rightOp = aplha as Comment;

            if (rightOp != null)
            {
                if (Score.CompareTo(rightOp.Score) == 0)
                {
                    return timeStamp.CompareTo(rightOp.timeStamp);
                }
                else
                {
                    return Score.CompareTo(rightOp.Score); //This might have to be switched around
                }
            }
            else
            {
                throw new ArgumentException("[Comment]:CompareTo argument is not a Comment Object.");
            }
        }

        public override string ToString()
        {
            string authorName = "";
            foreach (User item in RedditForm.myUsers)
            {
                if (item.Id == this.authorID)
                {
                    authorName = item.Name;
                    break;
                }
            }
            if (authorName.Length == 0)
                authorName = this.authorID.ToString();
            int count = 0;
            return "<" + this.CommentID + "> (" + this.Score + ") " + this.content + " - " + authorName + "|" + this.timeStamp.ToString(); // + PrintReplies(count + 1, this.commentID) ;
            
        }
      

        private string PrintReplies(int _count, uint parentID)
        {
            string tabsToAppend = "";
            string authorName = "";


            foreach (Comment reply in RedditForm.myComments)
            {
                if (parentID == reply.parentID)//we have a reply
                {
                    foreach (User item in RedditForm.myUsers)
                    {
                        if (item.Id == reply.authorID)
                        {
                            authorName = item.Name;
                            break;
                        }
                    }
                    if (authorName.Length == 0)
                        authorName = reply.authorID.ToString();

                    for (int i = 0; i < _count; ++i)
                    {
                        tabsToAppend += '\t';
                    }

                    return Environment.NewLine + '\t' + "<" + reply.CommentID + "> (" + reply.Score + ") " + reply.content + " - " + authorName + "|" + reply.timeStamp.ToString() + "\n";

                }
                else //no reply found this run
                {
                   //do nothing
                }
            }
    
            return "";
            /*
              if (parentID == reply.parentID)//we have a reply
                { 
                    return PrintReplies(_count + 1, reply.commentID);
                }
                else //no reply found this run
                { 
                    foreach (User item in RedditForm.myUsers)
                    {
                        if (item.Id == reply.authorID)
                        {
                            authorName = item.Name;
                            break;
                        }
                    }
                    if (authorName.Length == 0)
                        authorName = reply.authorID.ToString();

                    for (int i = 0;i < _count; ++i)
                    {
                        tabsToAppend += '\t';
                    }
                    
                    return Environment.NewLine + tabsToAppend + "<" + reply.CommentID + "> (" + reply.Score + ") " + reply.content + " - " + authorName + "|" + reply.timeStamp.ToString() + "\n";
                }
                */
            
        }

    }//End comment class



    /** Collection of Comment objects. This class
     * implements IEnumerable so that it can be used
     * with ForEach syntax. 
     */
    public class Comments : IEnumerable
    {
        private Comment[] _comment;
        public Comments(Comment[] cArray)
        {
            _comment = new Comment[cArray.Length];

            for (int i = 0; i < cArray.Length; i++)
            {
                _comment[i] = cArray[i];
            }
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CommentEnum GetEnumerator()
        {
            return new CommentEnum(_comment);
        }
    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class CommentEnum : IEnumerator
    {
        public Comment[] _comment;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public CommentEnum(Comment[] list)
        {
            _comment = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _comment.Length);
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

        public Comment Current
        {
            get
            {
                try
                {
                    return _comment[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
 * Pupose : This provides a definition of the Subbreddit class
 */

namespace BigBadBolts_Assign4
{
    /* Subreddit class
     * by Margaret
     */
    public class Subreddit : IComparable
    {
        private readonly uint id;
        private string name;
        private uint members;
        private uint active;
        private SortedSet<Post> subPosts;

        //public versions
        public uint Id
        {
            get { return id; }
            set { }// id = value; } added the '}' this needs to be fixed
        }

        public SortedSet<Post> SubPosts
        {
            get
            {
                return subPosts;
            }
        }

        public string Title
        {
            get { return name; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 3 && value.Length <= 21)
                    name = value;
            }
        }

        public uint Members
        {
            get { return members; }
            set { members = value; }
        }

        public uint Active
        {
            get { return active; }
            set { active = value; }
        }

        //defult constructor
        public Subreddit()
        {
            id = (uint)Reddit.mySubReddits.Count + 1;
            name = "";
            members = 0;
            active = 0;
            subPosts = Reddit.myPosts;
        }

        //constructor to create new subreddit
        public Subreddit(string conName)
        {
            id = (uint)Reddit.mySubReddits.Count + 1;//A somewhat unique identifier
            name = conName;
            members = 0;
            active = 0;
            subPosts = Reddit.myPosts;
        }

        //constructor for input file
        public Subreddit(uint conId, string conName, uint conMembers, uint conActive)
        {
            id = conId;
            name = conName;
            members = conMembers;
            active = conActive;
            subPosts = Reddit.myPosts;
        }

        public int CompareTo(Object alpha)
        {
            if (alpha == null)
                throw new ArgumentNullException();

            Subreddit rightOp = alpha as Subreddit;

            if (rightOp != null)
                return Name.CompareTo(rightOp.Name);
            else
                throw new ArgumentException("[Subreddit]: CompareTo argument is not a name");
        }

        public override string ToString()
        {
            return this.name;
            //return "<" + this.id + "> " + this.name + " -- (" + this.active + "/" + this.members + ")";
        }

    }


    //Subreddit IEnumerable
    public class SubredditEnum : IEnumerable
    {
        private Subreddit[] _subreddit;

        public SubredditEnum(Subreddit[] subArray)
        {
            _subreddit = new Subreddit[_subreddit.Length];

            for (int i = 0; i < subArray.Length; i++)
            {
                _subreddit[i] = subArray[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public SubEnum GetEnumerator()
        {
            return new SubEnum(_subreddit);
        }

    }

    //Subreddit IEnumerator
    public class SubEnum : IEnumerator
    {
        public Subreddit[] _subreddit;

        int position = -1;

        public SubEnum(Subreddit[] list)
        {
            _subreddit = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _subreddit.Length);
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

        public Subreddit Current
        {
            get
            {
                try
                {
                    return _subreddit[position];
                }

                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }

            }

        }

    }

}

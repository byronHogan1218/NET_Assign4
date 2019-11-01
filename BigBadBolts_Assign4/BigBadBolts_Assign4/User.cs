using System;
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
 * Pupose : This provides a definition of the User class
 */
namespace BigBadBolts_Assign4
{
    /* The User class
        * By Margaret
    */
    public class User : IComparable
    {
        private readonly uint id;
        private int type;
        private readonly string name;
        private string passwordHash;
        private int postScore;
        private int commonScore;
        private List<string> moderartingSubs = new List<string>();

        //public versions
        public uint Id
        {
            get { return id; }
        }
        
        public List<string> ModeratingSubs
        {
            get { return moderartingSubs; }
        }

        public int Type
        {
            get { return type; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length >= 5 && value.Length <= 21) ; //Added a semicolon

            }
        }

        public string PasswordHash
        {
            get { return passwordHash; }
        }

        public int PostScore
        {
            get { return postScore; }
            set { postScore = value; }
        }

        public int CommonScore
        {
            get { return commonScore; }
            set { commonScore = value; }
        }

        // default constructor for User
        public User()
        {
            id = (uint)Reddit.myUsers.Count + 1;
            type = 0;
            name = "";
            passwordHash = "";
            postScore = 0;
            commonScore = 0;
            moderartingSubs = null;
        }

        // constructor for User when all properties are set
        public User(uint conId, int conType, string conName, string conPasswordHash, int conPost, int conCommon, List<string> conModeratingSubNames)
        {
            id = conId;
            type = conType;
            name = conName;
            passwordHash = conPasswordHash;
            postScore = conPost;
            commonScore = conCommon;
            foreach (string subName in conModeratingSubNames) //check each name passed in to the existing subreddits
            {
                this.moderartingSubs.Add(subName);
            }
        }

        //Used to create new user
        public User(string conName)
        {
            id = (uint)Reddit.myUsers.Count + 1;
            type = 0;
            name = conName;
            passwordHash = "";
            postScore = 0;
            commonScore = 0;
            moderartingSubs = null;
        }

        public int CompareTo(object alpha)
        {
            if (alpha == null)
                throw new ArgumentNullException();

            User rightOp = alpha as User;

            if (rightOp != null)
                return Name.CompareTo(rightOp.Name);
            else
                throw new ArgumentException("[User]: CompareTo argument is not a Name");
        }
        //need to finish toString
        public override string ToString()
        {//wasn't sure how to format toString
            return name; // Console.WriteLine();  THIS NEEDS TO BE FIXED
        }

    }

}


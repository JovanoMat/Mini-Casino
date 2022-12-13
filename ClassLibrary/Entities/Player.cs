using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Player
    {
        public int UserID { get; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Create Player object.
        /// </summary>
        /// <param name="Player"></param>
        public Player(int userID, string firstname, string lastname, string userName, string password)
        {
            UserID = userID;
            Firstname = firstname;
            Lastname = lastname;
            UserName = userName;
            Password = password;
        }

        /// <summary>
        /// Create Player object without Firstname and Lastname. 
        /// </summary>
        /// <param name="Player"></param>
        public Player(int userID, string userName, string password)
        {
            UserID = userID;
            UserName = userName;
            Password = password;
        }
    }
}

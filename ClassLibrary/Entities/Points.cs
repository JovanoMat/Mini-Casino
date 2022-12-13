using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Points
    {
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public string Game { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }

        public Points(int score, DateTime date, string game, int userID)
        {
            Score = score;
            Date = date;
            Game = game;
            UserID = userID;
        }

        public Points(int score, string username)
        {
            Score = score;
            Username = username;
        }
    }
}

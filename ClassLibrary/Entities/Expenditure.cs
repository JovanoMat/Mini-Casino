using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Expenditure
    {
        public string Game { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }

        public Expenditure(string game, int amount, int userID)
        {
            Game = game;
            Amount = amount;
            UserID = userID;
        }
    }
}

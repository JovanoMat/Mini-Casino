using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class BankAccount
    {
        public int AmountOnHand { get; set; }
        public int AmountDeposited { get; set; }
        public int UserID { get; set; }

        //Only userID because it will only be used for creating an account for a new user. 
        public BankAccount(int userID)
        {
            AmountOnHand = 0;
            AmountDeposited = 0;
            UserID = userID;
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace DB_Tests
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        [ExpectedException(typeof(PasswordIncorrectException))]
        public void CheckPlayerWithNonExistingUser()
        {
            DataManager.setConnectionString();
            DataManager.CheckPlayer("PlayerTest", "Password");

        }

        [TestMethod]
        public void CorrectArraySizeForHighscores()
        {
            ObservableCollection<Points> points = DataManager.GetTop10("Blackjack");
            bool isCorrectSize;
            if (points.Count == 10)
            {
                isCorrectSize = true;
            }
            else
            {
                isCorrectSize = false;

            }
            Assert.IsTrue(isCorrectSize);
                
        }


        [TestMethod]
        public void GetExpendituresDeiversCorrectValue()
        {
            int expendituresFromSlots = DataManager.GetExpenditures("Slots");
            Assert.AreEqual(1600, expendituresFromSlots);

        }

        [TestMethod]
        public void GetDepositedOnBank()
        {
            int banksChips = DataManager.GetDeposited(1);
            Assert.AreEqual(99999, banksChips);

        }

        [TestMethod]
        public void GetOnHandOfBank()
        {
            int banksChipsOnHand = DataManager.GetOnHand(1);
            Assert.AreEqual(0, banksChipsOnHand);
            
        }

        [TestMethod]
        public void ChipsForLuckyWheel()
        {
            int banksChips = (DataManager.GetChipsFromBank())/2;
            Assert.AreEqual(99999 / 2, banksChips);
        }

        



    }
}

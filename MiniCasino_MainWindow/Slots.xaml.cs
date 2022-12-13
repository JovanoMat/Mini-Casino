using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using ClassLibrary;

namespace MiniCasino_MainWindow
{
    /// <summary>
    /// Interaktionslogik für Slots.xaml
    /// </summary>
    public partial class Slots : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Slots(string username)
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 3);
            timer.Tick += Timer_Tick;

            sUsername = username;

            int uID = DataManager.GetUserID(username);
            int cash = DataManager.GetOnHand(uID);
            tblMoney.Text = Convert.ToString(cash) + " Chips";

            symbols = new List<string> { "♠", "♥", "♦", "♣", "7" };
        }

        int pos = 0;
        private void Timer_Tick(object sender, EventArgs e)
        {
            tblSlot1.Text = symbols[pos];
            tblSlot2.Text = symbols[pos];
            tblSlot3.Text = symbols[pos];

            pos += 1;
            if (pos == 5)
            {
                pos = 0;
            }

        }

        private List<string> symbols;

        private string sUsername;

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "1";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "5";
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "10";
        }

        private void btn50_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "50";
        }

        private int win = 0;
        private void Spin_Click(object sender, RoutedEventArgs e)
        {
            //timer.Start();
            //if (timer.IsEnabled == false)
            //{

            //}
            Random rg = new Random();
            //List<string> positions = new List<string>();
            string pos1 = symbols[rg.Next(0, 5)];
            string pos2 = symbols[rg.Next(0, 5)];
            string pos3 = symbols[rg.Next(0, 5)];
            //positions.Add(pos1);
            //positions.Add(pos2);
            //positions.Add(pos3);
            int uID = DataManager.GetUserID(sUsername);
            int bet = 0;
            win = 0;

            bool isInt = Int32.TryParse(tbAmount.Text, out bet);
            int moneyOnHand = DataManager.GetOnHand(uID);
            int newOnHand = moneyOnHand - bet;

            if (newOnHand >= 0)
            {
                if (isInt && bet > 0)
                {
                    // "♠", "♥", "♦", "♣"
                    switch (pos1)
                    {
                        //if first slot is 7
                        case "7":
                            switch (pos2)
                            {
                                //if second slot is also 7
                                case "7":
                                    switch (pos3)
                                    {
                                        //if third slot is also 7 
                                        case "7":
                                            //win in 15 times the bet 
                                            win = bet * 15;
                                            break;
                                        //else win is 7 times the bet
                                        case "♣":
                                            win = bet * 7;
                                            break;
                                        case "♦":
                                            win = bet * 7;
                                            break;
                                        case "♥":
                                            win = bet * 7;
                                            break;
                                        case "♠":
                                            win = bet * 7;
                                            break;
                                    }
                                    break;
                                //if second slot is a heart
                                case "♥":
                                    switch (pos3)
                                    {
                                        //and third slot is a heart
                                        case "♥":
                                            //win 4 times the bet
                                            win = bet * 4;
                                            break;

                                    }
                                    break;
                                //if second slot is a club
                                case "♣":
                                    switch (pos3)
                                    {
                                        //and third slot is a club
                                        case "♣":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;

                                    }
                                    break;
                                //if second slot is a diamond
                                case "♦":
                                    switch (pos3)
                                    {
                                        //if third slot is a diamond
                                        case "♦":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;
                                    }
                                    break;
                                //if third slot is a spade 
                                case "♠":
                                    switch (pos3)
                                    {
                                        case "♠":
                                            //get your bet back
                                            win = bet;
                                            break;
                                    }
                                    break;



                            }
                            break;
                        //if first slot is a heart
                        case "♥":
                            switch (pos2)
                            {
                                //if second slot is also a heart
                                case "♥":
                                    switch (pos3)
                                    {
                                        //if third slot is also a heart
                                        case "♥":
                                            //win 7 times the bet
                                            win = bet * 7;
                                            break;
                                        //else win 4 times the bet
                                        case "♣":
                                            win = bet * 4;
                                            break;
                                        case "♦":
                                            win = bet * 4;
                                            break;
                                        case "7":
                                            win = bet * 4;
                                            break;
                                        case "♠":
                                            win = bet * 4;
                                            break;

                                    }
                                    break;
                                //if second slot is a 7
                                case "7":
                                    switch (pos3)
                                    {
                                        //and third slot is a 7
                                        case "7":
                                            //win 7 times the bet
                                            win = bet * 7;
                                            break;

                                    }
                                    break;
                                //if second slot is a club
                                case "♣":
                                    switch (pos3)
                                    {
                                        //and third slot is a club
                                        case "♣":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;

                                    }
                                    break;
                                //if second slot is a diamond
                                case "♦":
                                    switch (pos3)
                                    {
                                        //if third slot is a diamond
                                        case "♦":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;
                                    }
                                    break;
                                //if third slot is a spade 
                                case "♠":
                                    switch (pos3)
                                    {
                                        case "♠":
                                            //get your bet back
                                            win = bet;
                                            break;
                                    }
                                    break;


                            }
                            break;
                        //if first slot is a club
                        case "♣":
                            switch (pos2)
                            {
                                //if second slot is also a club
                                case "♣":
                                    switch (pos3)
                                    {
                                        //if third slot is also a club
                                        case "♣":
                                            //win 5 times the bet
                                            win = bet * 5;
                                            break;
                                        //else win 2 times the bet
                                        case "7":
                                            win = bet * 2;
                                            break;
                                        case "♦":
                                            win = bet * 2;
                                            break;
                                        case "♥":
                                            win = bet * 2;
                                            break;
                                        case "♠":
                                            win = bet * 2;
                                            break;

                                    }
                                    break;
                                //if second slot is a 7
                                case "7":
                                    switch (pos3)
                                    {
                                        //and third slot is a 7
                                        case "7":
                                            //win 7 times the bet
                                            win = bet * 7;
                                            break;

                                    }
                                    break;
                                //if second slot is a heart
                                case "♥":
                                    switch (pos3)
                                    {
                                        //and third slot is a heart
                                        case "♥":
                                            //win 4 times the bet
                                            win = bet * 4;
                                            break;

                                    }
                                    break;
                                //if second slot is a diamond
                                case "♦":
                                    switch (pos3)
                                    {
                                        //if third slot is a diamond
                                        case "♦":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;
                                    }
                                    break;
                                //if third slot is a spade 
                                case "♠":
                                    switch (pos3)
                                    {
                                        case "♠":
                                            //get your bet back
                                            win = bet;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        //if first slot is a diamond
                        case "♦":
                            switch (pos2)
                            {
                                //if second slot is a diamond
                                case "♦":
                                    switch (pos3)
                                    {
                                        //if third slot is a diamond
                                        case "♦":
                                            //win 3 times the bet
                                            win = bet * 3;
                                            break;
                                        //else win 2 times the bet
                                        case "7":
                                            win = bet * 2;
                                            break;
                                        case "♣":
                                            win = bet * 2;
                                            break;
                                        case "♥":
                                            win = bet * 2;
                                            break;
                                        case "♠":
                                            win = bet * 2;
                                            break;

                                    }
                                    break;
                                //if second slot is a 7
                                case "7":
                                    switch (pos3)
                                    {
                                        //and third slot is a 7
                                        case "7":
                                            //win 7 times the bet
                                            win = bet * 7;
                                            break;

                                    }
                                    break;
                                //if second slot is a heart
                                case "♥":
                                    switch (pos3)
                                    {
                                        //and third slot is a heart
                                        case "♥":
                                            //win 4 times the bet
                                            win = bet * 4;
                                            break;

                                    }
                                    break;
                                //if second slot is a club
                                case "♣":
                                    switch (pos3)
                                    {
                                        //if third slot is a club
                                        case "♣":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;
                                    }
                                    break;
                                //if third slot is a spade 
                                case "♠":
                                    switch (pos3)
                                    {
                                        case "♠":
                                            //get your bet back
                                            win = bet;
                                            break;
                                    }
                                    break;
                            }
                            break;
                        //if first slot it a spade
                        case "♠":
                            switch (pos2)
                            {
                                //if second slot is a spade
                                case "♠":
                                    switch (pos3)
                                    {
                                        //if thirst slot is a spade
                                        case "♠":
                                            //win 3 times the bet
                                            win = 3 * bet;
                                            break;
                                        //get your bet back
                                        case "7":
                                            win = bet;
                                            break;
                                        case "♣":
                                            win = bet;
                                            break;
                                        case "♥":
                                            win = bet;
                                            break;
                                        case "♦":
                                            win = bet;
                                            break;

                                    }
                                    break;
                                //if second slot is a 7
                                case "7":
                                    switch (pos3)
                                    {
                                        //and third slot is a 7
                                        case "7":
                                            //win 7 times the bet
                                            win = bet * 7;
                                            break;

                                    }
                                    break;
                                //if second slot is a club
                                case "♣":
                                    switch (pos3)
                                    {
                                        //and third slot is a club
                                        case "♣":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;

                                    }
                                    break;
                                //if second slot is a diamond
                                case "♦":
                                    switch (pos3)
                                    {
                                        //if third slot is a diamond
                                        case "♦":
                                            //win 2 times the bet
                                            win = bet * 2;
                                            break;
                                    }
                                    break;
                                //if second slot is a heart
                                case "♥":
                                    switch (pos3)
                                    {
                                        //and if third slot is a heart
                                        case "♥":
                                            //win 4 times the bet
                                            win = bet * 4;
                                            break;
                                    }
                                    break;



                            }
                            break;

                        //if no combination was made, lose your bet
                        default:
                            win = 0;
                            break;

                    }


                    //add the win to users balance, show message and update balance textblock and slots textblocks
                    DataManager.RemoveOfAmountOnHandOrDeposited(uID, bet, true);
                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                    tblWinMSG.Text = $"You won {win} chips!";
                    int newCash = DataManager.GetOnHand(uID);
                    tblMoney.Text = Convert.ToString(newCash) + " Chips";
                    //Add new row to expenditures and points with every round
                    DataManager.AddExpenditures(uID, bet, "Slots");
                    //DataManager.AddPoints(uID, win, DateTime.Now, "Slots");
                    //DataManager.AddToAmountOnHandOrDeposited(1, bet, false);

                    tblSlot1.Text = pos1;
                    tblSlot2.Text = pos2;
                    tblSlot3.Text = pos3;

                }
                else
                {
                    tblWinMSG.Text = "Invalid bet.";
                }

            }
            else
            {
                tblWinMSG.Text = "You can't afford that.";
            }

           

            

        }

        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            rules r = new rules();
            r.Show();
        }
    }
}

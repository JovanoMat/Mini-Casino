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
    /// Interaktionslogik für Blackjack.xaml
    /// </summary>
    public partial class Blackjack : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Blackjack(string username)
        {
            InitializeComponent();

            timer.Interval = new TimeSpan(0, 0, 5);
            timer.Tick += Timer_Tick;

            sUsername = username;

            int uID = DataManager.GetUserID(sUsername);
            int money = DataManager.GetOnHand(uID);

            tblMoney.Text = Convert.ToString(money) + " Chips";




        }

        private void Timer_Tick(object sender, EventArgs e)
        {


        }

        private List<string> cards = new List<string> { "2C","3C","4C","5C","6C","7C","8C","9C","10C","AC","JC","QC","KC",
                                       "2S","3S","4S","5S","6S","7S","8S","9S","10S","AS","JS","QS","KS",
                                       "2D","3D","4D","5D","6D","7D","8D","9D","10D","AD","JD","QD","KD",
                                       "2H","3H","4H","5H","6H","7H","8H","9H","10H","AH","JH","QH","KH"};

        private string sUsername;
        private void updateGame()
        {
            int uID = DataManager.GetUserID(sUsername);
            btnPlay.IsEnabled = true;
            btnNewCard.IsEnabled = false;
            btnDouble.IsEnabled = false;
            btnFold.IsEnabled = false;
            btnLeave.IsEnabled = true;
            tblDealerSum.Text = Convert.ToString(dealerSum);
            tblPlayerSum.Text = Convert.ToString(playerSum);
            dealerSum = 0;
            dealerSumWithAceAs1 = 0;
            dealerAceSum = 0;
            playerSum = 0;
            playerSumWithAceAs1 = 0;
            playerAceSum = 0;
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn50_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "50";
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "10";

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "5";

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "1";

        }

        int dealerSum = 0;
        int dealerSumWithAceAs1 = 0;
        int dealerAceSum = 0;
        int playerSum = 0;
        int playerSumWithAceAs1 = 0;
        int playerAceSum = 0;
        int bet = 0;
        int win = 0;
        string dealer1;
        string dealer2;
        string player1;
        string player2;
        char[] splitBy = new char[] { Convert.ToChar("H"), Convert.ToChar("S"), Convert.ToChar("C"), Convert.ToChar("D") };
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            tblDealer.Text = "Dealer:";
            if (cards.Count < 1)
            {
                cards = new List<string> { "2C","3C","4C","5C","6C","7C","8C","9C","10C","AC","JC","QC","KC",
                                       "2S","3S","4S","5S","6S","7S","8S","9S","10S","AS","JS","QS","KS",
                                       "2D","3D","4D","5D","6D","7D","8D","9D","10D","AD","JD","QD","KD",
                                       "2H","3H","4H","5H","6H","7H","8H","9H","10H","AH","JH","QH","KH"};
            }
            int uID = DataManager.GetUserID(sUsername);
            Random rg = new Random();
            dealer1 = cards[rg.Next(0, cards.Count)];
            cards.Remove(dealer1);
            
            dealer2 = cards[rg.Next(0, cards.Count)];
            cards.Remove(dealer2);
            
            player1 = cards[rg.Next(0, cards.Count)];
            cards.Remove(player1);
            
            player2 = cards[rg.Next(0, cards.Count)];
            cards.Remove(player2);

            //imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/10H.png", UriKind.Relative));
            string[] d1splitted = dealer1.Split(splitBy);
            string[] d2splitted = dealer2.Split(splitBy);
            string[] p1splitted = player1.Split(splitBy);
            string[] p2splitted = player2.Split(splitBy);

            bet = 0;
            win = 0;

            bool isInt = Int32.TryParse(tbAmount.Text, out bet);
            int moneyOnHand = DataManager.GetOnHand(uID);
            int newOnHand = moneyOnHand - bet;

            btnLeave.IsEnabled = false;
            DataManager.RemoveOfAmountOnHandOrDeposited(uID, bet, true);


            if (newOnHand >= 0)
            {
                if (isInt && bet > 0)
                {
                    //determine dealers first cards
                    switch (dealer1)
                    {
                        case "2C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/2C.png", UriKind.Relative));
                            dealerSum += 2;
                            break;
                        case "3C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/3C.png", UriKind.Relative));
                            dealerSum += 3;
                            break;
                        case "4C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/4C.png", UriKind.Relative));
                            dealerSum += 4;
                            break;
                        case "5C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/5C.png", UriKind.Relative));
                            dealerSum += 5;
                            break;
                        case "6C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/6C.png", UriKind.Relative));
                            dealerSum += 6;
                            break;
                        case "7C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/7C.png", UriKind.Relative));
                            dealerSum += 7;
                            break;
                        case "8C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/8C.png", UriKind.Relative));
                            dealerSum += 8;
                            break;
                        case "9C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/9C.png", UriKind.Relative));
                            dealerSum += 9;
                            break;
                        case "10C":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/10C.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "AC":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/AC.png", UriKind.Relative));
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JC":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/JC.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "QC":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/QC.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "KC":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/KC.png", UriKind.Relative));
                            dealerSum += 10;
                            break;


                        case "2S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/2S.png", UriKind.Relative));
                            dealerSum += 2;
                            break;
                        case "3S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/3S.png", UriKind.Relative));
                            dealerSum += 3;
                            break;
                        case "4S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/4S.png", UriKind.Relative));
                            dealerSum += 4;
                            break;
                        case "5S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/5S.png", UriKind.Relative));
                            dealerSum += 5;
                            break;
                        case "6S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/6S.png", UriKind.Relative));
                            dealerSum += 6;
                            break;
                        case "7S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/7S.png", UriKind.Relative));
                            dealerSum += 7;
                            break;
                        case "8S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/8S.png", UriKind.Relative));
                            dealerSum += 8;
                            break;
                        case "9S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/9S.png", UriKind.Relative));
                            dealerSum += 9;
                            break;
                        case "10S":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/10S.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "AS":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/AS.png", UriKind.Relative));
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JS":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/JS.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "QS":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/QS.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "KS":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/KS.png", UriKind.Relative));
                            dealerSum += 10;
                            break;

                        case "2D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/2D.png", UriKind.Relative));
                            dealerSum += 2;
                            break;
                        case "3D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/3D.png", UriKind.Relative));
                            dealerSum += 3;
                            break;
                        case "4D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/4D.png", UriKind.Relative));
                            dealerSum += 4;
                            break;
                        case "5D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/5D.png", UriKind.Relative));
                            dealerSum += 5;
                            break;
                        case "6D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/6D.png", UriKind.Relative));
                            dealerSum += 6;
                            break;
                        case "7D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/7D.png", UriKind.Relative));
                            dealerSum += 7;
                            break;
                        case "8D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/8D.png", UriKind.Relative));
                            dealerSum += 8;
                            break;
                        case "9D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/9D.png", UriKind.Relative));
                            dealerSum += 9;
                            break;
                        case "10D":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/10D.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "AD":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/AD.png", UriKind.Relative));
                            dealerSum += 10;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JD":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/JD.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "QD":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/QD.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "KD":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/KD.png", UriKind.Relative));
                            dealerSum += 10;
                            break;

                        case "2H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/2H.png", UriKind.Relative));
                            dealerSum += 2;
                            break;
                        case "3H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/3H.png", UriKind.Relative));
                            dealerSum += 3;
                            break;
                        case "4H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/4H.png", UriKind.Relative));
                            dealerSum += 4;
                            break;
                        case "5H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/5H.png", UriKind.Relative));
                            dealerSum += 5;
                            break;
                        case "6H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/6H.png", UriKind.Relative));
                            dealerSum += 6;
                            break;
                        case "7H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/7H.png", UriKind.Relative));
                            dealerSum += 7;
                            break;
                        case "8H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/8H.png", UriKind.Relative));
                            dealerSum += 8;
                            break;
                        case "9H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/9H.png", UriKind.Relative));
                            dealerSum += 9;
                            break;
                        case "10H":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/10H.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "AH":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/AH.png", UriKind.Relative));
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JH":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/JH.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "QH":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/QH.png", UriKind.Relative));
                            dealerSum += 10;
                            break;
                        case "KH":
                            imgDealer1.Source = new BitmapImage(new Uri(@"/Cards/KH.png", UriKind.Relative));
                            dealerSum += 10;
                            break;

                    }
                    //determine dealers second card
                    switch (dealer2)
                    {
                        case "2C":
                            dealerSum += 2;
                            break;
                        case "3C":
                            dealerSum += 3;
                            break;
                        case "4C":
                            dealerSum += 4;
                            break;
                        case "5C":
                            dealerSum += 5;
                            break;
                        case "6C":
                            dealerSum += 6;
                            break;
                        case "7C":
                            dealerSum += 7;
                            break;
                        case "8C":
                            dealerSum += 8;
                            break;
                        case "9C":
                            dealerSum += 9;
                            break;
                        case "10C":
                            dealerSum += 10;
                            break;
                        case "AC":
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JC":
                            dealerSum += 10;
                            break;
                        case "QC":
                            dealerSum += 10;
                            break;
                        case "KC":
                            dealerSum += 10;
                            break;


                        case "2S":
                            dealerSum += 2;
                            break;
                        case "3S":
                            dealerSum += 3;
                            break;
                        case "4S":
                            dealerSum += 4;
                            break;
                        case "5S":
                            dealerSum += 5;
                            break;
                        case "6S":
                            dealerSum += 6;
                            break;
                        case "7S":
                            dealerSum += 7;
                            break;
                        case "8S":
                            dealerSum += 8;
                            break;
                        case "9S":
                            dealerSum += 9;
                            break;
                        case "10S":
                            dealerSum += 10;
                            break;
                        case "AS":
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JS":
                            dealerSum += 10;
                            break;
                        case "QS":
                            dealerSum += 10;
                            break;
                        case "KS":
                            dealerSum += 10;
                            break;

                        case "2D":
                            dealerSum += 2;
                            break;
                        case "3D":
                            dealerSum += 3;
                            break;
                        case "4D":
                            dealerSum += 4;
                            break;
                        case "5D":
                            dealerSum += 5;
                            break;
                        case "6D":
                            dealerSum += 6;
                            break;
                        case "7D":
                            dealerSum += 7;
                            break;
                        case "8D":
                            dealerSum += 8;
                            break;
                        case "9D":
                            dealerSum += 9;
                            break;
                        case "10D":
                            dealerSum += 10;
                            break;
                        case "AD":
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JD":
                            dealerSum += 10;
                            break;
                        case "QD":
                            dealerSum += 10;
                            break;
                        case "KD":
                            dealerSum += 10;
                            break;

                        case "2H":
                            dealerSum += 2;
                            break;
                        case "3H":
                            dealerSum += 3;
                            break;
                        case "4H":
                            dealerSum += 4;
                            break;
                        case "5H":
                            dealerSum += 5;
                            break;
                        case "6H":
                            dealerSum += 6;
                            break;
                        case "7H":
                            dealerSum += 7;
                            break;
                        case "8H":
                            dealerSum += 8;
                            break;
                        case "9H":
                            dealerSum += 9;
                            break;
                        case "10H":
                            dealerSum += 10;
                            break;
                        case "AH":
                            dealerSum += 11;
                            dealerSumWithAceAs1 += 1;
                            break;
                        case "JH":
                            dealerSum += 10;
                            break;
                        case "QH":
                            dealerSum += 10;
                            break;
                        case "KH":
                            dealerSum += 10;
                            break;

                    }
                    
                        btnPlay.IsEnabled = false;
                        btnNewCard.IsEnabled = true;
                        btnDouble.IsEnabled = true;
                        btnFold.IsEnabled = true;
                        ////determine if dealer has an ace to show both sums
                        //if (dealerSumWithAceAs1 >= 1)
                        //{
                        //    dealerAceSum = (dealerSum - 11) + dealerSumWithAceAs1;
                        //    tblDealerSum.Text = $"{dealerSum}/{dealerAceSum}";
                        //}
                        //else
                        //{
                        //    tblDealerSum.Text = $"{dealerSum}";
                        //}

                        string number = d1splitted[0];
                        if (number == "A")
                        {
                            tblDealerSum.Text = "11";
                        }
                        else if (number == "J" || number == "Q" || number == "K")
                        {
                            tblDealerSum.Text = "10";
                        }
                        else
                        {
                            tblDealerSum.Text = number;
                        }
                            
                        

                        //determin players cards
                        switch (player1)
                        {
                            case "2C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/2C.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/3C.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/4C.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/5C.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/6C.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/7C.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/8C.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/9C.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10C":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/10C.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AC":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/AC.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JC":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/JC.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QC":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/QC.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KC":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/KC.png", UriKind.Relative));
                                playerSum += 10;
                                break;


                            case "2S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/2S.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/3S.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/4S.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/5S.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/6S.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/7S.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/8S.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/9S.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10S":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/10S.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AS":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/AS.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JS":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/JS.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QS":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/QS.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KS":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/KS.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                            case "2D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/2D.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/3D.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/4D.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/5D.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/6D.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/7D.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/8D.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/9D.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10D":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/10D.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AD":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/AD.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JD":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/JD.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QD":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/QD.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KD":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/KD.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                            case "2H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/2H.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/3H.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/4H.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/5H.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/6H.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/7H.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/8H.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/9H.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10H":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/10H.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AH":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/AH.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JH":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/JH.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QH":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/QH.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KH":
                                imgPlayer1.Source = new BitmapImage(new Uri(@"/Cards/KH.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                        }
                        //determine players second card
                        switch (player2)
                        {
                            case "2C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/2C.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/3C.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/4C.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/5C.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/6C.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/7C.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/8C.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/9C.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10C":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/10C.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AC":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/AC.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JC":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/JC.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QC":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/QC.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KC":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/KC.png", UriKind.Relative));
                                playerSum += 10;
                                break;


                            case "2S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/2S.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/3S.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/4S.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/5S.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/6S.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/7S.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/8S.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/9S.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10S":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/10S.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AS":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/AS.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JS":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/JS.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QS":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/QS.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KS":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/KS.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                            case "2D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/2D.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/3D.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/4D.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/5D.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/6D.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/7D.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/8D.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/9D.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10D":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/10D.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AD":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/AD.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JD":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/JD.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QD":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/QD.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KD":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/KD.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                            case "2H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/2H.png", UriKind.Relative));
                                playerSum += 2;
                                break;
                            case "3H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/3H.png", UriKind.Relative));
                                playerSum += 3;
                                break;
                            case "4H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/4H.png", UriKind.Relative));
                                playerSum += 4;
                                break;
                            case "5H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/5H.png", UriKind.Relative));
                                playerSum += 5;
                                break;
                            case "6H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/6H.png", UriKind.Relative));
                                playerSum += 6;
                                break;
                            case "7H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/7H.png", UriKind.Relative));
                                playerSum += 7;
                                break;
                            case "8H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/8H.png", UriKind.Relative));
                                playerSum += 8;
                                break;
                            case "9H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/9H.png", UriKind.Relative));
                                playerSum += 9;
                                break;
                            case "10H":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/10H.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "AH":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/AH.png", UriKind.Relative));
                                playerSum += 11;
                                playerSumWithAceAs1 += 1;
                                break;
                            case "JH":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/JH.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "QH":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/QH.png", UriKind.Relative));
                                playerSum += 10;
                                break;
                            case "KH":
                                imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/KH.png", UriKind.Relative));
                                playerSum += 10;
                                break;

                        }
                        if (playerSum == 21 && dealerSum == 21)
                        {
                            tblDealer.Text = "Both blackjack!";
                            imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                            updateGame();

                        }
                        else if(dealerSum == 21)
                        {
                            tblDealer.Text = "Dealer blackjack!";
                            imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                            updateGame();

                        }
                        else if (playerSum == 21)
                        {
                            tblDealer.Text = "Blackjack!";
                            imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                            win = (bet*2 + (bet / 2)); 
                            DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                            DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");
                            int money = DataManager.GetOnHand(uID);

                            tblMoney.Text = Convert.ToString(money) + " Chips";
                            updateGame();

                        }
                        else
                        {
                            
                            string numberp1 = p1splitted[0];
                            string numberp2 = p2splitted[0];
                            int num1;
                            int num2;
                            if (numberp1 == "A" || numberp2 == "A")
                            {
                                playerAceSum = (playerSum - 11) + playerSumWithAceAs1;
                                tblPlayerSum.Text = $"{playerSum}/{playerAceSum}";
                            }
                            else if(numberp1 == "Q" || numberp1 == "J" || numberp1 == "K" ||
                                    numberp2 == "Q" || numberp2 == "J" || numberp2 == "K")
                                 {
                                     if (numberp1 == "Q" || numberp1 == "J" || numberp1 == "K" && numberp2 != "Q" && numberp2 != "J" && numberp2 != "K" && numberp2 != "A")
                                     {
                                        num1 = 10;
                                        int num = Convert.ToInt32(numberp2);
                                        int erg = num + num1;
                                        tblPlayerSum.Text = Convert.ToString(erg);
                                     }
                                     else if(numberp2 == "Q" || numberp2 == "J" || numberp2 == "K" && numberp1 != "Q" && numberp1 != "J" && numberp1 != "K")
                                     {
                                        num2 = 10;
                                        int num = Convert.ToInt32(numberp1);
                                        int erg = num + num2;
                                        tblPlayerSum.Text = Convert.ToString(erg);
                                     }

                                 }
                            else
                            {
                                tblPlayerSum.Text = Convert.ToString(playerSum);
                            }


                            //add the win to users balance, show message and update balance textblock and slots textblocks
                            int newCash = DataManager.GetOnHand(uID);
                            tblMoney.Text = Convert.ToString(newCash) + " Chips";
                            //Add new row to expenditures with every round
                            DataManager.AddExpenditures(uID, bet, "Slots");
                            //DataManager.AddToAmountOnHandOrDeposited(1, bet, false);

                            //if (p1splitted[0] == p2splitted[0])
                            //{
                            //    btnSplit.IsEnabled = true;
                            //}
                        }
                        

                    
                }
                else
                {
                    tblDealer.Text = "Invalid bet.";
                    btnLeave.IsEnabled = true;
                    btnPlay.IsEnabled = true;
                }
            }
            else
            {
                tblDealer.Text = "You can't afford that.";
                btnLeave.IsEnabled = true;
                btnPlay.IsEnabled = true;
            }
            






        }

        private void btnFold_Click(object sender, RoutedEventArgs e)
        {
            tblDealer.Text = "Dealer:";

            if (cards.Count < 1)
            {
                cards = new List<string> { "2C","3C","4C","5C","6C","7C","8C","9C","10C","AC","JC","QC","KC",
                                       "2S","3S","4S","5S","6S","7S","8S","9S","10S","AS","JS","QS","KS",
                                       "2D","3D","4D","5D","6D","7D","8D","9D","10D","AD","JD","QD","KD",
                                       "2H","3H","4H","5H","6H","7H","8H","9H","10H","AH","JH","QH","KH"};
            }
            int uID = DataManager.GetUserID(sUsername);
            Random rg = new Random();
            btnNewCard.IsEnabled = false;
            while (dealerSum < 17)
            {
                string newDealer = cards[rg.Next(0, cards.Count)];
                cards.Remove(newDealer);
                imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + newDealer + ".png", UriKind.Relative));
                string[] split = newDealer.Split(splitBy);
                string splitted = split[0]; 
                if (splitted == "A")
                {
                    dealerSum += 1;

                }
                else if (splitted == "J" || splitted == "Q" || splitted == "K" )
                {
                    dealerSum += 10;
                }
                else
                {
                    dealerSum += Convert.ToInt32(splitted);
                }

            }
            //determine if player has an ace to show both sums
            if (playerSumWithAceAs1 >= 1)
            {
                playerAceSum = (playerSum - 11) + playerSumWithAceAs1;
                if (dealerSum > 21)
                {
                    tblDealer.Text = "You win!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    win = bet * 2;
                    DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                    int money = DataManager.GetOnHand(uID);

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
                else if (playerSum == dealerSum)
                {
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    tblDealer.Text = "Both the same!";
                    int money = DataManager.GetOnHand(uID);

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
                else if (playerAceSum < dealerSum && playerSum < dealerSum)
                {
                    tblDealer.Text = "Dealer wins!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    int money = DataManager.GetOnHand(uID);

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
                else
                {
                    tblDealer.Text = "You win!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    win = bet * 2;
                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                    int money = DataManager.GetOnHand(uID);
                    DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
            }
            else
            {
                if (dealerSum > 21)
                {
                    tblDealer.Text = "You win!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    win = bet * 2;
                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                    int money = DataManager.GetOnHand(uID);
                    DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
                else if (playerSum == dealerSum)
                {
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    tblDealer.Text = "Both the same!";
                    updateGame();
                }
                else if (playerSum < dealerSum)
                {
                    tblDealer.Text = "Dealer wins!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    int money = DataManager.GetOnHand(uID);

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
                else
                {
                    tblDealer.Text = "You win!";
                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                    win = bet * 2;
                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                    int money = DataManager.GetOnHand(uID);
                    DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                    tblMoney.Text = Convert.ToString(money) + " Chips";
                    updateGame();
                }
            }

        }

        private void btnNewCard_Click(object sender, RoutedEventArgs e)
        {
            tblDealer.Text = "Dealer:";

            if (cards.Count < 1)
            {
                cards = new List<string> { "2C","3C","4C","5C","6C","7C","8C","9C","10C","AC","JC","QC","KC",
                                       "2S","3S","4S","5S","6S","7S","8S","9S","10S","AS","JS","QS","KS",
                                       "2D","3D","4D","5D","6D","7D","8D","9D","10D","AD","JD","QD","KD",
                                       "2H","3H","4H","5H","6H","7H","8H","9H","10H","AH","JH","QH","KH"};
            }

            btnDouble.IsEnabled = false;
            int uID = DataManager.GetUserID(sUsername);
            Random rg = new Random();
            string newPlayer = cards[rg.Next(0, cards.Count)];
            cards.Remove(newPlayer);
            imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/" + newPlayer + ".png", UriKind.Relative));
            string[] split = newPlayer.Split(splitBy);
            string splitted = split[0];
            if (splitted == "A")
            {
                playerSumWithAceAs1 += 1;
                tblPlayerSum.Text = $"{playerSumWithAceAs1}/{playerSum}";
                
                
            }
            else if (splitted == "J" || splitted == "Q" || splitted == "K")
            {
                playerSum += 10;
                if (playerSumWithAceAs1 >= 1)
                {
                    int playerSumAce = playerSumWithAceAs1 + (playerSum - (11 * playerSumWithAceAs1));
                    tblPlayerSum.Text = $"{playerAceSum}/{playerSum}";
                }
                else
                {
                    tblPlayerSum.Text = $"{playerSum}";

                }
            }
            else
            {
                playerSum += Convert.ToInt32(splitted);
                if (playerSumWithAceAs1 >= 1)
                {
                    int playerSumAce = playerSumWithAceAs1 + (playerSum - (11 * playerSumWithAceAs1));
                    tblPlayerSum.Text = $"{playerAceSum}/{playerSum}";
                }
                else
                {
                    tblPlayerSum.Text = $"{playerSum}";

                }
            }

            if (playerSum > 21)
            {
                tblDealer.Text = "Bust!";
                int money = DataManager.GetOnHand(uID);

                tblMoney.Text = Convert.ToString(money) + " Chips";
                updateGame();
            }
            else if (playerSum == 21 && dealerSum == 21)
            {
                tblDealer.Text = "Both blackjack!";
                imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                updateGame(); 
            }
            else if (playerSum == 21)
            {
                tblDealer.Text = "Blackjack!";
                imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                win = bet * 2;
                DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");


                int money = DataManager.GetOnHand(uID);

                tblMoney.Text = Convert.ToString(money) + " Chips"; 
                updateGame();

            }
            

        }

        private void btnDouble_Click(object sender, RoutedEventArgs e)
        {
            tblDealer.Text = "Dealer:";

            if (cards.Count < 1)
            {
                cards = new List<string> { "2C","3C","4C","5C","6C","7C","8C","9C","10C","AC","JC","QC","KC",
                                       "2S","3S","4S","5S","6S","7S","8S","9S","10S","AS","JS","QS","KS",
                                       "2D","3D","4D","5D","6D","7D","8D","9D","10D","AD","JD","QD","KD",
                                       "2H","3H","4H","5H","6H","7H","8H","9H","10H","AH","JH","QH","KH"};
            }
            bet += bet;
            int uID = DataManager.GetUserID(sUsername);
            Random rg = new Random();
            string newPlayer = cards[rg.Next(0, cards.Count)];
            cards.Remove(newPlayer);
            imgPlayer2.Source = new BitmapImage(new Uri(@"/Cards/" + newPlayer + ".png", UriKind.Relative));
            string[] split2 = newPlayer.Split(splitBy);
            string splitted2 = split2[0];
            if (splitted2 == "A")
            {
                playerSumWithAceAs1 += 1;
                tblPlayerSum.Text = $"{playerSumWithAceAs1}/{playerSum}";


            }
            else if (splitted2 == "J" || splitted2 == "Q" || splitted2 == "K")
            {
                playerSum += 10;
                if (playerSumWithAceAs1 >= 1)
                {
                    int playerSumAce = playerSumWithAceAs1 + (playerSum - (11 * playerSumWithAceAs1));
                    tblPlayerSum.Text = $"{playerAceSum}/{playerSum}";
                }
                else
                {
                    tblPlayerSum.Text = $"{playerSum}";

                }
            }
            else
            {
                playerSum += Convert.ToInt32(splitted2);
                if (playerSumWithAceAs1 >= 1)
                {
                    int playerSumAce = playerSumWithAceAs1 + (playerSum - (11 * playerSumWithAceAs1));
                    tblPlayerSum.Text = $"{playerAceSum}/{playerSum}";
                }
                else
                {
                    tblPlayerSum.Text = $"{playerSum}";

                }
            }
            if (playerSum > 21)
            {
                tblDealer.Text = "Bust!";
                int money = DataManager.GetOnHand(uID);

                tblMoney.Text = Convert.ToString(money) + " Chips";
                updateGame();
            }
            else
            {
                btnNewCard.IsEnabled = false;
                while (dealerSum < 17)
                {
                    string newDealer = cards[rg.Next(0, cards.Count)];
                    cards.Remove(newDealer);


                    imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + newDealer + ".png", UriKind.Relative));
                    string[] split = newDealer.Split(splitBy);
                    string splitted = split[0];
                    if (splitted == "A")
                    {
                        dealerSum += 1;

                    }
                    else if (splitted == "J" || splitted == "Q" || splitted == "K")
                    {
                        dealerSum += 10;
                    }
                    else
                    {
                        dealerSum += Convert.ToInt32(splitted);
                    }

                }
                //determine if player has an ace to show both sums
                if (playerSumWithAceAs1 >= 1)
                {
                    playerAceSum = (playerSum - 11) + playerSumWithAceAs1;
                    if (dealerSum > 21)
                    {
                        tblDealer.Text = "You win!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        win = bet * 2;
                        DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                        int money = DataManager.GetOnHand(uID);
                        DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                    else if (playerSum == dealerSum)
                    {
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        tblDealer.Text = "Both the same!";
                        int money = DataManager.GetOnHand(uID);

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                    else if (playerAceSum < dealerSum && playerSum < dealerSum)
                    {
                        tblDealer.Text = "Dealer wins!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        int money = DataManager.GetOnHand(uID);

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                    else
                    {
                        tblDealer.Text = "You win!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        win = bet * 2;
                        DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                        DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");
                        int money = DataManager.GetOnHand(uID);

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                }
                else
                {
                    if (dealerSum > 21)
                    {
                        tblDealer.Text = "You win!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        win = bet * 2;
                        DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                        int money = DataManager.GetOnHand(uID);
                        DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                    else if (playerSum == dealerSum)
                    {
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        tblDealer.Text = "Both the same!";
                        updateGame();
                    }
                    else if (playerSum < dealerSum)
                    {
                        tblDealer.Text = "Dealer wins!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        int money = DataManager.GetOnHand(uID);

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                    else
                    {
                        tblDealer.Text = "You win!";
                        imgDealer2.Source = new BitmapImage(new Uri(@"/Cards/" + dealer2 + ".png", UriKind.Relative));
                        win = bet * 2;
                        DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                        int money = DataManager.GetOnHand(uID);
                        DataManager.AddPoints(uID, win, DateTime.Now, "Blackjack");

                        tblMoney.Text = Convert.ToString(money) + " Chips";
                        updateGame();
                    }
                }
            }

            
        }

        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            rules r = new rules();
            r.Show();
        }
    }
}

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
using ClassLibrary;

namespace MiniCasino_MainWindow
{
    /// <summary>
    /// Interaktionslogik für MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu(string username)
        {
            InitializeComponent();

            int uID = DataManager.GetUserID(username);
            int cash = DataManager.GetOnHand(uID);

            tblUsername.Text = username;

            sUsername = username;

            

        }

        private string sUsername;

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnBank_Click(object sender, RoutedEventArgs e)
        {
            BankWindow mWindow = new BankWindow(sUsername);
            mWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Leaderboard lWindow = new Leaderboard();
            lWindow.Show();
        }

        private void btnWheel_Click(object sender, RoutedEventArgs e)
        {
            LuckyWheel lwWindow = new LuckyWheel(sUsername);
            lwWindow.Show();
        }

        private void btnSlots_Click(object sender, RoutedEventArgs e)
        {
            Slots sWindow = new Slots(sUsername);
            sWindow.Show();
        }

        private void btnBlackjack_Click(object sender, RoutedEventArgs e)
        {
            Blackjack bWindow = new Blackjack(sUsername);
            bWindow.Show();
        }

        private void btnRoulette_Click(object sender, RoutedEventArgs e)
        {
            Roulette rWindow = new Roulette(sUsername);
            rWindow.Show();
        }
    }
}

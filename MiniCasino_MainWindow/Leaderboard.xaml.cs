using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        public Leaderboard()
        {
            InitializeComponent();

            Loaded += Leaderboard_Loaded;
        }

        

        private void Leaderboard_Loaded(object sender, RoutedEventArgs e)
        {
            //Get Top 10 Scores of Blackjack with username and show in datagrid
            ObservableCollection<Points> points = DataManager.GetTop10("Blackjack");
            ObservableCollection<Points> pointsWithUsername = new ObservableCollection<Points>();

            foreach (var item in points)
            {
                pointsWithUsername.Add(new Points (item.Score, DataManager.getUsername(item.UserID)));

            }

            dgBlackjack.ItemsSource = pointsWithUsername;

            //Get Top 10 Scores of slots with username and show in datagrid
            ObservableCollection<Points> pointsS = DataManager.GetTop10("Slots");
            ObservableCollection<Points> pointsWithUsernameS = new ObservableCollection<Points>();

            foreach (var item in pointsS)
            {
                pointsWithUsernameS.Add(new Points(item.Score, DataManager.getUsername(item.UserID)));

            }

            dgSlots.ItemsSource = pointsWithUsernameS;

            //Get Top 10 Scores of Roulette with username and show in datagrid
            ObservableCollection<Points> pointsR = DataManager.GetTop10("Blackjack");
            ObservableCollection<Points> pointsWithUsernameR = new ObservableCollection<Points>();

            foreach (var item in pointsR)
            {
                pointsWithUsernameR.Add(new Points(item.Score, DataManager.getUsername(item.UserID)));

            }

            dgRoulette.ItemsSource = pointsWithUsernameR;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;

namespace MiniCasino_MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        //Early stage testing
        //ObservableCollection<Points> pointsB = new ObservableCollection<Points>();
        //ObservableCollection<Points> pointsR = new ObservableCollection<Points>();
        //ObservableCollection<Points> pointsS = new ObservableCollection<Points>();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //DataManager.SetChips(2, 1);
            //DataManager.DepositChips(10, 1000);
            //DataManager.WithdrawChips(9, 9000);
            //lblHalfChips.Content = DataManager.GetChipsFromBank();
            //DataManager.CreateNewPlayer("JovanoMat", null, null, "MiniCasinoProjekt");
            //lblDeposited.Content = DataManager.GetDeposited(5);
            //lblOnHand.Content = DataManager.GetOnHand(5);
            //DataManager.AddPoints(7, 999, DateTime.Now, "Blackjack");
            //DataManager.AddExpenditures(8, 20, "Roulette");
            //lblExpenditures.Content = DataManager.GetExpenditures("Blackjack");
            //try
            //{
            //    lblExpenditures.Content = DataManager.CheckPlayer("PlayerTest", "player5pwd"); 

            //}
            //catch (PasswordIncorrectException)
            //{
            //    lblExpenditures.Content = false;
                
            //}

            //List<Points> pointsBJ = DataManager.GetTop10("Blackjack");
            //foreach (var item in pointsBJ)
            //{
            //    pointsB.Add(item);
            //}
            //dgBlackjack.ItemsSource = pointsB;

            //List<Points> pointsRL = DataManager.GetTop10("Roulette");
            //foreach (var item in pointsRL)
            //{
            //    pointsR.Add(item);
            //}
            //dgRoulette.ItemsSource = pointsR;

            //List<Points> pointsSL = DataManager.GetTop10("Slots");
            //foreach (var item in pointsSL)
            //{
            //    pointsS.Add(item);
            //}
            //dgSlots.ItemsSource = pointsS;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pwdbPassword.Password;

            if (username == "" || password == "")
            {
                tblError.Text = "Invalid input.";
            }
            else
            {
                bool exists = DataManager.CheckPlayer(username, password);
                if (exists == true)
                {
                    //if user and password match and exist, open main window and close login window
                    MainMenu mWindow = new MainMenu(username);
                    mWindow.Show();
                    Close();

                }
                else
                {
                    //else deliver error message
                    tblError.Text = "Password and username does not exist.";
                }

            }


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = pwdbPassword.Password;

            if (username == "" || password == "")
            {
                tblError.Text = "Invalid input.";
            }
            else
            {
                //check if combination of username and password exists
                bool exists = DataManager.CheckPlayer(username, password);
                if (exists == false)
                {
                    //if not create the new player with bankaccount and open new window aswell as close the login window
                    DataManager.CreateNewPlayer(username, null, null, password);
                    int uID = DataManager.GetUserID(username);
                    DataManager.CreateBankAccount(uID);


                    MainMenu mWindow = new MainMenu(username);
                    mWindow.Show();
                    Close();


                }
                else
                {
                    //error message if combionation of user and password already exist
                    tblError.Text = "User and password already exists.";
                }
            }



        }
    }
}

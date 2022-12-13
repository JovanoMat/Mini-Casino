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
using System.Media;

namespace MiniCasino_MainWindow
{
    /// <summary>
    /// Interaktionslogik für BankWindow.xaml
    /// </summary>
    public partial class BankWindow : Window
    {

        public BankWindow(string username)
        {
            InitializeComponent();

            Loaded += BankWindow_Loaded;

            sUsername = username;

        }

        SoundPlayer sp = new SoundPlayer();
        
        private string sUsername;
        private void updateTextBlocks()
        {
            int uID = DataManager.GetUserID(sUsername);
            int amountOnHand = DataManager.GetOnHand(uID);
            int amountDeposited = DataManager.GetDeposited(uID);

            tblUsername.Text = sUsername;
            tblOnHand.Text = Convert.ToString(amountOnHand);
            tblDeposited.Text = Convert.ToString(amountDeposited);
        }

        

        private void BankWindow_Loaded(object sender, RoutedEventArgs e)
        {
            updateTextBlocks();

            
            

            //Statische Geräusche
            //Blinkendes Licht

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            sp.Stop();    
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            int uID = DataManager.GetUserID(sUsername);
            int amountOnHand = DataManager.GetOnHand(uID);
            int amountDeposited = DataManager.GetDeposited(uID);

            int amount = 0;

            //Check if tb value is an int
            bool isInt = Int32.TryParse(tbAmount.Text, out amount);
            if (isInt && amount >= 0)
            {
                //Execute the transaction
                DataManager.DepositChips(uID, amount);

                //Check if its affordable
                int amountOnHand2 = DataManager.GetOnHand(uID);
                if (amountOnHand2 < 0)
                {
                    //If its not affordable, revert the changes
                    tblError.Text = "You don't have enough chips.";
                    DataManager.AddToAmountOnHandOrDeposited(uID, amount, true);
                    DataManager.RemoveOfAmountOnHandOrDeposited(uID, amount, false);
                }
                else
                {
                    //Update textblocks
                    updateTextBlocks();
                }
                

            }
            else
            {
                tblError.Text = "Please enter a valid number.";
            }


        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            int uID = DataManager.GetUserID(sUsername);
            int amountOnHand = DataManager.GetOnHand(uID);
            int amountDeposited = DataManager.GetDeposited(uID);

            int amount = 0;

            //Check if tb value is an int
            bool isInt = Int32.TryParse(tbAmount.Text, out amount);
            if (isInt && amount >= 0)
            {
                //Execute the transaction
                DataManager.WithdrawChips(uID, amount);

                //Check if its affordable
                int amountDeposited2 = DataManager.GetDeposited(uID);
                if (amountDeposited2 < 0)
                {
                    //If its not affordable, revert the changes
                    tblError.Text = "You can't afford that.";
                    DataManager.RemoveOfAmountOnHandOrDeposited(uID, amount, true);
                    DataManager.AddToAmountOnHandOrDeposited(uID, amount, false);
                }
                else
                {
                    //Update textblocks
                    updateTextBlocks();
                }


            }
            else
            {
                tblError.Text = "Please enter a valid number.";
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaktionslogik für LuckyWheel.xaml
    /// </summary>
    public partial class LuckyWheel : Window
    {
        public LuckyWheel(string username)
        {
            InitializeComponent();

            Loaded += LuckyWheel_Loaded;

            sUsername = username;
        }

        private string sUsername;


        //https://www.thatsoftwaredude.com/content/1019/how-to-calculate-time-ago-in-c
        public static double GetTimeSince(DateTime objDateTime)
        {
            // here we are going to subtract the passed in DateTime from the current time converted to UTC
            TimeSpan ts = DateTime.Now.Subtract(objDateTime);
            //int intDays = ts.Days;
            double intHours = ts.TotalHours;
            //int intMinutes = ts.Minutes;
            //int intSeconds = ts.Seconds;

            return intHours;
            //if (intDays > 0)
            //    return string.Format("{0} days", intDays);

            //if (intHours > 0)
            //    return string.Format("{0} hours", intHours);

            //if (intMinutes > 0)
            //    return string.Format("{0} minutes", intMinutes);

            //if (intSeconds > 0)
            //    return string.Format("{0} seconds", intSeconds);

            //// let's handle future times..just in case
            //if (intDays < 0)
            //    return string.Format("in {0} days", Math.Abs(intDays));

            //if (intHours < 0)
            //    return string.Format(" in {0} hours", Math.Abs(intHours));

            //if (intMinutes < 0)
            //    return string.Format("in {0} minutes", Math.Abs(intMinutes));

            //if (intSeconds < 0)
            //    return string.Format("in {0} seconds", Math.Abs(intSeconds));

            //return "a bit";
        }


        private void LuckyWheel_Loaded(object sender, RoutedEventArgs e)
        {
            //int uID = DataManager.GetUserID(sUsername);
            //DataManager.UpdateLastSpin(DateTime.Now, uID);

            string lastSpinString = DataManager.GetDateOfLastSpin(sUsername);
            DateTime lastSpin = Convert.ToDateTime(lastSpinString);
            lastSpin.AddDays(1);
            double sinceLastSpin = GetTimeSince(lastSpin);

            //check if last spin was 24 hours ago
            if (sinceLastSpin > 24)
            {
                //if yes enable the spin button
                btnSpin.IsEnabled = true;
                tblTime.Text = "Now!";
            }
            else
            {
                //if not show remaining amount of hours / minutes
                int timeUntilNextSpin = 24 - Convert.ToInt32(Math.Round(Convert.ToDecimal(sinceLastSpin)));

                tblTime.Text = Convert.ToString(timeUntilNextSpin) + " hours";
                if (timeUntilNextSpin == 0)
                {
                    timeUntilNextSpin = Convert.ToInt32(Math.Round((24 - Convert.ToDecimal(sinceLastSpin)) * 60));
                    tblTime.Text = Convert.ToString(timeUntilNextSpin) + " minutes";

                }


            }




        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(5000);
            //timer.Tick += Timer_Tick;

            //generate the win by splitting banks money randomly in 10 parts and picking one out.
            int win = 0;

            while (win == 0)
            {
                Random rg = new Random();
                int pos = rg.Next(0, 10);
                int[] money = GetRandomChipsFromBank();
                win = money[pos];

            }

            //Win message 
            tblWin.Text = Convert.ToString(win);
            tblWinMSG.Text = "You won " + Convert.ToString(win) + " chips!";
            DataManager.RemoveOfAmountOnHandOrDeposited(1, win, false);
            
            //Disable the spin button
            int uID = DataManager.GetUserID(sUsername);

            DataManager.UpdateLastSpin(DateTime.Now, uID);

            btnSpin.IsEnabled = false;

            //show time until next spin (danke max)
            string lastSpinString = DataManager.GetDateOfLastSpin(sUsername);
            DateTime lastSpin = Convert.ToDateTime(lastSpinString);
            lastSpin.AddDays(1);
            double sinceLastSpin = GetTimeSince(lastSpin);

            int timeUntilNextSpin = 24 - Convert.ToInt32(Math.Round(Convert.ToDecimal(sinceLastSpin)));

            tblTime.Text = Convert.ToString(timeUntilNextSpin) + " hours";
            if (timeUntilNextSpin == 0)
            {
                timeUntilNextSpin = Convert.ToInt32(Math.Round((24 - Convert.ToDecimal(sinceLastSpin)) * 60));
                tblTime.Text = Convert.ToString(timeUntilNextSpin) + " minutes";

            }


            DataManager.AddToAmountOnHandOrDeposited(uID, win, true);



        }

        private static int[] GetRandomChipsFromBank()
        {
            int amount = DataManager.GetChipsFromBank();
            int n = 0;

            int[] divideBy = new int[10];
            int[] banksMoneyDivided = new int[10];
            Random rg = new Random();

            for (int i = 0; i < divideBy.Length; i++)
            {
                divideBy[i] = rg.Next(1, 10);
            }
            foreach (var item in divideBy)
            {
                banksMoneyDivided[n] = (amount / item);
                amount = amount / item;
                n += 1;
            }

            return banksMoneyDivided;

        }

        //private void Timer_Tick(object sender, EventArgs e)
        //{

        //    int n = 0;
        //    int[] money = GetRandomChipsFromBank();
        //    tblWin.Text = Convert.ToString(money[n]);



        //    // Forcing the CommandManager to raise the RequerySuggested event
        //    CommandManager.InvalidateRequerySuggested();
        //    n += 1;
        //}

        
    }
}

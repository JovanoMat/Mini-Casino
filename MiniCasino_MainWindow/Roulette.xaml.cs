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
    /// Interaktionslogik für Roulette.xaml
    /// </summary>
    public partial class Roulette : Window
    {
        public Roulette(string username)
        {
            InitializeComponent();

            sUsername = username;
            uID = DataManager.GetUserID(username);
            int money = DataManager.GetOnHand(uID);
            tblMoney.Text = $"{money} chips";
        }

        private int uID;
        private string sUsername;
        List<string> selectedSlots = new List<string>();
        List<string> history = new List<string>();

        List<string> table = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36"};


        
        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btn1Amount_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "1";
            
        }

        private void btn5Amount_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "5";

        }

        private void btn10Amount_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "10";

        }

        private void btn50Amount_Click(object sender, RoutedEventArgs e)
        {
            tbAmount.Text = "50";

        }

        Color c = Color.FromRgb(165, 141, 0);
        Color blue = Color.FromRgb(158,250,255);
        Color black = Color.FromRgb(12,3,28);
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("1"))
            {
                selectedSlots.Remove("1");
                btn1.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("1");
                btn1.Background = new SolidColorBrush(c);

            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("2"))
            {
                selectedSlots.Remove("2");
                btn2.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("2");
                btn2.Background = new SolidColorBrush(c);

            }

        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("3"))
            {
                selectedSlots.Remove("3");
                btn3.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("3");
                btn3.Background = new SolidColorBrush(c);

            }

        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("4"))
            {
                selectedSlots.Remove("4");
                btn4.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("4");
                btn4.Background = new SolidColorBrush(c);

            }

        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("5"))
            {
                selectedSlots.Remove("5");
                btn5.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("5");
                btn5.Background = new SolidColorBrush(c);

            }

        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("6"))
            {
                selectedSlots.Remove("6");
                btn6.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("6");
                btn6.Background = new SolidColorBrush(c);

            }

        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("7"))
            {
                selectedSlots.Remove("7");
                btn7.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("7");
                btn7.Background = new SolidColorBrush(c);

            }

        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("8"))
            {
                selectedSlots.Remove("8");
                btn8.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("8");
                btn8.Background = new SolidColorBrush(c);

            }

        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("9"))
            {
                selectedSlots.Remove("9");
                btn9.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("9");
                btn9.Background = new SolidColorBrush(c);

            }

        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("10"))
            {
                selectedSlots.Remove("10");
                btn10.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("10");
                btn10.Background = new SolidColorBrush(c);

            }
        }

        private void btn11_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("11"))
            {
                selectedSlots.Remove("11");
                btn11.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("11");
                btn11.Background = new SolidColorBrush(c);

            }
        }

        private void btn12_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("12"))
            {
                selectedSlots.Remove("12");
                btn12.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("12");
                btn12.Background = new SolidColorBrush(c);

            }
        }

        private void btn13_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("13"))
            {
                selectedSlots.Remove("13");
                btn13.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("13");
                btn13.Background = new SolidColorBrush(c);

            }
        }

        private void btn14_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("14"))
            {
                selectedSlots.Remove("14");
                btn14.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("14");
                btn14.Background = new SolidColorBrush(c);

            }
        }

        private void btn15_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("15"))
            {
                selectedSlots.Remove("15");
                btn15.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("15");
                btn15.Background = new SolidColorBrush(c);

            }
        }

        private void btn16_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("16"))
            {
                selectedSlots.Remove("16");
                btn16.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("16");
                btn16.Background = new SolidColorBrush(c);

            }
        }

        private void btn17_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("17"))
            {
                selectedSlots.Remove("17");
                btn17.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("17");
                btn17.Background = new SolidColorBrush(c);

            }
        }

        private void btn18_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("18"))
            {
                selectedSlots.Remove("18");
                btn18.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("18");
                btn18.Background = new SolidColorBrush(c);

            }
        }

        private void btn19_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("19"))
            {
                selectedSlots.Remove("19");
                btn19.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("19");
                btn19.Background = new SolidColorBrush(c);

            }
        }

        private void btn20_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("20"))
            {
                selectedSlots.Remove("20");
                btn20.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("20");
                btn20.Background = new SolidColorBrush(c);

            }
        }

        private void btn21_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("21"))
            {
                selectedSlots.Remove("21");
                btn21.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("21");
                btn21.Background = new SolidColorBrush(c);

            }
        }

        private void btn22_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("22"))
            {
                selectedSlots.Remove("22");
                btn22.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("22");
                btn22.Background = new SolidColorBrush(c);

            }
        }

        private void btn23_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("23"))
            {
                selectedSlots.Remove("23");
                btn23.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("23");
                btn23.Background = new SolidColorBrush(c);

            }
        }

        private void btn24_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("24"))
            {
                selectedSlots.Remove("24");
                btn24.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("24");
                btn24.Background = new SolidColorBrush(c);

            }
        }

        private void btn25_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("25"))
            {
                selectedSlots.Remove("25");
                btn25.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("25");
                btn25.Background = new SolidColorBrush(c);

            }
        }

        private void btn26_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("26"))
            {
                selectedSlots.Remove("26");
                btn26.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("26");
                btn26.Background = new SolidColorBrush(c);

            }
        }

        private void btn27_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("27"))
            {
                selectedSlots.Remove("27");
                btn27.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("27");
                btn27.Background = new SolidColorBrush(c);

            }
        }

        private void btn28_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("28"))
            {
                selectedSlots.Remove("28");
                btn28.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("28");
                btn28.Background = new SolidColorBrush(c);

            }
        }

        private void btn29_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("29"))
            {
                selectedSlots.Remove("29");
                btn29.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("29");
                btn29.Background = new SolidColorBrush(c);

            }
        }

        private void btn30_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("30"))
            {
                selectedSlots.Remove("30");
                btn30.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("30");
                btn30.Background = new SolidColorBrush(c);

            }
        }

        private void btn31_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("31"))
            {
                selectedSlots.Remove("31");
                btn31.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("31");
                btn31.Background = new SolidColorBrush(c);

            }
        }

        private void btn32_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("32"))
            {
                selectedSlots.Remove("32");
                btn32.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("32");
                btn32.Background = new SolidColorBrush(c);

            }
        }

        private void btn33_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("33"))
            {
                selectedSlots.Remove("33");
                btn33.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("33");
                btn33.Background = new SolidColorBrush(c);

            }
        }

        private void btn34_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("34"))
            {
                selectedSlots.Remove("34");
                btn34.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("34");
                btn34.Background = new SolidColorBrush(c);

            }
        }

        private void btn35_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("35"))
            {
                selectedSlots.Remove("35");
                btn35.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("35");
                btn35.Background = new SolidColorBrush(c);

            }
        }

        private void btn36_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("36"))
            {
                selectedSlots.Remove("36");
                btn36.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("36");
                btn36.Background = new SolidColorBrush(c);

            }
        }

        Color t = Color.FromArgb(0, 0, 0, 0);
        private void btn2to1_1_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("3-36"))
            {
                selectedSlots.Remove("3-36");
                btn2to1_1.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("3-36");
                btn2to1_1.Background = new SolidColorBrush(c);

            }
        }

        private void btn2to1_2_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("2-35"))
            {
                selectedSlots.Remove("2-35");
                btn2to1_2.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("2-35");
                btn2to1_2.Background = new SolidColorBrush(c);

            }
        }

        private void btn2to1_3_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("1-34"))
            {
                selectedSlots.Remove("1-34");
                btn2to1_3.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("1-34");
                btn2to1_3.Background = new SolidColorBrush(c);

            }
        }

        private void btn12_1_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("1-12"))
            {
                selectedSlots.Remove("1-12");
                btn12_1.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("1-12");
                btn12_1.Background = new SolidColorBrush(c);

            }

        }

        private void btn12_2_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("13-24"))
            {
                selectedSlots.Remove("13-24");
                btn12_2.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("13-24");
                btn12_2.Background = new SolidColorBrush(c);

            }
        }

        private void btn12_3_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("25-36"))
            {
                selectedSlots.Remove("25-36");
                btn12_3.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("25-36");
                btn12_3.Background = new SolidColorBrush(c);

            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("0"))
            {
                selectedSlots.Remove("0");
                btn0.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("0");
                btn0.Background = new SolidColorBrush(c);

            }
        }

        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("00"))
            {
                selectedSlots.Remove("00");
                btn00.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("00");
                btn00.Background = new SolidColorBrush(c);

            }
        }

        private void btn1to18_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("1-18"))
            {
                selectedSlots.Remove("1-18");
                btn1to18.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("1-18");
                btn1to18.Background = new SolidColorBrush(c);

            }
        }

        private void btn19to36_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("19-36"))
            {
                selectedSlots.Remove("19-36");
                btn19to36.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("19-36");
                btn19to36.Background = new SolidColorBrush(c);

            }
        }

        private void btnOdd_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("Odd"))
            {
                selectedSlots.Remove("Odd");
                btnOdd.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("Odd");
                btnOdd.Background = new SolidColorBrush(c);

            }
        }

        private void btnEven_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("Even"))
            {
                selectedSlots.Remove("Even");
                btnEven.Background = new SolidColorBrush(t);


            }
            else
            {
                selectedSlots.Add("Even");
                btnEven.Background = new SolidColorBrush(c);

            }
        }

        private void btnBlack_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("Black"))
            {
                selectedSlots.Remove("Black");
                btnBlack.Background = new SolidColorBrush(black);


            }
            else
            {
                selectedSlots.Add("Black");
                btnBlack.Background = new SolidColorBrush(c);

            }
        }

        private void btnBlue_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSlots.Contains("Blue"))
            {
                selectedSlots.Remove("Blue");
                btnBlue.Background = new SolidColorBrush(blue);


            }
            else
            {
                selectedSlots.Add("Blue");
                btnBlue.Background = new SolidColorBrush(c);

            }
        }
        int bet = 0;
        int win = 0 ;
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            int uID = DataManager.GetUserID(sUsername);
            Random rg = new Random();
            string role = table[rg.Next(0, table.Count)];

            bool isInt = Int32.TryParse(tbAmount.Text, out bet);
            bet = bet * selectedSlots.Count;
            int moneyOnHand = DataManager.GetOnHand(uID);
            int newOnHand = moneyOnHand - bet;

            if (selectedSlots.Count != 0)
            {
                if (newOnHand >= 0)
                {
                    if (isInt && bet > 0)
                    {
                        tblRoled.Text = "Roled: " + role;
                        history.Insert(0, role);

                        switch (role)
                        {
                            case "1":
                                if (selectedSlots.Contains("1"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "2":
                                if (selectedSlots.Contains("2"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "3":
                                if (selectedSlots.Contains("3"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "4":
                                if (selectedSlots.Contains("4"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "5":
                                if (selectedSlots.Contains("5"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "6":
                                if (selectedSlots.Contains("6"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "7":
                                if (selectedSlots.Contains("7"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "8":
                                if (selectedSlots.Contains("7"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "9":
                                if (selectedSlots.Contains("9"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "10":
                                if (selectedSlots.Contains("10"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "11":
                                if (selectedSlots.Contains("11"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "12":
                                if (selectedSlots.Contains("12"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-12"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "13":
                                if (selectedSlots.Contains("13"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "14":
                                if (selectedSlots.Contains("14"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "15":
                                if (selectedSlots.Contains("15"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "16":
                                if (selectedSlots.Contains("16"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "17":
                                if (selectedSlots.Contains("17"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "18":
                                if (selectedSlots.Contains("18"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("1-18"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "19":
                                if (selectedSlots.Contains("19"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "20":
                                if (selectedSlots.Contains("20"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "21":
                                if (selectedSlots.Contains("21"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                    }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "22":
                                if (selectedSlots.Contains("22"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "23":
                                if (selectedSlots.Contains("23"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "24":
                                if (selectedSlots.Contains("24"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("13-24"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "25":
                                if (selectedSlots.Contains("25"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "26":
                                if (selectedSlots.Contains("26"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "27":
                                if (selectedSlots.Contains("27"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "28":
                                if (selectedSlots.Contains("28"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "29":
                                if (selectedSlots.Contains("29"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "30":
                                if (selectedSlots.Contains("30"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "31":
                                if (selectedSlots.Contains("31"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "32":
                                if (selectedSlots.Contains("32"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "33":
                                if (selectedSlots.Contains("33"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "34":
                                if (selectedSlots.Contains("34"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("1-34"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "35":
                                if (selectedSlots.Contains("35"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("2-35"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Odd"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Blue"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;
                            case "36":
                                if (selectedSlots.Contains("36"))
                                {
                                    win += bet * 35;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("25-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("3-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);
                                }
                                if (selectedSlots.Contains("Even"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("Black"))
                                {
                                    win += bet * 2;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                if (selectedSlots.Contains("19-36"))
                                {
                                    win += bet * 3;
                                    DataManager.AddToAmountOnHandOrDeposited(uID, win, true);

                                }
                                break;

                        }

                        if (win != 0)
                        {
                            DataManager.AddPoints(uID, win, DateTime.Now, "Roulette");
                            tblMsg.Text = $"You won {win} chips!";

                        }
                        else
                        {
                            tblMsg.Text = "You lost!";
                            DataManager.RemoveOfAmountOnHandOrDeposited(uID, bet, true);
                        }

                        //update at the end
                        int money = DataManager.GetOnHand(uID);
                        tblMoney.Text = $"{money} chips";
                        selectedSlots.Clear();
                        win = 0;
                        bet = 0;

                        btn1.Background = new SolidColorBrush(black);
                        btn2.Background = new SolidColorBrush(blue);
                        btn3.Background = new SolidColorBrush(black);
                        btn4.Background = new SolidColorBrush(blue);
                        btn5.Background = new SolidColorBrush(black);
                        btn6.Background = new SolidColorBrush(blue);
                        btn7.Background = new SolidColorBrush(black);
                        btn8.Background = new SolidColorBrush(blue);
                        btn9.Background = new SolidColorBrush(black);
                        btn10.Background = new SolidColorBrush(blue);
                        btn11.Background = new SolidColorBrush(blue);
                        btn12.Background = new SolidColorBrush(black);
                        btn13.Background = new SolidColorBrush(blue);
                        btn14.Background = new SolidColorBrush(black);
                        btn15.Background = new SolidColorBrush(blue);
                        btn16.Background = new SolidColorBrush(black);
                        btn17.Background = new SolidColorBrush(blue);
                        btn18.Background = new SolidColorBrush(black);
                        btn19.Background = new SolidColorBrush(black);
                        btn20.Background = new SolidColorBrush(blue);
                        btn21.Background = new SolidColorBrush(black);
                        btn22.Background = new SolidColorBrush(blue);
                        btn23.Background = new SolidColorBrush(black);
                        btn24.Background = new SolidColorBrush(blue);
                        btn25.Background = new SolidColorBrush(black);
                        btn26.Background = new SolidColorBrush(blue);
                        btn27.Background = new SolidColorBrush(black);
                        btn28.Background = new SolidColorBrush(blue);
                        btn29.Background = new SolidColorBrush(blue);
                        btn30.Background = new SolidColorBrush(black);
                        btn31.Background = new SolidColorBrush(blue);
                        btn32.Background = new SolidColorBrush(black);
                        btn33.Background = new SolidColorBrush(blue);
                        btn34.Background = new SolidColorBrush(black);
                        btn35.Background = new SolidColorBrush(blue);
                        btn36.Background = new SolidColorBrush(black);
                        btn0.Background = new SolidColorBrush(t);
                        btn00.Background = new SolidColorBrush(t);
                        btn2to1_1.Background = new SolidColorBrush(t);
                        btn2to1_2.Background = new SolidColorBrush(t);
                        btn2to1_3.Background = new SolidColorBrush(t);
                        btn12_1.Background = new SolidColorBrush(t);
                        btn12_2.Background = new SolidColorBrush(t);
                        btn12_3.Background = new SolidColorBrush(t);
                        btn1to18.Background = new SolidColorBrush(t);
                        btn19to36.Background = new SolidColorBrush(t);
                        btnEven.Background = new SolidColorBrush(t);
                        btnOdd.Background = new SolidColorBrush(t);
                        btnBlack.Background = new SolidColorBrush(black);
                        btnBlue.Background = new SolidColorBrush(blue);


                    }
                    else
                    {
                        tblMsg.Text = "Invalid bet.";
                    }

                }
                else
                {
                    tblMsg.Text = "You can't afford that";
                }
            }
            else
            {
                tblMsg.Text = "Please select your slots.";
            }


            

            


        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            history hWindow = new history(history);
            hWindow.Show();
        }

        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            rules r = new rules();
            r.Show();
        }
    }
}

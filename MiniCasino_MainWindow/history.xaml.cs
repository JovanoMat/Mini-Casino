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

namespace MiniCasino_MainWindow
{
    /// <summary>
    /// Interaktionslogik für history.xaml
    /// </summary>
    public partial class history : Window
    {
        public history(List<string> history)
        {
            InitializeComponent();

            lbHistory.ItemsSource = history;
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

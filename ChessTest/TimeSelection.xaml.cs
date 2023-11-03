using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ChessTest
{
    public partial class TimeSelection : Window
    {
        public int TotalTime;
        public TimeSelection()
        {
            InitializeComponent();
        }
        public void Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse((sender as Button)?.Tag.ToString(), out int selectedTime))
            {
                TotalTime = selectedTime;
                DialogResult = true;
            }
        }
    }
}

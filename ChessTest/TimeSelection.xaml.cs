using System.Windows;
using System.Windows.Controls;

namespace ChessTest
{
    public partial class TimeSelection : Window
    {
        public static double TotalTime;

        // Times for bullet games
        private readonly string[] Bullet = { "0.50", "1", "2" };

        // Times for blitz games
        private readonly string[] Blitz = { "3", "5", "7.50" };

        // Times for rapid games
        private readonly string[] Rapid = { "10", "15", "25" };

        public TimeSelection()
        {
            InitializeComponent();
        }
        
        private void ChangeBullet(object sender, RoutedEventArgs e)
        {
            int idx = 0;
            foreach (Button button in time.Children)
            {
                button.Content = Bullet[idx] + " Minutes";
                button.Tag = Bullet[idx++];
                button.Click -= ChangeBullet;
                button.Click -= ChangeBlitz;
                button.Click -= ChangeRapid;
                button.Click += Click;
            }
        }
        private void ChangeBlitz(object sender, RoutedEventArgs e)
        {
            int idx = 0;
            foreach (Button button in time.Children)
            {
                button.Content = Blitz[idx] + " Minutes";
                button.Tag = Blitz[idx++];
                button.Click -= ChangeBullet;
                button.Click -= ChangeBlitz;
                button.Click -= ChangeRapid;
                button.Click += Click;
            }
        }
        private void ChangeRapid(object sender, RoutedEventArgs e)
        {
            int idx = 0;
            foreach (Button button in time.Children)
            {
                button.Content = Rapid[idx] + " Minutes";
                button.Tag = Rapid[idx++];
                button.Click -= ChangeBullet;
                button.Click -= ChangeBlitz;
                button.Click -= ChangeRapid;
                button.Click += Click;
            }
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse((sender as Button)?.Tag.ToString(), out double selectedTime))
            {
                TotalTime = selectedTime;
                ChessBoard chessBoard = new ChessBoard
                {
                    Left = 100,
                    Top = 100
                };
                chessBoard.Show();
                Close();
            }
        }
    }
}

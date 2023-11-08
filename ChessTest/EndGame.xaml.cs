using System.Windows;

namespace ChessTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public EndGame()
        {
            string result = ChessBoard.whiteLost == 0 ? "White Is The Winner" : "Black Is The Winner";
            ChessBoard.whiteLost = 0;
            ChessBoard.blackLost = 0;
            InitializeComponent();
            Winner.Content = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TimeSelection timeSelection = new TimeSelection
            {
                Left = 100,
                Top = 100
            };
            timeSelection.Show();
            Close();
        }
    }
}

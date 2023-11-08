using System.Windows;

namespace ChessTest
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public static int WhiteWins = 0;
        public static int BlackWins = 0;
        public EndGame()
        {
            string result = ChessBoard.whiteLost == 0 ? "White Is The Winner" : "Black Is The Winner";
            WhiteWins += ChessBoard.blackLost;
            BlackWins += ChessBoard.whiteLost;
            ChessBoard.whiteLost = 0;
            ChessBoard.blackLost = 0;
            InitializeComponent();
            Winner.Content = result;
            WhiteScore.Content = "White: " + WhiteWins;
            BlackScore.Content = "Black: " + BlackWins;
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

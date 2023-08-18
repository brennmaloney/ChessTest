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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Image WhitePawn = new Image();
            Image WhiteKnight = new Image();
            Image WhiteBishop = new Image();
            Image WhiteRook = new Image();
            Image WhiteQueen = new Image();
            Image WhiteKing = new Image();
            Image BlackPawn = new Image();
            Image BlackKnight = new Image();
            Image BlackBishop = new Image();
            Image BlackRook = new Image();
            Image BlackQueen = new Image();
            Image BlackKing = new Image();

            WhitePawn.Source = new BitmapImage(new Uri(@"/ChessTest;components/Images/WhitePawn.png", UriKind.Relative));
            

            

        }
    }
}

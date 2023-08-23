using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;



namespace ChessTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        
    public partial class MainWindow : Window
    {

        private bool isDragging = false;
        private UIElement draggedPiece;
        private Image originalImage;
        private Image pieceImage;
        private Point startPosition;
        private Point originalPosition;
        private ImageSource originalSource;
        private Dictionary<string, ImageSource> pieceImageSources = new Dictionary<String, ImageSource>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pieceImageSources["A8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["B8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["C8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["D8"] = new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["E8"] = new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["F8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["G8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["H8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));

            pieceImageSources["A7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["B7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["C7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["D7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["E7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["F7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["G7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["H7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));

            pieceImageSources["A6"] = null;
            pieceImageSources["B6"] = null;
            pieceImageSources["C6"] = null;
            pieceImageSources["D6"] = null;
            pieceImageSources["E6"] = null;
            pieceImageSources["F6"] = null;
            pieceImageSources["G6"] = null;
            pieceImageSources["H6"] = null;

            pieceImageSources["A5"] = null;
            pieceImageSources["B5"] = null;
            pieceImageSources["C5"] = null;
            pieceImageSources["D5"] = null;
            pieceImageSources["E5"] = null;
            pieceImageSources["F5"] = null;
            pieceImageSources["G5"] = null;
            pieceImageSources["H5"] = null;

            pieceImageSources["A4"] = null;
            pieceImageSources["B4"] = null;
            pieceImageSources["C4"] = null;
            pieceImageSources["D4"] = null;
            pieceImageSources["E4"] = null;
            pieceImageSources["F4"] = null;
            pieceImageSources["G4"] = null;
            pieceImageSources["H4"] = null;

            pieceImageSources["A3"] = null;
            pieceImageSources["B3"] = null;
            pieceImageSources["C3"] = null;
            pieceImageSources["D3"] = null;
            pieceImageSources["E3"] = null;
            pieceImageSources["F3"] = null;
            pieceImageSources["G3"] = null;
            pieceImageSources["H3"] = null;

            pieceImageSources["A2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["B2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["C2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["D2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["E2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["F2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["G2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["H2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));

            pieceImageSources["A1"] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["B1"] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["C1"] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["D1"] = new BitmapImage(new Uri("/Images/WhiteQueen.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["E1"] = new BitmapImage(new Uri("/Images/WhiteKing.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["F1"] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["G1"] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources["H1"] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
        }

        private void SquareMouseDown(object sender, MouseButtonEventArgs e)
        {
            originalImage = (sender as Grid)?.Children.OfType<Image>().FirstOrDefault();
            if (originalImage == null) return;


            draggedPiece = sender as UIElement;
            startPosition = e.GetPosition(board);
            originalPosition = new Point(Canvas.GetLeft(originalImage), Canvas.GetTop(originalImage));
            pieceImage = originalImage;
            originalSource = originalImage.Source;
            isDragging = true;
        }

        private void SquareMouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging && draggedPiece != null)
            {
                Point currentPosition = e.GetPosition(board);
                double offsetX = currentPosition.X - startPosition.X;
                double offsetY = currentPosition.Y - startPosition.Y;

                Canvas.SetLeft(draggedPiece, originalPosition.X + offsetX);
                Canvas.SetTop(draggedPiece, originalPosition.Y + offsetY);
            }
        }

        private void SquareMouseUp(object sender, MouseButtonEventArgs e)
        {
            Grid clickedSquare = sender as Grid;
            if(clickedSquare != null)
            {
                string squareName = clickedSquare.Name;

                Debug.WriteLine(squareName);
            }
            if(isDragging && draggedPiece != null)
            {
                if(originalImage != null)
                {
                    originalImage.Source = originalSource;
                    Debug.WriteLine(originalImage.Source);
                }
                draggedPiece = null;
                isDragging = false;
                pieceImage = null;
            }
        }
    }
}

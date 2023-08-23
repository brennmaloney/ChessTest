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
        private Dictionary<Image, ImageSource> pieceImageSources = new Dictionary<Image, ImageSource>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pieceImageSources[BPawn1] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn2] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn3] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn4] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn5] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn6] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BPawn7] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BRook1] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BRook2] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BKnight1] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BKnight2] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BBishop1] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BBishop2] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BKing] = new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[BQueen] = new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute));

            pieceImageSources[WPawn1] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn2] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn3] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn4] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn5] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn6] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WPawn7] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WRook1] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WRook2] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WKnight1] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WKnight2] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WBishop1] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WBishop2] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WKing] = new BitmapImage(new Uri("/Images/WhiteKing.png", UriKind.RelativeOrAbsolute));
            pieceImageSources[WQueen] = new BitmapImage(new Uri("/Images/WhiteQueen.png", UriKind.RelativeOrAbsolute));
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
            if(isDragging && draggedPiece != null)
            {
                originalImage.Source = originalSource;

                //ImageSource tempSource = pieceImageSources[originalImage];

                //pieceImage.Source = tempSource;




                draggedPiece = null;
                isDragging = false;
                pieceImage = null;
            }
        }
    }
}

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
        private Grid draggedPiece;
        private Image originalImage;
        private Image pieceImage;
        private Point startPosition;
        private Point originalPosition;
        private ImageSource originalSource;
        private Dictionary<string, ImageSource> pieceSources = new Dictionary<String, ImageSource>();

        public MainWindow()
        {
            InitializeComponent();
            Loaded += WindowLoaded;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pieceSources["B8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["C8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["D8"] = new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute));
            pieceSources["E8"] = new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute));
            pieceSources["F8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["G8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["H8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));

            pieceSources["A8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));
            pieceSources["A7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["B7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["C7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["D7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["E7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["F7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["G7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["H7"] = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute));

            pieceSources["A6"] = null;
            pieceSources["B6"] = null;
            pieceSources["C6"] = null;
            pieceSources["D6"] = null;
            pieceSources["E6"] = null;
            pieceSources["F6"] = null;
            pieceSources["G6"] = null;
            pieceSources["H6"] = null;

            pieceSources["A5"] = null;
            pieceSources["B5"] = null;
            pieceSources["C5"] = null;
            pieceSources["D5"] = null;
            pieceSources["E5"] = null;
            pieceSources["F5"] = null;
            pieceSources["G5"] = null;
            pieceSources["H5"] = null;

            pieceSources["A4"] = null;
            pieceSources["B4"] = null;
            pieceSources["C4"] = null;
            pieceSources["D4"] = null;
            pieceSources["E4"] = null;
            pieceSources["F4"] = null;
            pieceSources["G4"] = null;
            pieceSources["H4"] = null;

            pieceSources["A3"] = null;
            pieceSources["B3"] = null;
            pieceSources["C3"] = null;
            pieceSources["D3"] = null;
            pieceSources["E3"] = null;
            pieceSources["F3"] = null;
            pieceSources["G3"] = null;
            pieceSources["H3"] = null;

            pieceSources["A2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["B2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["C2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["D2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["E2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["F2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["G2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));
            pieceSources["H2"] = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute));

            pieceSources["A1"] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
            pieceSources["B1"] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["C1"] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["D1"] = new BitmapImage(new Uri("/Images/WhiteQueen.png", UriKind.RelativeOrAbsolute));
            pieceSources["E1"] = new BitmapImage(new Uri("/Images/WhiteKing.png", UriKind.RelativeOrAbsolute));
            pieceSources["F1"] = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["G1"] = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["H1"] = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute));
        }

        private void SquareMouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid square = sender as Grid;
            if(pieceSources.ContainsKey(square.Name) && pieceSources[square.Name] != null)
            {
                draggedPiece = square;
                startPosition = e.GetPosition(draggedPiece);

                pieceImage = new Image
                {
                    Source = pieceSources[square.Name],
                    Width = 100,
                    Height = 100,
                    Opacity = 0.8
                };
                pieceImage.MouseMove += SquareMouseMove;
                pieceImage.MouseUp += SquareMouseUp;

                board.Children.Add(pieceImage);

                Canvas.SetLeft(pieceImage, 0);
                Canvas.SetTop(pieceImage, 0);

                isDragging = true;
            }
        }

        private void SquareMouseMove(object sender, MouseEventArgs e)
        {
            if(isDragging && pieceImage != null)
            {
                Point currentPosition = e.GetPosition(board);
                double offsetX = currentPosition.X - startPosition.X;
                double offsetY = currentPosition.Y - startPosition.Y;

                Canvas.SetLeft(pieceImage, Canvas.GetLeft(pieceImage) + offsetX);
                Canvas.SetTop(pieceImage, Canvas.GetTop(pieceImage) + offsetY);

                startPosition = currentPosition;
            }
        }

        private void SquareMouseUp(object sender, MouseButtonEventArgs e)
        {
            if(isDragging && pieceImage != null)
            {
                Grid targetSquare = FindSquareUnderMouse(e.GetPosition(board));
                if (targetSquare != null)
                {
                    pieceSources[targetSquare.Name] = pieceSources[draggedPiece.Name];
                    pieceSources[draggedPiece.Name] = null;
                    Debug.WriteLine(pieceSources[targetSquare.Name]);
                }

                for (int i = 1; i < 9; ++i) 
                {
                    string A = "A";
                    A = string.Concat(A, i.ToString());
                    string B = "B";
                    B = string.Concat(B, i.ToString());
                    string C = "C";
                    C = string.Concat(C, i.ToString());
                    string D = "D";
                    D = string.Concat(D, i.ToString());
                    string E = "E";
                    E = string.Concat(E, i.ToString());
                    string F = "F";
                    F = string.Concat(F, i.ToString());
                    string G = "G";
                    G = string.Concat(G, i.ToString());
                    string H = "H";
                    H = string.Concat(H, i.ToString());

                    Grid A_Update = FindName(A) as Grid;
                    Grid B_Update = FindName(B) as Grid;
                    Grid C_Update = FindName(C) as Grid;
                    Grid D_Update = FindName(D) as Grid;
                    Grid E_Update = FindName(E) as Grid;
                    Grid F_Update = FindName(F) as Grid;
                    Grid G_Update = FindName(G) as Grid;
                    Grid H_Update = FindName(H) as Grid;

                    Image A_ImageUpdate = A_Update.Children[0] as Image;
                    Image B_ImageUpdate = B_Update.Children[0] as Image;
                    Image C_ImageUpdate = C_Update.Children[0] as Image;
                    Image D_ImageUpdate = D_Update.Children[0] as Image;
                    Image E_ImageUpdate = E_Update.Children[0] as Image;
                    Image F_ImageUpdate = F_Update.Children[0] as Image;
                    Image G_ImageUpdate = G_Update.Children[0] as Image;
                    Image H_ImageUpdate = H_Update.Children[0] as Image;

                    A_ImageUpdate.Source = pieceSources[A];
                    B_ImageUpdate.Source = pieceSources[B];
                    C_ImageUpdate.Source = pieceSources[C];
                    D_ImageUpdate.Source = pieceSources[D];
                    E_ImageUpdate.Source = pieceSources[E];
                    F_ImageUpdate.Source = pieceSources[F];
                    G_ImageUpdate.Source = pieceSources[G];
                    H_ImageUpdate.Source = pieceSources[H];
                }

                board.Children.Remove(pieceImage);
                isDragging = false;
                draggedPiece = null;
            }
        }

        private Grid FindSquareUnderMouse(Point mousePosition)
        {
            foreach (UIElement child in board.Children)
            {
                if (child is Grid square && IsMouseOverSquare(square, mousePosition))
                {
                    Debug.WriteLine(square.Name);
                    return square;
                }
            }
            return null;
        }

        private bool IsMouseOverSquare(UIElement element, Point mousePosition)
        {
            Point elementPosition = element.TranslatePoint(new Point(0, 0), board);
            Rect elementBounds = new Rect(elementPosition, element.RenderSize);
            return elementBounds.Contains(mousePosition);
        }
    }
}

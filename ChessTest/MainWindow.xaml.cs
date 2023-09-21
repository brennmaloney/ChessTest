using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
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
        private Image pieceImage;
        private Point startPosition;
        private int turn = 1; // 1 for white 0 for black
        private int start = 0;
        private int gameover = 0;
        private Dictionary<string, ImageSource> pieceSources = new Dictionary<String, ImageSource>();
        private Dictionary<string, int> pieceValues = new Dictionary<string, int>();

        private TimeSpan whiteTime = TimeSpan.FromMinutes(5);
        private TimeSpan blackTime = TimeSpan.FromMinutes(5);

        DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Render);

        public MainWindow()
        {
            InitializeComponent();
            Loaded += WindowLoaded;


            timerWhite.Content = whiteTime.ToString("mm\\:ss");
            timerBlack.Content = blackTime.ToString("mm\\:ss");
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            pieceSources["A8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));
            pieceSources["B8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["C8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["D8"] = new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute));
            pieceSources["E8"] = new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute));
            pieceSources["F8"] = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute));
            pieceSources["G8"] = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute));
            pieceSources["H8"] = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute));

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

            pieceValues["A8"] = -5;
            pieceValues["B8"] = -3;
            pieceValues["C8"] = -3;
            pieceValues["D8"] = -9;
            pieceValues["E8"] = -100;
            pieceValues["F8"] = -3;
            pieceValues["G8"] = -3;
            pieceValues["H8"] = -5;
                                 
            pieceValues["A7"] = -1;
            pieceValues["B7"] = -1;
            pieceValues["C7"] = -1;
            pieceValues["D7"] = -1;
            pieceValues["E7"] = -1;
            pieceValues["F7"] = -1;
            pieceValues["G7"] = -1;
            pieceValues["H7"] = -1;

            pieceValues["A6"] = 0;
            pieceValues["B6"] = 0;
            pieceValues["C6"] = 0;
            pieceValues["D6"] = 0;
            pieceValues["E6"] = 0;
            pieceValues["F6"] = 0;
            pieceValues["G6"] = 0;
            pieceValues["H6"] = 0;
                                
            pieceValues["A5"] = 0;
            pieceValues["B5"] = 0;
            pieceValues["C5"] = 0;
            pieceValues["D5"] = 0;
            pieceValues["E5"] = 0;
            pieceValues["F5"] = 0;
            pieceValues["G5"] = 0;
            pieceValues["H5"] = 0;
                                
            pieceValues["A4"] = 0;
            pieceValues["B4"] = 0;
            pieceValues["C4"] = 0;
            pieceValues["D4"] = 0;
            pieceValues["E4"] = 0;
            pieceValues["F4"] = 0;
            pieceValues["G4"] = 0;
            pieceValues["H4"] = 0;
                                
            pieceValues["A3"] = 0;
            pieceValues["B3"] = 0;
            pieceValues["C3"] = 0;
            pieceValues["D3"] = 0;
            pieceValues["E3"] = 0;
            pieceValues["F3"] = 0;
            pieceValues["G3"] = 0;
            pieceValues["H3"] = 0;
                 
            pieceValues["A2"] = 1;
            pieceValues["B2"] = 1;
            pieceValues["C2"] = 1;
            pieceValues["D2"] = 1;
            pieceValues["E2"] = 1;
            pieceValues["F2"] = 1;
            pieceValues["G2"] = 1;
            pieceValues["H2"] = 1;

            pieceValues["A1"] = 5;
            pieceValues["B1"] = 3;
            pieceValues["C1"] = 3;
            pieceValues["D1"] = 9;
            pieceValues["E1"] = 100;
            pieceValues["F1"] = 3;
            pieceValues["G1"] = 3;
            pieceValues["H1"] = 5;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (start == 1)
            {
                if (whiteTime.TotalSeconds < 0)
                {
                    gameover = 1;
                    start = 0;
                }
                else if (blackTime.TotalSeconds < 0)
                {
                    gameover = 1;
                    start = 0;
                }
                else if (turn == 1)
                {
                    whiteTime = whiteTime.Add(TimeSpan.FromSeconds(-1));
                    timerWhite.Content = whiteTime.ToString("mm\\:ss");
                }
                else
                {
                    blackTime = blackTime.Add(TimeSpan.FromSeconds(-1));
                    timerBlack.Content = blackTime.ToString("mm\\:ss");
                }
            }
        }

        private void SquareMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameover == 0)
            {
                start = 1;

                Grid square = sender as Grid;
                if(pieceSources.ContainsKey(square.Name) && pieceSources[square.Name] != null)
                {
                    draggedPiece = square;
                    startPosition = e.GetPosition(draggedPiece);

                    if ((pieceValues[square.Name] > 0 && turn == 1) || (pieceValues[square.Name] < 0 && turn == 0))
                    {
                        pieceImage = new Image
                        {
                            Source = pieceSources[square.Name],
                            Width = 100,
                            Height = 100,
                            Opacity = 0.8
                        };
                    
                        pieceImage.MouseMove += SquareMouseMove;
                        pieceImage.MouseUp += SquareMouseUp;

                        Canvas.SetLeft(pieceImage, 0);
                        Canvas.SetTop(pieceImage, 0);

                        isDragging = true;
                    }
                    else
                    {
                        isDragging = false;
                        draggedPiece = null;
                    }
                }
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
                if(pieceValues[targetSquare.Name] <= 0 && pieceValues[draggedPiece.Name] >= 0 ||
                   pieceValues[targetSquare.Name] >= 0 && pieceValues[draggedPiece.Name] <= 0)
                {
                    if (targetSquare != null)
                    {
                        pieceSources[targetSquare.Name] = pieceSources[draggedPiece.Name];
                        pieceSources[draggedPiece.Name] = null;

                        pieceValues[targetSquare.Name] = pieceValues[draggedPiece.Name];
                        pieceValues[draggedPiece.Name] = 0;
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

                        Grid A_UpdateSources = FindName(A) as Grid;
                        Grid B_UpdateSources = FindName(B) as Grid;
                        Grid C_UpdateSources = FindName(C) as Grid;
                        Grid D_UpdateSources = FindName(D) as Grid;
                        Grid E_UpdateSources = FindName(E) as Grid;
                        Grid F_UpdateSources = FindName(F) as Grid;
                        Grid G_UpdateSources = FindName(G) as Grid;
                        Grid H_UpdateSources = FindName(H) as Grid;

                        Image A_ImageUpdateSources = A_UpdateSources.Children[0] as Image;
                        Image B_ImageUpdateSources = B_UpdateSources.Children[0] as Image;
                        Image C_ImageUpdateSources = C_UpdateSources.Children[0] as Image;
                        Image D_ImageUpdateSources = D_UpdateSources.Children[0] as Image;
                        Image E_ImageUpdateSources = E_UpdateSources.Children[0] as Image;
                        Image F_ImageUpdateSources = F_UpdateSources.Children[0] as Image;
                        Image G_ImageUpdateSources = G_UpdateSources.Children[0] as Image;
                        Image H_ImageUpdateSources = H_UpdateSources.Children[0] as Image;

                        A_ImageUpdateSources.Source = pieceSources[A];
                        B_ImageUpdateSources.Source = pieceSources[B];
                        C_ImageUpdateSources.Source = pieceSources[C];
                        D_ImageUpdateSources.Source = pieceSources[D];
                        E_ImageUpdateSources.Source = pieceSources[E];
                        F_ImageUpdateSources.Source = pieceSources[F];
                        G_ImageUpdateSources.Source = pieceSources[G];
                        H_ImageUpdateSources.Source = pieceSources[H];
                    }

                    board.Children.Remove(pieceImage);
                    isDragging = false;
                    draggedPiece = null;

                    turn = turn == 1 ? 0 : 1;
                }
            }
        }

        private Grid FindSquareUnderMouse(Point mousePosition)
        {
            foreach (UIElement child in board.Children)
            {
                if (child is Grid square && IsMouseOverSquare(square, mousePosition))
                {
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
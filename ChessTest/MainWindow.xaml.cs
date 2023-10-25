using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Media;
using System.Collections.Generic;
using ChessTest.Helpers;


namespace ChessTest
{
        
    public partial class MainWindow : Window
    {

        private bool isDragging = false;
        private Grid draggedPiece;
        private Image pieceImage;
        private Point startPosition;
        private int turn = 1; // 1 for white 0 for black
        private int start = 0;
        private int gameover = 0;
        private Dictionary<string, ImageSource> PieceSources = new Dictionary<String, ImageSource>();
        private Dictionary<string, int> PieceValues = new Dictionary<string, int>();

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
            PieceSources = PieceData.PieceSources;
            PieceValues = PieceData.PieceValues;
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
                if(PieceSources.ContainsKey(square.Name) && PieceSources[square.Name] != null)
                {
                    draggedPiece = square;
                    startPosition = e.GetPosition(draggedPiece);

                    if ((PieceValues[square.Name] > 0 && turn == 1) || (PieceValues[square.Name] < 0 && turn == 0))
                    {
                        pieceImage = new Image
                        {
                            Source = PieceSources[square.Name],
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
                if(PieceValues[targetSquare.Name] <= 0 && PieceValues[draggedPiece.Name] >= 0 ||
                   PieceValues[targetSquare.Name] >= 0 && PieceValues[draggedPiece.Name] <= 0)
                {
                    if (targetSquare != null)
                    {
                        PieceSources[targetSquare.Name] = PieceSources[draggedPiece.Name];
                        PieceSources[draggedPiece.Name] = null;

                        PieceValues[targetSquare.Name] = PieceValues[draggedPiece.Name];
                        PieceValues[draggedPiece.Name] = 0;
                    }

                    Update();

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

        private void Update()
        {
            string[] letters = {"A", "B", "C", "D", "E", "F", "G", "H"};
            for (int i = 1; i < 9; ++i)
            {
                foreach (string letter in letters)
                {
                    string position = string.Concat(letter, i.ToString()); 

                    Grid UpdateSources = FindName(position) as Grid;

                    Image ImageUpdateSources = UpdateSources.Children[0] as Image;

                    ImageUpdateSources.Source = PieceSources[position];
                }
            }
        }
    }
}
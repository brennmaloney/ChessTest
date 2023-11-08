using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.Generic;
using ChessTest.Helpers;

namespace ChessTest
{
        
    public partial class ChessBoard : Window
    {
        // Variables for helping piece movement
        private bool isDragging = false;
        private Grid draggedPiece;
        private Image pieceImage;
        private Point startPosition;

        // Dictionary and other global variable initialization
        private Dictionary<string, PieceValues> PieceData = new Dictionary<String, PieceValues>();
        private int turn = 1;
        private int start = 0;
        private int gameover = 0;
        public static int whiteLost = 0;
        public static int blackLost = 0;

        // Timer intialization, change .FromMinutes value if you want to play with a different amount of time
        private TimeSpan whiteTime;
        private TimeSpan blackTime;
        readonly DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Render);

        public ChessBoard()
        {
            whiteTime = TimeSpan.FromMinutes(TimeSelection.TotalTime);
            blackTime = TimeSpan.FromMinutes(TimeSelection.TotalTime);
            
            InitializeComponent();
            Loaded += WindowLoaded;

            // TODO: make a separate window for the user to select how much time they would like
            timerWhite.Content = whiteTime.ToString("mm\\:ss");
            timerBlack.Content = blackTime.ToString("mm\\:ss");
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Main dictionary for the piece data including image source and piece values
            PieceData = HelperDict.PieceData;
        }

        private void Gameover()
        {
            Console.WriteLine(whiteLost);
            Console.WriteLine(blackLost);
            EndGame endGame = new EndGame
            {
                Left = 100,
                Top = 100
            };
            endGame.Show();
            Close();
        }

        // Function to update the timers of each of the players
        private void TimerTick(object sender, EventArgs e)
        {
            if (start == 1)
            {
                if (whiteTime.TotalSeconds < 0)
                {
                    timer.Stop();
                    gameover = 1;
                    start = 0;
                    whiteLost = 1;
                    Gameover();
                }
                else if (blackTime.TotalSeconds < 0)
                {
                    timer.Stop();
                    gameover = 1;
                    start = 0;
                    blackLost = 1;
                    Gameover();
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

        // Action when the user clicks on a piece on the board
        // Creates a copy of the piece and determines if the game is over by timeout
        private void SquareMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (gameover == 0)
            {
                start = 1;

                Grid square = sender as Grid;
                if(PieceData.ContainsKey(square.Name) && PieceData[square.Name] != null)
                {
                    draggedPiece = square;
                    startPosition = e.GetPosition(draggedPiece);

                    if ((PieceData[square.Name].Value > 0 && turn == 1) || (PieceData[square.Name].Value < 0 && turn == 0))
                    {
                        pieceImage = new Image
                        {
                            Source = PieceData[square.Name].Image,
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

        // Finds where the mouse is being moved on the chess board
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

        // Action after the user lifts the mouse button up
        // Calls Update function to update the dictionaries if there is a piece placed
        private void SquareMouseUp(object sender, MouseButtonEventArgs e)
        {
            
            if(isDragging && pieceImage != null)
            {
                Grid targetSquare = FindSquareUnderMouse(e.GetPosition(board));
                if(PieceData[targetSquare.Name].Value <= 0 && PieceData[draggedPiece.Name].Value >= 0 ||
                   PieceData[targetSquare.Name].Value >= 0 && PieceData[draggedPiece.Name].Value <= 0)
                {
                    if (targetSquare != null)
                    {
                        PieceData[targetSquare.Name].Image = PieceData[draggedPiece.Name].Image;
                        PieceData[draggedPiece.Name].Image = null;

                        PieceData[targetSquare.Name].Value = PieceData[draggedPiece.Name].Value;
                        PieceData[draggedPiece.Name].Value = 0;

                        PieceData[targetSquare.Name].Piece = PieceData[draggedPiece.Name].Piece;
                        PieceData[draggedPiece.Name].Piece = '_';
                    }

                    Update();

                    board.Children.Remove(pieceImage);
                    isDragging = false;
                    draggedPiece = null;

                    turn = turn == 1 ? 0 : 1;
                }
            }
        }

        // Finds the sqaure under the users mouse positition on the board
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

        // Determines if the users mouse if over a square for the piece to be placed on
        private bool IsMouseOverSquare(UIElement element, Point mousePosition)
        {
            Point elementPosition = element.TranslatePoint(new Point(0, 0), board);
            Rect elementBounds = new Rect(elementPosition, element.RenderSize);
            return elementBounds.Contains(mousePosition);
        }

        // Updates the source and values of each of the pieces on the board after a move is made
        // Could be made faster if there is only the two squares which need to be updated
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

                    ImageUpdateSources.Source = PieceData[position].Image;
                    Console.WriteLine(PieceData[position].Image);
                    Console.WriteLine(PieceData[position].Value);
                    Console.WriteLine(PieceData[position].Piece);
                }
            }
        }

        private void WhiteResign(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            gameover = 1;
            whiteLost = 1;
            Gameover();
        }
        private void BlackResign(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            gameover = 1;
            blackLost = 1;
            Gameover();
        }
    }
}
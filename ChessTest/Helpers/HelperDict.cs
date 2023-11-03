using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace ChessTest.Helpers
{
    class PieceValues
    {
        public ImageSource Image { get; set; }
        public int Value { get; set; }
        public char Piece { get; set; }
    }
    class HelperDict
    {
        public static Dictionary<string, PieceValues> PieceData = new Dictionary<string, PieceValues>
        {
            { "A8", new PieceValues 
            {
                Image = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute)),
                Value = -5,
                Piece = 'R'
            } },
            { "B8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute)),
                Value = -3,
                Piece = 'N'
            } },
            { "C8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute)),
                Value = -3,
                Piece = 'B'
            } },
            { "D8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute)),
                Value = -9,
                Piece = 'Q'
            } },
            { "E8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute)),
                Value = -100,
                Piece = 'K'
            } },
            { "F8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute)),
                Value = -3,
                Piece = 'B'
            } },
            { "G8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute)),
                Value = -3,
                Piece = 'N'
            } },
            { "H8", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute)),
                Value = -5,
                Piece = 'R'
            } },
            { "A7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "B7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "C7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "D7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "E7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "F7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "G7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "H7", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)),
                Value = -1,
                Piece = 'P'
            } },
            { "A6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "B6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "C6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "D6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "E6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "F6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "G6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "H6", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "A5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "B5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "C5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "D5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "E5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "F5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "G5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "H5", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "A4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "B4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "C4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "D4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "E4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "F4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "G4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "H4", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "A3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "B3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "C3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "D3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "E3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "F3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "G3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "H3", new PieceValues
            {
                Image = null,
                Value = 0,
                Piece = '_'
            } },
            { "A2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "B2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "C2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "D2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "E2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "F2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "G2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "H2", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)),
                Value = 1,
                Piece = 'P'
            } },
            { "A1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute)),
                Value = 5,
                Piece = 'R'
            } },
            { "B1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute)),
                Value = 3,
                Piece = 'N'
            } },
            { "C1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute)),
                Value = 3,
                Piece = 'B'
            } },
            { "D1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteQueen.png", UriKind.RelativeOrAbsolute)),
                Value = 9,
                Piece = 'Q'
            } },
            { "E1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteKing.png", UriKind.RelativeOrAbsolute)),
                Value = 100,
                Piece = 'K'
            } },
            { "F1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute)),
                Value = 3,
                Piece = 'B'
            } },
            { "G1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute)),
                Value = 3,
                Piece = 'N'
            } },
            { "H1", new PieceValues
            {
                Image = new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute)),
                Value = 5,
                Piece = 'R'
            } },
        };
    }
}

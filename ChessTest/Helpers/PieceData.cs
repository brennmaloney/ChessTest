using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace ChessTest.Helpers
{
    class PieceData
    {
        public static Dictionary<string, ImageSource> PieceSources = new Dictionary<string, ImageSource>
        {
            { "A8", new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute)) },
            { "B8", new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute)) },
            { "C8", new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute)) },
            { "D8", new BitmapImage(new Uri("/Images/BlackQueen.png", UriKind.RelativeOrAbsolute)) },
            { "E8", new BitmapImage(new Uri("/Images/BlackKing.png", UriKind.RelativeOrAbsolute)) },
            { "F8", new BitmapImage(new Uri("/Images/BlackBishop.png", UriKind.RelativeOrAbsolute)) },
            { "G8", new BitmapImage(new Uri("/Images/BlackKnight.png", UriKind.RelativeOrAbsolute)) },
            { "H8", new BitmapImage(new Uri("/Images/BlackRook.png", UriKind.RelativeOrAbsolute)) },

            { "A7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "B7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "C7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "D7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "E7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "F7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "G7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },
            { "H7", new BitmapImage(new Uri("/Images/BlackPawn.png", UriKind.RelativeOrAbsolute)) },

            { "A6", null },
            { "B6", null },
            { "C6", null },
            { "D6", null },
            { "E6", null },
            { "F6", null },
            { "G6", null },
            { "H6", null },

            { "A5", null },
            { "B5", null },
            { "C5", null },
            { "D5", null },
            { "E5", null },
            { "F5", null },
            { "G5", null },
            { "H5", null },

            { "A4", null },
            { "B4", null },
            { "C4", null },
            { "D4", null },
            { "E4", null },
            { "F4", null },
            { "G4", null },
            { "H4", null },

            { "A3", null },
            { "B3", null },
            { "C3", null },
            { "D3", null },
            { "E3", null },
            { "F3", null },
            { "G3", null },
            { "H3", null },

            { "A2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "B2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "C2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "D2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "E2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "F2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "G2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },
            { "H2", new BitmapImage(new Uri("/Images/WhitePawn.png", UriKind.RelativeOrAbsolute)) },

            { "A1", new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute)) },
            { "B1", new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute)) },
            { "C1", new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute)) },
            { "D1", new BitmapImage(new Uri("/Images/WhiteQueen.png", UriKind.RelativeOrAbsolute)) },
            { "E1", new BitmapImage(new Uri("/Images/WhiteKing.png", UriKind.RelativeOrAbsolute)) },
            { "F1", new BitmapImage(new Uri("/Images/WhiteBishop.png", UriKind.RelativeOrAbsolute)) },
            { "G1", new BitmapImage(new Uri("/Images/WhiteKnight.png", UriKind.RelativeOrAbsolute)) },
            { "H1", new BitmapImage(new Uri("/Images/WhiteRook.png", UriKind.RelativeOrAbsolute)) }
        };

        public static Dictionary<string, int> PieceValues = new Dictionary<string, int>
        {
            { "A8", -5 },
            { "B8", -3 },
            { "C8", -3 },
            { "D8", -9 },
            { "E8", -100 },
            { "F8", -3 },
            { "G8", -3 },
            { "H8", -5 },

            { "A7", -1 },
            { "B7", -1 },
            { "C7", -1 },
            { "D7", -1 },
            { "E7", -1 },
            { "F7", -1 },
            { "G7", -1 },
            { "H7", -1 },

            { "A6", 0 },
            { "B6", 0 },
            { "C6", 0 },
            { "D6", 0 },
            { "E6", 0 },
            { "F6", 0 },
            { "G6", 0 },
            { "H6", 0 },

            { "A5", 0 },
            { "B5", 0 },
            { "C5", 0 },
            { "D5", 0 },
            { "E5", 0 },
            { "F5", 0 },
            { "G5", 0 },
            { "H5", 0 },

            { "A4", 0 },
            { "B4", 0 },
            { "C4", 0 },
            { "D4", 0 },
            { "E4", 0 },
            { "F4", 0 },
            { "G4", 0 },
            { "H4", 0 },

            { "A3", 0 },
            { "B3", 0 },
            { "C3", 0 },
            { "D3", 0 },
            { "E3", 0 },
            { "F3", 0 },
            { "G3", 0 },
            { "H3", 0 },

            { "A2", 1 },
            { "B2", 1 },
            { "C2", 1 },
            { "D2", 1 },
            { "E2", 1 },
            { "F2", 1 },
            { "G2", 1 },
            { "H2", 1 },

            { "A1", 5 },
            { "B1", 3 },
            { "C1", 3 },
            { "D1", 9 },
            { "E1", 100 },
            { "F1", 3 },
            { "G1", 3 },
            { "H1", 5 }
        };
    }
}

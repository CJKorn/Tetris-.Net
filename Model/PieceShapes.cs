using System.Collections.Generic;

public static class PieceShapes {
    public static readonly Dictionary<int, List<int[,]>> Shapes;

    static PieceShapes() {
        // LPiece 0 Orange
        LPiece = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { 1, 1 }
        };
        LPieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { 1, -1 }
        };
        LPieceRotated180 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { -1, -1 }
        };
        LPieceRotated270 = new int[,] {
            { 0, 0 },
            { 0, 1 },
            { 0, -1 },
            { -1, 1 }
        };

        // JPiece 1 Dark Blue
        JPiece = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { -1, 1 }
        };
        JPieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { 1, 1 }
        };
        JPieceRotated180 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { 1, -1 }
        };
        JPieceRotated270 = new int[,] {
            { 0, 0 },
            { 0, 1 },
            { 0, -1 },
            { -1, -1 }
        };

        // TPiece 2 Purple
        TPiece = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 0, 1 },
            { 1, 0 }
        };
        TPieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { 1, 0 }
        };
        TPieceRotated180 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 0, -1 },
            { 1, 0 }
        };
        TPieceRotated270 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { -1, 0 }
        };

        // SPiece 3 Green
        SPiece = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 0, 1 },
            { 1, 1 }
        };
        SPieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, 1 },
            { 1, 0 },
            { 1, -1 }
        };
        SPieceRotated180 = new int[,] {
            { 0, 0 },
            { 1, 0 },
            { 0, -1 },
            { -1, -1 }
        };
        SPieceRotated270 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { -1, 0 },
            { -1, 1 }
        };

        // ZPiece 4 Red
        ZPiece = new int[,] {
            { 0, 0 },
            { -1, 1 },
            { 0, 1 },
            { 1, 0 }
        };
        ZPieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 1, 0 },
            { 1, 1 }
        };
        ZPieceRotated180 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 0, -1 },
            { 1, -1 }
        };
        ZPieceRotated270 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 0, 1 },
            { -1, -1 }
        };

        // LinePiece 5 Cyan
        LinePiece = new int[,] { // Origin of Line piece is at [][].[][]
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { 2, 0 }
        };
        LinePieceRotated90 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { 0, 2 }
        };
        LinePieceRotated180 = new int[,] {
            { 0, 0 },
            { -1, 0 },
            { 1, 0 },
            { 2, 0 }
        };
        LinePieceRotated270 = new int[,] {
            { 0, 0 },
            { 0, -1 },
            { 0, 1 },
            { 0, 2 }
        };

        // SquarePiece 6 Yellow
        SquarePiece = new int[,] {// Origin of Square piece is at 0.5, 0.5
            { 0, 0 },
            { 0, 1 },
            { 1, 0 },
            { 1, 1 }
        };

        // Initialize the Shapes dictionary
        Shapes = new Dictionary<int, List<int[,]>>() {
            { 0, new List<int[,]> { LPiece, LPieceRotated90, LPieceRotated180, LPieceRotated270 } },
            { 1, new List<int[,]> { JPiece, JPieceRotated90, JPieceRotated180, JPieceRotated270 } },
            { 2, new List<int[,]> { TPiece, TPieceRotated90, TPieceRotated180, TPieceRotated270 } },
            { 3, new List<int[,]> { SPiece, SPieceRotated90, SPieceRotated180, SPieceRotated270 } },
            { 4, new List<int[,]> { ZPiece, ZPieceRotated90, ZPieceRotated180, ZPieceRotated270 } },
            { 5, new List<int[,]> { LinePiece, LinePieceRotated90, LinePieceRotated180, LinePieceRotated270 } },
            { 6, new List<int[,]> { SquarePiece } } // Square piece does not change with rotation
        };
    }

    // Define the static arrays for the piece shapes
    public static readonly int[,] LPiece;
    public static readonly int[,] LPieceRotated90;
    public static readonly int[,] LPieceRotated180;
    public static readonly int[,] LPieceRotated270;

    public static readonly int[,] JPiece;
    public static readonly int[,] JPieceRotated90;
    public static readonly int[,] JPieceRotated180;
    public static readonly int[,] JPieceRotated270;

    public static readonly int[,] TPiece;
    public static readonly int[,] TPieceRotated90;
    public static readonly int[,] TPieceRotated180;
    public static readonly int[,] TPieceRotated270;

    public static readonly int[,] SPiece;
    public static readonly int[,] SPieceRotated90;
    public static readonly int[,] SPieceRotated180;
    public static readonly int[,] SPieceRotated270;

    public static readonly int[,] ZPiece;
    public static readonly int[,] ZPieceRotated90;
    public static readonly int[,] ZPieceRotated180;
    public static readonly int[,] ZPieceRotated270;

    public static readonly int[,] LinePiece;
    public static readonly int[,] LinePieceRotated90;
    public static readonly int[,] LinePieceRotated180;
    public static readonly int[,] LinePieceRotated270;

    public static readonly int[,] SquarePiece;
}

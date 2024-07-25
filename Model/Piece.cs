namespace TetrisCSharp {

    public class Piece {
        public int PieceX { get; private set; }
        public int PieceY { get; private set; }
        public int PieceType { get; private set; }
        public int PieceRotation { get; private set; }
        public int[,] PieceShape { get; private set; }
        public Board GameBoard { get; private set; }
        public GameModel model;

        public Piece(int pieceType, Board GameBoard, GameModel model) {
            PieceX = 4;
            PieceY = 24;
            PieceType = pieceType;
            PieceRotation = 0;
            PieceShape = GetPieceShape(pieceType, PieceRotation);
            this.GameBoard = GameBoard;
            this.PieceType = pieceType;
            this.model = model;
        }

        public void Reset() {
            PieceX = 4;
            PieceY = 24;
            PieceRotation = 0;
            PieceShape = GetPieceShape(PieceType, PieceRotation);
        }

        public bool CanMoveDown() {
            for (int i = 0; i < 4; i++) {
                int x = PieceX + PieceShape[i, 0];
                int y = PieceY + PieceShape[i, 1];
                if (x >= 0 && x < GameBoard.Tiles.GetLength(0) && y < GameBoard.Tiles.GetLength(1)) {
                    if (y <= 0) {
                        return false;
                    }
                    if (GameBoard.GetTile(x, y - 1) > 0) {
                        return false;
                    }
                }
            }
            return true;
        }

        public void MoveDown() {
            PieceY--;
        }

        public int[,] GetPieceOnBoard(bool GhostPieces) {
            int[,] pieceOnBoard = new int[10, 24];
            for (int i = 0; i < 4; i++) {
                int x = PieceX + PieceShape[i, 0];
                int y = PieceY + PieceShape[i, 1];
                int DropDist = GetDropDist();
                if ((DropDist > 0) && (y - DropDist >= 0) && (GhostPieces) && (x >= 0) && (x < 10) && (pieceOnBoard[x, y - DropDist] == 0)) {
                    pieceOnBoard[x, y - DropDist] = (8);
                }
                if (x >= 0 && x < pieceOnBoard.GetLength(0) && y >= 0 && y < pieceOnBoard.GetLength(1)) { 
                    pieceOnBoard[x, y] = (PieceType + 1);
                }
            }
            return pieceOnBoard;
        }

        public void MoveLeft() {
            for (int i = 0; i < 4; i++) {
                int x = PieceX + PieceShape[i, 0];
                int y = PieceY + PieceShape[i, 1];
                if (x - 1 < 0 || GameBoard.GetTile(x - 1, y) > 0) {
                    return;
                }
            }
            PieceX--;
        }

        public void MoveRight() {
            for (int i = 0; i < 4; i++) {
                int x = PieceX + PieceShape[i, 0];
                int y = PieceY + PieceShape[i, 1];
                if (x + 1 >= GameBoard.Tiles.GetLength(0) || GameBoard.GetTile(x + 1, y) > 0) {
                    return;
                }
            }
            PieceX++;
        }

        public void RotateLeft() {
            if (PieceType != 6) {
                int TempRotation = PieceRotation - 1;
                if (TempRotation < 0) {
                    TempRotation = PieceShapes.Shapes[PieceType].Count - 1;
                }
                int[] results = TestRotation(TempRotation);
                if (results != null) {
                    PieceRotation = TempRotation;
                    PieceX += results[0];
                    PieceY += results[1];
                    PieceShape = GetPieceShape(PieceType, PieceRotation);
                }
            }
        }

        public void RotateRight() {
            if (PieceType != 6) {
                int TempRotation = PieceRotation + 1;
                if (TempRotation >= PieceShapes.Shapes[PieceType].Count) {
                    TempRotation = 0;
                }
                int[] results = TestRotation(TempRotation);
                if (results != null) {
                    PieceRotation = TempRotation;
                    PieceX += results[0];
                    PieceY += results[1];
                    PieceShape = GetPieceShape(PieceType, PieceRotation);
                }
            }
        }

        public int[] TestRotation(int NewRotation) { // Holy shit it works, 4am
            if (PieceType == 5) {
                for (int i = 0; i < 5; i++) {
                    int x = WallKick.Offsets[0][(PieceRotation, NewRotation)][i].Item1;
                    int y = WallKick.Offsets[0][(PieceRotation, NewRotation)][i].Item2;
                    if (!TestOverlap(PieceShapes.Shapes[PieceType][NewRotation], PieceX + x, PieceY + y)) {
                        return new int[] { x, y };
                    }
                }
            }
            else {
                for (int i = 0; i < 5; i++) {
                    int x = WallKick.Offsets[1][(PieceRotation, NewRotation)][i].Item1;
                    int y = WallKick.Offsets[1][(PieceRotation, NewRotation)][i].Item2;
                    if (!TestOverlap(PieceShapes.Shapes[PieceType][NewRotation], PieceX + x, PieceY + y)) {
                        return new int[] { x, y };
                    }
                }
            }

            return null;
        }

        public bool TestOverlap(int[,] Shape, int TestX, int TestY) {
            for (int i = 0; i < 4; i++) {
                int x = TestX + Shape[i, 0];
                int y = TestY + Shape[i, 1];
                if (x >= 0 && x < GameBoard.Tiles.GetLength(0) && y >= 0 && y < GameBoard.Tiles.GetLength(1)) {
                    if (GameBoard.GetTile(x, y) < 0) {
                        return true;
                    }
                }
            }
            return false;
        }

        public void SoftDrop() {
            if (CanMoveDown()) {
                MoveDown();
            }
            else {
                placePiece();
            }
        }

        public void HardDrop() {
            PieceY -= GetDropDist();
            placePiece();
        }

        public int GetDropDist() {
            int DropDist = 0;
            for (int i = 0; i < 4; i++) {
                int temp = 0;
                int x = PieceX + PieceShape[i, 0];
                int y = PieceY + PieceShape[i, 1];
                while (y - temp > 0 && GameBoard.GetTile(x, y - temp - 1) == 0) {
                    temp++;
                }
                if (temp < DropDist || DropDist == 0) {
                    DropDist = temp;
                }
            }
            return DropDist;
        }

        public void placePiece() {
            int[,] pieceOnBoard = GetPieceOnBoard(false);
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 24; j++) {
                    if (pieceOnBoard[i, j] > 0 && pieceOnBoard[i, j] != 8) {
                        GameBoard.SetTile(i, j, PieceType + 1);
                    }
                }
            }
            GameBoard.ClearLines();
            model.newPiece();
        }

        public int[,] GetPieceShape(int pieceType, int rotationIndex) {
            rotationIndex = rotationIndex % PieceShapes.Shapes[pieceType].Count;
            return PieceShapes.Shapes[pieceType][rotationIndex];
        }
    }
}
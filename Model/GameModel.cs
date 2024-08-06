namespace TetrisCSharp {
    public class GameModel {
        public int Score { get; private set; }
        private GameView view;
        public Board GameBoard { get; private set; }
        private System.Windows.Forms.Timer gameTimer;
        private Piece currentPiece;
        private int interval = 500;
        private Piece[] nextPieceList;
        private Piece heldPiece;
        private bool holdable = true;

        public GameModel(GameView view) {
            this.view = view;
            Score = 0;
            GameBoard = new Board();

            //Timer Update Logic
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Interval = interval;
            gameTimer.Tick += UpdateGameState;
            gameTimer.Start();

            //GameBoard.RandomizeBoard();
        }

        private void UpdateGameState(object? sender, EventArgs e) {
            if (currentPiece == null) {
                newPiece();
            }
            if (currentPiece.CanMoveDown()) {
                currentPiece.MoveDown();
            }
            else {
                currentPiece.placePiece();
            }
            view.UpdateView();
        }

        public void TetrisForm_KeyDown(object sender, KeyEventArgs e) {
            if (currentPiece == null) {
                return;
            }
            switch (e.KeyCode) { //Todo: Make custom input handling
                case Keys.Left:
                    currentPiece.MoveLeft();
                    break;
                case Keys.Right:
                    currentPiece.MoveRight();
                    break;
              case Keys.Down:
                  currentPiece.SoftDrop();
                  break;
              case Keys.Up:
                  currentPiece.HardDrop();
                  break;
              case Keys.Space:
                  Hold();
                  break;
              case Keys.Z:
                  currentPiece.RotateLeft();
                  break;
              case Keys.X:
                  currentPiece.RotateRight();
                  break;
                default:
                    return;
            }
            view.UpdateView();
        }

        //public void placePiece() {
        //    int[,] pieceOnBoard = currentPiece.GetPieceOnBoard(false);
        //    for (int i = 0; i < 10; i++) {
        //        for (int j = 0; j < 24; j++) {
        //            if (pieceOnBoard[i, j] > 0) {
        //                GameBoard.SetTile(i, j, 1);
        //            }
        //        }
        //    }
        //    currentPiece = null;
        //}

        public int[,] getBoard() {
            int[,] board = new int[10, 24];
            int[,] tiles = GameBoard.Tiles;
            if (currentPiece == null) {
                return tiles;
            }
            int[,] pieceOnBoard = currentPiece.GetPieceOnBoard(true);
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 24; j++) {
                    board[i, j] = tiles[i, j] + pieceOnBoard[i, j];
                    if (tiles[i, j] > 0 && pieceOnBoard[i, j] > 0) {
                        board[i, j] = pieceOnBoard[i, j];
                    }
                }
            }

            return board;
        }

        public void Hold() {
            if (holdable) {
                if (heldPiece == null) {
                    heldPiece = currentPiece;
                    newPiece();
                } else {
                    Piece temp = currentPiece;
                    currentPiece = heldPiece;
                    heldPiece.Reset();
                    heldPiece = temp;
                }
                holdable = false;
            }
        }

        public void SetScore(int score) {
            Score = score;
        }

        public void newPieceList() { //There's probably a better way to do this but I've rewritten this like 5 times and it works so oh well
            Piece nextPiece;
            Piece[] tempPieceList = new Piece[7];
            int[] pieceTypeList;
            if (nextPieceList == null) {
                nextPieceList = new Piece[7];
                pieceTypeList = Enumerable.Range(0, 7).OrderBy(x => Random.Shared.Next()).ToArray();
                for (int i = 0; i < 7; i++) {
                    nextPieceList[i] = new Piece(pieceTypeList[i], GameBoard, this);
                }
            }
            pieceTypeList = Enumerable.Range(0, 7).OrderBy(x => Random.Shared.Next()).ToArray();
            for (int i = 0; i < 7; i++) {
                tempPieceList[i] = new Piece(pieceTypeList[i], GameBoard, this);
            }
            nextPieceList = nextPieceList.Concat(tempPieceList).ToArray();
            //nextPieceList = nextPieceList.Concat(Enumerable.Range(0, 7).OrderBy(x => Random.Shared.Next())).ToArray(); //Dunno why += doesn't work
        }

        public void newPiece() {
            holdable = true;
            if (nextPieceList == null || nextPieceList.Length < 8) {
                newPieceList();
            }
            //currentPiece = new Piece(0, GameBoard, this);
            currentPiece = nextPieceList[0];
            nextPieceList = nextPieceList.Skip(1).ToArray();
        }

        public Piece getHeldPiece() {
            return heldPiece;
        }

        public bool pieceHeld() {
            return heldPiece != null;
        }

        public Piece[] GetNextPieceList() {
            return nextPieceList;
        }

        public bool pieceListExists() {
            return nextPieceList != null;
        }
    }
}
namespace TetrisCSharp {
    public class Board {
        public int[,] Tiles { get; private set; }
        private Piece currentPiece;

        public Board() {
            Tiles = new int[10, 24];
        }

        public int GetTile(int x, int y) {
            try {
                return Tiles[x, y];
            }
            catch {
                if (y < 0) {
                    return 1;
                }
                else {
                    return 0;
                }
            }
        }

        public void SetTile(int x, int y, int value) {
            Tiles[x, y] = value;
        }

        public void ClearBoard() {
            Tiles = new int[10, 24];
        }

        public void RandomizeBoard() {
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 24; j++) {
                    Tiles[i, j] = Random.Shared.Next(0, 7);
                }
            }
        }

        public void ClearLines() { //Nightmare to figure out
            bool LineFull = true;
            for (int i = 23; i >= 0; i--) {
                LineFull = true;
                for (int j = 0; j < 10; j++) {
                    if (Tiles[j, i] == 0) {
                        LineFull = false;
                        break;
                    }
                }
                if (LineFull) {
                    for (int j = 0; j < 10; j++) { //Probably don't need this
                        Tiles[j, i] = 0;
                    }
                    for (int k = i; k < 23; k++) {
                        for (int j = 0; j < 10; j++) { //Evil triple nested loop
                            Tiles[j, k] = Tiles[j, k + 1];
                        }
                    }
                }
            }
        }
    }
}
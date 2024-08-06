using System.Drawing;
using System.Windows.Forms;
using TetrisCSharp;

namespace TetrisCSharp {

    public partial class GameView : Form {
        Color[] BlockColors = new Color[] {
            Color.FromArgb(255, 24, 25, 38), // EmptyBlock
            Color.FromArgb(255, 245, 169, 127),   // LPiece
            Color.FromArgb(255, 138, 173, 244),     // JPiece
            Color.FromArgb(255, 198, 160, 246),     // TPiece
            Color.FromArgb(255, 237, 135, 150),       // SPiece
            Color.FromArgb(255, 166, 218, 149),       // ZPiece
            Color.FromArgb(255, 145, 215, 227),       // IPiece
            Color.FromArgb(255, 238, 212, 0159),     // OPiece
            Color.FromArgb(255, 54, 58, 79)    // GhostPiece
        };

        int centerX = 0;
        int centerY = 0;
        int offsetX = 0;
        int offsetY = 0;
        private int previewLength = 7;
        private GameModel model;

        public GameView() {
            model = new GameModel(this);
            InitializeComponent();
            Invalidate();
            this.DoubleBuffered = true; //Thank god for this
                                        // Keeping this just in case
                                        //System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                                        //timer.Interval = 16;
                                        //timer.Tick += (sender, e) => {
                                        //    this.Invalidate();
                                        //};
                                        //timer.Start();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(model.TetrisForm_KeyDown);
            this.Resize += new System.EventHandler(this.GameView_Resize);
        }

        public void UpdateView() {
            Invalidate();
        }

        private void GameView_Resize(object sender, System.EventArgs e) {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (model.pieceHeld()) {
                DrawPiece(40, 40, 24, model.getHeldPiece(), e);
            }
            if (model.pieceListExists()) {
                for (int i = 0; i < previewLength; i++) {
                    DrawPiece(600, 40 + (i * 100), 24, model.GetNextPieceList().ElementAt(i), e);
                }
            }
            DrawBoard(e);
        }

        public void DrawBoard(PaintEventArgs e) {
            var board = model.getBoard();

            //int blockSize = Math.Min(ClientSize.Width / 10, ClientSize.Height / 24);
            int blockSize = 32;
            centerX = (ClientSize.Width / 2) - (5 * blockSize);
            centerY = (ClientSize.Height / 2) - (12 * blockSize);

            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 24; y++) {
                    Color color = BlockColors[0];
                    try {
                        color = BlockColors[board[x, y]];
                    }
                    catch {
                        color = BlockColors[0];
                        MessageBox.Show("Error: " + x + " " + y);
                    }

                    // Draw the block
                    using (Brush brush = new SolidBrush(color)) {
                        e.Graphics.FillRectangle(brush, ((x) * blockSize) + centerX + offsetX, ((23 - y) * blockSize) + centerY + offsetY, blockSize, blockSize);
                    }
                }
            }
        }

        public void DrawPiece(int drawX, int drawY, int size, Piece piece, PaintEventArgs e) {
            base.OnPaint(e);
            int[,] shape = piece.getPiecePreview();
            shape = CenterPiece(piece.GetPieceShape(), piece.GetPieceType());
            int pieceOffsetX = (shape.GetLength(0) - 3) * (size / 2);
            int pieceOffsetY = (shape.GetLength(1) - 3) * (size / 2);
            using (Brush brush = new SolidBrush(BlockColors[0])) {
                e.Graphics.FillRectangle(brush, drawX - (size / 2), drawY + (size / 2), size * 4, size * 4);
            }
            for (int x = 0; x < shape.GetLength(0); x++) {
                for (int y = 0; y < shape.GetLength(1); y++) {
                    Color color = BlockColors[0];
                    try {
                        color = BlockColors[shape[x, y]];
                    }
                    catch {
                        color = BlockColors[0];
                        MessageBox.Show("Error: " + x + " " + y);
                    }

                    // Draw the block
                    using (Brush brush = new SolidBrush(color)) {
                        e.Graphics.FillRectangle(brush, ((x) * size) + drawX - pieceOffsetX, ((3 - y) * size) + drawY + pieceOffsetY, size, size);
                    }
                }
            }
        }

        public int[,] CenterPiece(int[,] blockList, int pieceType) {
            int top = blockList[0,1];
            int left = blockList[0,0];
            int bottom = blockList[0, 1];
            int right = blockList[0, 0];

            for (int i = 1; i < 4; i++) {
                if (blockList[i, 1] > top) {
                    top = blockList[i, 1];
                }
                if (blockList[i, 0] < left) {
                    left = blockList[i, 0];
                }
                if (blockList[i, 1] < bottom) {
                    bottom = blockList[i, 1];
                }
                if (blockList[i, 0] > right) {
                    right = blockList[i, 0];
                }
            }
            int[,] centeredShape = new int[right - left + 1, top - bottom + 1];
            for (int i = 0; i < 4; i++) {
                centeredShape[blockList[i, 0] - left, blockList[i, 1] - bottom] = pieceType + 1;
            }
            return centeredShape;
            
        }
    }
}
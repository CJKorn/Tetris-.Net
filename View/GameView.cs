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

        int offsetX = 0;
        int offsetY = 0;
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
        }

        public void UpdateView() {
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            var board = model.getBoard();

            //int blockSize = Math.Min(ClientSize.Width / 10, ClientSize.Height / 24);
            int blockSize = 32;
            offsetX = ClientSize.Width / 2 - 5 * blockSize;

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
                        e.Graphics.FillRectangle(brush, ((x) * blockSize) + offsetX, ((23 - y) * blockSize) + offsetY, blockSize, blockSize);
                    }
                }
            }
        }

    }
}
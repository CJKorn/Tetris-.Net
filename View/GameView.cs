using System.Drawing;
using System.Windows.Forms;
using TetrisCSharp;

namespace TetrisCSharp {
    public partial class GameView : Form {
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

            int blockSize = Math.Min(ClientSize.Width / 10, ClientSize.Height / 24);

            Color[] BlockColors = new Color[] {
                        Color.Black, // EmptyBlock
                        Color.FromArgb(255, 255, 128, 0),   // LPiece
                        Color.FromArgb(255, 0, 0, 255),     // JPiece
                        Color.FromArgb(255, 128, 0, 128),     // TPiece
                        Color.FromArgb(255, 255, 0, 0),       // SPiece
                        Color.FromArgb(255, 0, 255, 0),       // ZPiece
                        Color.FromArgb(255, 128, 128, 255),       // IPiece
                        Color.FromArgb(255, 255, 255, 0),     // OPiece
                        Color.FromArgb(255, 128, 128, 128)    // GhostPiece
                    };

            for (int x = 0; x < 10; x++) {
                for (int y = 0; y < 24; y++) {
                    Color color = BlockColors[board[x, y]];

                    // Draw the block
                    using (Brush brush = new SolidBrush(color)) {
                        e.Graphics.FillRectangle(brush, (x) * blockSize, (23 - y) * blockSize, blockSize, blockSize);
                    }
                }
            }
        }

    }
}
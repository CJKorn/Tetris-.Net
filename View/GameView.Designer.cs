namespace TetrisCSharp {
    partial class GameView {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            panel1 = new Panel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Desktop;
            panel1.Location = new Point(200, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 800);
            panel1.TabIndex = 0;
            panel1.Visible = false;
            // 
            // GameView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(36, 39, 58);
            ClientSize = new Size(800, 800);
            Controls.Add(panel1);
            Name = "GameView";
            Text = "Tetris";
            ResumeLayout(false);
        }

        private Panel panel1;
    }
}

namespace TetrisGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameBoard = new System.Windows.Forms.PictureBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.tetrisLogo = new System.Windows.Forms.PictureBox();
            this.lineLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // gameBoard
            // 
            this.gameBoard.BackColor = System.Drawing.Color.Transparent;
            this.gameBoard.Location = new System.Drawing.Point(20, 17);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(321, 641);
            this.gameBoard.TabIndex = 2;
            this.gameBoard.TabStop = false;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBoard_Paint);
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.BackColor = System.Drawing.Color.Transparent;
            this.levelLabel.Font = new System.Drawing.Font("Georgia", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.levelLabel.Location = new System.Drawing.Point(378, 69);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(65, 43);
            this.levelLabel.TabIndex = 3;
            this.levelLabel.Text = "00";
            // 
            // tetrisLogo
            // 
            this.tetrisLogo.BackColor = System.Drawing.Color.Transparent;
            this.tetrisLogo.Enabled = false;
            this.tetrisLogo.Location = new System.Drawing.Point(35, 28);
            this.tetrisLogo.Name = "tetrisLogo";
            this.tetrisLogo.Size = new System.Drawing.Size(263, 198);
            this.tetrisLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tetrisLogo.TabIndex = 4;
            this.tetrisLogo.TabStop = false;
            this.tetrisLogo.Visible = false;
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.BackColor = System.Drawing.Color.Transparent;
            this.lineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lineLabel.Location = new System.Drawing.Point(362, 176);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(83, 44);
            this.lineLabel.TabIndex = 5;
            this.lineLabel.Text = "000";
            this.lineLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scoreLabel.Location = new System.Drawing.Point(388, 288);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(41, 44);
            this.scoreLabel.TabIndex = 6;
            this.scoreLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 674);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.tetrisLogo);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.gameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox gameBoard;

        int[] bank1 = new int[0];
        int row1 = 0;
        int[] bank2 = new int[0];
        int row2 = 0;
        int[] bank3 = new int[0];
        int row3 = 0;
        int[] bank4 = new int[0];
        int row4 = 0;
        int[] bank5 = new int[0];
        int row5 = 0;
        int[] bank6 = new int[0];
        int row6 = 0;
        int[] bank7 = new int[0];
        int row7 = 0;
        int[] bank8 = new int[0];
        int row8 = 0;
        int[] bank9 = new int[0];
        int row9 = 0;
        int[] bank10 = new int[0];
        int row10 = 0;
        int[] bank11 = new int[0];
        int row11 = 0;
        int[] bank12 = new int[0];
        int row12 = 0;
        int[] bank13 = new int[0];
        int row13 = 0;
        int[] bank14 = new int[0];
        int row14 = 0;
        int[] bank15 = new int[0];
        int row15 = 0;
        int[] bank16 = new int[0];
        int row16 = 0;
        int[] bank17 = new int[0];
        int row17 = 0;
        int[] bank18 = new int[0];
        int row18 = 0;
        int[] bank19 = new int[0];
        int row19 = 0;
        int[] bank20 = new int[0];
        int row20 = 0;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.PictureBox tetrisLogo;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label scoreLabel;
    }
}


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
            this.label1 = new System.Windows.Forms.Label();
            this.tetrisLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 650;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // gameBoard
            // 
            this.gameBoard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gameBoard.Location = new System.Drawing.Point(12, 76);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(321, 641);
            this.gameBoard.TabIndex = 2;
            this.gameBoard.TabStop = false;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.GameBoard_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // tetrisLogo
            // 
            this.tetrisLogo.BackColor = System.Drawing.Color.Transparent;
            this.tetrisLogo.Location = new System.Drawing.Point(35, 90);
            this.tetrisLogo.Name = "tetrisLogo";
            this.tetrisLogo.Size = new System.Drawing.Size(263, 198);
            this.tetrisLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tetrisLogo.TabIndex = 4;
            this.tetrisLogo.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 729);
            this.Controls.Add(this.tetrisLogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox tetrisLogo;
    }
}


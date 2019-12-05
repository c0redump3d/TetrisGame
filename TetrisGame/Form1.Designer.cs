using SharpDX.XInput;
using System;
using System.Drawing;
using System.Drawing.Text;

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
            this.gravityTimer = new System.Windows.Forms.Timer(this.components);
            this.gameBoard = new System.Windows.Forms.PictureBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.tetrisLogo = new System.Windows.Forms.PictureBox();
            this.lineLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.confimTimer = new System.Windows.Forms.Timer(this.components);
            this.startLabel = new System.Windows.Forms.Label();
            this.nextShapeBox = new System.Windows.Forms.PictureBox();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.thumbStickTimer = new System.Windows.Forms.Timer(this.components);
            this.controllerButtonTimer = new System.Windows.Forms.Timer(this.components);
            this.selectedLevelLabel = new System.Windows.Forms.Label();
            this.rightArrowLabel = new System.Windows.Forms.Label();
            this.leftArrowLabel = new System.Windows.Forms.Label();
            this.githubLink = new System.Windows.Forms.PictureBox();
            this.createdByLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextShapeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubLink)).BeginInit();
            this.SuspendLayout();
            // 
            // gravityTimer
            // 
            this.gravityTimer.Enabled = true;
            this.gravityTimer.Interval = 1000;
            this.gravityTimer.Tick += new System.EventHandler(this.GravityTimer_Tick);
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
            this.tetrisLogo.Location = new System.Drawing.Point(20, 17);
            this.tetrisLogo.Name = "tetrisLogo";
            this.tetrisLogo.Size = new System.Drawing.Size(321, 300);
            this.tetrisLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tetrisLogo.TabIndex = 4;
            this.tetrisLogo.TabStop = false;
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
            // confimTimer
            // 
            this.confimTimer.Interval = 300;
            this.confimTimer.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.BackColor = System.Drawing.Color.Transparent;
            this.startLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startLabel.Location = new System.Drawing.Point(55, 382);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(225, 37);
            this.startLabel.TabIndex = 7;
            this.startLabel.Text = "START GAME";
            this.startLabel.Click += new System.EventHandler(this.StartLabel_Click);
            // 
            // nextShapeBox
            // 
            this.nextShapeBox.BackColor = System.Drawing.Color.Transparent;
            this.nextShapeBox.Location = new System.Drawing.Point(360, 384);
            this.nextShapeBox.Name = "nextShapeBox";
            this.nextShapeBox.Size = new System.Drawing.Size(100, 100);
            this.nextShapeBox.TabIndex = 8;
            this.nextShapeBox.TabStop = false;
            this.nextShapeBox.Paint += new System.Windows.Forms.PaintEventHandler(this.NextShapeBox_Paint);
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 1;
            this.updateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // thumbStickTimer
            // 
            this.thumbStickTimer.Enabled = true;
            this.thumbStickTimer.Interval = 80;
            this.thumbStickTimer.Tick += new System.EventHandler(this.ThumbStickTimer_Tick);
            // 
            // controllerButtonTimer
            // 
            this.controllerButtonTimer.Enabled = true;
            this.controllerButtonTimer.Interval = 50;
            this.controllerButtonTimer.Tick += new System.EventHandler(this.ControllerButtonTimer_Tick);
            // 
            // selectedLevelLabel
            // 
            this.selectedLevelLabel.AutoSize = true;
            this.selectedLevelLabel.BackColor = System.Drawing.Color.Transparent;
            this.selectedLevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLevelLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.selectedLevelLabel.Location = new System.Drawing.Point(97, 431);
            this.selectedLevelLabel.Name = "selectedLevelLabel";
            this.selectedLevelLabel.Size = new System.Drawing.Size(144, 37);
            this.selectedLevelLabel.TabIndex = 9;
            this.selectedLevelLabel.Text = "LEVEL 0";
            // 
            // rightArrowLabel
            // 
            this.rightArrowLabel.AutoSize = true;
            this.rightArrowLabel.BackColor = System.Drawing.Color.Transparent;
            this.rightArrowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightArrowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightArrowLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.rightArrowLabel.Location = new System.Drawing.Point(262, 431);
            this.rightArrowLabel.Name = "rightArrowLabel";
            this.rightArrowLabel.Size = new System.Drawing.Size(36, 37);
            this.rightArrowLabel.TabIndex = 10;
            this.rightArrowLabel.Text = ">";
            this.rightArrowLabel.Click += new System.EventHandler(this.rightArrowLabel_Click);
            // 
            // leftArrowLabel
            // 
            this.leftArrowLabel.AutoSize = true;
            this.leftArrowLabel.BackColor = System.Drawing.Color.Transparent;
            this.leftArrowLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftArrowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftArrowLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.leftArrowLabel.Location = new System.Drawing.Point(65, 431);
            this.leftArrowLabel.Name = "leftArrowLabel";
            this.leftArrowLabel.Size = new System.Drawing.Size(36, 37);
            this.leftArrowLabel.TabIndex = 11;
            this.leftArrowLabel.Text = "<";
            this.leftArrowLabel.Click += new System.EventHandler(this.leftArrowLabel_Click);
            // 
            // githubLink
            // 
            this.githubLink.BackColor = System.Drawing.Color.Transparent;
            this.githubLink.BackgroundImage = global::TetrisGame.Properties.Resources.GitHub_Mark_64px;
            this.githubLink.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.githubLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.githubLink.Location = new System.Drawing.Point(300, 617);
            this.githubLink.Name = "githubLink";
            this.githubLink.Size = new System.Drawing.Size(32, 32);
            this.githubLink.TabIndex = 12;
            this.githubLink.TabStop = false;
            this.githubLink.Click += new System.EventHandler(this.GithubLink_Click);
            // 
            // createdByLabel
            // 
            this.createdByLabel.AutoSize = true;
            this.createdByLabel.BackColor = System.Drawing.Color.Transparent;
            this.createdByLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdByLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.createdByLabel.Location = new System.Drawing.Point(168, 635);
            this.createdByLabel.Name = "createdByLabel";
            this.createdByLabel.Size = new System.Drawing.Size(130, 14);
            this.createdByLabel.TabIndex = 13;
            this.createdByLabel.Text = "Created by Carson Kelley";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 674);
            this.Controls.Add(this.createdByLabel);
            this.Controls.Add(this.githubLink);
            this.Controls.Add(this.leftArrowLabel);
            this.Controls.Add(this.rightArrowLabel);
            this.Controls.Add(this.selectedLevelLabel);
            this.Controls.Add(this.nextShapeBox);
            this.Controls.Add(this.startLabel);
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
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tetrisLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextShapeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.githubLink)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gravityTimer;
        private System.Windows.Forms.PictureBox gameBoard;

        private bool movingDown = false;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font hoogfont24;
        Font hoogfont28;

        int selectedLevel = 0;
        SFX sfx;
        GamepadSupport gamepad;
        Tetris tetris;
        private State stateOld;
        int lines = 0;
        int score = 0;
        int level = 0;
        int points = 40;
        bool confirm = false;
        bool remove = false;
        private bool paused = false;
        private bool rotating = false;
        private bool stop = true;

        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.PictureBox tetrisLogo;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer confimTimer;
        private System.Windows.Forms.Label startLabel;
        private System.Windows.Forms.PictureBox nextShapeBox;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer thumbStickTimer;
        private System.Windows.Forms.Timer controllerButtonTimer;
        private System.Windows.Forms.Label selectedLevelLabel;
        private System.Windows.Forms.Label rightArrowLabel;
        private System.Windows.Forms.Label leftArrowLabel;
        private System.Windows.Forms.PictureBox githubLink;
        private System.Windows.Forms.Label createdByLabel;
    }
}


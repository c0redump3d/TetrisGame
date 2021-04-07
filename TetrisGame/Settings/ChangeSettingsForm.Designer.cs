
namespace TetrisGame.Settings
{
    partial class ChangeSettingsForm
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
            this.leftLabel = new System.Windows.Forms.Label();
            this.rightLabel = new System.Windows.Forms.Label();
            this.downLabel = new System.Windows.Forms.Label();
            this.rotateLabel = new System.Windows.Forms.Label();
            this.leftButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.rotateButton = new System.Windows.Forms.Button();
            this.forceDropButton = new System.Windows.Forms.Button();
            this.forceDropLabel = new System.Windows.Forms.Label();
            this.audioLabel = new System.Windows.Forms.Label();
            this.audioTrackBar = new System.Windows.Forms.TrackBar();
            this.musicLabel = new System.Windows.Forms.Label();
            this.musicButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.audioTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // leftLabel
            // 
            this.leftLabel.AutoSize = true;
            this.leftLabel.BackColor = System.Drawing.Color.Transparent;
            this.leftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.leftLabel.Location = new System.Drawing.Point(12, 13);
            this.leftLabel.Name = "leftLabel";
            this.leftLabel.Size = new System.Drawing.Size(70, 37);
            this.leftLabel.TabIndex = 6;
            this.leftLabel.Text = "Left";
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.BackColor = System.Drawing.Color.Transparent;
            this.rightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.rightLabel.Location = new System.Drawing.Point(12, 81);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(91, 37);
            this.rightLabel.TabIndex = 7;
            this.rightLabel.Text = "Right";
            // 
            // downLabel
            // 
            this.downLabel.AutoSize = true;
            this.downLabel.BackColor = System.Drawing.Color.Transparent;
            this.downLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.downLabel.Location = new System.Drawing.Point(10, 150);
            this.downLabel.Name = "downLabel";
            this.downLabel.Size = new System.Drawing.Size(99, 37);
            this.downLabel.TabIndex = 8;
            this.downLabel.Text = "Down";
            // 
            // rotateLabel
            // 
            this.rotateLabel.AutoSize = true;
            this.rotateLabel.BackColor = System.Drawing.Color.Transparent;
            this.rotateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rotateLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.rotateLabel.Location = new System.Drawing.Point(10, 221);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.Size = new System.Drawing.Size(110, 37);
            this.rotateLabel.TabIndex = 9;
            this.rotateLabel.Text = "Rotate";
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(145, 13);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(90, 45);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "button1";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.button_Click);
            this.leftButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_KeyPress);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(145, 81);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(90, 45);
            this.rightButton.TabIndex = 2;
            this.rightButton.Text = "button2";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.button_Click);
            this.rightButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_KeyPress);
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(145, 150);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(90, 45);
            this.downButton.TabIndex = 3;
            this.downButton.Text = "button3";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.button_Click);
            this.downButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_KeyPress);
            // 
            // rotateButton
            // 
            this.rotateButton.Location = new System.Drawing.Point(145, 221);
            this.rotateButton.Name = "rotateButton";
            this.rotateButton.Size = new System.Drawing.Size(90, 45);
            this.rotateButton.TabIndex = 4;
            this.rotateButton.Text = "button4";
            this.rotateButton.UseVisualStyleBackColor = true;
            this.rotateButton.Click += new System.EventHandler(this.button_Click);
            this.rotateButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_KeyPress);
            // 
            // forceDropButton
            // 
            this.forceDropButton.Location = new System.Drawing.Point(467, 13);
            this.forceDropButton.Name = "forceDropButton";
            this.forceDropButton.Size = new System.Drawing.Size(90, 45);
            this.forceDropButton.TabIndex = 5;
            this.forceDropButton.Text = "button5";
            this.forceDropButton.UseVisualStyleBackColor = true;
            this.forceDropButton.Click += new System.EventHandler(this.button_Click);
            this.forceDropButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.button_KeyPress);
            // 
            // forceDropLabel
            // 
            this.forceDropLabel.AutoSize = true;
            this.forceDropLabel.BackColor = System.Drawing.Color.Transparent;
            this.forceDropLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forceDropLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.forceDropLabel.Location = new System.Drawing.Point(259, 13);
            this.forceDropLabel.Name = "forceDropLabel";
            this.forceDropLabel.Size = new System.Drawing.Size(178, 37);
            this.forceDropLabel.TabIndex = 8;
            this.forceDropLabel.Text = "Force Drop";
            // 
            // audioLabel
            // 
            this.audioLabel.AutoSize = true;
            this.audioLabel.BackColor = System.Drawing.Color.Transparent;
            this.audioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.audioLabel.Location = new System.Drawing.Point(306, 93);
            this.audioLabel.Name = "audioLabel";
            this.audioLabel.Size = new System.Drawing.Size(100, 37);
            this.audioLabel.TabIndex = 10;
            this.audioLabel.Text = "Audio";
            // 
            // audioTrackBar
            // 
            this.audioTrackBar.BackColor = System.Drawing.Color.Black;
            this.audioTrackBar.Location = new System.Drawing.Point(306, 133);
            this.audioTrackBar.Name = "audioTrackBar";
            this.audioTrackBar.Size = new System.Drawing.Size(210, 45);
            this.audioTrackBar.TabIndex = 11;
            this.audioTrackBar.Scroll += new System.EventHandler(this.audioTrackBar_Scroll);
            // 
            // musicLabel
            // 
            this.musicLabel.AutoSize = true;
            this.musicLabel.BackColor = System.Drawing.Color.Transparent;
            this.musicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.musicLabel.Location = new System.Drawing.Point(306, 188);
            this.musicLabel.Name = "musicLabel";
            this.musicLabel.Size = new System.Drawing.Size(100, 37);
            this.musicLabel.TabIndex = 12;
            this.musicLabel.Text = "Music";
            // 
            // musicButton
            // 
            this.musicButton.Location = new System.Drawing.Point(426, 184);
            this.musicButton.Name = "musicButton";
            this.musicButton.Size = new System.Drawing.Size(90, 45);
            this.musicButton.TabIndex = 13;
            this.musicButton.Text = "button6";
            this.musicButton.UseVisualStyleBackColor = true;
            this.musicButton.Click += new System.EventHandler(this.button_Click);
            // 
            // ChangeSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(576, 288);
            this.Controls.Add(this.musicButton);
            this.Controls.Add(this.musicLabel);
            this.Controls.Add(this.audioTrackBar);
            this.Controls.Add(this.audioLabel);
            this.Controls.Add(this.forceDropButton);
            this.Controls.Add(this.forceDropLabel);
            this.Controls.Add(this.rotateButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rotateLabel);
            this.Controls.Add(this.downLabel);
            this.Controls.Add(this.rightLabel);
            this.Controls.Add(this.leftLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeSettingsForm";
            this.Text = "Tetris Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangeSettingsForm_FormClosing);
            this.Load += new System.EventHandler(this.ChangeSettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.audioTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leftLabel;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label downLabel;
        private System.Windows.Forms.Label rotateLabel;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button rotateButton;
        private System.Windows.Forms.Button forceDropButton;
        private System.Windows.Forms.Label forceDropLabel;
        private System.Windows.Forms.Label audioLabel;
        private System.Windows.Forms.TrackBar audioTrackBar;
        private System.Windows.Forms.Label musicLabel;
        private System.Windows.Forms.Button musicButton;
    }
}
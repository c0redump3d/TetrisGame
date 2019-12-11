using SharpDX.XInput;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TetrisGame
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            sfx = new SFX();
            gamepad = new GamepadSupport();
            tetris = new Tetris();

            this.Icon = Properties.Resources.tetrisico; // set icon

            //add custom font
            byte[] fontData = Properties.Resources.hoog0553;
            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.hoog0553.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.hoog0553.Length, IntPtr.Zero, ref dummy);
            Marshal.FreeCoTaskMem(fontPtr);

            hoogfont24 = new Font(fonts.Families[0], 24.0F); // setup 24pt font
            hoogfont28 = new Font(fonts.Families[0], 28.0F); // setup 28pt font

            //set labels to correct font
            scoreLabel.Font = new Font(hoogfont28, FontStyle.Regular);
            lineLabel.Font = new Font(hoogfont28, FontStyle.Regular);
            levelLabel.Font = new Font(hoogfont28, FontStyle.Regular);
            startLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            selectedLevelLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            rightArrowLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            leftArrowLabel.Font = new Font(hoogfont24, FontStyle.Regular);

            tetrisLogo.Image = Properties.Resources.tetrislogo;
            this.BackgroundImage = Properties.Resources.gui;

            gravityTimer.Stop();
            paused = true;

            if (gamepad.isConnected())
                MessageBox.Show("Controller detected! Please feel free to use the controller.");
        }

        private void NextShapeBox_Paint(object sender, PaintEventArgs e)
        {
            if (!stop)
            {
                tetris.setNextShape(e.Graphics);
            }
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (!stop)
            {

                tetris.Draw(e.Graphics);

            }

            #region Collision

            tetris.blockCollision(ref confimTimer, ref gravityTimer, ref confirm, ref nextShapeBox, ref hardDrop, noSound);

            if (tetris.HitTop())
            {
                gravityTimer.Stop(); // stop gravity
                paused = true; // pause game
                stop = true; // stop music
                startLabel.Show(); // show start button
                tetrisLogo.Show(); // show tetris logo
                selectedLevelLabel.Show();
                leftArrowLabel.Show();
                rightArrowLabel.Show();
                githubLink.Show();
                createdByLabel.Show();
                gameBoard.Invalidate();
                if (!noSound)
                    sfx.playMusic(ref stop);
            }

            #endregion

            #region labels
            /*
             * 
             * Nothing interesting here, just updating labels to the information
             * they should contain.
             * 
             */

            if (lines < 10)
                lineLabel.Text = "00" + lines;
            else if (lines < 100)
                lineLabel.Text = "0" + lines;
            else
                lineLabel.Text = "" + lines;

            if(lines == 10 && level != 1 && selectedLevel < 1)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 925;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 20 && level != 2 && selectedLevel < 2)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 850;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 30 && level != 3 && selectedLevel < 3)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 775;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 40 && level != 4 && selectedLevel < 4)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 700;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 50 && level != 5 && selectedLevel < 5)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 625;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 60 && level != 6 && selectedLevel < 6)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 550;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 70 && level != 7 && selectedLevel < 7)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 475;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 80 && level != 8 && selectedLevel < 8)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 400;
                if (!noSound)
                    sfx.playLevelUp();
            }
            else if (lines == 90 && level != 9 && selectedLevel < 9)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 325;
                if (!noSound)
                    sfx.playLevelUp();
            }

            if (score >= 0 && score < 10)
            {
                scoreLabel.Left = 388;
                scoreLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);
            }
            else if (score > 10 && score < 100)
            {
                scoreLabel.Left = 378;
                scoreLabel.Text = "" + score;
                scoreLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);
            }
            else if (score >= 100 && score < 1000)
            {
                scoreLabel.Left = 365;
                scoreLabel.Text = "" + score;
                scoreLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);

            }
            else if (score >= 1000 && score < 2000)
            {
                scoreLabel.Font = new System.Drawing.Font(hoogfont24, FontStyle.Regular);
                scoreLabel.Left = 358;
                scoreLabel.Text = "" + score;

            }
            else if (score >= 2000 && score < 10000)
            {
                scoreLabel.Font = new System.Drawing.Font(hoogfont24, FontStyle.Regular);
                scoreLabel.Left = 358;
                scoreLabel.Text = "" + score;
            }
            else if (score >= 10000 && score < 20000)
            {
                scoreLabel.Font = new System.Drawing.Font(hoogfont24, FontStyle.Regular);
                scoreLabel.Left = 350;
                scoreLabel.Text = "" + score;
            }
            else if (score >= 20000)
            {
                scoreLabel.Font = new System.Drawing.Font(hoogfont24, FontStyle.Regular);
                scoreLabel.Left = 346;
                scoreLabel.Text = "" + score;
            }
            #endregion

        }

        #region Game Functions

        //used for when we remove a row, just does the other work.
        public void cleanUp()
        {
            remove = false;
            lines++; // add one to lines removed
            if (!noSound)
                sfx.playClear(ref lines); // play our clear sound
            score += points; // add 40 points to our score
            tetris.resetBank();
            gameBoard.Invalidate();
        }

        public static bool isMuted()
        {
            return changedMute;
        }

        private void resetGame()
        {
            //reset stats
            points = 40;
            lines = 0;
            score = 0;
            level = selectedLevel;
            levelLabel.Text = "0" + level;
            if (selectedLevel == 0)
                gravityTimer.Interval = 1000;
            else if (selectedLevel == 1)
                gravityTimer.Interval = 925;
            else if (selectedLevel == 2)
                gravityTimer.Interval = 850;
            else if (selectedLevel == 3)
                gravityTimer.Interval = 775;
            else if (selectedLevel == 4)
                gravityTimer.Interval = 700;
            else if (selectedLevel == 5)
                gravityTimer.Interval = 625;
            else if (selectedLevel == 6)
                gravityTimer.Interval = 550;
            else if (selectedLevel == 7)
                gravityTimer.Interval = 475;
            else if (selectedLevel == 8)
                gravityTimer.Interval = 400;
            else if (selectedLevel == 9)
                gravityTimer.Interval = 325;
            scoreLabel.Text = "0";
            //wipe all placed rectangles
            //reset bank
            tetris.resetBank();
            tetris.Reset();

            if (level > 6)
                tetris.randomBlock(7);

            gameBoard.Invalidate();
        }

        #endregion

        #region Controls/Movement

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.S:
                    if (paused)
                        return;

                    confirm = true;

                    if (tetris.moveDown())
                    {
                        if (!noSound)
                            sfx.playMove();
                        movingDown = true;
                    }
                    break;
                case Keys.Escape:
                    if (paused == false)
                    {
                        gravityTimer.Stop();
                        paused = true;
                    }
                    else if(paused && !stop)
                    {
                        gravityTimer.Start();
                        paused = false;
                    }
                    break;
                case Keys.Left:
                case Keys.A:
                    tetris.moveLeft(ref paused);
                    if(!noSound)
                        sfx.playMove();
                    break;
                case Keys.Right:
                case Keys.D:
                    tetris.moveRight(ref paused);
                    if (!noSound)
                        sfx.playMove();
                    break;
                case Keys.Z:
                case Keys.X:
                case Keys.Up:
                    if (!rotating)
                    {
                        if (paused)
                            return;
                        rotating = true;

                        tetris.rotateTetris();

                        if (!noSound)
                            sfx.playRotate();
                    }
                    break;
                case Keys.C:
                    if (fastFall)
                        return;
                    hardDrop = true;
                    fastFall = true;
                    tetris.instantFall();
                    confirm = true;
                    break;
            }

            gameBoard.Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                case Keys.Down:
                    confirm = false;
                    movingDown = false;
                    break;
                case Keys.Left:
                case Keys.A:
                case Keys.Right:
                case Keys.D:
                    confirm = false;
                    break;
                case Keys.Z: 
                case Keys.X:
                case Keys.Up:
                    rotating = false;
                    break;
                case Keys.C:
                    fastFall = false;
                    break;
            }
        }

        #endregion

        #region Timers
        private void GravityTimer_Tick(object sender, EventArgs e)
        {
            tetris.Gravity(ref gameBoard, ref movingDown);

            gameBoard.Invalidate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //this timer just allows the player to make a last second move once they have reach the
            //bottom of the board or are abover another shape
            confirm = true;
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (gamepad.isConnected())
                gamepad.ControllerUpdate();

            tetris.update(ref paused, ref gameBoard);

            #region Check Row

            tetris.checkRows();

            #endregion

            #region Remove Row

            tetris.removeRow(ref remove);

            #endregion

            if (remove)
                cleanUp();

        }

        #endregion

        #region Controller

        private void ThumbStickTimer_Tick(object sender, EventArgs e)
        {
            if (gamepad.isConnected())
            {

                if (gamepad.leftThumb.X < -50 || gamepad.gamepad.Buttons == GamepadButtonFlags.DPadLeft)
                {
                    tetris.moveLeft(ref paused);
                    gameBoard.Invalidate();
                }

                if (gamepad.leftThumb.X > 50 || gamepad.gamepad.Buttons == GamepadButtonFlags.DPadRight)
                {
                    tetris.moveRight(ref paused);
                    gameBoard.Invalidate();
                }

                if (gamepad.leftThumb.Y < -80 || gamepad.gamepad.Buttons == GamepadButtonFlags.DPadDown)
                {
                    if (paused)
                        return;
                    tetris.joystickDown(ref movingDown);
                    if (!noSound)
                        sfx.playMove();
                    gameBoard.Invalidate();
                }
                else
                {
                    movingDown = false;
                }
            }
            else
            {//if no controller is gamepad.isConnected(), we stop the timer from updating because its pointless.
                thumbStickTimer.Stop();
                controllerButtonTimer.Stop();
            }
        }

        private void ControllerButtonTimer_Tick(object sender, EventArgs e)
        {
            if (gamepad.isConnected())
            {
                State stateNew = gamepad.controller.GetState();
                if (stateOld.Gamepad.Buttons != GamepadButtonFlags.A && stateNew.Gamepad.Buttons == GamepadButtonFlags.A)
                {
                    SendKeys.SendWait("{X}");
                }

                if (stateOld.Gamepad.Buttons != GamepadButtonFlags.Start && stateNew.Gamepad.Buttons == GamepadButtonFlags.Start)
                {
                    if(stop && paused)
                    {
                        gravityTimer.Start();
                        paused = false;
                        stop = false;
                        if (!noSound)
                            sfx.playMusic(ref stop);
                        startLabel.Hide();
                        selectedLevelLabel.Hide();
                        leftArrowLabel.Hide();
                        rightArrowLabel.Hide();
                        tetrisLogo.Hide();
                        githubLink.Hide();
                        createdByLabel.Hide();
                        resetGame();
                        nextShapeBox.Invalidate();
                    }
                    else
                    {
                        if (paused == false)
                        {
                            gravityTimer.Stop();
                            paused = true;
                        }
                        else if (paused && !stop)
                        {
                            gravityTimer.Start();
                            paused = false;
                        }
                    }
                }
                stateOld = stateNew;
            }
        }

        #endregion

        #region Label Functions

        private void leftArrowLabel_Click(object sender, EventArgs e)
        {
            if (selectedLevel == 0)
                selectedLevel = 9;
            else
                selectedLevel--;

            selectedLevelLabel.Text = "LEVEL " + selectedLevel;
        }

        private void rightArrowLabel_Click(object sender, EventArgs e)
        {
            if (selectedLevel == 9)
                selectedLevel = 0;
            else
                selectedLevel++;

            selectedLevelLabel.Text = "LEVEL " + selectedLevel;
        }

        private void StartLabel_Click(object sender, EventArgs e)
        {
            //hides labels, starts timers and starts to play music
            gravityTimer.Start();
            paused = false;
            stop = false;
            startLabel.Hide();
            selectedLevelLabel.Hide();
            leftArrowLabel.Hide();
            rightArrowLabel.Hide();
            tetrisLogo.Hide();
            githubLink.Hide();
            createdByLabel.Hide();
            resetGame();
            nextShapeBox.Invalidate();
            try
            {
                sfx.playMusic(ref stop);
            }
            catch (Exception)
            {
                if(!noSound)
                    MessageBox.Show("You are missing required files to use sound. Please make sure you have the \"TetrisGame.exe.config\" file found on" +
                        " the github release page.\nIf you have this file, please make sure you have DirectX installed on your machine.", "Sound Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                soundBox.Image = Properties.Resources.Mute;
                noSound = true;
            }
        }

        private void GithubLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/StrugglingDoge/TetrisGame");
        }

        private void SoundBox_Click(object sender, EventArgs e)
        {
            if (noSound)
            {
                MessageBox.Show("You are missing required files to use sound. Please make sure you have the \"TetrisGame.exe.config\" file found on" +
                    " the github release page.\nIf you have this file, please make sure you have DirectX installed on your machine.", "Sound Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (changedMute)
            {
                soundBox.Image = Properties.Resources.unMute;
                changedMute = false;
                if (!noSound)
                    sfx.playMusic(ref stop);
                return;
            }
            else if (soundBox.Image != Properties.Resources.Mute && !changedMute)
            {
                changedMute = true;
                soundBox.Image = Properties.Resources.Mute;
                if (!noSound)
                    sfx.playMusic(ref stop);
            }
        }

        #endregion

    }
}

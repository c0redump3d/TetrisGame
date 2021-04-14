using SharpDX.XInput;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TetrisGame.Main;
using TetrisGame.Other;
using TetrisGame.Settings;

namespace TetrisGame
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            new InstanceManager(this);

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
            settingsLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            selectedLevelLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            rightArrowLabel.Font = new Font(hoogfont24, FontStyle.Regular);
            leftArrowLabel.Font = new Font(hoogfont24, FontStyle.Regular);

            tetrisLogo.Image = Properties.Resources.tetrislogo;
            this.BackgroundImage = Properties.Resources.gui;

            gravityTimer.Stop();

            if (InstanceManager.getGamepad().isConnected())
                MessageBox.Show("Controller detected! Please feel free to use the controller.");
        }

        private void NextShapeBox_Paint(object sender, PaintEventArgs e)
        {
            if (!stop)
            {
                InstanceManager.getNextShape().setNextShape(e.Graphics);
            }
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            InstanceManager.setGameGraphics(e.Graphics);

            if (!stop)
            {

                InstanceManager.getPlayer().Draw();

            }

            #region Collision

            InstanceManager.getPlayer().blockCollision(ref confirm, ref hardDrop, ref remove, level);

            if (InstanceManager.getPlayer().HitTop())
            {
                endGame();
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

            if(lines >= 10 && lines < 20 && level != 1 && selectedLevel < 1)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 925;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 20 && lines < 30 && level != 2 && selectedLevel < 2)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 850;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 30 && lines < 40 && level != 3 && selectedLevel < 3)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 775;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 40 && lines < 50 && level != 4 && selectedLevel < 4)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 700;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 50 && lines < 60 && level != 5 && selectedLevel < 5)
            {
                level++;
                InstanceManager.getSound().stopMusic();
                InstanceManager.getSound().playMusic(level);
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 625;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 60 && lines < 70 && level != 6 && selectedLevel < 6)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 550;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 70 && lines < 80 && level != 7 && selectedLevel < 7)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 475;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 80 && lines < 90 && level != 8 && selectedLevel < 8)
            {
                level++;
                InstanceManager.getSound().stopMusic();
                InstanceManager.getSound().playMusic(level);
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 400;
                InstanceManager.getSound().playLevelUp();
            }
            else if (lines >= 90 && level != 9 && selectedLevel < 9)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 325;
                InstanceManager.getSound().playLevelUp();
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

        public void endGame()
        {
            gravityTimer.Stop(); // stop gravity
            paused = true; // pause game
            stop = true; // stop music
            startLabel.Show(); // show start button
            settingsLabel.Show();
            tetrisLogo.Show(); // show tetris logo
            selectedLevelLabel.Show();
            leftArrowLabel.Show();
            rightArrowLabel.Show();
            githubLink.Show();
            createdByLabel.Show();
            gameBoard.Invalidate();
            InstanceManager.getSound().stopMusic();
            Debug.debugMessage("GAME: End", 1, false);
        }

        //used for when we remove a row, just does the other work.
        public void cleanUp()
        {
            remove = false;
            lines += InstanceManager.getPlayer().getLinesCleared(); // add one to lines removed
            InstanceManager.getSound().playClear(InstanceManager.getPlayer().getLinesCleared()); // play our clear sound
            score += points * InstanceManager.getPlayer().getLinesCleared(); // add 40 points to our score
            gameBoard.Invalidate();
        }

        public bool isPaused()
        {
            return paused;
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
            InstanceManager.getPlayer().Reset();

            if (level > 6)
                InstanceManager.getPlayer().randomBlock(level - 3);

            gameBoard.Invalidate();
        }

        #endregion

        #region Controls/Movement

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            movePlayer(e.KeyCode);

            switch (e.KeyCode)
            {
                case Keys.Escape:
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
                    break;
                case Keys.F4:
                    Debug.setUp();
                    break;
                case Keys.F1:
                    if (Debug.isEnabled())
                    {
                        int shape = InstanceManager.getRotate().getCurShape();
                        if (shape < 7)
                            shape++;
                        if (shape == 7)
                            shape = 1;

                        InstanceManager.getRotate().setCurShape(shape);
                        InstanceManager.getRotate().setCurAngel(1);
                        InstanceManager.getPlayer().setShape();
                        InstanceManager.getRotateCheck().setAllPositions();
                    }
                    break;
            }

            gameBoard.Invalidate();
        }

        public void movePlayer(Keys key)
        {
            //cant use switch statement since movementkeys are not a constant value.... thanks c#
            if (key == MovementKeys.DOWN)
            {
                if (paused)
                    return;

                confirm = true;

                if (InstanceManager.getMove().moveDown())
                {
                    movingDown = true;
                }
            }
            if (key == MovementKeys.LEFT)
            {
                InstanceManager.getMove().moveLeft();
            }
            if (key == MovementKeys.RIGHT)
            {
                InstanceManager.getMove().moveRight();
            }
            if (key == MovementKeys.ROTATE)
            {
                if (!rotating)
                {
                    if (paused)
                        return;
                    rotating = true;

                    InstanceManager.getRotate().rotateTetris();
                    InstanceManager.getSound().playRotate();
                }
            }
            if (key == MovementKeys.FORCEDROP)
            {
                if (fastFall || paused)
                    return;
                hardDrop = true;
                fastFall = true;
                InstanceManager.getPlayer().instantFall();
                confirm = true;
            }
        }

        public void keyUp(Keys key)
        {
            if(key == MovementKeys.LEFT || key == MovementKeys.RIGHT)
            {
                confirm = false;
            }
            if(key == MovementKeys.DOWN)
            {
                confirm = false;
                movingDown = false;
            }
            if(key == MovementKeys.ROTATE)
            {
                rotating = false;
            }
            if(key == MovementKeys.FORCEDROP)
            {
                fastFall = false;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(e.KeyCode);
        }

        #endregion

        #region Timers
        private void GravityTimer_Tick(object sender, EventArgs e)
        {
            InstanceManager.getPlayer().Gravity(ref gameBoard, ref movingDown);

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
            if (InstanceManager.getGamepad().isConnected())
                InstanceManager.getGamepad().ControllerUpdate();

            InstanceManager.getPlayer().update();

            if (remove)
                cleanUp();

        }

        #endregion

        #region Controller

        private void ThumbStickTimer_Tick(object sender, EventArgs e)
        {
            if (InstanceManager.getGamepad().isConnected())
            {

                if (InstanceManager.getGamepad().leftThumb.X < -50 || InstanceManager.getGamepad().gamepad.Buttons == GamepadButtonFlags.DPadLeft)
                {
                    InstanceManager.getMove().moveLeft();
                    gameBoard.Invalidate();
                }

                if (InstanceManager.getGamepad().leftThumb.X > 50 || InstanceManager.getGamepad().gamepad.Buttons == GamepadButtonFlags.DPadRight)
                {
                    InstanceManager.getMove().moveRight();
                    gameBoard.Invalidate();
                }

                if (InstanceManager.getGamepad().leftThumb.Y < -80 || InstanceManager.getGamepad().gamepad.Buttons == GamepadButtonFlags.DPadDown)
                {
                    if (paused)
                        return;
                    //TODO: remove ref
                    InstanceManager.getMove().joystickDown(ref movingDown);
                    InstanceManager.getSound().playMove();
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
            if (InstanceManager.getGamepad().isConnected())
            {
                State stateNew = InstanceManager.getGamepad().controller.GetState();
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
                        InstanceManager.getSound().playMusic(level);
                        startLabel.Hide();
                        settingsLabel.Hide();
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
            settingsLabel.Hide();
            selectedLevelLabel.Hide();
            leftArrowLabel.Hide();
            rightArrowLabel.Hide();
            tetrisLogo.Hide();
            githubLink.Hide();
            createdByLabel.Hide();
            resetGame();
            nextShapeBox.Invalidate();
            InstanceManager.getSound().playMusic(level);
        }

        private void GithubLink_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/StrugglingDoge/TetrisGame");
        }
        private void settingsLabel_Click(object sender, EventArgs e)
        {
            ChangeSettingsForm form = new ChangeSettingsForm();
            form.ShowDialog();
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            string oldText = ((Label)sender).Text;
            ((Label)sender).Text = ">" + oldText;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            string oldText = ((Label)sender).Text;
            ((Label)sender).Text = oldText.Remove(0, 1);
        }

        #endregion

    }
}

using Microsoft.DirectX.DirectSound;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TetrisGame
{
    
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.tetrisico; // set icon

            //add custom font
            byte[] fontData = Properties.Resources.hoog0553;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.hoog0553.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.hoog0553.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            hoogfont24 = new Font(fonts.Families[0], 24.0F); // setup 24pt font
            hoogfont28 = new Font(fonts.Families[0], 28.0F); // setup 28pt font

            controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;

            //set labels to correct font
            scoreLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);
            lineLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);
            levelLabel.Font = new System.Drawing.Font(hoogfont28, FontStyle.Regular);
            startLabel.Font = new System.Drawing.Font(hoogfont24, FontStyle.Regular);

            tetrisLogo.Image = Properties.Resources.tetris_logo;
            this.BackgroundImage = Properties.Resources.gui;

            //setup rows, placedrectangles, etc
            placedrect = new Rectangle[2];
            storedColor = new Brush[0];
            rows = new Rectangle[2];
            rand = new Random();

            gravityTimer.Stop();
            paused = true;

            //choose shape
            currentBlock = rand.Next(1, 8);

            if (currentBlock == 1)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 0;
                t1 = 32;
                t2 = 0;
                currentColor = Brushes.Purple;
                rotationAng = 1;
            }
            else if (currentBlock == 2)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 32;
                t1 = 32;
                t2 = 0;
                currentColor = Brushes.Red;
                rotationAng = 1;

            }
            else if (currentBlock == 3)
            {
                r1 = -32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                currentColor = Brushes.Blue;
                rotationAng = 1;

            }
            else if (currentBlock == 4)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 0;
                t2 = 64;
                t1 = 0;
                currentColor = Brushes.Cyan;
                rotationAng = 1;
            }
            else if (currentBlock == 5)
            {
                r1 = 32;
                r2 = 32;
                l1 = 0;
                l2 = (-32);
                t1 = 0;
                t2 = 32;
                currentColor = Brushes.Yellow;
                rotationAng = 1;
            }
            else if (currentBlock == 6)
            {
                r1 = 32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                currentColor = Brushes.Gold;
                rotationAng = 1;
            }
            else if (currentBlock == 7)
            {
                r1 = -32;
                r2 = 0;
                l1 = (-32);
                l2 = 32;
                t1 = 32;
                t2 = 0;
                currentColor = Brushes.LimeGreen;
                rotationAng = 1;
            }
            List<Brush> addcolor = storedColor.ToList();
            addcolor.Add(currentColor);
            addcolor.Add(currentColor);
            storedColor = addcolor.ToArray();

            for (int y = 0; y < 20; y++) // makes a 10x20 grid
            {
                for (int x = 0; x < 10; x++)
                {
                    List<Rectangle> addtile = rows.ToList();
                    addtile.Add(new Rectangle(x * 32, y * 32, 32, 32));
                    rows = addtile.ToArray();
                }
            }
            nextShape = rand.Next(1, 8);

            if (connected)
                MessageBox.Show("Controller detected! Please feel free to use the controller.");
        }

        private void NextShapeBox_Paint(object sender, PaintEventArgs e)
        {
            if (!stop)
            {
                if (nextShape == 1)
                {
                    nX = 34; nY = 50;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX + 32, nY + 0, 32, 32);
                    nThree = new Rectangle(nX - 32, nY - 0, 32, 32);
                    nFour = new Rectangle(nX + 0, nY - 32, 32, 32);
                    nextCol = Brushes.Purple;
                }
                else if (nextShape == 2)
                {
                    nX = 34; nY = 50;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX + 32, nY + 0, 32, 32);
                    nThree = new Rectangle(nX - 32, nY - 32, 32, 32);
                    nFour = new Rectangle(nX + 0, nY - 32, 32, 32);
                    nextCol = Brushes.Red;
                }
                else if (nextShape == 3)
                {
                    nX = 34; nY = 50;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX - 32, nY - 32, 32, 32);
                    nThree = new Rectangle(nX - 32, nY - 0, 32, 32);
                    nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                    nextCol = Brushes.Blue;
                }
                else if (nextShape == 4)
                {
                    nX = 27; nY = 40;
                    nOne = new Rectangle(nX, nY, 24, 24); // player controlled rect
                    nTwo = new Rectangle(nX + 24, nY + 0, 24, 24);
                    nThree = new Rectangle(nX - 24, nY - 0, 24, 24);
                    nFour = new Rectangle(nX + 48, nY - 0, 24, 24);
                    nextCol = Brushes.Cyan;
                }
                else if (nextShape == 5)
                {
                    nX = 17; nY = 20;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX + 32, nY + 32, 32, 32);
                    nThree = new Rectangle(nX - 0, nY - (-32), 32, 32);
                    nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                    nextCol = Brushes.Yellow;
                }
                else if (nextShape == 6)
                {
                    nX = 34; nY = 50;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX + 32, nY + -32, 32, 32);
                    nThree = new Rectangle(nX - 32, nY - 0, 32, 32);
                    nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                    nextCol = Brushes.Gold;
                }
                else if (nextShape == 7)
                {
                    nX = 34; nY = 50;
                    nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                    nTwo = new Rectangle(nX + -32, nY + 0, 32, 32);
                    nThree = new Rectangle(nX - (-32), nY - 32, 32, 32);
                    nFour = new Rectangle(nX + 0, nY - 32, 32, 32);
                    nextCol = Brushes.LimeGreen;
                }

                e.Graphics.FillRectangle(nextCol, nOne);
                e.Graphics.FillRectangle(nextCol, nTwo);
                e.Graphics.FillRectangle(nextCol, nThree);
                e.Graphics.FillRectangle(nextCol, nFour);


                e.Graphics.DrawRectangle(Pens.Black, nOne);
                e.Graphics.DrawRectangle(Pens.Black, nTwo);
                e.Graphics.DrawRectangle(Pens.Black, nThree);
                e.Graphics.DrawRectangle(Pens.Black, nFour);


            }
        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            if (!stop)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    e.Graphics.FillRectangle(storedColor[i], placedrect[i]);

                bOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
                bTwo = new Rectangle(plyX + r1, plyY + r2, 32, 32);
                bThree = new Rectangle(plyX - l1, plyY - l2, 32, 32);
                bFour = new Rectangle(plyX + t2, plyY - t1, 32, 32);
                //draw player rectangles
                e.Graphics.FillRectangle(currentColor, bOne);
                e.Graphics.FillRectangle(currentColor, bTwo);
                e.Graphics.FillRectangle(currentColor, bThree);
                e.Graphics.FillRectangle(currentColor, bFour);

                //if rows contain player or placed rect, draw grid
                for (int j = rows.Length - 1; j > 0; j--)
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (bOne.X == rows[j].X && bOne.Y == rows[j].Y || bTwo.X == rows[j].X && bTwo.Y == rows[j].Y || bThree.X == rows[j].X && bThree.Y == rows[j].Y
                        || bFour.X == rows[j].X && bFour.Y == rows[j].Y || placedrect[i].X == rows[j].X && placedrect[i].Y == rows[j].Y)
                            e.Graphics.DrawRectangle(new Pen(Color.Black), rows[j]);

            }

            //these 2 rectangles must be put off screen, they can interfere with gameplay
            placedrect[0].Y = 99999;
            placedrect[1].Y = 99999;


            #region Collision

            //player collision at the bottom of board, once reached duplicate player and reset player pos w/ new shape.
            if (plyY == 608 || bTwo.Y == 608 || bThree.Y == 608 || bFour.Y == 608)
            {
                confimTimer.Start();
                if (!confirm)
                    return;
                gravityTimer.Stop(); // stop gravity
                //reset player
                bOne = new Rectangle();
                bTwo = new Rectangle();
                bThree = new Rectangle();
                bFour = new Rectangle();

                //we duplicate the four player rectangles pos
                List<Rectangle> createblock = placedrect.ToList();
                createblock.Add(new Rectangle(plyX, plyY, 32, 32));
                createblock.Add(new Rectangle(plyX + r1, plyY + r2, 32, 32));
                createblock.Add(new Rectangle(plyX - l1, plyY - l2, 32, 32));
                createblock.Add(new Rectangle(plyX + t2, plyY - t1, 32, 32));
                placedrect = createblock.ToArray();

                //we duplicate the shapes color
                List<Brush> addcolor = storedColor.ToList();
                addcolor.Add(currentColor);
                addcolor.Add(currentColor);
                addcolor.Add(currentColor);
                addcolor.Add(currentColor);
                storedColor = addcolor.ToArray();

                //reset player pos
                plyY = 0;
                plyX = 160;

                //generate random number between 1 and 7
                currentBlock = nextShape;

                //set player to what ever number was selected
                if (currentBlock == 1)
                {
                    r1 = 32;
                    r2 = 0;
                    l1 = 32;
                    l2 = 0;
                    t1 = 32;
                    t2 = 0;
                    currentColor = Brushes.Purple;
                    rotationAng = 1;
                }
                else if (currentBlock == 2)
                {
                    r1 = 32;
                    r2 = 0;
                    l1 = 32;
                    l2 = 32;
                    t1 = 32;
                    t2 = 0;
                    currentColor = Brushes.Red;
                    rotationAng = 1;

                }
                else if (currentBlock == 3)
                {
                    r1 = -32;
                    r2 = -32;
                    l1 = 32;
                    l2 = 0;
                    t1 = 0;
                    t2 = 32;
                    currentColor = Brushes.Blue;
                    rotationAng = 1;

                }
                else if (currentBlock == 4)
                {
                    r1 = 32;
                    r2 = 0;
                    l1 = 32;
                    l2 = 0;
                    t2 = 64;
                    t1 = 0;
                    currentColor = Brushes.Cyan;
                    rotationAng = 1;
                }
                else if (currentBlock == 5)
                {
                    r1 = 32;
                    r2 = 32;
                    l1 = 0;
                    l2 = (-32);
                    t1 = 0;
                    t2 = 32;
                    currentColor = Brushes.Yellow;
                    rotationAng = 1;
                }
                else if (currentBlock == 6)
                {
                    r1 = 32;
                    r2 = -32;
                    l1 = 32;
                    l2 = 0;
                    t1 = 0;
                    t2 = 32;
                    currentColor = Brushes.Gold;
                    rotationAng = 1;
                }
                else if (currentBlock == 7)
                {
                    r1 = -32;
                    r2 = 0;
                    l1 = (-32);
                    l2 = 32;
                    t1 = 32;
                    t2 = 0;
                    currentColor = Brushes.LimeGreen;
                    rotationAng = 1;
                }

                playFall(); // play fall sound.
                nextShape = rand.Next(1, 8);

                gravityTimer.Start();// enable gravity
                confimTimer.Stop();
                confirm = false;
                nextShapeBox.Invalidate();
            }

            // if player rectangle collides with placed rectangles
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                    || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                    || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                    || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                {
                    confimTimer.Start();
                    if (!confirm)
                        return;

                    if (plyY < 0) // if above screen, stop, this may not be an issue anymore, keeping just incase.
                        return;

                    gravityTimer.Stop(); // stop gravity

                    //reset player
                    bOne = new Rectangle();
                    bTwo = new Rectangle();
                    bThree = new Rectangle();
                    bFour = new Rectangle();

                    if (!bOne.Contains(placedrect[i]) // this check is supposed to be incase the player rotates into a placed rect
                    || !bTwo.Contains(placedrect[i]) // it may not work, not sure.
                    || !bThree.Contains(placedrect[i])
                    || !bFour.Contains(placedrect[i]))
                    {
                        //duplicate player pos
                        List<Rectangle> createblock = placedrect.ToList();
                        createblock.Add(new Rectangle(plyX, plyY, 32, 32));
                        createblock.Add(new Rectangle(plyX + r1, plyY + r2, 32, 32));
                        createblock.Add(new Rectangle(plyX - l1, plyY - l2, 32, 32));
                        createblock.Add(new Rectangle(plyX + t2, plyY - t1, 32, 32));
                        placedrect = createblock.ToArray();
                        //duplicate shapes color
                        List<Brush> addcolor = storedColor.ToList();
                        addcolor.Add(currentColor);
                        addcolor.Add(currentColor);
                        addcolor.Add(currentColor);
                        addcolor.Add(currentColor);
                        storedColor = addcolor.ToArray();
                    }

                    //reset player pos
                    plyY = 0;
                    plyX = 160;

                    //select random number for next shape
                    currentBlock = nextShape;

                    //set shape
                    if (currentBlock == 1)
                    {
                        r1 = 32;
                        r2 = 0;
                        l1 = 32;
                        l2 = 0;
                        t1 = 32;
                        t2 = 0;
                        currentColor = Brushes.Purple;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 2)
                    {
                        r1 = 32;
                        r2 = 0;
                        l1 = 32;
                        l2 = 32;
                        t1 = 32;
                        t2 = 0;
                        currentColor = Brushes.Red;
                        rotationAng = 1;

                    }
                    else if (currentBlock == 3)
                    {
                        r1 = -32;
                        r2 = -32;
                        l1 = 32;
                        l2 = 0;
                        t1 = 0;
                        t2 = 32;
                        currentColor = Brushes.Blue;
                        rotationAng = 1;

                    }
                    else if (currentBlock == 4)
                    {
                        r1 = 32;
                        r2 = 0;
                        l1 = 32;
                        l2 = 0;
                        t2 = 64;
                        t1 = 0;
                        currentColor = Brushes.Cyan;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 5)
                    {
                        r1 = 32;
                        r2 = 32;
                        l1 = 0;
                        l2 = (-32);
                        t1 = 0;
                        t2 = 32;
                        currentColor = Brushes.Yellow;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 6)
                    {
                        r1 = 32;
                        r2 = -32;
                        l1 = 32;
                        l2 = 0;
                        t1 = 0;
                        t2 = 32;
                        currentColor = Brushes.Gold;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 7)
                    {
                        r1 = -32;
                        r2 = 0;
                        l1 = (-32);
                        l2 = 32;
                        t1 = 32;
                        t2 = 0;
                        currentColor = Brushes.LimeGreen;
                        rotationAng = 1;
                    }

                    nextShape = rand.Next(1, 8);
                    playFall();// play fall sound

                    gravityTimer.Start();// enable gravity

                    confirm = false;
                    confimTimer.Stop();
                    nextShapeBox.Invalidate();
                }

            try
            {
                for (int i = placedrect.Length - 1; i > 1; i--)
                    if (placedrect[i].Y == 0) // if placed rectangle reaches top of board, end game.
                    {
                        placedrect = new Rectangle[2];
                        gravityTimer.Stop(); // stop gravity
                        paused = true; // pause game
                        stop = true; // stop music
                        playMusic();
                        startLabel.Show(); // show start button
                        tetrisLogo.Show(); // show tetris logo
                        gameBoard.Invalidate();
                    }
            }
            catch (Exception) { }

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

            if(lines == 10 && level != 1)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 925;
                playLevelUp();
            }
            else if (lines == 20 && level != 2)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 850;
                playLevelUp();
            }
            else if (lines == 30 && level != 3)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 775;
                playLevelUp();
            }
            else if (lines == 40 && level != 4)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 700;
                playLevelUp();
            }
            else if (lines == 50 && level != 5)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 625;
                playLevelUp();
            }
            else if (lines == 60 && level != 6)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 550;
                playLevelUp();
            }
            else if (lines == 70 && level != 7)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 475;
                playLevelUp();
            }
            else if (lines == 80 && level != 8)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 400;
                playLevelUp();
            }
            else if (lines == 90 && level != 9)
            {
                level++;
                points += 40;
                levelLabel.Text = "0" + level;
                gravityTimer.Interval = 325;
                playLevelUp();
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
        private void cleanUp()
        {
            lines++; // add one to lines removed
            playClear(); // play our clear sound
            score += points; // add 40 points to our score
            resetBank(); // reset all banks
            gameBoard.Invalidate();
        }

        private void resetGame()
        {
            //reset stats
            points = 40;
            lines = 0;
            score = 0;
            level = 0;
            levelLabel.Text = "00";
            scoreLabel.Text = "0";
            //reset timer interval
            gravityTimer.Interval = 1000;
            //wipe all placed rectangles
            placedrect = new Rectangle[2];
            //reset bank
            resetBank();
            //reset all stored colors
            storedColor = new Brush[0];
            List<Brush> addcolor = storedColor.ToList();
            addcolor.Add(currentColor);
            addcolor.Add(currentColor);
            storedColor = addcolor.ToArray();
            gameBoard.Invalidate();
        }

        //wipe all banks
        private void resetBank()
        {
            bank1 = new int[0];
            row1 = 0;
            bank2 = new int[0];
            row2 = 0;
            bank3 = new int[0];
            row3 = 0;
            bank4 = new int[0];
            row4 = 0;
            bank5 = new int[0];
            row5 = 0;
            bank6 = new int[0];
            row6 = 0;
            bank7 = new int[0];
            row7 = 0;
            bank8 = new int[0];
            row8 = 0;
            bank9 = new int[0];
            row9 = 0;
            bank10 = new int[0];
            row10 = 0;
            bank11 = new int[0];
            row11 = 0;
            bank12 = new int[0];
            row12 = 0;
            bank13 = new int[0];
            row13 = 0;
            bank14 = new int[0];
            row14 = 0;
            bank15 = new int[0];
            row15 = 0;
            bank16 = new int[0];
            row16 = 0;
            bank17 = new int[0];
            row17 = 0;
            bank18 = new int[0];
            row18 = 0;
            bank19 = new int[0];
            row19 = 0;
            bank20 = new int[0];
            row20 = 0;
        }

        #endregion

        #region Music/SFX

        private void playFall()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.fall, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.fall, dev);
            sound.Volume = -1000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        private void playLevelUp()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.lvlup, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.lvlup, dev);
            sound.Volume = -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        private void playClear()
        {
            if (lines == 10 || lines == 20 || lines == 30
                || lines == 40 || lines == 50 || lines == 60
                || lines == 70 || lines == 80 || lines == 90)
                return;

            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.clear, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.clear, dev);
            sound.Volume = -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        private void playRotate()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.rotate, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.rotate, dev);
            sound.Volume = -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        private void playMove()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.move, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.move, dev);
            sound.Volume = -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        private void playMusic()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            soundBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.tetris_loop, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.tetris_loop, dev);
            sound.Volume = -3000;

            if (!stop)
                sound.Play(0, BufferPlayFlags.Looping);
            else
                sound.Stop();
        }

        #endregion

        #region Controls/Movement

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.S:

                    confirm = true;

                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                            return;
                    if (paused)
                        return;
                    if (bOne.Y != 608 && bTwo.Y != 608
                && bThree.Y != 608 && bFour.Y != 608)
                    {
                        plyY += 32;
                        playMove();
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
                    moveLeft();
                    break;
                case Keys.Right:
                case Keys.D:
                    moveRight();
                    break;
                case Keys.K:
                    break;
                case Keys.Z:
                case Keys.X:
                case Keys.Up:
                    if (!rotating)
                    {
                        rotating = true;
                        if (paused)
                            return;
                        for (int i = placedrect.Length - 1; i > 0; i--)
                            if (bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X + 32
                                || bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X - 32)
                                return;
                        for (int i = placedrect.Length - 1; i > 0; i--)
                            if (currentBlock == 4 && bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X + 32 || currentBlock == 4 && rotationAng == 1 && bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X - 64
                                || currentBlock == 4 && bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X - 32 || currentBlock == 4 && rotationAng == 1 && bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X + 64)
                                return;
                        if (currentBlock == 1)
                        {
                            rotateTblock();
                        }
                        else if (currentBlock == 2)
                        {
                            rotateZblock();
                        }
                        else if (currentBlock == 3)
                        {
                            rotateJblock();
                        }
                        else if (currentBlock == 4)
                        {
                            rotateIblock();
                        }
                        else if (currentBlock == 6)
                        {
                            rotateLblock();
                        }
                        else if (currentBlock == 7)
                        {
                            rotateSblock();
                        }
                    }
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
                case Keys.Z: 
                case Keys.X:
                case Keys.Up:
                    rotating = false;
                    break;
            }
        }


        private void moveRight()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.X == placedrect[i].X - 32 && bOne.Y == placedrect[i].Y
                    || bTwo.X == placedrect[i].X - 32 && bTwo.Y == placedrect[i].Y
                    || bThree.X == placedrect[i].X - 32 && bThree.Y == placedrect[i].Y
                    || bFour.X == placedrect[i].X - 32 && bFour.Y == placedrect[i].Y
                    || bOne.X >= 288
                    || bTwo.X >= 288
                    || bThree.X >= 288
                    || bFour.X >= 288)
                {
                    return;
                }
            if (paused)
                return;
            plyX += 32;
            playMove();

        }

        private void moveLeft()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.X == placedrect[i].X + 32 && bOne.Y == placedrect[i].Y
                    || bTwo.X == placedrect[i].X + 32 && bTwo.Y == placedrect[i].Y
                    || bThree.X == placedrect[i].X + 32 && bThree.Y == placedrect[i].Y
                    || bFour.X == placedrect[i].X + 32 && bFour.Y == placedrect[i].Y
                    || bOne.X <= 0
                    || bTwo.X <= 0
                    || bThree.X <= 0
                    || bFour.X <= 0)
                {
                    return;
                }
            if (paused)
                return;

            plyX -= 32;
            playMove();

        }
        #endregion

        #region Rotation Logic

        /*
         * 
         * Each shape has its own rotation function, all it does is check current rotation
         * and sets rectangles to a new position and adds one to rotationAng.
         * 
         * Also, some have checks to make sure that in certain areas you are unable to
         * rotate our of the game board/into another placed block.
         * 
         */

        private void rotateIblock()
        {
            if (rotationAng == 1)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                        return;

                if (plyY == 608)
                    return;

                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = 0;
                r2 = 64;
                l1 = 0;
                l2 = (-32);
                t1 = 32;
                t2 = 0;
                rotationAng++;
                playRotate();
            }
            else if(rotationAng == 2)
            {
                if (plyX == 288)
                    plyX -= 64;
                else if (plyX == 256)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 0;
                t2 = 64;
                t1 = 0;
                rotationAng = 1;
                playRotate();
            }
        }

        private void rotateTblock()
        {
            if (rotationAng == 1)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X + 64
                            || bTwo.Y == placedrect[i].Y && bTwo.X == placedrect[i].X + 32
                            || bThree.Y == placedrect[i].Y && bThree.X == placedrect[i].X + 32
                            || bFour.Y == placedrect[i].Y && bFour.X == placedrect[i].X + 32 || bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X - 64
                            || bTwo.Y == placedrect[i].Y && bTwo.X == placedrect[i].X - 32
                            || bThree.Y == placedrect[i].Y && bThree.X == placedrect[i].X - 32
                            || bFour.Y == placedrect[i].Y && bFour.X == placedrect[i].X - 32)
                        return;

                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                        return;

                if (plyY == 608)
                    return;

                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = 0;
                t2 = t1;
                t1 = 0;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 2)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X + 64
                            || bTwo.Y == placedrect[i].Y && bTwo.X == placedrect[i].X + 64
                            || bThree.Y == placedrect[i].Y && bThree.X == placedrect[i].X + 64
                            || bFour.Y == placedrect[i].Y && bFour.X == placedrect[i].X + 64 || bOne.Y == placedrect[i].Y && bOne.X == placedrect[i].X - 64
                            || bTwo.Y == placedrect[i].Y && bTwo.X == placedrect[i].X - 64
                            || bThree.Y == placedrect[i].Y && bThree.X == placedrect[i].X - 64
                            || bFour.Y == placedrect[i].Y && bFour.X == placedrect[i].X - 64)
                        return;
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = r2;
                r2 = 0;
                l1 = l2;
                l2 = 0;
                t1 = -t2;
                t2 = 0;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 3)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = 0;
                t2 = t1;
                t1 = 0;
                rotationAng = 2;
                playRotate();
            }
        }

        private void rotateZblock()
        {
            if (rotationAng == 1)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                        return;
                if (plyY == 608)
                    return;

                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = -32;
                t2 = t1;
                t1 = 0;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 2)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = r2;
                r2 = 0;
                l1 = l2;
                l2 = 32;
                t1 = t2;
                t2 = 0;
                rotationAng = 1;
                playRotate();
            }
        }

        private void rotateSblock()
        {
            if (rotationAng == 1)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                        return;
                if (plyY == 608)
                    return;

                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = -32;
                t2 = t1;
                t1 = 0;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 2)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = r2;
                r2 = 0;
                l1 = l2;
                l2 = 32;
                t1 = t2;
                t2 = 0;
                rotationAng = 1;
                playRotate();
            }
        }

        private void rotateJblock()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                        || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                        || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                        || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                    return;

            if (plyY == 608)
                return;

            if (rotationAng == 1)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = 32;
                r1 = 0;
                l2 = 32;
                l1 = 0;
                t2 = 32;
                t1 = 32;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 2)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = 32;
                r2 = 32;
                l1 = l2;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng++;
                playRotate();
            }
            else if(rotationAng == 3)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = -32;
                r2 = 32;
                l1 = 0;
                l2 = 32;
                t1 = (-32);
                t2 = 0;
                rotationAng++;
                playRotate();
            }
            else if(rotationAng == 4)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = -32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng = 1;
                playRotate();
            }
        }

        private void rotateLblock()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                        || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                        || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                        || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                    return;

            if (plyY == 608)
                return;

            if (rotationAng == 1)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r2 = 32;
                r1 = 0;
                l2 = 32;
                l1 = 0;
                t2 = 32;
                t1 = (-32);
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 2)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = (-32);
                r2 = 32;
                l1 = l2;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 3)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = -32;
                r2 = (-32);
                l1 = 0;
                l2 = 32;
                t1 = (-32);
                t2 = 0;
                rotationAng++;
                playRotate();
            }
            else if (rotationAng == 4)
            {
                if (plyX == 288)
                    plyX -= 32;
                else if (plyX == 0)
                    plyX += 32;
                r1 = 32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng = 1;
                playRotate();
            }
        }

        #endregion

        #region Timers
        private void GravityTimer_Tick(object sender, EventArgs e)
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                        || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                        || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                        || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                {// if player is above an already placed shape, we return.
                    gameBoard.Invalidate();
                    return;
                }

            if (bOne.Y != 608 && bTwo.Y != 608
            && bThree.Y != 608 && bFour.Y != 608 && !movingDown) // make sure we aren't at the bottom of the board.
                plyY += 32;

            gameBoard.Invalidate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //this timer just allows the player to make a last second move once they have reach the
            //bottom of the board or are abover another shape
            confirm = true;
        }

        #endregion

        private void StartLabel_Click(object sender, EventArgs e)
        {
            gravityTimer.Start();
            paused = false;
            stop = false;
            playMusic();
            startLabel.Hide();
            tetrisLogo.Hide();
            resetGame();
            nextShapeBox.Invalidate();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {

            Update();

            #region Check Row

            /*
             * 
             * Here we check if any grid box(hidden) contains a placed rectangle,
             * if it does, we add the placed rectangle's index into the corresponding
             * bank(row).
             * 
             * --only commenting on bank1 because every other row is the same.
             * 
             */

            for (int i = placedrect.Length - 1; i > 0; i--)
                for (int j = rows.Length - 1; j > 0; j--)
                    if (placedrect[i].Contains(rows[j])) // if a row is contained in a placed rectangle
                    {
                        if (!bank1.Contains(i) && placedrect[i].Y == 608)
                        {

                            List<int> addbank = bank1.ToList();
                            addbank.Add(i); // add index of placed rectangle to bank
                            bank1 = addbank.ToArray();
                            Array.Sort(bank1);// sort array from big to least
                            row1++; // add one to row1 counter
                        }
                        else if (!bank2.Contains(i) && placedrect[i].Y == 576)
                        {
                            List<int> addbank = bank2.ToList();
                            addbank.Add(i);
                            bank2 = addbank.ToArray();
                            Array.Sort(bank2);
                            row2++;
                        }
                        else if (!bank3.Contains(i) && placedrect[i].Y == 544)
                        {
                            List<int> addbank = bank3.ToList();
                            addbank.Add(i);
                            bank3 = addbank.ToArray();
                            Array.Sort(bank3);
                            row3++;
                        }
                        else if (!bank4.Contains(i) && placedrect[i].Y == 512)
                        {
                            List<int> addbank = bank4.ToList();
                            addbank.Add(i);
                            bank4 = addbank.ToArray();
                            Array.Sort(bank4);
                            row4++;
                        }
                        else if (!bank5.Contains(i) && placedrect[i].Y == 480)
                        {
                            List<int> addbank = bank5.ToList();
                            addbank.Add(i);
                            bank5 = addbank.ToArray();
                            Array.Sort(bank5);
                            row5++;
                        }
                        else if (!bank6.Contains(i) && placedrect[i].Y == 448)
                        {
                            List<int> addbank = bank6.ToList();
                            addbank.Add(i);
                            bank6 = addbank.ToArray();
                            Array.Sort(bank6);
                            row6++;
                        }
                        else if (!bank7.Contains(i) && placedrect[i].Y == 416)
                        {
                            List<int> addbank = bank7.ToList();
                            addbank.Add(i);
                            bank7 = addbank.ToArray();
                            Array.Sort(bank7);
                            row7++;
                        }
                        else if (!bank8.Contains(i) && placedrect[i].Y == 384)
                        {
                            List<int> addbank = bank8.ToList();
                            addbank.Add(i);
                            bank8 = addbank.ToArray();
                            Array.Sort(bank8);
                            row8++;
                        }
                        else if (!bank9.Contains(i) && placedrect[i].Y == 352)
                        {
                            List<int> addbank = bank9.ToList();
                            addbank.Add(i);
                            bank9 = addbank.ToArray();
                            Array.Sort(bank9);
                            row9++;
                        }
                        else if (!bank10.Contains(i) && placedrect[i].Y == 320)
                        {
                            List<int> addbank = bank10.ToList();
                            addbank.Add(i);
                            bank10 = addbank.ToArray();
                            Array.Sort(bank10);
                            row10++;
                        }
                        else if (!bank11.Contains(i) && placedrect[i].Y == 288)
                        {
                            List<int> addbank = bank11.ToList();
                            addbank.Add(i);
                            bank11 = addbank.ToArray();
                            Array.Sort(bank11);
                            row11++;
                        }
                        else if (!bank12.Contains(i) && placedrect[i].Y == 256)
                        {
                            List<int> addbank = bank12.ToList();
                            addbank.Add(i);
                            bank12 = addbank.ToArray();
                            Array.Sort(bank12);
                            row12++;
                        }
                        else if (!bank13.Contains(i) && placedrect[i].Y == 224)
                        {
                            List<int> addbank = bank13.ToList();
                            addbank.Add(i);
                            bank13 = addbank.ToArray();
                            Array.Sort(bank13);
                            row13++;
                        }
                        else if (!bank14.Contains(i) && placedrect[i].Y == 192)
                        {
                            List<int> addbank = bank14.ToList();
                            addbank.Add(i);
                            bank14 = addbank.ToArray();
                            Array.Sort(bank14);
                            row14++;
                        }
                        else if (!bank15.Contains(i) && placedrect[i].Y == 160)
                        {
                            List<int> addbank = bank15.ToList();
                            addbank.Add(i);
                            bank15 = addbank.ToArray();
                            Array.Sort(bank15);
                            row15++;
                        }
                        else if (!bank16.Contains(i) && placedrect[i].Y == 128)
                        {
                            List<int> addbank = bank16.ToList();
                            addbank.Add(i);
                            bank16 = addbank.ToArray();
                            Array.Sort(bank16);
                            row16++;
                        }
                        else if (!bank17.Contains(i) && placedrect[i].Y == 96)
                        {
                            List<int> addbank = bank17.ToList();
                            addbank.Add(i);
                            bank17 = addbank.ToArray();
                            Array.Sort(bank17);
                            row17++;
                        }
                        else if (!bank18.Contains(i) && placedrect[i].Y == 64)
                        {
                            List<int> addbank = bank18.ToList();
                            addbank.Add(i);
                            bank18 = addbank.ToArray();
                            Array.Sort(bank18);
                            row18++;
                        }
                        else if (!bank19.Contains(i) && placedrect[i].Y == 32)
                        {
                            List<int> addbank = bank19.ToList();
                            addbank.Add(i);
                            bank19 = addbank.ToArray();
                            Array.Sort(bank19);
                            row19++;
                        }
                        else if (!bank20.Contains(i) && placedrect[i].Y == 0)
                        {
                            List<int> addbank = bank20.ToList();
                            addbank.Add(i);
                            bank20 = addbank.ToArray();
                            Array.Sort(bank20);
                            row20++;
                        }

                    }
            #endregion

            #region Remove Row
            /*
             * 
             * Yes, this is a mess but this is required to remove rows if they're full.
             * 
             * Each row contains it's own 'bank' which contains the placed rectangles on that Y level
             * for each rectangle in the row, we add one, so once it equals 10 it passes to down here.
             * 
             * We check each row individually.
             * 
             */

            try
            {
                if (row1 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank1[i]); // remove rectangles stored in bank array
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank1[i]); // remove color stored in bank array
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        placedrect[i].Y += 32; // move all remaining blocks down
                    cleanUp(); // clean up
                }
                else if (row2 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank2[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank2[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 576)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row3 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank3[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank3[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 544)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row4 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank4[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank4[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 512)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row5 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank5[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank5[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 480)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row6 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank6[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank6[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 448)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row7 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank7[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank7[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 416)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row8 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank8[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank8[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 384)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row9 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank9[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank9[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 352)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row10 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank10[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank10[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 320)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row11 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank11[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank11[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 288)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row12 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank12[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank12[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 256)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row13 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank13[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank13[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 224)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row14 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank14[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank14[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 192)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row15 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank15[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank15[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 160)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row16 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank16[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank16[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 128)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row17 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank17[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank17[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 96)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row18 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank18[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank18[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 64)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row19 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank19[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank19[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 32)
                            placedrect[i].Y += 32;
                    cleanUp();
                }
                else if (row20 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank20[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank20[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    cleanUp();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("" + bank1[1]);
            }

            #endregion

        }

        public void Update()
        {
            if (!connected)
                return;

            gamepad = controller.GetState().Gamepad;

            leftThumb.X = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
            leftThumb.Y = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;
            rightThumb.Y = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
            rightThumb.X = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;


            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;
        }

        private void ThumbStickTimer_Tick(object sender, EventArgs e)
        {
            if (connected)
            {

                if (leftThumb.X < -50 || gamepad.Buttons == GamepadButtonFlags.DPadLeft)
                {
                    moveLeft();
                    gameBoard.Invalidate();
                }

                if (leftThumb.X > 50 || gamepad.Buttons == GamepadButtonFlags.DPadRight)
                {
                    moveRight();
                    gameBoard.Invalidate();
                }

                if (leftThumb.Y < -80 || gamepad.Buttons == GamepadButtonFlags.DPadDown)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                            return;
                    if (paused)
                        return;
                    if (bOne.Y != 608 && bTwo.Y != 608
                && bThree.Y != 608 && bFour.Y != 608)
                    {
                        plyY += 32;
                        movingDown = true;
                        playMove();
                    }
                    gameBoard.Invalidate();
                }
                else
                {
                    movingDown = false;
                }
            }
            else
            {
                thumbStickTimer.Stop();
                controllerButtonTimer.Stop();
            }
        }

        private void ControllerButtonTimer_Tick(object sender, EventArgs e)
        {
            if (connected)
            {
                State stateNew = controller.GetState();
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
                        playMusic();
                        startLabel.Hide();
                        tetrisLogo.Hide();
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
    }
}

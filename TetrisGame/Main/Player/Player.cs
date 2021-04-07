using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TetrisGame.Other;

namespace TetrisGame.Main.Player
{
    public class Player
    {
        public Rectangle[] placedrect, rows;
        public Rectangle bOne, bTwo, bThree, bFour;
        public int plyX = 160;
        public int plyY = 32;

        int randX = 0;

        Graphics graphics;

        public int r1 = 32;
        public int r2 = 0;
        public int l1 = 32;
        public int l2 = 32;
        public int t1 = 32;
        public int t2 = 0;

        Bitmap currentTetImage;
        Font debugFont;

        Brush currentColor;
        Brush[] storedColor;

        SFX sfx;
        RowCheck checkRow;
        Random rand;
        Timer confirmTimer;
        Timer gravityTimer;
        PictureBox nextShapeBox;
        Prediction predict;

        public Player()
        {
            sfx = InstanceManager.getSound();
            checkRow = InstanceManager.getRowCheck();
            confirmTimer = InstanceManager.getMainForm().confimTimer;
            gravityTimer = InstanceManager.getMainForm().gravityTimer;
            nextShapeBox = InstanceManager.getMainForm().nextShapeBox;
            predict = InstanceManager.getPredict();
            rand = InstanceManager.getRandom();

            debugFont = new Font("Arial", 12.0F);

            //setup rows, placedrectangles, etc
            placedrect = new Rectangle[2];
            storedColor = new Brush[0];
            rows = new Rectangle[2];
            rand = new Random();

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

            InstanceManager.getNextShape().generateNextShape();
        }

        /// <summary>
        /// This function is used to check if any placed tetris blocks reaches the top of the screen.
        /// If it does, it will end the game.
        /// </summary>
        /// <returns></returns>
        public bool HitTop()
        {
            for (int i = placedrect.Length - 1; i > 1; i--)
                if (placedrect[i].Y == 0) // if placed rectangle reaches top of board, end game.
                {
                    Debug.debugMessage("Rectangle " + i + " reached top of screen.", 1);
                    placedrect = new Rectangle[2];
                    return true;
                }

            return false;
        }

        /// <summary>
        /// This is a very important function. This adds proper collision detection to the tetris blocks
        /// to allow the blocks to land on top of eachother and makes sure the tetris blocks do not go past
        /// the bottom of the board.
        /// </summary>
        /// <param name="confirmTimer"></param>
        /// <param name="gravityTimer"></param>
        /// <param name="confirm"></param>
        /// <param name="nextShapeBox"></param>
        public void blockCollision(ref bool confirm, ref bool hardDrop, ref bool remove, int level)
        {

            //these 2 rectangles must be put off screen, they can interfere with gameplay
            placedrect[0].Y = 99999;
            placedrect[1].Y = 99999;

            //player collision at the bottom of board, once reached duplicate player and reset player pos w/ new shape.
            try
            {
                if (plyY == 608 || bTwo.Y == 608 || bThree.Y == 608 || bFour.Y == 608)
                {
                    confirmTimer.Start();
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

                    checkRow.update(ref placedrect, ref storedColor, ref remove);

                    if (getLinesCleared() > 1 && level > 6)
                    {
                        for (int f = placedrect.Length - 1; f > 0; f--)
                            placedrect[f].Y -= 32;
                        randomBlock(1);
                    }

                    //reset player pos
                    plyY = 0;
                    plyX = 160;

                    InstanceManager.getRotate().setCurShape(InstanceManager.getNextShape().getNextShape());
                    InstanceManager.getRotateCheck().setAllPositions();
                    predict.reset();

                    //set player to what ever number was selected
                    setShape();

                    if (hardDrop)
                        sfx.playHardDrop();
                    else if (!hardDrop)
                        sfx.playFall(); // play fall sound.

                    //generate random number between 1 and 7
                    InstanceManager.getNextShape().generateNextShape();

                    gravityTimer.Start();// enable gravity
                    confirmTimer.Stop();
                    hardDrop = false;
                    confirm = false;
                    nextShapeBox.Invalidate();
                    try
                    {
                        if (Debug.isEnabled() && Debug.getSelection() == 2)
                        {
                            checkRow.update(ref placedrect, ref storedColor, ref remove);
                            checkRow.update(ref placedrect, ref storedColor, ref remove);
                            Debug.debugMessage(checkRow.showBoard(), 2);
                        }

                    }
                    catch (Exception) { }
                }

                // if player rectangle collides with placed rectangles
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                        || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                        || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                        || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                    {
                        confirmTimer.Start();
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
                        checkRow.update(ref placedrect, ref storedColor, ref remove);

                        if (getLinesCleared() > 1 && level > 6)
                        {
                            for (int f = placedrect.Length - 1; f > 0; f--)
                                placedrect[f].Y -= 32;
                            randomBlock(1);
                        }

                        //reset player pos
                        plyY = 0;
                        plyX = 160;

                        //select random number for next shape
                        InstanceManager.getRotate().setCurShape(InstanceManager.getNextShape().getNextShape());
                        InstanceManager.getRotateCheck().setAllPositions();
                        predict.reset();

                        //set shape
                        setShape();

                        InstanceManager.getNextShape().generateNextShape();

                        if (hardDrop)
                            sfx.playHardDrop();
                        else if (!hardDrop)
                            sfx.playFall(); // play fall sound.

                        gravityTimer.Start();// enable gravity

                        confirm = false;
                        hardDrop = false;
                        confirmTimer.Stop();
                        nextShapeBox.Invalidate();
                        try
                        {
                            if (Debug.isEnabled() && Debug.getSelection() == 2)
                            {
                                checkRow.update(ref placedrect, ref storedColor, ref remove);
                                checkRow.update(ref placedrect, ref storedColor, ref remove);
                                Debug.debugMessage(checkRow.showBoard(), 2);
                            }
                        }
                        catch (Exception) { }
                    }
            }
            catch (Exception ex) { Debug.debugMessage("GAME: Unable to check on block! " + ex.Message, 1, true); }
        }

        internal int getLinesCleared()
        {
            return checkRow.getLinesCleared();
        }

        public void instantFall()
        {
            if (predict.isStopped())
            {
                plyY = predict.getY();
            }
        }

        public int getY()
        {
            return plyY;
        }

        /// <summary>
        /// Draws the proper rectangles and grid on screen.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw()
        {
            if (graphics != InstanceManager.getGameGraphics())
                graphics = InstanceManager.getGameGraphics();

            for (int i = placedrect.Length - 1; i > 0; i--)
                graphics.DrawImage(BlockUtils.translateColorToImage(storedColor[i], false), placedrect[i]);

            predict.Draw(graphics, currentColor);

            bOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
            bTwo = new Rectangle(plyX + r1, plyY + r2, 32, 32);
            bThree = new Rectangle(plyX - l1, plyY - l2, 32, 32);
            bFour = new Rectangle(plyX + t2, plyY - t1, 32, 32);
            //draw player rectangles
            graphics.DrawImage(currentTetImage, bOne);
            graphics.DrawImage(currentTetImage, bTwo);
            graphics.DrawImage(currentTetImage, bThree);
            graphics.DrawImage(currentTetImage, bFour);

            //Helpful debug information
            if (Debug.isEnabled())
            {
                Rectangle[] positions = new Rectangle[] { bOne, bTwo, bThree, bFour };
                int lastY = 0;
                for (int i = 0; i < positions.Length; i++)
                {
                    string blPos = "";
                    switch (i)
                    {
                        case 1:
                            blPos = " r1: " + r1 + " r2: " + r2;
                            break;
                        case 2:
                            blPos = " l1: " + l1 + " l2: " + l2;
                            break;
                        case 3:
                            blPos = " t1: " + r1 + " t2: " + t2;
                            break;
                    }
                    graphics.DrawString("(" + i + ")X: " + positions[i].X + " " + " Y: " + positions[i].Y + blPos, debugFont, Brushes.White, new Point(0, (i * 18)));
                    lastY = i + 1;
                }
                graphics.DrawString("ply", debugFont, Brushes.Black, bOne.X + 3, bOne.Y + 5);
                graphics.DrawString("rgt", debugFont, Brushes.Black, bTwo.X + 4, bTwo.Y + 5);
                graphics.DrawString("lft", debugFont, Brushes.Black, bThree.X + 5, bThree.Y + 5);
                graphics.DrawString("top", debugFont, Brushes.Black, bFour.X + 3, bFour.Y + 5);
                graphics.DrawString("shape: " + InstanceManager.getRotate().getCurShape(), debugFont, Brushes.White, new Point(0, lastY * 18));
                for (int i = 0; i < 4; i++)
                    graphics.DrawImage(BlockUtils.SetOpacity(BlockUtils.translateColorToImage(currentColor, true), 0.2F), InstanceManager.getRotateCheck().getRotationBlocks()[i]);
            }
        }

        /// <summary>
        /// Updates the tetris block to the corresponding currentBlock variable.
        /// </summary>
        public void setShape()
        {
            switch (InstanceManager.getRotate().getCurShape())
            {
                case 1:
                    r1 = 32; r2 = 0; l1 = 32;
                    l2 = 0; t1 = 32; t2 = 0;
                    currentColor = Brushes.Purple;
                    currentTetImage = Properties.Resources.tetris_t_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 2:
                    r1 = 32; r2 = 0; l1 = 32;
                    l2 = 32; t1 = 32; t2 = 0;
                    currentColor = Brushes.Red;
                    currentTetImage = Properties.Resources.tetris_z1_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 3:
                    r1 = -32; r2 = -32; l1 = 32;
                    l2 = 0; t1 = 0; t2 = 32;
                    currentColor = Brushes.Blue;
                    currentTetImage = Properties.Resources.tetris_l1_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 4:
                    r1 = 32; r2 = 0; l1 = 32;
                    l2 = 0; t2 = 64; t1 = 0;
                    currentColor = Brushes.Cyan;
                    currentTetImage = Properties.Resources.tetris_i_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 5:
                    r1 = 32; r2 = 32; l1 = 0;
                    l2 = (-32); t1 = 0; t2 = 32;
                    currentColor = Brushes.Yellow;
                    currentTetImage = Properties.Resources.tetris_o_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 6:
                    r1 = 32; r2 = -32; l1 = 32;
                    l2 = 0; t1 = 0; t2 = 32;
                    currentColor = Brushes.Gold;
                    currentTetImage = Properties.Resources.tetris_l2_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                case 7:
                    r1 = -32; r2 = 0; l1 = (-32);
                    l2 = 32; t1 = 32; t2 = 0;
                    currentColor = Brushes.LimeGreen;
                    currentTetImage = Properties.Resources.tetris_z2_full;
                    InstanceManager.getRotate().setCurAngel(1);
                    break;
                default:
                    Debug.debugMessage("Attempting to set unknown shape! ID: " + InstanceManager.getRotate().getCurShape(), 1, true);
                    break;
            }
            InstanceManager.getRotateCheck().setAllPositions();
            Debug.debugMessage("PLAYER: Shape set(" + InstanceManager.getRotate().getCurShape() + ")", 1);
        }

        /// <summary>
        /// Every time this function is called it will move the player tetris block down one tile.
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="movingDown"></param>
        public void Gravity(ref PictureBox gameBoard, ref bool movingDown)
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
        }

        public void update()
        {
            if (InstanceManager.getMainForm().isPaused())
                return;

            predict.Gravity();
            predict.blockCollision();

            InstanceManager.getMainForm().gameBoard.Invalidate();
        }

        public void setPlayerCoords(int plyX, int plyY)
        {
            this.plyX = plyX;
            this.plyY = plyY;
        }

        public int[] getPlyCoord()
        {
            return new int[] { plyX, plyY };
        }

        public Rectangle[] getPlaced()
        {
            return placedrect;
        }

        public Rectangle[] getBlocks()
        {
            return new Rectangle[] { bOne, bTwo, bThree, bFour };
        }

        /// <summary>
        /// Resets rectangle array and color array.
        /// </summary>
        public void Reset()
        {
            Debug.debugMessage("GAME: Start", 1);
            checkRow.Reset();
            placedrect = new Rectangle[2];
            //reset all stored colors
            storedColor = new Brush[0];
            List<Brush> addcolor = storedColor.ToList();
            addcolor.Add(currentColor);
            addcolor.Add(currentColor);
            storedColor = addcolor.ToArray();
            checkRow = InstanceManager.resetRow();
            setShape();
        }


        #region Random Block

        /// <summary>
        /// This function is used for when the user selects a level greater than 6.
        /// This will randomly generate grey blocks on screen to add a bit more of a
        /// challenge, more of a fun feature to make the game a little more difficult
        /// on higher levels.This only works if the user selects the level on the main
        /// menu.
        /// </summary>
        /// <param name="blocks"></param>
        public void randomBlock(int blocks)
        {
            int y = 608;
            while (blocks > 0)
            {
                Debug.debugMessage("GAME: Generating " + blocks + " random blocks", 1);
                int x = 0;
                randX = rand.Next(1, 11);

                for (int i = placedrect.Length - 1; i > 1; i--)
                    if (x == placedrect[i].X && y == placedrect[i].Y)
                        return;

                List<Rectangle> createblock = placedrect.ToList();
                List<Brush> addcolor2 = storedColor.ToList();
                for (int i = 10; i > 0; i--)
                {
                    if (randX != i)
                    {
                        createblock.Add(new Rectangle(x, y, 32, 32));
                        addcolor2.Add(Brushes.Gray);
                    }
                    x += 32;
                }
                placedrect = createblock.ToArray();
                storedColor = addcolor2.ToArray();
                y -= 32;
                blocks--;
            }
        }

        #endregion

    }
}

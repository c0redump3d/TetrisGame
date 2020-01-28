using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TetrisGame
{

    /// <summary>
    /// This class is in charge of the basically the entire game.
    /// Draws player, adds control functions, rotation logic, collision logic,
    /// etc.
    /// </summary>
    class Tetris
    {

        #region Variables

        Rectangle[] rows;

        SFX sfx;
        Prediction predict;
        RowCheck checkRow;

        int rotationAng = 1; // 1 default
        int currentBlock = 1;

        int nextShape;
        Brush nextCol;

        int r1 = 32;
        int r2 = 0;
        int l1 = 32;
        int l2 = 32; // normally 0
        int t1 = 32;
        int t2 = 0;
        Random rand;
        int randX = 0;
        int randY = 0;

        Brush currentColor;
        Brush[] storedColor;
        Rectangle[] placedrect;
        Rectangle bOne;
        Rectangle bTwo;
        Rectangle bThree;
        Rectangle bFour;
        int plyX = 160;
        int plyY = 32;

        Rectangle nOne;
        Rectangle nTwo;
        Rectangle nThree;
        Rectangle nFour;
        int nX = 34;
        int nY = 50;

        #endregion

        public Tetris()
        {
            sfx = new SFX();
            checkRow = new RowCheck();
            predict = new Prediction(this);

            //setup rows, placedrectangles, etc
            placedrect = new Rectangle[2];
            storedColor = new Brush[0];
            rows = new Rectangle[2];
            rand = new Random();

            List<Brush> addcolor = storedColor.ToList();
            addcolor.Add(currentColor);
            addcolor.Add(currentColor);
            storedColor = addcolor.ToArray();

            //choose shape
            currentBlock = rand.Next(1, 8);

            setShape();

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
        }

        #region Player

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
        public void blockCollision(ref Timer confirmTimer, ref Timer gravityTimer, ref bool confirm, ref PictureBox nextShapeBox, ref bool hardDrop, bool noSound, ref bool remove, int level)
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

                    currentBlock = nextShape;
                    predict.reset();

                    //set player to what ever number was selected
                    setShape();

                    if (hardDrop && !noSound)
                        sfx.playHardDrop();
                    else if (!hardDrop && !noSound)
                        sfx.playFall(); // play fall sound.

                    //generate random number between 1 and 7
                    nextShape = rand.Next(1, 8);

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
                        currentBlock = nextShape;
                        predict.reset();

                        //set shape
                        setShape();

                        nextShape = rand.Next(1, 8);

                        if (hardDrop && !noSound)
                            sfx.playHardDrop();
                        else if (!hardDrop && !noSound)
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
            }catch(Exception ex) { Debug.debugMessage("GAME: Unable to check on block! " + ex.Message, 1, true); }
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

        /// <summary>
        /// Draws the proper rectangles and grid on screen.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {

            for (int i = placedrect.Length - 1; i > 0; i--)
                graphics.FillRectangle(storedColor[i], placedrect[i]);

            bOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
            bTwo = new Rectangle(plyX + r1, plyY + r2, 32, 32);
            bThree = new Rectangle(plyX - l1, plyY - l2, 32, 32);
            bFour = new Rectangle(plyX + t2, plyY - t1, 32, 32);
            //draw player rectangles
            graphics.FillRectangle(currentColor, bOne);
            graphics.FillRectangle(currentColor, bTwo);
            graphics.FillRectangle(currentColor, bThree);
            graphics.FillRectangle(currentColor, bFour);

            //if rows contain player or placed rect, draw grid
            for (int j = rows.Length - 1; j > 0; j--)
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (bOne.X == rows[j].X && bOne.Y == rows[j].Y || bTwo.X == rows[j].X && bTwo.Y == rows[j].Y || bThree.X == rows[j].X && bThree.Y == rows[j].Y
                    || bFour.X == rows[j].X && bFour.Y == rows[j].Y || placedrect[i].X == rows[j].X && placedrect[i].Y == rows[j].Y)
                        graphics.DrawRectangle(new Pen(Color.Black), rows[j]);

            predict.Draw(graphics, currentColor);
        }

        /// <summary>
        /// Updates the tetris block to the corresponding currentBlock variable.
        /// </summary>
        public void setShape()
        {
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

            Debug.debugMessage("PLAYER: Shape set(" + currentBlock + ")", 1);
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

        public void update(ref bool paused, ref PictureBox gameBoard)
        {
            if (paused)
                return;

            int x2 = bTwo.X;
            int x3 = bThree.X;
            int x4 = bFour.X;

            predict.Gravity(ref placedrect, ref gameBoard);
            predict.blockCollision(ref plyX, ref x2, ref x3, ref x4, ref placedrect);

            gameBoard.Invalidate();
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
            checkRow = new RowCheck();
        }

        public int getY()
        {
            return plyY;
        }

        #endregion

        #region Next Shape

        /// <summary>
        /// This will set the shape of the next tetris block picture box.
        /// </summary>
        /// <param name="graphics"></param>
        public void setNextShape(Graphics graphics)
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

            graphics.FillRectangle(nextCol, nOne);
            graphics.FillRectangle(nextCol, nTwo);
            graphics.FillRectangle(nextCol, nThree);
            graphics.FillRectangle(nextCol, nFour);


            graphics.DrawRectangle(Pens.Black, nOne);
            graphics.DrawRectangle(Pens.Black, nTwo);
            graphics.DrawRectangle(Pens.Black, nThree);
            graphics.DrawRectangle(Pens.Black, nFour);

            Debug.debugMessage("NEXT_BLOCK: Generating next block...", 1);
        }

        #endregion

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

        #region Controller

        public void joystickDown(ref bool movingDown)
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                    || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                    || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                    || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                    return;
            if (bOne.Y != 608 && bTwo.Y != 608
        && bThree.Y != 608 && bFour.Y != 608)
            {
                plyY += 32;
                movingDown = true;
            }
        }

        #endregion

        #region Movement

        /// <summary>
        /// Moves tetris block right one tile.
        /// </summary>
        /// <param name="paused"></param>
        public void moveRight(ref bool paused)
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
            predict.reset();

            plyX += 32;

        }

        /// <summary>
        /// Moves tetris block left one tile.
        /// </summary>
        /// <param name="paused"></param>
        public void moveLeft(ref bool paused)
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

            predict.reset();

            plyX -= 32;

        }

        /// <summary>
        /// Moves tetris block down a tile.
        /// </summary>
        /// <returns></returns>
        public bool moveDown()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                    || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                    || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                    || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                    return false;
            if (bOne.Y != 608 && bTwo.Y != 608
        && bThree.Y != 608 && bFour.Y != 608)
            {
                plyY += 32;
                return true;
            }

            return true;
        }

        #endregion

        #region Rotation

        /// <summary>
        /// Each shape has its own rotation function, all it does is check current rotation
        /// and sets rectangles to a new position and adds one to rotationAng.
        ///
        /// Also, some have checks to make sure that in certain areas you are unable to
        /// rotate out of the game board/into another placed block.
        /// </summary>
        public void rotateTetris()
        {
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
            int x2 = bTwo.X;
            int x3 = bThree.X;
            int x4 = bFour.X;
            int y2 = bTwo.Y;
            int y3 = bThree.Y;
            int y4 = bFour.Y;
            predict.reset();

            Debug.debugMessage("PLAYER: Rotate", 1);
        }

        public int getr2()
        {
            return r2;
        }

        public int getl2()
        {
            return l2;
        }
        public int gett1()
        {
            return t1;
        }
        /// <summary>
        /// Rotates I block(4).
        /// </summary>
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

            }
            else if (rotationAng == 2)
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

            }
        }

        /// <summary>
        /// Rotates T block(1).
        /// </summary>
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

            }
        }

        /// <summary>
        /// Rotates Z block(2).
        /// </summary>
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

            }
        }

        /// <summary>
        /// Rotates S block(7).
        /// </summary>
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

            }
        }

        /// <summary>
        /// Rotates J block(3).
        /// </summary>
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

            }
            else if (rotationAng == 3)
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

            }
            else if (rotationAng == 4)
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

            }
        }

        /// <summary>
        /// Rotates L block(6).
        /// </summary>
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

            }
        }

        #endregion

    }
}

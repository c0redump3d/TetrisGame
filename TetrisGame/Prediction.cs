using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    class Prediction
    {
        #region Variables

        Rectangle[] rows;

        SFX sfx;
        Tetris tetris;

        int rotationAng = 1; // 1 default
        int currentBlock = 1;

        int r1 = 32;
        int r2 = 0;
        int l1 = 32;
        int l2 = 32; // normally 0
        int t1 = 32;
        int t2 = 0;
        Rectangle tOne;
        Rectangle tTwo;
        Rectangle tThree;
        Rectangle tFour;
        int plyX = 160;
        int plyY = 608;

        int sub = 32;
        bool stopped = false;

        #endregion

        public Prediction(Tetris tetris1)
        {
            sfx = new SFX();
            tetris = tetris1;
        }

        #region Player

        /// <summary>
        /// This is a very important function. This adds proper collision detection to the tetris blocks
        /// to allow the blocks to land on top of eachother and makes sure the tetris blocks do not go past
        /// the bottom of the board.
        /// </summary>
        /// <param name="confirmTimer"></param>
        /// <param name="gravityTimer"></param>
        /// <param name="confirm"></param>
        /// <param name="nextShapeBox"></param>
        public void blockCollision(ref int x1, ref int x2, ref int x3, ref int x4, ref Rectangle[] placedrect)
        {

            plyX = x1;
            tTwo.X = x2;
            tThree.X = x3;
            tFour.X = x4;

            for (int i = placedrect.Length - 1; i > 0; i--)
                if (placedrect[i].Contains(tOne) || placedrect[i].Contains(tTwo) || placedrect[i].Contains(tThree) || placedrect[i].Contains(tFour) || plyY > 608 || tTwo.Y > 608 || tThree.Y > 608 || tFour.Y > 608)
                {
                    plyY -= 32;
                    tTwo.Y -= 32;
                    tThree.Y -= 32;
                    tFour.Y -= 32;
                    stopped = true;
                }

                    // if player rectangle collides with placed rectangles
                    for (int i = placedrect.Length - 1; i > 0; i--)
                if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                    || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                    || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                    || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
                {
                    currentBlock = tetris.getShape();
                    rotationAng = tetris.rotationAngle();
                    stopped = true;


                }

            //player collision at the bottom of board, once reached duplicate player and reset player pos w/ new shape.
            if (plyY == 608 || tTwo.Y == 608 || tThree.Y == 608 || tFour.Y == 608)
            {

                currentBlock = tetris.getShape();
                rotationAng = tetris.rotationAngle();
                stopped = true;
            }
        }

        public void reset(ref Rectangle[] placedrect)
        {
            if (!stopped)
                return;

            tOne = new Rectangle(); // player controlled rect
            tTwo = new Rectangle();
            tThree = new Rectangle();
            tFour = new Rectangle();
            plyY = tetris.getY();
            currentBlock = tetris.getShape();
            rotationAng = tetris.rotationAngle();

            //set player to what ever number was selected
            setShape();
            setRotation(ref placedrect);
            sub = 32;
            stopped = false;
        }

        public int getY()
        {
            return plyY;
        }

        public bool isStopped()
        {
            return stopped;
        }

        /// <summary>
        /// Draws the proper rectangles and grid on screen.
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(Graphics graphics)
        {

            tOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
            tTwo = new Rectangle(tTwo.X, plyY + tetris.getr2(), 32, 32);
            tThree = new Rectangle(tThree.X, plyY - tetris.getl2(), 32, 32);
            tFour = new Rectangle(tFour.X, plyY - tetris.gett1(), 32, 32);
            //draw player rectangles
            graphics.DrawRectangle(new Pen(Color.Black), tOne);
            graphics.DrawRectangle(new Pen(Color.Black), tTwo);
            graphics.DrawRectangle(new Pen(Color.Black), tThree);
            graphics.DrawRectangle(new Pen(Color.Black), tFour);

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
            }
            else if (currentBlock == 2)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 32;
                t1 = 32;
                t2 = 0;

            }
            else if (currentBlock == 3)
            {
                r1 = -32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;

            }
            else if (currentBlock == 4)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 0;
                t2 = 64;
                t1 = 0;
            }
            else if (currentBlock == 5)
            {
                r1 = 32;
                r2 = 32;
                l1 = 0;
                l2 = (-32);
                t1 = 0;
                t2 = 32;
            }
            else if (currentBlock == 6)
            {
                r1 = 32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
            }
            else if (currentBlock == 7)
            {
                r1 = -32;
                r2 = 0;
                l1 = (-32);
                l2 = 32;
                t1 = 32;
                t2 = 0;
            }
        }

        public void setRotation(ref Rectangle[] placedrect)
        {
            if (currentBlock == 1)
            {
                if (rotationAng == 2)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tOne.Y == placedrect[i].Y && tOne.X == placedrect[i].X + 64
                                || tTwo.Y == placedrect[i].Y && tTwo.X == placedrect[i].X + 32
                                || tThree.Y == placedrect[i].Y && tThree.X == placedrect[i].X + 32
                                || tFour.Y == placedrect[i].Y && tFour.X == placedrect[i].X + 32 || tOne.Y == placedrect[i].Y && tOne.X == placedrect[i].X - 64
                                || tTwo.Y == placedrect[i].Y && tTwo.X == placedrect[i].X - 32
                                || tThree.Y == placedrect[i].Y && tThree.X == placedrect[i].X - 32
                                || tFour.Y == placedrect[i].Y && tFour.X == placedrect[i].X - 32)
                            return;

                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                                || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                                || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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

                }
                else if (rotationAng == 3)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tOne.Y == placedrect[i].Y && tOne.X == placedrect[i].X + 64
                                || tTwo.Y == placedrect[i].Y && tTwo.X == placedrect[i].X + 64
                                || tThree.Y == placedrect[i].Y && tThree.X == placedrect[i].X + 64
                                || tFour.Y == placedrect[i].Y && tFour.X == placedrect[i].X + 64 || tOne.Y == placedrect[i].Y && tOne.X == placedrect[i].X - 64
                                || tTwo.Y == placedrect[i].Y && tTwo.X == placedrect[i].X - 64
                                || tThree.Y == placedrect[i].Y && tThree.X == placedrect[i].X - 64
                                || tFour.Y == placedrect[i].Y && tFour.X == placedrect[i].X - 64)
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

                }
                else if (rotationAng == 4)
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

                }
            } else if (currentBlock == 2)
            {
                if (rotationAng == 1)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                                || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                                || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                                || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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

                }
            }
            else if(currentBlock == 3)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                            || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                            || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                            || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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

                }
            }
            else if(currentBlock == 4)
            {
                if (rotationAng == 2)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                                || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                                || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                                || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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
                }
                else if (rotationAng == 1)
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

                }
            }
            else if(currentBlock == 5)
            {

            }else if(currentBlock == 6)
            {
                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                            || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                            || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                            || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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

                }
            }
            else if(currentBlock == 7)
            {
                if (rotationAng == 1)
                {
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                                || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                                || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                                || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
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

                }
            }
        }

        /// <summary>
        /// Every time this function is called it will move the player tetris block down one tile.
        /// </summary>
        /// <param name="gameBoard"></param>
        /// <param name="movingDown"></param>
        public void Gravity(ref Rectangle[] placedrect, ref PictureBox gameBoard)
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                        || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                        || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                        || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
                {// if player is above an already placed shape, we return.
                    gameBoard.Invalidate();
                    return;
                }

            if (tOne.Y != 608 && tTwo.Y != 608
            && tThree.Y != 608 && tFour.Y != 608) // make sure we aren't at the bottom of the board.
                plyY += sub;
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

        #endregion
    }
}

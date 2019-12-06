using System.Drawing;
using System.Windows.Forms;

namespace TetrisGame
{
    class Prediction
    {
        #region Variables

        Tetris tetris;

        Rectangle tOne;
        Rectangle tTwo;
        Rectangle tThree;
        Rectangle tFour;
        int plyX = 160;
        int plyY = 608;

        bool stopped = false;

        #endregion

        public Prediction(Tetris tetris1)
        {
            tetris = tetris1;
        }

        #region Player

        public void blockCollision(ref int x1, ref int x2, ref int x3, ref int x4, ref Rectangle[] placedrect)
        {

            plyX = x1;
            tTwo.X = x2;
            tThree.X = x3;
            tFour.X = x4;

            for (int i = placedrect.Length - 1; i > 0; i--)
                if (placedrect[i].Contains(tOne) || placedrect[i].Contains(tTwo) || placedrect[i].Contains(tThree) || placedrect[i].Contains(tFour)
                    || plyY > 608 || tTwo.Y > 608 || tThree.Y > 608 || tFour.Y > 608
                    || placedrect[i].X == tOne.X && placedrect[i].Y == tOne.Y || placedrect[i].X == tTwo.X && placedrect[i].Y == tTwo.Y
                    || placedrect[i].X == tThree.X && placedrect[i].Y == tThree.Y || placedrect[i].X == tFour.X && placedrect[i].Y == tFour.Y)
                {
                    reset();
                }

            // if player rectangle collides with placed rectangles
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                    || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                    || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                    || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
                {
                    stopped = true;
                }

            if (plyY == 608 || tTwo.Y == 608 || tThree.Y == 608 || tFour.Y == 608)
            {
                stopped = true;
            }
        }

        public void reset()
        {
            if (!stopped)
                return;
            plyY = tetris.getY();

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

        public void Draw(Graphics graphics, Rectangle bOne, Rectangle bTwo, Rectangle bThree, Rectangle bFour, Brush currentColor)
        {

            tOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
            tTwo = new Rectangle(tTwo.X, plyY + tetris.getr2(), 32, 32);
            tThree = new Rectangle(tThree.X, plyY - tetris.getl2(), 32, 32);
            tFour = new Rectangle(tFour.X, plyY - tetris.gett1(), 32, 32);
            //draw player rectangles
            graphics.DrawRectangle(new Pen(currentColor), tOne);
            graphics.DrawRectangle(new Pen(currentColor), tTwo);
            graphics.DrawRectangle(new Pen(currentColor), tThree);
            graphics.DrawRectangle(new Pen(currentColor), tFour);

        }

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
                plyY += 32;
        }

        #endregion
    }
}

using System.Drawing;
using TetrisGame.Main.Player;
using TetrisGame.Other;

namespace TetrisGame
{
    public class Prediction
    {
        #region Variables

        private Player ply;

        private Rectangle tOne;
        private Rectangle tTwo;
        private Rectangle tThree;
        private Rectangle tFour;
        private int plyX = 160;
        private int plyY = 608;
        private bool addOpacity = false;
        private float currentOpacity = 0.8F;
        private bool stopped = false;

        #endregion

        #region Player

        public void blockCollision()
        {
            Rectangle[] placedrect = ply.getPlaced();

            plyX = ply.plyX;
            tTwo.X = ply.bTwo.X;
            tThree.X = ply.bThree.X;
            tFour.X = ply.bFour.X;

            if(plyY < ply.getY())
                plyY = 608;

            for (int i = placedrect.Length - 1; i > 0; i--)
                if (placedrect[i].Contains(tOne) || placedrect[i].Contains(tTwo) || placedrect[i].Contains(tThree) || placedrect[i].Contains(tFour)
                    || plyY > 608 || tTwo.Y > 608 || tThree.Y > 608 || tFour.Y > 608
                    || placedrect[i].X == tOne.X && placedrect[i].Y == tOne.Y || placedrect[i].X == tTwo.X && placedrect[i].Y == tTwo.Y
                    || placedrect[i].X == tThree.X && placedrect[i].Y == tThree.Y || placedrect[i].X == tFour.X && placedrect[i].Y == tFour.Y)
                {
                    plyY -= 64;
                    stopped = false;
                    return;
                }

            /*
             * if predicted y is below a placed block, this will correct its position.
             * also checks to see if the actual tetris block is under the placedblock its checking
             * if it is, then it will not correct it.
             */
            for (int i = placedrect.Length - 1; i > 0; i--)
            {
                if (placedrect[i].X == plyX && placedrect[i].Y <= plyY && placedrect[i].Y > ply.getY())
                    plyY = placedrect[i].Y - 32;
                if (placedrect[i].X == tTwo.X && placedrect[i].Y <= tTwo.Y && placedrect[i].Y > ply.getY())
                    plyY = placedrect[i].Y - 32;
                if (placedrect[i].X == tThree.X && placedrect[i].Y <= tThree.Y && placedrect[i].Y > ply.getY())
                    plyY = placedrect[i].Y - 32;
                if (placedrect[i].X == tFour.X && placedrect[i].Y <= tFour.Y && placedrect[i].Y > ply.getY())
                    plyY = placedrect[i].Y - 32;
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

        public void Draw(Graphics graphics, Brush currentColor)
        {
            tOne = new Rectangle(plyX, plyY, 32, 32); // player controlled rect
            tTwo = new Rectangle(tTwo.X, plyY + InstanceManager.getRotate().getr2(), 32, 32);
            tThree = new Rectangle(tThree.X, plyY - InstanceManager.getRotate().getl2(), 32, 32);
            tFour = new Rectangle(tFour.X, plyY - InstanceManager.getRotate().gett1(), 32, 32);
            //draw player rectangles
            Image currentImage = BlockUtils.SetOpacity(BlockUtils.translateColorToImage(currentColor, true), currentOpacity);
            graphics.DrawImage(currentImage, tOne);
            graphics.DrawImage(currentImage, tTwo);
            graphics.DrawImage(currentImage, tThree);
            graphics.DrawImage(currentImage, tFour);

            if (currentOpacity >= 0.8F)
            {
                addOpacity = false;
            }
            if (currentOpacity > 0.4F && !addOpacity)
            {
                currentOpacity -= 0.01F;
            }
            if (addOpacity)
            {
                currentOpacity += 0.01F;
            }
            if (currentOpacity <= 0.4F)
            {
                addOpacity = true;
            }
        }

        public void Gravity()
        {
            if (ply == null)
                ply = InstanceManager.getPlayer();

            Rectangle[] placedrect = ply.getPlaced();

            for (int i = placedrect.Length - 1; i > 0; i--)
                if (tOne.Y == placedrect[i].Y - 32 && tOne.X == placedrect[i].X
                        || tTwo.Y == placedrect[i].Y - 32 && tTwo.X == placedrect[i].X
                        || tThree.Y == placedrect[i].Y - 32 && tThree.X == placedrect[i].X
                        || tFour.Y == placedrect[i].Y - 32 && tFour.X == placedrect[i].X)
                {// if player is above an already placed shape, we return.
                    InstanceManager.getMainForm().gameBoard.Invalidate();
                    return;
                }

            if (tOne.Y != 608 && tTwo.Y != 608
            && tThree.Y != 608 && tFour.Y != 608) // make sure we aren't at the bottom of the board.
                plyY += 32;
        }

        #endregion
    }
}

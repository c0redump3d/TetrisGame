using System.Drawing;
using TetrisGame.Other;

namespace TetrisGame.Main.Player
{
    public class Move
    {
        Rectangle bOne;
        Rectangle bTwo;
        Rectangle bThree;
        Rectangle bFour;
        Rectangle[] placedrect;
        Prediction predict;

        int plyX;
        int plyY;

        public Move()
        {
            predict = InstanceManager.getPredict();
        }

        private void updateLoc()
        {
            bOne = InstanceManager.getPlayer().getBlocks()[0];
            bTwo = InstanceManager.getPlayer().getBlocks()[1];
            bThree = InstanceManager.getPlayer().getBlocks()[2];
            bFour = InstanceManager.getPlayer().getBlocks()[3];
            placedrect = InstanceManager.getPlayer().getPlaced();
            plyX = InstanceManager.getPlayer().getPlyCoord()[0];
            plyY = InstanceManager.getPlayer().getPlyCoord()[1];
        }

        /// <summary>
        /// Moves tetris block right one tile.
        /// </summary>
        /// <param name="paused"></param>
        public void moveRight()
        {
            updateLoc();
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
            if (InstanceManager.getMainForm().isPaused())
                return;
            predict.reset();

            plyX += 32;
            InstanceManager.getSound().playMove();
            InstanceManager.getPlayer().setPlayerCoords(plyX, plyY);
        }

        /// <summary>
        /// Moves tetris block left one tile.
        /// </summary>
        /// <param name="paused"></param>
        public void moveLeft()
        {
            updateLoc();
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
            if (InstanceManager.getMainForm().isPaused())
                return;

            predict.reset();

            plyX -= 32;
            InstanceManager.getSound().playMove();
            InstanceManager.getPlayer().setPlayerCoords(plyX, plyY);

        }

        /// <summary>
        /// Moves tetris block down a tile.
        /// </summary>
        /// <returns></returns>
        public bool moveDown()
        {
            updateLoc();
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
                InstanceManager.getSound().playMove();
                InstanceManager.getPlayer().setPlayerCoords(plyX, plyY);
                return true;
            }

            return true;
        }

        public void joystickDown(ref bool movingDown)
        {
            updateLoc();
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
                InstanceManager.getSound().playMove();
                InstanceManager.getPlayer().setPlayerCoords(plyX, plyY);
                movingDown = true;
            }
        }

    }
}

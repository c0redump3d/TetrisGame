using System.Drawing;
using TetrisGame.Other;

namespace TetrisGame.Main.Player
{
    public class RotateCheck
    {
        private Player ply;

        public int r1 = 32;
        public int r2 = 0;
        public int l1 = 32;
        public int l2 = 32; // normally 0
        public int t1 = 32;
        public int t2 = 0;

        public Rectangle cOne;
        public Rectangle cTwo;
        public Rectangle cThree;
        public Rectangle cFour;
        public int checkX = 160;
        public int checkY = 32;

        private void doesNeedToRotate()
        {
            int tried = 0;
            Rectangle[] test = new Rectangle[] { cOne, cTwo, cThree, cFour };
            for (int l = 0; l < test.Length; l++)
                if (test[l].Y >= 608)
                {
                    return;
                }

            for (int i = 0; i < 30; i++)
            {
                bool rotated = false;
                updateRectangles();
                Rectangle[] boxes = new Rectangle[] { cOne, cTwo, cThree, cFour };
                if (isOutOfBounds())
                {

                    for (int l = 0; l < boxes.Length; l++)
                    {

                        for (int f = ply.placedrect.Length - 1; f > 0; f--)
                        {
                            if (boxes[l].IntersectsWith(ply.placedrect[f]))
                            {
                                if (InstanceManager.getRotate().getCurShape() == 1)
                                {
                                    setAllPositions();
                                    setPlayerPosition();
                                    return;
                                }
                                InstanceManager.getRotate().rotateTetris();
                                updateRectangles();
                                tried++;
                                rotated = true;
                            }
                        }
                        if (rotated)
                            break;
                        if (boxes[l].X > 288)
                        {
                            checkX -= 32;
                            break;
                        }
                        else if (boxes[l].X < 0)
                        {
                            checkX += 32;
                            break;
                        }
                    }

                    if (checkIsOkay() && !isOutOfBounds())
                    {
                        break;
                    }
                }

            }
            setPlayerPosition();
        }

        private bool checkIsOkay()
        {
            updateRectangles();
            Rectangle[] boxes = new Rectangle[] { cOne, cTwo, cThree, cFour };

            for (int i = ply.placedrect.Length - 1; i > 0; i--)
                for (int l = 0; l < boxes.Length; l++)
                    if (boxes[l].IntersectsWith(ply.placedrect[i]))
                        return false;

            return true;
        }

        public void updateCheck()
        {
            updateXY();

            updateRectangles();

            doesNeedToRotate();
        }

        private void updateRectangles()
        {
            cOne = new Rectangle(checkX, checkY, 32, 32); // player controlled rect
            cTwo = new Rectangle(checkX + r1, checkY + r2, 32, 32);
            cThree = new Rectangle(checkX - l1, checkY - l2, 32, 32);
            cFour = new Rectangle(checkX + t2, checkY - t1, 32, 32);
        }

        private void updateXY()
        {
            if (ply == null)
            {
                ply = InstanceManager.getPlayer();
            }
            checkX = ply.plyX;
            checkY = ply.plyY;
        }

        private bool isOutOfBounds()
        {
            updateRectangles();
            Rectangle[] boxes = new Rectangle[] { cOne, cTwo, cThree, cFour };

            for (int i = 0; i < boxes.Length; i++)
            {
                if (boxes[i].X < 0 || boxes[i].X > 288)
                {
                    return true;
                }
                if (boxes[i].Y > 608)
                {
                    return true;
                }

                for (int f = ply.placedrect.Length - 1; f > 0; f--)
                    if (boxes[i].IntersectsWith(ply.placedrect[f]))
                        return true;
            }

            return false;
        }

        public Rectangle[] getRotationBlocks()
        {
            return new Rectangle[] { cOne, cTwo, cThree, cFour };
        }

        public void setAllPositions()
        {
            if (ply == null)
            {
                ply = InstanceManager.getPlayer();
                return;
            }
            cOne = ply.bOne;
            cTwo = ply.bTwo;
            cThree = ply.bThree;
            cFour = ply.bFour;
            checkX = ply.plyX;
            checkY = ply.plyY;
            r1 = ply.r1;
            r2 = ply.r2;
            l1 = ply.l1;
            l2 = ply.l2;
            t1 = ply.t1;
            t2 = ply.t2;
        }

        private void setPlayerPosition()
        {
            ply.bOne = cOne;
            ply.bTwo = cTwo;
            ply.bThree = cThree;
            ply.bFour = cFour;
            ply.plyX = checkX;
            ply.plyY = checkY;
            ply.r1 = r1;
            ply.r2 = r2;
            ply.l1 = l1;
            ply.l2 = l2;
            ply.t1 = t1;
            ply.t2 = t2;
        }
    }
}

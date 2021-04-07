using System;
using TetrisGame.Other;

namespace TetrisGame.Main.Player
{
    public class Rotate
    {

        private Random rand;
        private Player ply = null;
        private RotateCheck rotCheck = null;
        int rotationAng = 1; // 1 default
        int currentBlock = 1;

        public Rotate()
        {
            rand = InstanceManager.getRandom();
            //choose shape
            currentBlock = rand.Next(1, 8);
        }

        public void setCurAngel(int ang)
        {
            rotationAng = ang;
        }

        public int getCurAngle()
        {
            return rotationAng;
        }

        public int getCurShape()
        {
            return currentBlock;
        }

        public void setCurShape(int block)
        {
            currentBlock = block;
        }

        /// <summary>
        /// Each shape has its own rotation function, all it does is check current rotation
        /// and sets rectangles to a new position and adds one to rotationAng.
        ///
        /// Also, some have checks to make sure that in certain areas you are unable to
        /// rotate out of the game board/into another placed block.
        /// </summary>
        public void rotateTetris()
        {
            InstanceManager.getRotateCheck().setAllPositions();
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
            InstanceManager.getRotateCheck().updateCheck();
            InstanceManager.getPredict().reset();

            Debug.debugMessage("PLAYER: Rotate", 1);
        }

        public int getr2()
        {
            if (ply == null || rotCheck == null)
            {
                ply = InstanceManager.getPlayer();
                rotCheck = InstanceManager.getRotateCheck();
            }
            return ply.r2;
        }

        public int getl2()
        {
            return ply.l2;
        }

        public int gett1()
        {
            return ply.t1;
        }
        /// <summary>
        /// Rotates I block(4).
        /// </summary>
        private void rotateIblock()
        {
            if (rotationAng == 1)
            {
                rotCheck.r1 = 0;
                rotCheck.r2 = 64;
                rotCheck.l1 = 0;
                rotCheck.l2 = (-32);
                rotCheck.t1 = 32;
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 32;
                rotCheck.l2 = 0;
                rotCheck.t2 = 64;
                rotCheck.t1 = 0;
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
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 0;
                rotCheck.l2 = -32;
                rotCheck.t1 = 32; // on top
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 32;
                rotCheck.l2 = 0;
                rotCheck.t1 = -32;
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 3)
            {
                rotCheck.r1 = -32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 0;
                rotCheck.l2 = 32;
                rotCheck.t1 = -32; // on top
                rotCheck.t2 = 0;
                rotationAng++;
            }else if(rotationAng == 4)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 32;
                rotCheck.l2 = 0;
                rotCheck.t1 = 32;
                rotCheck.t2 = 0;
                rotationAng = 1;
            }
        }

        /// <summary>
        /// Rotates Z block(2).
        /// </summary>
        private void rotateZblock()
        {

            if (rotationAng == 1)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 0;
                rotCheck.l2 = -32;
                rotCheck.t1 = 32;
                rotCheck.t2 = 32;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = 0;
                rotCheck.r2 = 32; // directly under plyX
                rotCheck.l1 = 32; // to the right of plyX
                rotCheck.l2 = 0;
                rotCheck.t1 = -32;
                rotCheck.t2 = 32;
                rotationAng++;
            }
            else if (rotationAng == 3)
            {
                rotCheck.r1 = -32;
                rotCheck.r2 = 32;
                rotCheck.l1 = 32; // to right of plyX
                rotCheck.l2 = 0;
                rotCheck.t1 = 32; // above plyY
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 4)
            {
                rotCheck.r1 = 32; rotCheck.r2 = 0; rotCheck.l1 = 32;
                rotCheck.l2 = 32; rotCheck.t1 = 32; rotCheck.t2 = 0;
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
                rotCheck.r1 = 32; // infront of ply
                rotCheck.r2 = 0;
                rotCheck.l1 = -32;
                rotCheck.l2 = -32;
                rotCheck.t1 = 32; // above plyY
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 0;
                rotCheck.l1 = 32;
                rotCheck.l2 = -32;
                rotCheck.t1 = -32;
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 3)
            {
                rotCheck.r1 = 0;
                rotCheck.r2 = 32;//below
                rotCheck.l1 = 32;//directly to right
                rotCheck.l2 = 0;
                rotCheck.t1 = 32;
                rotCheck.t2 = -32;
                rotationAng++;
            }
            else if (rotationAng == 4)
            {
                rotCheck.r1 = -32; rotCheck.r2 = 0; rotCheck.l1 = (-32);
                rotCheck.l2 = 32; rotCheck.t1 = 32; rotCheck.t2 = 0;
                rotationAng = 1;
            }
        }

        /// <summary>
        /// Rotates J block(3).
        /// </summary>
        private void rotateJblock()
        {
            if (rotationAng == 1)
            {
                rotCheck.r2 = 32;
                rotCheck.r1 = 0;
                rotCheck.l2 = 32;
                rotCheck.l1 = 0;
                rotCheck.t2 = 32;
                rotCheck.t1 = 32;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = 32;
                rotCheck.l1 = rotCheck.l2;
                rotCheck.l2 = 0;
                rotCheck.t1 = 0;
                rotCheck.t2 = 32;
                rotationAng++;
            }
            else if (rotationAng == 3)
            {
                rotCheck.r1 = -32;
                rotCheck.r2 = 32;
                rotCheck.l1 = 0;
                rotCheck.l2 = 32;
                rotCheck.t1 = (-32);
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 4)
            {
                rotCheck.r1 = -32;
                rotCheck.r2 = -32;
                rotCheck.l1 = 32;
                rotCheck.l2 = 0;
                rotCheck.t1 = 0;
                rotCheck.t2 = 32;
                rotationAng = 1;
            }
        }

        /// <summary>
        /// Rotates L block(6).
        /// </summary>
        private void rotateLblock()
        {
            if (rotationAng == 1)
            {
                rotCheck.r2 = 32;
                rotCheck.r1 = 0;
                rotCheck.l2 = 32;
                rotCheck.l1 = 0;
                rotCheck.t2 = 32;
                rotCheck.t1 = (-32);
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                rotCheck.r1 = (-32);
                rotCheck.r2 = 32;
                rotCheck.l1 = rotCheck.l2;
                rotCheck.l2 = 0;
                rotCheck.t1 = 0;
                rotCheck.t2 = 32;
                rotationAng++;
            }
            else if (rotationAng == 3)
            {
                rotCheck.r1 = -32;
                rotCheck.r2 = (-32);
                rotCheck.l1 = 0;
                rotCheck.l2 = 32;
                rotCheck.t1 = (-32);
                rotCheck.t2 = 0;
                rotationAng++;
            }
            else if (rotationAng == 4)
            {
                rotCheck.r1 = 32;
                rotCheck.r2 = -32;
                rotCheck.l1 = 32;
                rotCheck.l2 = 0;
                rotCheck.t1 = 0;
                rotCheck.t2 = 32;
                rotationAng = 1;
            }
        }

    }
}

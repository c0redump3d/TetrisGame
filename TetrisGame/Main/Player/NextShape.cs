using System;
using System.Drawing;
using TetrisGame.Other;

namespace TetrisGame.Main.Player
{
    public class NextShape
    {

        Rectangle nOne;
        Rectangle nTwo;
        Rectangle nThree;
        Rectangle nFour;
        int nX = 34;
        int nY = 50;
        Brush nextCol;
        Bitmap nextTetImage;
        int nextShape;

        Random rand;

        public NextShape()
        {
            rand = InstanceManager.getRandom();
        }


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
                nextTetImage = Properties.Resources.tetris_t_full;
            }
            else if (nextShape == 2)
            {
                nX = 34; nY = 50;
                nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                nTwo = new Rectangle(nX + 32, nY + 0, 32, 32);
                nThree = new Rectangle(nX - 32, nY - 32, 32, 32);
                nFour = new Rectangle(nX + 0, nY - 32, 32, 32);
                nextCol = Brushes.Red;
                nextTetImage = Properties.Resources.tetris_z1_full;
            }
            else if (nextShape == 3)
            {
                nX = 34; nY = 50;
                nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                nTwo = new Rectangle(nX - 32, nY - 32, 32, 32);
                nThree = new Rectangle(nX - 32, nY - 0, 32, 32);
                nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                nextCol = Brushes.Blue;
                nextTetImage = Properties.Resources.tetris_l1_full;
            }
            else if (nextShape == 4)
            {
                nX = 27; nY = 40;
                nOne = new Rectangle(nX, nY, 24, 24); // player controlled rect
                nTwo = new Rectangle(nX + 24, nY + 0, 24, 24);
                nThree = new Rectangle(nX - 24, nY - 0, 24, 24);
                nFour = new Rectangle(nX + 48, nY - 0, 24, 24);
                nextCol = Brushes.Cyan;
                nextTetImage = Properties.Resources.tetris_i_full;
            }
            else if (nextShape == 5)
            {
                nX = 17; nY = 20;
                nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                nTwo = new Rectangle(nX + 32, nY + 32, 32, 32);
                nThree = new Rectangle(nX - 0, nY - (-32), 32, 32);
                nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                nextCol = Brushes.Yellow;
                nextTetImage = Properties.Resources.tetris_o_full;
            }
            else if (nextShape == 6)
            {
                nX = 34; nY = 50;
                nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                nTwo = new Rectangle(nX + 32, nY + -32, 32, 32);
                nThree = new Rectangle(nX - 32, nY - 0, 32, 32);
                nFour = new Rectangle(nX + 32, nY - 0, 32, 32);
                nextCol = Brushes.Gold;
                nextTetImage = Properties.Resources.tetris_l2_full;
            }
            else if (nextShape == 7)
            {
                nX = 34; nY = 50;
                nOne = new Rectangle(nX, nY, 32, 32); // player controlled rect
                nTwo = new Rectangle(nX + -32, nY + 0, 32, 32);
                nThree = new Rectangle(nX - (-32), nY - 32, 32, 32);
                nFour = new Rectangle(nX + 0, nY - 32, 32, 32);
                nextCol = Brushes.LimeGreen;
                nextTetImage = Properties.Resources.tetris_z2_full;
            }

            graphics.DrawImage(nextTetImage, nOne);
            graphics.DrawImage(nextTetImage, nTwo);
            graphics.DrawImage(nextTetImage, nThree);
            graphics.DrawImage(nextTetImage, nFour);

            Debug.debugMessage("NEXT_BLOCK: Generating next block...", 1);
        }

        public int getNextShape()
        {
            return nextShape;
        }

        public void generateNextShape()
        {
            nextShape = rand.Next(1, 8);
        }

    }
}

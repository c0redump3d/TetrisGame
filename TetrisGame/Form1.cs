using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    public partial class Form1 : Form
    {
        int plyX = 50;
        int plyY = 50;
        Rectangle bOne;
        Rectangle bTwo;
        Rectangle bThree;
        Rectangle bFour;
        int rotationAng = 1; // 1 default
        int currentBlock = 2;
        Rectangle[] placedrect;


        int r1 = 10;
        int r2 = 0;
        int l1 = 10;
        int l2 = 10; // normally 0
        int t1 = 10;
        int t2 = 0;

        public Form1()
        {
            InitializeComponent();
            this.panel1.Anchor |= AnchorStyles.Bottom | AnchorStyles.Right;
            this.panel1.Resize += panel1_Resize;
            this.panel1.Paint += panel1_Paint;

            placedrect = new Rectangle[1];

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void S(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = placedrect.Length - 1; i > 0; i--)
                e.Graphics.FillRectangle(Brushes.Orange, placedrect[i]);
            if (currentBlock == 1)
            {
                bOne = new Rectangle(plyX, plyY, 10, 10); // middle block
                bTwo = new Rectangle(plyX + r1, plyY + r2, 10, 10); //right/top
                bThree = new Rectangle(plyX - l1, plyY - l2, 10, 10);
                bFour = new Rectangle(plyX + t2, plyY - t1, 10, 10);
            }
            else if (currentBlock == 2)
            {
                bOne = new Rectangle(plyX, plyY, 10, 10); // middle block
                bTwo = new Rectangle(plyX + r1, plyY + r2, 10, 10); //right/top
                bThree = new Rectangle(plyX - l1, plyY - l2, 10, 10);
                bFour = new Rectangle(plyX + t2, plyY - t1, 10, 10);
            }
            Brush blackPen = Brushes.Black;
            e.Graphics.FillRectangle(blackPen, bOne);
            e.Graphics.FillRectangle(blackPen, bTwo);
            e.Graphics.FillRectangle(blackPen, bThree);
            e.Graphics.FillRectangle(blackPen, bFour);

            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 20; y++)
                    e.Graphics.DrawRectangle(new Pen(Color.Black), x * 10, y * 10, 10, 10);
            //use union method 

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'c':
                    MessageBox.Show("" + plyX + ".." + plyY);
                    break;
                case 's':
                    plyY += 10;
                    break;
                case 'w':
                    if(currentBlock == 1)
                    {
                        rotateTblock();
                    }else if(currentBlock == 2)
                    {
                        rotateZblock();
                    }
                    break;
                case 'k'://duplicate player
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.Add(new Rectangle(plyX, plyY, 10, 10));
                    createblock.Add(new Rectangle(plyX + r1, plyY + r2, 10, 10));
                    createblock.Add(new Rectangle(plyX - l1, plyY - l2, 10, 10));
                    createblock.Add(new Rectangle(plyX + t2, plyY - t1, 10, 10));
                    placedrect = createblock.ToArray();
                    break;
                case 'l':
                    if (currentBlock == 1)
                    {
                        currentBlock = 2;
                        r1 = 10;
                        r2 = 0;
                        l1 = 10;
                        l2 = 10;
                        t1 = 10;
                        t2 = 0;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 2)
                    {
                        currentBlock = 1;
                        r1 = 10;
                        r2 = 0;
                        l1 = 10;
                        l2 = 0;
                        t1 = 10;
                        t2 = 0;
                        rotationAng = 1;

                    }
                    break;

            }

            panel1.Invalidate();
        }

        private void rotateTblock()
        {
            if (rotationAng == 1)
            {
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
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = 0;
                t2 = t1;
                t1 = 0;
                rotationAng = 2;
            }
        }

        private void rotateZblock()
        {
            if (rotationAng == 1)
            {
                r2 = r1;
                r1 = 0;
                l2 = l1;
                l1 = -10;
                t2 = t1;
                t1 = 0;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                r1 = r2;
                r2 = 0;
                l1 = l2;
                l2 = 10;
                t1 = t2;
                t2 = 0;
                rotationAng = 1;
            }
        }

    }
}

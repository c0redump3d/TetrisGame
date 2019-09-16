using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    public partial class Form1 : Form
    {


        int plyX = 160;
        int plyY = 32;
        Rectangle bOne;
        Rectangle bTwo;
        Rectangle bThree;
        Rectangle bFour;
        int rotationAng = 1; // 1 default
        int currentBlock = 3;
        Rectangle[] placedrect;
        int[] bank;
        int row1 = 0;


        Rectangle[] rows;


        int r1 = 32;
        int r2 = 0;
        int l1 = 32;
        int l2 = 32; // normally 0
        int t1 = 32;
        int t2 = 0;

        public Form1()
        {
            InitializeComponent();
            this.panel1.Anchor |= AnchorStyles.Bottom | AnchorStyles.Right;
            this.panel1.Paint += panel1_Paint;

            placedrect = new Rectangle[1];
            rows = new Rectangle[2];
            bank = new int[0];

            if (currentBlock == 1)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 32;
                t1 = 32;
                t2 = 0;
                rotationAng = 1;
            }
            else if (currentBlock == 2)
            {
                r1 = 32;
                r2 = 0;
                l1 = 32;
                l2 = 0;
                t1 = 32;
                t2 = 0;
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
                rotationAng = 1;

            }

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    //e.Graphics.DrawRectangle(new Pen(Color.Black), x * 32, y * 32, 32, 32);
                    List<Rectangle> addtile = rows.ToList();
                    addtile.Add(new Rectangle(x * 32, y * 32, 32, 32));
                    rows = addtile.ToArray();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


            for (int i = placedrect.Length - 1; i > 0; i--)
                e.Graphics.FillRectangle(Brushes.Orange, placedrect[i]);

            bOne = new Rectangle(plyX, plyY, 32, 32); // middle block
            bTwo = new Rectangle(plyX + r1, plyY + r2, 32, 32); //right/top
            bThree = new Rectangle(plyX - l1, plyY - l2, 32, 32);
            bFour = new Rectangle(plyX + t2, plyY - t1, 32, 32);
            Brush blackPen = Brushes.Black;
            e.Graphics.FillRectangle(blackPen, bOne);
            e.Graphics.FillRectangle(blackPen, bTwo);
            e.Graphics.FillRectangle(blackPen, bThree);
            e.Graphics.FillRectangle(blackPen, bFour);



            for (int i = placedrect.Length - 1; i > 0; i--)
                for (int j = rows.Length - 1; j > 0; j--)
                    if (placedrect[i].Contains(rows[j]) && placedrect[i].Y == 608)
                    {
                        if (!bank.Contains(i))
                        {

                            List<int> addbank = bank.ToList();
                            addbank.Add(i);
                            bank = addbank.ToArray();
                            Array.Sort(bank);
                            row1++;
                        }
                        
                    }

            if (row1 == 10)
            {
                try
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    label1.Text += "\n" + bank[0];
                    createblock.RemoveAt(bank[9]);
                    createblock.RemoveAt(bank[8]);
                    createblock.RemoveAt(bank[7]);
                    createblock.RemoveAt(bank[6]);
                    createblock.RemoveAt(bank[5]);
                    createblock.RemoveAt(bank[4]);
                    createblock.RemoveAt(bank[3]);
                    createblock.RemoveAt(bank[2]);
                    createblock.RemoveAt(bank[1]);
                    createblock.RemoveAt(bank[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        placedrect[i].Y += 32;
                }
                catch (Exception)
                {
                    MessageBox.Show("" + bank[1]);
                }

                bank = new int[0];
                row1 = 0;

            }




            for (int j = rows.Length - 1; j > 0; j--)
                e.Graphics.DrawRectangle(new Pen(Color.Black), rows[j]);


                for (int i = placedrect.Length - 1; i > 1; i--)
                if (placedrect[i].Y == 32)
                    Array.Clear(placedrect, 0, placedrect.Length);


            if (plyY == 608 || bTwo.Y == 608 || bThree.Y == 608 || bFour.Y == 608)
            {
                timer1.Stop();
                bOne = new Rectangle();
                bTwo = new Rectangle();
                bThree = new Rectangle();
                bFour = new Rectangle();
                List<Rectangle> createblock = placedrect.ToList();
                createblock.Add(new Rectangle(plyX, plyY, 32, 32));
                createblock.Add(new Rectangle(plyX + r1, plyY + r2, 32, 32));
                createblock.Add(new Rectangle(plyX - l1, plyY - l2, 32, 32));
                createblock.Add(new Rectangle(plyX + t2, plyY - t1, 32, 32));
                placedrect = createblock.ToArray();
                plyY = 0;
                plyX = 160;

                if (currentBlock == 1)
                {
                    currentBlock = 3;
                    r1 = -32;
                    r2 = -32;
                    l1 = 32;
                    l2 = 0;
                    t1 = 0;
                    t2 = 32;
                    rotationAng = 1;
                }
                else if (currentBlock == 2)
                {
                    currentBlock = 1;
                    r1 = 32;
                    r2 = 0;
                    l1 = 32;
                    l2 = 0;
                    t1 = 32;
                    t2 = 0;
                    rotationAng = 1;

                }
                else if (currentBlock == 3)
                {
                    currentBlock = 2;
                    r1 = 32;
                    r2 = 0;
                    l1 = 32;
                    l2 = 32;
                    t1 = 32;
                    t2 = 0;
                    rotationAng = 1;

                }
                timer1.Start();
            }
            //use union method 
            for (int i = placedrect.Length - 1; i > 0; i--)
                if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                    || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                    || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                    || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                {
                    timer1.Stop();
                    bOne = new Rectangle();
                    bTwo = new Rectangle();
                    bThree = new Rectangle();
                    bFour = new Rectangle();
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.Add(new Rectangle(plyX, plyY, 32, 32));
                    createblock.Add(new Rectangle(plyX + r1, plyY + r2, 32, 32));
                    createblock.Add(new Rectangle(plyX - l1, plyY - l2, 32, 32));
                    createblock.Add(new Rectangle(plyX + t2, plyY - t1, 32, 32));
                    placedrect = createblock.ToArray();
                    plyY = 0;
                    plyX = 160;

                    if (currentBlock == 1)
                    {
                        currentBlock = 3;
                        r1 = -32;
                        r2 = -32;
                        l1 = 32;
                        l2 = 0;
                        t1 = 0;
                        t2 = 32;
                        rotationAng = 1;
                    }
                    else if (currentBlock == 2)
                    {
                        currentBlock = 1;
                        r1 = 32;
                        r2 = 0;
                        l1 = 32;
                        l2 = 0;
                        t1 = 32;
                        t2 = 0;
                        rotationAng = 1;

                    }
                    else if (currentBlock == 3)
                    {
                        currentBlock = 2;
                        r1 = 32;
                        r2 = 0;
                        l1 = 32;
                        l2 = 32;
                        t1 = 32;
                        t2 = 0;
                        rotationAng = 1;

                    }
                    timer1.Start();
                }


        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'v':
                    MessageBox.Show("" + plyX + ".." + plyY);
                    break;
                case 's':

                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (bOne.Y == placedrect[i].Y - 32 && bOne.X == placedrect[i].X
                            || bTwo.Y == placedrect[i].Y - 32 && bTwo.X == placedrect[i].X
                            || bThree.Y == placedrect[i].Y - 32 && bThree.X == placedrect[i].X
                            || bFour.Y == placedrect[i].Y - 32 && bFour.X == placedrect[i].X)
                            return;
                    plyY += 32;
                    break;
                case 'w':
                    //plyY -= 32;
                    break;
                case 'a':
                    moveLeft();
                    break;
                case 'd':
                    moveRight();
                    break;
                case 'c':
                    if(currentBlock == 1)
                    {
                        rotateTblock();
                    }else if(currentBlock == 2)
                    {
                        rotateZblock();
                    }else if(currentBlock == 3)
                    {
                        rotateJblock();
                    }
                    break;
                case 'k'://duplicate player
                    MessageBox.Show("" + bank.Length);
                    break;
                case 'l':
                    
                    break;

            }
            
            panel1.Invalidate();
        }

        private void moveRight()
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

            plyX += 32;

        }

        private void moveLeft()
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

            plyX -= 32;

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
                l1 = -32;
                t2 = t1;
                t1 = 0;
                rotationAng++;
            }
            else if (rotationAng == 2)
            {
                r1 = r2;
                r2 = 0;
                l1 = l2;
                l2 = 32;
                t1 = t2;
                t2 = 0;
                rotationAng = 1;
            }
        }
        private void rotateJblock()
        {
            if (rotationAng == 1)
            {
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
                r1 = 32;
                r2 = 32;
                l1 = l2;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng++;
            }else if(rotationAng == 3)
            {
                r1 = -32;
                r2 = 32;
                l1 = 0;
                l2 = 32;
                t1 = (-32);
                t2 = 0;
                rotationAng++;
            }else if(rotationAng == 4)
            {
                r1 = -32;
                r2 = -32;
                l1 = 32;
                l2 = 0;
                t1 = 0;
                t2 = 32;
                rotationAng = 1;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            plyY += 32;


                panel1.Invalidate();
        }
    }
}

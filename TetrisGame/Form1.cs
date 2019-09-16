using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        int[] bank1 = new int[0];
        int row1 = 0;
        int[] bank2 = new int[0];
        int row2 = 0;
        int[] bank3 = new int[0];
        int row3 = 0;
        int[] bank4 = new int[0];
        int row4 = 0;
        int[] bank5 = new int[0];
        int row5 = 0;
        int[] bank6 = new int[0];
        int row6 = 0;
        int[] bank7 = new int[0];
        int row7 = 0;
        int[] bank8 = new int[0];
        int row8 = 0;
        int[] bank9 = new int[0];
        int row9 = 0;
        int[] bank10 = new int[0];
        int row10 = 0;
        int[] bank11 = new int[0];
        int row11 = 0;
        int[] bank12 = new int[0];
        int row12 = 0;
        int[] bank13 = new int[0];
        int row13 = 0;
        int[] bank14 = new int[0];
        int row14 = 0;
        int[] bank15 = new int[0];
        int row15 = 0;
        int[] bank16 = new int[0];
        int row16 = 0;
        int[] bank17 = new int[0];
        int row17 = 0;
        int[] bank18 = new int[0];
        int row18 = 0;
        int[] bank19 = new int[0];
        int row19 = 0;
        int[] bank20 = new int[0];
        int row20 = 0;


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

            placedrect = new Rectangle[2];
            rows = new Rectangle[2];

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
                    List<Rectangle> addtile = rows.ToList();
                    addtile.Add(new Rectangle(x * 32, y * 32, 32, 32));
                    rows = addtile.ToArray();
                }
            }
        }


        private void GameBoard_Paint(object sender, PaintEventArgs e)
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
                    if (placedrect[i].Contains(rows[j]))
                    {
                        if (!bank1.Contains(i) && placedrect[i].Y == 608)
                        {

                            List<int> addbank = bank1.ToList();
                            addbank.Add(i);
                            bank1 = addbank.ToArray();
                            Array.Sort(bank1);
                            row1++;
                        }
                        else if (!bank2.Contains(i) && placedrect[i].Y == 576)
                        {
                            List<int> addbank = bank2.ToList();
                            addbank.Add(i);
                            bank2 = addbank.ToArray();
                            Array.Sort(bank2);
                            row2++;
                        }
                        else if (!bank3.Contains(i) && placedrect[i].Y == 544)
                        {
                            List<int> addbank = bank3.ToList();
                            addbank.Add(i);
                            bank3 = addbank.ToArray();
                            Array.Sort(bank3);
                            row3++;
                        }
                        else if (!bank4.Contains(i) && placedrect[i].Y == 512)
                        {
                            List<int> addbank = bank4.ToList();
                            addbank.Add(i);
                            bank4 = addbank.ToArray();
                            Array.Sort(bank4);
                            row4++;
                        }
                        else if (!bank5.Contains(i) && placedrect[i].Y == 480)
                        {
                            List<int> addbank = bank5.ToList();
                            addbank.Add(i);
                            bank5 = addbank.ToArray();
                            Array.Sort(bank5);
                            row5++;
                        }
                        else if (!bank6.Contains(i) && placedrect[i].Y == 448)
                        {
                            List<int> addbank = bank6.ToList();
                            addbank.Add(i);
                            bank6 = addbank.ToArray();
                            Array.Sort(bank6);
                            row6++;
                        }
                        else if (!bank7.Contains(i) && placedrect[i].Y == 416)
                        {
                            List<int> addbank = bank7.ToList();
                            addbank.Add(i);
                            bank7 = addbank.ToArray();
                            Array.Sort(bank7);
                            row7++;
                        }
                        else if (!bank8.Contains(i) && placedrect[i].Y == 384)
                        {
                            List<int> addbank = bank8.ToList();
                            addbank.Add(i);
                            bank8 = addbank.ToArray();
                            Array.Sort(bank8);
                            row8++;
                        }
                        else if (!bank9.Contains(i) && placedrect[i].Y == 352)
                        {
                            List<int> addbank = bank9.ToList();
                            addbank.Add(i);
                            bank9 = addbank.ToArray();
                            Array.Sort(bank9);
                            row9++;
                        }
                        else if (!bank10.Contains(i) && placedrect[i].Y == 320)
                        {
                            List<int> addbank = bank10.ToList();
                            addbank.Add(i);
                            bank10 = addbank.ToArray();
                            Array.Sort(bank10);
                            row10++;
                        }
                        else if (!bank11.Contains(i) && placedrect[i].Y == 288)
                        {
                            List<int> addbank = bank11.ToList();
                            addbank.Add(i);
                            bank11 = addbank.ToArray();
                            Array.Sort(bank11);
                            row11++;
                        }
                        else if (!bank12.Contains(i) && placedrect[i].Y == 256)
                        {
                            List<int> addbank = bank12.ToList();
                            addbank.Add(i);
                            bank12 = addbank.ToArray();
                            Array.Sort(bank12);
                            row12++;
                        }
                        else if (!bank13.Contains(i) && placedrect[i].Y == 224)
                        {
                            List<int> addbank = bank13.ToList();
                            addbank.Add(i);
                            bank13 = addbank.ToArray();
                            Array.Sort(bank13);
                            row13++;
                        }
                        else if (!bank14.Contains(i) && placedrect[i].Y == 192)
                        {
                            List<int> addbank = bank14.ToList();
                            addbank.Add(i);
                            bank14 = addbank.ToArray();
                            Array.Sort(bank14);
                            row14++;
                        }
                        else if (!bank15.Contains(i) && placedrect[i].Y == 160)
                        {
                            List<int> addbank = bank15.ToList();
                            addbank.Add(i);
                            bank15 = addbank.ToArray();
                            Array.Sort(bank15);
                            row15++;
                        }
                        else if (!bank16.Contains(i) && placedrect[i].Y == 128)
                        {
                            List<int> addbank = bank16.ToList();
                            addbank.Add(i);
                            bank16 = addbank.ToArray();
                            Array.Sort(bank16);
                            row16++;
                        }
                        else if (!bank17.Contains(i) && placedrect[i].Y == 96)
                        {
                            List<int> addbank = bank17.ToList();
                            addbank.Add(i);
                            bank17 = addbank.ToArray();
                            Array.Sort(bank17);
                            row17++;
                        }
                        else if (!bank18.Contains(i) && placedrect[i].Y == 64)
                        {
                            List<int> addbank = bank18.ToList();
                            addbank.Add(i);
                            bank18 = addbank.ToArray();
                            Array.Sort(bank18);
                            row18++;
                        }
                        else if (!bank19.Contains(i) && placedrect[i].Y == 32)
                        {
                            List<int> addbank = bank19.ToList();
                            addbank.Add(i);
                            bank19 = addbank.ToArray();
                            Array.Sort(bank19);
                            row19++;
                        }
                        else if (!bank20.Contains(i) && placedrect[i].Y == 0)
                        {
                            List<int> addbank = bank20.ToList();
                            addbank.Add(i);
                            bank20 = addbank.ToArray();
                            Array.Sort(bank20);
                            row20++;
                        }

                    }
            placedrect[0].Y = 99999;
            placedrect[1].Y = 99999;


            try
            {
                if (row1 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank1[9]);
                    createblock.RemoveAt(bank1[8]);
                    createblock.RemoveAt(bank1[7]);
                    createblock.RemoveAt(bank1[6]);
                    createblock.RemoveAt(bank1[5]);
                    createblock.RemoveAt(bank1[4]);
                    createblock.RemoveAt(bank1[3]);
                    createblock.RemoveAt(bank1[2]);
                    createblock.RemoveAt(bank1[1]);
                    createblock.RemoveAt(bank1[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row2 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank2[9]);
                    createblock.RemoveAt(bank2[8]);
                    createblock.RemoveAt(bank2[7]);
                    createblock.RemoveAt(bank2[6]);
                    createblock.RemoveAt(bank2[5]);
                    createblock.RemoveAt(bank2[4]);
                    createblock.RemoveAt(bank2[3]);
                    createblock.RemoveAt(bank2[2]);
                    createblock.RemoveAt(bank2[1]);
                    createblock.RemoveAt(bank2[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 576)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row3 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank3[9]);
                    createblock.RemoveAt(bank3[8]);
                    createblock.RemoveAt(bank3[7]);
                    createblock.RemoveAt(bank3[6]);
                    createblock.RemoveAt(bank3[5]);
                    createblock.RemoveAt(bank3[4]);
                    createblock.RemoveAt(bank3[3]);
                    createblock.RemoveAt(bank3[2]);
                    createblock.RemoveAt(bank3[1]);
                    createblock.RemoveAt(bank3[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 544)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row4 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank4[9]);
                    createblock.RemoveAt(bank4[8]);
                    createblock.RemoveAt(bank4[7]);
                    createblock.RemoveAt(bank4[6]);
                    createblock.RemoveAt(bank4[5]);
                    createblock.RemoveAt(bank4[4]);
                    createblock.RemoveAt(bank4[3]);
                    createblock.RemoveAt(bank4[2]);
                    createblock.RemoveAt(bank4[1]);
                    createblock.RemoveAt(bank4[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 512)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row5 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank5[9]);
                    createblock.RemoveAt(bank5[8]);
                    createblock.RemoveAt(bank5[7]);
                    createblock.RemoveAt(bank5[6]);
                    createblock.RemoveAt(bank5[5]);
                    createblock.RemoveAt(bank5[4]);
                    createblock.RemoveAt(bank5[3]);
                    createblock.RemoveAt(bank5[2]);
                    createblock.RemoveAt(bank5[1]);
                    createblock.RemoveAt(bank5[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 480)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row6 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank6[9]);
                    createblock.RemoveAt(bank6[8]);
                    createblock.RemoveAt(bank6[7]);
                    createblock.RemoveAt(bank6[6]);
                    createblock.RemoveAt(bank6[5]);
                    createblock.RemoveAt(bank6[4]);
                    createblock.RemoveAt(bank6[3]);
                    createblock.RemoveAt(bank6[2]);
                    createblock.RemoveAt(bank6[1]);
                    createblock.RemoveAt(bank6[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 448)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row7 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank7[9]);
                    createblock.RemoveAt(bank7[8]);
                    createblock.RemoveAt(bank7[7]);
                    createblock.RemoveAt(bank7[6]);
                    createblock.RemoveAt(bank7[5]);
                    createblock.RemoveAt(bank7[4]);
                    createblock.RemoveAt(bank7[3]);
                    createblock.RemoveAt(bank7[2]);
                    createblock.RemoveAt(bank7[1]);
                    createblock.RemoveAt(bank7[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 416)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row8 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank8[9]);
                    createblock.RemoveAt(bank8[8]);
                    createblock.RemoveAt(bank8[7]);
                    createblock.RemoveAt(bank8[6]);
                    createblock.RemoveAt(bank8[5]);
                    createblock.RemoveAt(bank8[4]);
                    createblock.RemoveAt(bank8[3]);
                    createblock.RemoveAt(bank8[2]);
                    createblock.RemoveAt(bank8[1]);
                    createblock.RemoveAt(bank8[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 384)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row9 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank9[9]);
                    createblock.RemoveAt(bank9[8]);
                    createblock.RemoveAt(bank9[7]);
                    createblock.RemoveAt(bank9[6]);
                    createblock.RemoveAt(bank9[5]);
                    createblock.RemoveAt(bank9[4]);
                    createblock.RemoveAt(bank9[3]);
                    createblock.RemoveAt(bank9[2]);
                    createblock.RemoveAt(bank9[1]);
                    createblock.RemoveAt(bank9[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 352)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row10 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank10[9]);
                    createblock.RemoveAt(bank10[8]);
                    createblock.RemoveAt(bank10[7]);
                    createblock.RemoveAt(bank10[6]);
                    createblock.RemoveAt(bank10[5]);
                    createblock.RemoveAt(bank10[4]);
                    createblock.RemoveAt(bank10[3]);
                    createblock.RemoveAt(bank10[2]);
                    createblock.RemoveAt(bank10[1]);
                    createblock.RemoveAt(bank10[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 320)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row11 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank11[9]);
                    createblock.RemoveAt(bank11[8]);
                    createblock.RemoveAt(bank11[7]);
                    createblock.RemoveAt(bank11[6]);
                    createblock.RemoveAt(bank11[5]);
                    createblock.RemoveAt(bank11[4]);
                    createblock.RemoveAt(bank11[3]);
                    createblock.RemoveAt(bank11[2]);
                    createblock.RemoveAt(bank11[1]);
                    createblock.RemoveAt(bank11[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 288)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row12 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank12[9]);
                    createblock.RemoveAt(bank12[8]);
                    createblock.RemoveAt(bank12[7]);
                    createblock.RemoveAt(bank12[6]);
                    createblock.RemoveAt(bank12[5]);
                    createblock.RemoveAt(bank12[4]);
                    createblock.RemoveAt(bank12[3]);
                    createblock.RemoveAt(bank12[2]);
                    createblock.RemoveAt(bank12[1]);
                    createblock.RemoveAt(bank12[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 256)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row13 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank13[9]);
                    createblock.RemoveAt(bank13[8]);
                    createblock.RemoveAt(bank13[7]);
                    createblock.RemoveAt(bank13[6]);
                    createblock.RemoveAt(bank13[5]);
                    createblock.RemoveAt(bank13[4]);
                    createblock.RemoveAt(bank13[3]);
                    createblock.RemoveAt(bank13[2]);
                    createblock.RemoveAt(bank13[1]);
                    createblock.RemoveAt(bank13[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 224)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row14 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank14[9]);
                    createblock.RemoveAt(bank14[8]);
                    createblock.RemoveAt(bank14[7]);
                    createblock.RemoveAt(bank14[6]);
                    createblock.RemoveAt(bank14[5]);
                    createblock.RemoveAt(bank14[4]);
                    createblock.RemoveAt(bank14[3]);
                    createblock.RemoveAt(bank14[2]);
                    createblock.RemoveAt(bank14[1]);
                    createblock.RemoveAt(bank14[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 192)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row15 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank15[9]);
                    createblock.RemoveAt(bank15[8]);
                    createblock.RemoveAt(bank15[7]);
                    createblock.RemoveAt(bank15[6]);
                    createblock.RemoveAt(bank15[5]);
                    createblock.RemoveAt(bank15[4]);
                    createblock.RemoveAt(bank15[3]);
                    createblock.RemoveAt(bank15[2]);
                    createblock.RemoveAt(bank15[1]);
                    createblock.RemoveAt(bank15[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 160)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row16 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank16[9]);
                    createblock.RemoveAt(bank16[8]);
                    createblock.RemoveAt(bank16[7]);
                    createblock.RemoveAt(bank16[6]);
                    createblock.RemoveAt(bank16[5]);
                    createblock.RemoveAt(bank16[4]);
                    createblock.RemoveAt(bank16[3]);
                    createblock.RemoveAt(bank16[2]);
                    createblock.RemoveAt(bank16[1]);
                    createblock.RemoveAt(bank16[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 128)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row17 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank17[9]);
                    createblock.RemoveAt(bank17[8]);
                    createblock.RemoveAt(bank17[7]);
                    createblock.RemoveAt(bank17[6]);
                    createblock.RemoveAt(bank17[5]);
                    createblock.RemoveAt(bank17[4]);
                    createblock.RemoveAt(bank17[3]);
                    createblock.RemoveAt(bank17[2]);
                    createblock.RemoveAt(bank17[1]);
                    createblock.RemoveAt(bank17[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 96)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row18 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank18[9]);
                    createblock.RemoveAt(bank18[8]);
                    createblock.RemoveAt(bank18[7]);
                    createblock.RemoveAt(bank18[6]);
                    createblock.RemoveAt(bank18[5]);
                    createblock.RemoveAt(bank18[4]);
                    createblock.RemoveAt(bank18[3]);
                    createblock.RemoveAt(bank18[2]);
                    createblock.RemoveAt(bank18[1]);
                    createblock.RemoveAt(bank18[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 64)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row19 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank19[9]);
                    createblock.RemoveAt(bank19[8]);
                    createblock.RemoveAt(bank19[7]);
                    createblock.RemoveAt(bank19[6]);
                    createblock.RemoveAt(bank19[5]);
                    createblock.RemoveAt(bank19[4]);
                    createblock.RemoveAt(bank19[3]);
                    createblock.RemoveAt(bank19[2]);
                    createblock.RemoveAt(bank19[1]);
                    createblock.RemoveAt(bank19[0]);
                    placedrect = createblock.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 32)
                            placedrect[i].Y += 32;
                    resetBank();
                }
                else if (row20 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    createblock.RemoveAt(bank20[9]);
                    createblock.RemoveAt(bank20[8]);
                    createblock.RemoveAt(bank20[7]);
                    createblock.RemoveAt(bank20[6]);
                    createblock.RemoveAt(bank20[5]);
                    createblock.RemoveAt(bank20[4]);
                    createblock.RemoveAt(bank20[3]);
                    createblock.RemoveAt(bank20[2]);
                    createblock.RemoveAt(bank20[1]);
                    createblock.RemoveAt(bank20[0]);
                    placedrect = createblock.ToArray();
                    resetBank();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("" + bank1[1]);
            }



            for (int j = rows.Length - 1; j > 0; j--)
                e.Graphics.DrawRectangle(new Pen(Color.Black), rows[j]);


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
                    if (plyY < 32)
                        return;
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



            try
            {
                for (int i = placedrect.Length - 1; i > 1; i--)
                    if (placedrect[i].Y == 32)
                    {
                        placedrect = new Rectangle[2];
                        resetBank();
                    }
            }
            catch (Exception) { }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            


        }

        private void removeAll()
        {
            for (int i = placedrect.Length - 1; i > 0; i--)
            {
                List<Rectangle> createblock = placedrect.ToList();
                createblock.RemoveAt(i);
                placedrect = createblock.ToArray();
            }
        }

        private void resetBank()
        {
            bank1 = new int[0];
            row1 = 0;
            bank2 = new int[0];
            row2 = 0;
            bank3 = new int[0];
            row3 = 0;
            bank4 = new int[0];
            row4 = 0;
            bank5 = new int[0];
            row5 = 0;
            bank6 = new int[0];
            row6 = 0;
            bank7 = new int[0];
            row7 = 0;
            bank8 = new int[0];
            row8 = 0;
            bank9 = new int[0];
            row9 = 0;
            bank10 = new int[0];
            row10 = 0;
            bank11 = new int[0];
            row11 = 0;
            bank12 = new int[0];
            row12 = 0;
            bank13 = new int[0];
            row13 = 0;
            bank14 = new int[0];
            row14 = 0;
            bank15 = new int[0];
            row15 = 0;
            bank16 = new int[0];
            row16 = 0;
            bank17 = new int[0];
            row17 = 0;
            bank18 = new int[0];
            row18 = 0;
            bank19 = new int[0];
            row19 = 0;
            bank20 = new int[0];
            row20 = 0;
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
                    MessageBox.Show("" + bank1.Length + " " + bank2.Length + " " + bank3.Length + " " + bank4.Length + " " + bank5.Length + " " + bank6.Length + " " + bank7.Length + " " + bank8.Length
                         + " " + bank9.Length + " " + bank10.Length + " " + bank11.Length + " " + bank12.Length);
                    break;
                case 'l':
                    
                    break;

            }

            gameBoard.Invalidate();
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
            gameBoard.Invalidate();
        }

    }
}

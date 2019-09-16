
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
        public static Point tPoint1 = new Point(390, 10);
        public static Point tPoint2 = new Point(390, 20);
        public static Point tPoint3 = new Point(380, 20);
        public static Point tPoint4 = new Point(380, 30);
        public static Point tPoint5 = new Point(370, 30);
        public static Point tPoint6 = new Point(370, 20);
        public static Point tPoint7 = new Point(360, 20);
        public static Point tPoint8 = new Point(360, 10);
        public static int item_in_list = 0;

        private static Point[] points =
{
               tPoint1,
               tPoint2,
               tPoint3,
               tPoint4,
               tPoint5,
               tPoint6,
               tPoint7,
               tPoint8

            };
        private static Point[][] block_list = new Point[150][];


        public static Point[] currentPoints = points;
        
        public Form1()
        {
            InitializeComponent();
            this.panel1.Anchor |= AnchorStyles.Bottom | AnchorStyles.Right;
            this.panel1.Resize += panel1_Resize;
            this.panel1.Paint += panel1_Paint;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void S(object sender, EventArgs e)
        {

        }

        public static void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            foreach(Point[] value in block_list)
            {   
                if(value != null)
                {
                    e.Graphics.DrawPolygon(blackPen, value);
                }
               
                
            }
    

            e.Graphics.DrawPolygon(blackPen, currentPoints);
            
            e.Graphics.DrawLine(blackPen, 0, 450, 750, 450);

            
            //use union method

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            bool Add = true;
            if (currentPoints[3].Y == 450){
                Add = false;
            } 
            for (int a = 0; a < currentPoints.Length; a++)
            {

                if (Add == true)
                {
                    currentPoints[a].Y += 10;


                }
                else if (currentPoints[3].Y == 450)
                {
                    block_list[item_in_list] = new Point[] { currentPoints[0], currentPoints[1], currentPoints[2], currentPoints[3], currentPoints[4], currentPoints[5], currentPoints[6], currentPoints[7] };
                    panel1.Invalidate();
                    item_in_list += 1;
                    Array.Clear(currentPoints, 0, currentPoints.Length);

                    Point tOne = new Point(390, 10);
                    Point tTwo = new Point(390, 20);
                    Point tThree = new Point(380, 20);
                    Point tFour = new Point(380, 30);
                    Point tFive = new Point(370, 30);
                    Point tSix = new Point(370, 20);
                    Point tSeven = new Point(360, 20);
                    Point tEight = new Point(360, 10);

                   
                    Point[] points_rest = {
                        tOne,
                        tTwo,
                        tThree,
                        tFour,
                        tFive,
                        tSix,
                        tSeven,
                        tEight,
                    };
                    currentPoints = points_rest;
                    
                    panel1.Invalidate();

                    return;


                }
                

            }
            foreach (Point[] value in block_list)
            {
                if (value != null)
                {
                    for (int i = 3; i < 8; i++)
                    {
                        if (
                            currentPoints[3].Y == value[0].Y && currentPoints[3].X == value[i].X ||
                            currentPoints[4].Y == value[0].Y && currentPoints[4].X == value[i].X ||
                            currentPoints[5].Y == value[0].Y && currentPoints[5].X == value[i].X ||
                            currentPoints[6].Y == value[0].Y && currentPoints[6].X == value[i].X)

           
                        {

                            block_list[item_in_list] = new Point[] { currentPoints[0], currentPoints[1], currentPoints[2], currentPoints[3], currentPoints[4], currentPoints[5], currentPoints[6], currentPoints[7] };
                            panel1.Invalidate();
                            item_in_list += 1;
                            Array.Clear(currentPoints, 0, currentPoints.Length);

                            Point tOne = new Point(390, 10);
                            Point tTwo = new Point(390, 20);
                            Point tThree = new Point(380, 20);
                            Point tFour = new Point(380, 30);
                            Point tFive = new Point(370, 30);
                            Point tSix = new Point(370, 20);
                            Point tSeven = new Point(360, 20);
                            Point tEight = new Point(360, 10);

                            
                            Point[] points_rest = {
                                    tOne,
                                    tTwo,
                                    tThree,
                                    tFour, 
                                    tFive,
                                    tSix,
                                    tSeven,
                                    tEight,
                                    };
                            currentPoints = points_rest;
                           
                            panel1.Invalidate();

                        }
                    }
                }


            }
            panel1.Invalidate();

            
        }

        private void Form1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {

                case 'd':
                    panel1.Invalidate();
                    for (int a = 0; a < currentPoints.Length; a++)
                    {
                        if (currentPoints[a].Y != 450)
                        {
                            currentPoints[a].X += 10;
                        }


                    }
                    
                    break;

            }
        }
    }
}
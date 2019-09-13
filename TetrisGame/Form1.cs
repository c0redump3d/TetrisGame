
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
        public static Point tPoint1 = new Point(390, 10);
        public static Point tPoint2 = new Point(390, 20);
        public static Point tPoint3 = new Point(380, 20);
        public static Point tPoint4 = new Point(380, 30);
        public static Point tPoint5 = new Point(370, 30);
        public static Point tPoint6 = new Point(370, 20);
        public static Point tPoint7 = new Point(360, 20);
        public static Point tPoint8 = new Point(360, 10);
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
        private static Point[] startT =
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


            e.Graphics.DrawPolygon(blackPen, points);
            e.Graphics.DrawLine(blackPen, 0, 450, 750, 450);
            //use union method

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            panel1.Invalidate();
            for (int a = 0; a < points.Length; a++)
            {
                if (points[a].Y != 450)
                {
                    points[a].Y += 10;
                }
                else if (points[a].Y == 450)
                {
                    tPoint1.X = startT[0].X;
                    tPoint2.X = startT[1].X;
                    tPoint3.X = startT[2].X;
                    tPoint4.X = startT[3].X;
                    tPoint5.X = startT[4].X;
                    tPoint6.X = startT[5].X;
                    tPoint7.X = startT[6].X;
                    tPoint8.X = startT[7].X;

                    tPoint1.Y = startT[0].Y;
                    tPoint2.Y = startT[1].Y;
                    tPoint3.Y = startT[2].Y;
                    tPoint4.Y = startT[3].Y;
                    tPoint5.Y = startT[4].Y;
                    tPoint6.Y = startT[5].Y;
                    tPoint7.Y = startT[6].Y;
                    tPoint8.Y = startT[7].Y;
                    panel1.Invalidate();

                }

            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'd':
                    for (int a = 0; a < points.Length; a++)
                    {
                        points[a].X += 10;
                    }
                    panel1.Invalidate();
                    break;

            }
        }
    }
}
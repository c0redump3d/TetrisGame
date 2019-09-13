using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace TetrisGame
{
    public partial class Form1 : Form
    {
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black);
            Point[] points =
            {
                new Point(360, 10),
                new Point(390, 10),
                new Point(390, 20),
                new Point(380, 20),
                new Point(380, 30),
                new Point(370, 30),
                new Point(370, 20),
                new Point(360, 20),
                new Point(360, 10)

            };
            
            

        //use union method 

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}

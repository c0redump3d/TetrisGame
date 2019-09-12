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
            Rectangle bOne = new Rectangle(10, 10, 10, 10);
            Rectangle bTwo = new Rectangle(50, 10, 10, 10);
            Rectangle bThree = new Rectangle(10, 10, 10, 10);
            Rectangle bFour = new Rectangle(10, 10, 10, 10);
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), 5);
            e.Graphics.DrawRectangle(blackPen, bOne);
            e.Graphics.DrawRectangle(blackPen, bTwo);
        //use union method 

        }
        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}

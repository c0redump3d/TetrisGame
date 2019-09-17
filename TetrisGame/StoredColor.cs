using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{
    class ColoredRectangle
    {
        public Brush Color { get; set; }
        public ColoredRectangle(Brush color)
        {
            Color = color;
        }

    }
}
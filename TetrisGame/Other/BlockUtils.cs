using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace TetrisGame.Other
{
    public static class BlockUtils
    {

        public static Image SetOpacity(this Image image, float opacity)
        {
            var colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(
                colorMatrix,
                ColorMatrixFlag.Default,
                ColorAdjustType.Bitmap);
            var output = new Bitmap(image.Width, image.Height);
            using (var gfx = Graphics.FromImage(output))
            {
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.DrawImage(
                    image,
                    new Rectangle(0, 0, image.Width, image.Height),
                    0,
                    0,
                    image.Width,
                    image.Height,
                    GraphicsUnit.Pixel,
                    imageAttributes);
            }
            return output;
        }

        public static Image translateColorToImage(Brush color, bool placed)
        {
            //Could not use switch case here, c# requires that the value be a constant.

            if (color == Brushes.Purple)
            {
                if (placed)
                    return Properties.Resources.tetris_t_placed;
                else
                    return Properties.Resources.tetris_t_full;
            }
            if (color == Brushes.Red)
            {
                if (placed)
                    return Properties.Resources.tetris_z1_placed;
                else
                    return Properties.Resources.tetris_z1_full;
            }
            if (color == Brushes.Blue)
            {
                if (placed)
                    return Properties.Resources.tetris_l1_placed;
                else
                    return Properties.Resources.tetris_l1_full;
            }
            if (color == Brushes.Cyan)
            {
                if (placed)
                    return Properties.Resources.tetris_i_placed;
                else
                    return Properties.Resources.tetris_i_full;
            }
            if (color == Brushes.Yellow)
            {
                if (placed)
                    return Properties.Resources.tetris_o_placed;
                else
                    return Properties.Resources.tetris_o_full;
            }
            if (color == Brushes.Gold)
            {
                if (placed)
                    return Properties.Resources.tetris_l2_placed;
                else
                    return Properties.Resources.tetris_l2_full;
            }
            if (color == Brushes.LimeGreen)
            {
                if (placed)
                    return Properties.Resources.tetris_z2_placed;
                else
                    return Properties.Resources.tetris_z2_full;
            }
            if (color == Brushes.Gray)
            {
                return Properties.Resources.tetris_x_full;
            }

            //if something actually important is being drawn to the screen ig it will be the github logo.
            //but, nothing important should ever fall down here.
            return Properties.Resources.GitHub_Mark_64px;

        }

    }
}

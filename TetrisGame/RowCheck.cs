using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame
{

    /// <summary>
    /// This class is in charge of checking rows, meaning check if a row is full.
    /// If a row is full this class also is in charge of removing the corresponding
    /// row and update the form.
    /// </summary>
    class RowCheck
    {

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

        /// <summary>
        /// This function will remove any filled rows, the checkRow function will mark a row to remove and this will remove that row.
        /// </summary>
        /// <param name="placedrect"></param>
        /// <param name="rows"></param>
        /// <param name="storedColor"></param>
        /// <param name="remove"></param>
        public void removeRow(ref Rectangle[] placedrect, ref Rectangle[] rows, ref Brush[] storedColor, ref bool remove)
        {
            /*
             * 
             * Yes, this is a mess but this is required to remove rows if they're full.
             * 
             * Each row contains it's own 'bank' which contains the placed rectangles on that Y level
             * for each rectangle in the row, we add one, so once it equals 10 it passes to down here.
             * 
             * We check each row individually.
             * 
             */

            try
            {
                if (row1 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank1[i]); // remove rectangles stored in bank array
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank1[i]); // remove color stored in bank array
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        placedrect[i].Y += 32; // move all remaining blocks down
                    remove = true;
                }
                else if (row2 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank2[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank2[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 576)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row3 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank3[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank3[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 544)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row4 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank4[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank4[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 512)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row5 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank5[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank5[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 480)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row6 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank6[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank6[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 448)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row7 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank7[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank7[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 416)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row8 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank8[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank8[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 384)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row9 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank9[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank9[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 352)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row10 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank10[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank10[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 320)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row11 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank11[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank11[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 288)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row12 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank12[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank12[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 256)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row13 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank13[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank13[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 224)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row14 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank14[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank14[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 192)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row15 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank15[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank15[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 160)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row16 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank16[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank16[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 128)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row17 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank17[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank17[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 96)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row18 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank18[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank18[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 64)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row19 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank19[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank19[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    for (int i = placedrect.Length - 1; i > 0; i--)
                        if (placedrect[i].Y < 32)
                            placedrect[i].Y += 32;
                    remove = true;
                }
                else if (row20 == 10)
                {
                    List<Rectangle> createblock = placedrect.ToList();
                    List<Brush> removecolor = storedColor.ToList();
                    for (int i = 9; i >= 0; i--)
                        createblock.RemoveAt(bank20[i]);
                    for (int i = 9; i >= 0; i--)
                        removecolor.RemoveAt(bank20[i]);
                    placedrect = createblock.ToArray();
                    storedColor = removecolor.ToArray();
                    remove = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception was thrown! Game has encountered an issue with removing bank! \n" + ex.Message);
            }
        }

        /// <summary>
        /// Here we check if any grid box(hidden) contains a placed rectangle,
        /// if it does, we add the placed rectangle's index into the corresponding
        /// bank(row).
        /// </summary>
        /// <param name="placedrect"></param>
        /// <param name="rows"></param>
        public void checkRow(ref Rectangle[] placedrect, ref Rectangle[] rows)
        {
            /*
             * 
             * Here we check if any grid box(hidden) contains a placed rectangle,
             * if it does, we add the placed rectangle's index into the corresponding
             * bank(row).
             * 
             * --only commenting on bank1 because every other row is the same.
             * 
             */

            for (int i = placedrect.Length - 1; i > 0; i--)
                for (int j = rows.Length - 1; j > 0; j--)
                    if (placedrect[i].Contains(rows[j])) // if a row is contained in a placed rectangle
                    {
                        if (!bank1.Contains(i) && placedrect[i].Y == 608)
                        {

                            List<int> addbank = bank1.ToList();
                            addbank.Add(i); // add index of placed rectangle to bank
                            bank1 = addbank.ToArray();
                            Array.Sort(bank1);// sort array from big to least
                            row1++; // add one to row1 counter
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
        }

        //wipe all banks
        public void resetBank()
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

    }
}

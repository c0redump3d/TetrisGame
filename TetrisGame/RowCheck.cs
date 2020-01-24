using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        int[] bank = new int[0];
        int rowRemove;
        int[] toRemove = new int[20];
        bool removing = false;
        Rectangle[] row = new Rectangle[200];
        int k = 0;
        int l = 0;
        int[] xRow = new int[10] { 0, 32, 64, 96, 128, 160, 192, 224, 256, 288 };
        int[] yRow = new int[20] { 0, 32, 64, 96, 128, 160, 192, 224, 256, 288,
                                   320, 352, 384, 416, 448, 480, 512, 544, 576, 608};
        int[] added = new int[200];
        int[,] board = new int[20, 10];

        public RowCheck()
        {
            setBoard();

            int x = 0;
            int y = 0;
            int currentRect = 0;

            while (currentRect != 200) // creates invisible rectangles to cover board -- used for collision detection
            {
                row[currentRect] = new Rectangle(x, y, 32, 32);
                x += 32;
                if (x == 320)
                {
                    x = 0;
                    y += 32;
                }
                currentRect++;
            }
        }

        public void update(ref Rectangle[] placedrect, ref Brush[] storedColor, ref bool remove)
        {

            try
            {
                for (int i = 0; i < placedrect.Length; i++)
                    for (int j = 0; j < row.Length; j++)
                        if (placedrect[i].IntersectsWith(row[j])) // Basically means a block has landed on a specific square
                        {
                            if (removing)
                                break;
                            board[getLocationY(placedrect[i].Y), getLocationX(placedrect[i].X)] = i; // store the index of the placedrect inside the board array

                            check(ref placedrect, ref storedColor, ref remove); // check to see if any removals are needed

                            break;
                        }
            }
            catch (Exception ex) { Debug.debugMessage("ERROR: Exception thrown! function: " + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n" + ex.Message, 1, true); }
        }

        private void check(ref Rectangle[] placedrect, ref Brush[] storedColor, ref bool remove)
        {
            k = 0;
            l = 0;

            for (int c = 0; c < board.Length; c++) // best way i personally found to loop through ALL indexes in the multidim array
            {
                if (k == 10)
                {
                    l++;
                    k = 0;
                }

                if (board[l, k] > 0 && board[l, k] != added[c]) // if board piece does not equal 0 and has not already been added to the toRemove array
                {
                    added[c] = board[l, k];
                    toRemove[getLocationY(placedrect[board[l, k]].Y)]++;
                    Debug.debugMessage("BLOCK: " + board[l, k] + " added to board at ROW: " + l + " COLUMN: " + k, 1);

                    if (toRemove[getLocationY(placedrect[board[l, k]].Y)] == 10)
                    {
                        rowRemove = placedrect[board[l, k]].Y;

                        List<int> addBank = bank.ToList();
                        for (int i = 0; i < board.GetLength(1); i++)
                            addBank.Add(board[getLocationY(rowRemove), i]);
                        bank = addBank.ToArray();
                        Array.Sort(bank);
                    }

                }

                k++;
            }

            for (int i = 0; i < toRemove.Length; i++)
                if (toRemove[i] == 10)
                    removing = true;

            if (removing)
            {

                List<Rectangle> createblock = placedrect.ToList();
                List<Brush> removecolor = storedColor.ToList();
                for (int i = 9; i >= 0; i--)
                {
                    createblock.RemoveAt(bank[i]); // remove rectangles stored in bank array
                    Debug.debugMessage("BLOCK: " + bank[i] + " was removed from board\n", 1);
                }
                for (int i = 9; i >= 0; i--)
                    removecolor.RemoveAt(bank[i]); // remove color stored in bank array
                placedrect = createblock.ToArray();
                storedColor = removecolor.ToArray();

                for (int i = placedrect.Length - 1; i > 0; i--)
                    if (placedrect[i].Y < rowRemove)
                        placedrect[i].Y += 32;

                setBoard();
                bank = new int[0];
                added = new int[200];
                toRemove = new int[200];
                removing = false;
                remove = true;
            }
        }

        public string showBoard()
        {
            string output = "";
            int t = 0, t1 = 0;

            for (int c = 0; c < board.Length; c++) // best way i personally found to loop through ALL indexes in the multidim array
            {

                if (t1 == 10 && c == 200)
                    break;

                if (t1 == 10)
                {
                    output += t1 == 10 ? "\n" : board[t, t1] != 0 ? "1 " : "0 ";
                    t++;
                    t1 = 0;
                }

                output += t1 == 10 ? "\n" : board[t, t1] != 0 ? "1 " : "0 ";

                t1++;
            }

            return output;
        }

        private void setBoard()
        {
            board = new int[20, 10] {    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        }

        private int getLocationX(int x)
        {
            for (int i = 0; i < xRow.Length; i++)
                if (x == xRow[i])
                {
                    return x = i;
                }

            return 0;
        }

        private int getLocationY(int y)
        {
            for (int i = 0; i < yRow.Length; i++)
                if (y == yRow[i])
                {
                    return y = i;
                }

            return 0;
        }

    }
}

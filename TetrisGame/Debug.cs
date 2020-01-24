using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class Debug
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static int selection = 0;
        private static bool enabled = false;

        public static void setUp()
        {
            AllocConsole();
            enabled = true;
            Console.WriteLine("Tetris Game Debug Console");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("(1): Tetris Game Debug Output");
            Console.WriteLine("(2): Text Visual Game Board");
            while (selection == 0)
            {
                try
                {
                    selection = Convert.ToInt32(Console.ReadLine());
                }catch(Exception) { Console.WriteLine("Selection not understood. Please try again.");  selection = 0; continue; }

                if (selection == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Console will now output debug messages.");
                }
                else if (selection == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Console will now output game board.");
                }
            }
        }

        public static int getSelection()
        {
            return selection;
        }

        public static bool isEnabled()
        {
            return enabled;
        }

        public static void debugMessage(string Message, int Mode, bool Critical = false)
        {
            if (Critical)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Message.Insert(0, "CRITICAL: ");
            }
            else
                Console.ForegroundColor = ConsoleColor.White;

            if (selection == 1 && Mode == 1)
                Console.WriteLine("[" + DateTime.Now.ToShortTimeString() + "] TETRIS_DEBUG: " + Message);
            else if (selection == 2 && Mode == 2)
            {
                Console.Clear();
                Console.WriteLine(Message);
            }
        }

    }
}

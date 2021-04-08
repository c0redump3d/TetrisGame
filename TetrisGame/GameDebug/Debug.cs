using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using TetrisGame.Other;

namespace TetrisGame
{
    class Debug
    {
        /*
         * 
         * There is nothing particually important in this class.
         * This is mainly to help with development of this game when
         * adding new features, etc. as it outputs helpful debug messages
         * as well as providing other important things like player position,
         * rotation check, etc.
         * 
         */
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static int selection = 0;
        private static bool enabled = false;
        private static Thread consoleThread;

        public static void setUp()
        {
            AllocConsole();
            Console.Title = "Tetris Debug Console";
            consoleThread = new Thread(runConsole);
            consoleThread.Start();
            InstanceManager.getMainForm().Text = "Tetris (Debug Mode)";
            enabled = true;
        }

        private static void runConsole()
        {
            Console.WriteLine("Tetris Game Debug Console");
            helpMessage();
            while (true)
            {
                string command = Console.ReadLine();
                registerCommand(command);
            }
        }

        private static void helpMessage()
        {
            Console.WriteLine("~=~=~=~=~=~=~=~=~=~=~=~=~=~=COMMANDS~=~=~=~=~=~=~=~=~=~=~=~=~=~=~");
            Console.WriteLine("| debug - Will output debug messages.                           |");
            Console.WriteLine("| textboard - Will show the game board via cmd.                 |");
            Console.WriteLine("| level (int) - Will set the level in game.                     |");
            Console.WriteLine("| end - Will end the current game.                              |");
            Console.WriteLine("| clear *(game) - Will clear either the command prompt or game. |");
            Console.WriteLine("| help - Will show this message again.                          |");
            Console.WriteLine("| exit - Will exit the game.                                    |");
            Console.WriteLine("~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~=~");
        }

        private static void registerCommand(string cmd)
        {
            bool containsExtra = false;
            string cmdResponse = "[" + DateTime.Now.ToShortTimeString() + "] TETRIS_CMD: ";
            string inputCMD = "";
            string actualCmd = "";

            if (cmd.Contains(" "))
                containsExtra = true;

            if (containsExtra)
            {
                actualCmd = cmd.Split(' ')[0];
                inputCMD = cmd.Split(' ')[1];
            }
            else
            {
                actualCmd = cmd;
            }

            try
            {
                switch (actualCmd)
                {
                    case "debug":
                        selection = 1;
                        Console.WriteLine(cmdResponse + "Console will now display debug messages.");
                        break;
                    case "textboard":
                        selection = 2;
                        Console.WriteLine(cmdResponse + "Console will now display the text board.");
                        break;
                    case "help":
                        helpMessage();
                        break;
                    case "level":
                        InstanceManager.getMainForm().level = int.Parse(inputCMD);
                        InstanceManager.getSound().stopMusic();
                        InstanceManager.getSound().playMusic(InstanceManager.getMainForm().level);
                        Console.WriteLine(cmdResponse + "Set level to: " + inputCMD);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    case "end":
                        InstanceManager.getMainForm().endGame();
                        Console.WriteLine(cmdResponse + "Ended Game.");
                        break;
                    case "clear":
                        if (inputCMD == "game")
                        {
                            InstanceManager.getPlayer().placedrect = new Rectangle[2];
                            Console.WriteLine(cmdResponse + "Cleared board.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine(cmdResponse + "Cleared screen.");
                        }
                        break;
                    default:
                        Console.WriteLine(cmdResponse + "Unknown command: \'" + actualCmd + "\', type help for a list of commands.");
                        break;
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            if (!enabled)
                return;

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

using System;
using System.Drawing;
using TetrisGame.Main;
using TetrisGame.Main.Player;

namespace TetrisGame.Other
{
    /*
     * 
     * This class makes static references to all other classes in game.
     * This makes it incredibly easy to access any class and cleans
     * up a lot of code.
     * 
     */
    public class InstanceManager
    {
        private static Form1 grabForm;
        private static SFX sound;
        private static Rotate rotate;
        private static Prediction predict;
        private static RowCheck rowCheck;
        private static GamepadSupport gamepad;
        private static Graphics gameGraphics;
        private static Player ply;
        private static NextShape nextShape;
        private static Move move;
        private static Random rand;
        private static RotateCheck rotCheck;
        private static GameSettings gameSettings;

        public InstanceManager(Form1 form)
        {
            grabForm = form;
            sound = new SFX();
            rand = new Random();
            predict = new Prediction();
            rowCheck = new RowCheck();
            gamepad = new GamepadSupport();
            rotate = new Rotate();
            nextShape = new NextShape();
            move = new Move();
            rotCheck = new RotateCheck();
            ply = new Player();
            gameSettings = new GameSettings();
            getGameGraphics();
        }

        public static Graphics getGameGraphics()
        {
            if (gameGraphics == null)
                grabForm.gameBoard.Invalidate();

            return gameGraphics;
        }

        public static Graphics setGameGraphics(Graphics g)
        {
            return gameGraphics = g;
        }

        public static Random getRandom()
        {
            return rand;
        }

        public static GameSettings getGameSettings()
        {
            return gameSettings;
        }

        public static Move getMove()
        {
            return move;
        }

        public static NextShape getNextShape()
        {
            return nextShape;
        }

        public static RotateCheck getRotateCheck()
        {
            return rotCheck;
        }

        public static Player getPlayer()
        {
            return ply;
        }

        public static RowCheck resetRow()
        {
            return rowCheck = new RowCheck();
        }

        public static SFX getSound()
        {
            return sound;
        }

        public static Prediction getPredict()
        {
            return predict;
        }

        public static RowCheck getRowCheck()
        {
            return rowCheck;
        }

        public static GamepadSupport getGamepad()
        {
            return gamepad;
        }

        public static Rotate getRotate()
        {
            return rotate;
        }

        public static Form1 getMainForm()
        {
            return grabForm;
        }

    }
}

using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame
{
    class GamepadSupport
    {
        public Controller controller;
        public Gamepad gamepad;
        public bool connected = false;
        public int deadband = 2500;
        public System.Windows.Point leftThumb, rightThumb = new System.Windows.Point(0, 0);
        public float leftTrigger, rightTrigger;

        public GamepadSupport()
        {
            controller = new Controller(UserIndex.One);
            connected = controller.IsConnected;
        }

        //update controller input
        public void ControllerUpdate()
        {
            if (!connected)
                return;

            gamepad = controller.GetState().Gamepad;

            leftThumb.X = (Math.Abs((float)gamepad.LeftThumbX) < deadband) ? 0 : (float)gamepad.LeftThumbX / short.MinValue * -100;
            leftThumb.Y = (Math.Abs((float)gamepad.LeftThumbY) < deadband) ? 0 : (float)gamepad.LeftThumbY / short.MaxValue * 100;
            rightThumb.Y = (Math.Abs((float)gamepad.RightThumbX) < deadband) ? 0 : (float)gamepad.RightThumbX / short.MaxValue * 100;
            rightThumb.X = (Math.Abs((float)gamepad.RightThumbY) < deadband) ? 0 : (float)gamepad.RightThumbY / short.MaxValue * 100;


            leftTrigger = gamepad.LeftTrigger;
            rightTrigger = gamepad.RightTrigger;
        }

        public bool isConnected()
        {
            return connected;
        }

    }
}

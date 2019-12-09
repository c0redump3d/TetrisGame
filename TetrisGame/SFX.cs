using Microsoft.DirectX.DirectSound;
using System.Windows.Forms;

namespace TetrisGame
{

    /// <summary>
    /// This class is in charge of playing sound effects using DirectSound.
    /// Using this though does add an requirement, that being that the user
    /// must have DirectX installed on their system before playing the game.
    /// </summary>
    class SFX : Form
    {
        public Microsoft.DirectX.DirectSound.Buffer soundBuffer;
        public Microsoft.DirectX.DirectSound.Buffer sfxBuffer;
        public Microsoft.DirectX.DirectSound.Buffer playerBuffer;

        public void playFall()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.fall, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.fall, dev);
            sound.Stop();
            sound.Volume = Form1.isMuted() ? -10000 : -1000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playLevelUp()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.lvlup, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.lvlup, dev);
            sound.Stop();
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playHardDrop()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.harddrop, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.harddrop, dev);
            sound.Stop();
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playClear(ref int lines)
        {
            if (lines == 10 || lines == 20 || lines == 30
                || lines == 40 || lines == 50 || lines == 60
                || lines == 70 || lines == 80 || lines == 90)
                return;

            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.clear, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.clear, dev);
            sound.Stop();
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playRotate()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.rotate, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.rotate, dev);
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playMove()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.move, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.move, dev);
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
        }

        public void playMusic(ref bool stop)
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            soundBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.tetris_loop, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.tetris_loop, dev);
            sound.Volume = Form1.isMuted() ? -10000 : -3000;

            if (!stop)
                sound.Play(0, BufferPlayFlags.Looping);
            else
                sound.Stop();

        }

    }
}

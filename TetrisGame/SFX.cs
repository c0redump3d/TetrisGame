using Microsoft.DirectX.DirectSound;
using System;
using System.IO;
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
            Debug.debugMessage("Playing sound effect: Fall", 1);
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
            Debug.debugMessage("Playing sound effect: LevelUp", 1);
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
            Debug.debugMessage("Playing sound effect: HardDrop", 1);
        }

        public void playClear(int line)
        {
            
            if (line == 2)
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.linedouble, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.linedouble, dev);
                sound.Stop();
                sound.Volume = Form1.isMuted() ? -10000 : -3000;
                sound.Play(0, BufferPlayFlags.Default);
            }
            else if (line == 3)
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.linetriple, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.linetriple, dev);
                sound.Stop();
                sound.Volume = Form1.isMuted() ? -10000 : -3000;
                sound.Play(0, BufferPlayFlags.Default);
            }
            else if (line >= 4)
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.lineperfect, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.lineperfect, dev);
                sound.Stop();
                sound.Volume = Form1.isMuted() ? -10000 : -3000;
                sound.Play(0, BufferPlayFlags.Default);
            }
            else
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                sfxBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.clear, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.clear, dev);
                sound.Stop();
                sound.Volume = Form1.isMuted() ? -10000 : -3000;
                sound.Play(0, BufferPlayFlags.Default);
            }
            Debug.debugMessage("Playing sound effect: Clear", 1);
        }

        public void playRotate()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.rotate, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.rotate, dev);
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
            Debug.debugMessage("Playing sound effect: Rotate", 1);
        }

        public void playMove()
        {
            var dev = new Device();
            dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
            playerBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.move, dev);
            SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.move, dev);
            sound.Volume = Form1.isMuted() ? -10000 : -3000;
            sound.Play(0, BufferPlayFlags.Default);
            Debug.debugMessage("Playing sound effect: Move", 1);
        }

        public void playMusic(ref bool stop, int level)
        {
            if (level < 5)
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                soundBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.musicmain, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.musicmain, dev);
                sound.Volume = Form1.isMuted() ? -10000 : -3000;

                if (!stop)
                    sound.Play(0, BufferPlayFlags.Looping);
                else
                    sound.Stop();
            }else if(level < 8)
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                soundBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.musiclvl5, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.musiclvl5, dev);
                sound.Volume = Form1.isMuted() ? -10000 : -3000;

                if (!stop)
                    sound.Play(0, BufferPlayFlags.Looping);
                else
                    sound.Stop();
            }
            else
            {
                var dev = new Device();
                dev.SetCooperativeLevel(this, CooperativeLevel.Normal);
                soundBuffer = new Microsoft.DirectX.DirectSound.Buffer(Properties.Resources.musiclvl8, dev);
                SecondaryBuffer sound = new SecondaryBuffer(Properties.Resources.musiclvl8, dev);
                sound.Volume = Form1.isMuted() ? -10000 : -3000;

                if (!stop)
                    sound.Play(0, BufferPlayFlags.Looping);
                else
                    sound.Stop();
            }
            Debug.debugMessage("Playing sound effect: Music", 1);
        }
    }
}

using NAudio.Wave;
using System;
using System.IO;
using TetrisGame.Main;
using TetrisGame.Sound;

namespace TetrisGame
{

    /// <summary>
    /// This class is in charge of playing sound effects using NAudio.
    /// Since we are no longer using DirectSound, it no longer has any
    /// dependencies.
    /// </summary>
    public class SFX
    {
        private WaveFileReader wave = null;
        private DirectSoundOut outputMoveAndRotate = null; // gives outputSFX more time to dispose of other soundeffects
        private DirectSoundOut outputSFX = null;
        private DirectSoundOut outputMusic = null;

        public SFX()
        {
            outputMusic = new DirectSoundOut();
        }

        private void playSound(Stream sound)
        {
            if (AudioSettings.VOL == 0)
                return;

            wave = new WaveFileReader(sound);
            var reduce = new BlockAlignReductionStream(wave);
            var provider = new Wave16ToFloatProvider(reduce);
            provider.Volume = AudioSettings.VOL / 200F;
            outputSFX = new DirectSoundOut();
            outputSFX.PlaybackStopped += new EventHandler<StoppedEventArgs>(playBackStopped);
            outputSFX.Init(provider);
            outputSFX.Play();
        }

        private void playMoveRotate(Stream sound)
        {
            if (AudioSettings.VOL == 0)
                return;

            wave = new WaveFileReader(sound);
            var reduce = new BlockAlignReductionStream(wave);
            var provider = new Wave16ToFloatProvider(reduce);
            provider.Volume = AudioSettings.VOL / 200F;
            outputMoveAndRotate = new DirectSoundOut();
            outputMoveAndRotate.PlaybackStopped += new EventHandler<StoppedEventArgs>(playBackStoppedMoveRotate);
            outputMoveAndRotate.Init(provider);
            outputMoveAndRotate.Play();
        }

        private void playMusic(Stream music)
        {
            if (AudioSettings.VOL == 0 || AudioSettings.MUSIC == 0)
                return;

            wave = new WaveFileReader(music);
            var reduce = new BlockAlignReductionStream(wave);
            LoopStream loop = new LoopStream(reduce);
            var provider = new Wave16ToFloatProvider(loop);
            provider.Volume = AudioSettings.VOL / 200F;
            outputMusic = new DirectSoundOut();
            outputMusic.PlaybackStopped += new EventHandler<StoppedEventArgs>(playBackStoppedMusic);
            outputMusic.Init(provider);
            outputMusic.Play();
        }
        private void playBackStoppedMoveRotate(object stream, StoppedEventArgs e)
        {
            if (outputMoveAndRotate.PlaybackState == PlaybackState.Stopped)
            {
                outputMoveAndRotate.Dispose();
                Debug.debugMessage("disposing moverotatesfx...", 1, false);
            }
        }

        private void playBackStopped(object stream, StoppedEventArgs e)
        {
            if(outputSFX.PlaybackState == PlaybackState.Stopped)
            {
                outputSFX.Dispose();
                Debug.debugMessage("disposing soundFX...", 1, false);
            }
        }

        private void playBackStoppedMusic(object stream, StoppedEventArgs e)
        {
            if (outputMusic.PlaybackState == PlaybackState.Stopped)
            {
                outputMusic.Dispose();
            }
        }

        public void playFall()
        {
            playSound(Properties.Resources.fall);
        }

        public void playLevelUp()
        {
            playSound(Properties.Resources.lvlup);
            Debug.debugMessage("Playing sound effect: LevelUp", 1);
        }

        public void playHardDrop()
        {
            playSound(Properties.Resources.harddrop);
            Debug.debugMessage("Playing sound effect: HardDrop", 1);
        }

        public void playClear(int line)
        {
            if (line == 2)
            {
                playSound(Properties.Resources.linedouble);
            }
            else if (line == 3)
            {
                playSound(Properties.Resources.linetriple);
            }
            else if (line >= 4)
            {
                playSound(Properties.Resources.lineperfect);
            }
            else
            {
                playSound(Properties.Resources.clear);
            }
            Debug.debugMessage("Playing sound effect: Clear", 1);
        }

        public void playRotate()
        {
            playMoveRotate(Properties.Resources.rotate);
            Debug.debugMessage("Playing sound effect: Rotate", 1);
        }

        public void playMove()
        {
            playMoveRotate(Properties.Resources.move);
            Debug.debugMessage("Playing sound effect: Move", 1);
        }

        public void stopMusic()
        {
            outputMusic.Stop();
            outputMusic.Dispose();
        }

        public void playMusic(int level)
        {
            if (level < 5)
            {
                playMusic(Properties.Resources.musicmain);
            }
            else if (level < 8)
            {
                playMusic(Properties.Resources.musiclvl5);
            }
            else
            {
                playMusic(Properties.Resources.musiclvl8);
            }
            Debug.debugMessage("Playing sound effect: Music", 1);
        }
    }
}

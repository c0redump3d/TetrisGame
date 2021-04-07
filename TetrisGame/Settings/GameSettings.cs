using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TetrisGame.Main
{

    public class GameSettings
    {
        private string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); // appdata location

        public GameSettings()
        {
            try
            {
                if(!createSettingsFile())
                    LoadSettings();
            }catch(Exception ex)
            {
                MessageBox.Show("Unable to create/load settings file.\n" + ex.Message);
            }

        }

        private bool createSettingsFile()
        {
            if (File.Exists(appData + @"\TetrisGame\settings.tet"))
                return false;

            new MovementKeys(Keys.A, Keys.D, Keys.S, Keys.X, Keys.C);
            new AudioSettings(50, 1);

            if (!Directory.Exists(appData + @"\TetrisGame\"))
                Directory.CreateDirectory(appData + @"\TetrisGame\");

            var settingsFile = File.Create(appData + @"\TetrisGame\settings.tet");

            settingsFile.Close();

            saveSettings();

            return true;
        }

        public void saveSettings()
        {
            using(StreamWriter sw = new StreamWriter(appData + @"\TetrisGame\settings.tet"))
            {
                foreach(KeyValuePair<string, Keys> con in MovementKeys.CONTROLS)
                {
                    sw.WriteLine(con.Key + ":" + con.Value);
                }
                foreach (KeyValuePair<string, int> audio in AudioSettings.AUDIO)
                {
                    sw.WriteLine(audio.Key + ":" + audio.Value);
                }
            }
        }

        private void LoadSettings()
        {
            //Reads settings file and sets keys and audio

            int count = 0;
            Dictionary<string, Keys> keys = new Dictionary<string, Keys>();
            Dictionary<string, int> audio = new Dictionary<string, int>();
            using (StreamReader sr = new StreamReader(appData + @"\TetrisGame\settings.tet"))
            {
                string val;
                while((val = sr.ReadLine()) != null)
                {
                    string[] data = val.Split(':');
                    if (count < 5)
                    {
                        keys.Add(data[0], (Keys)Enum.Parse(typeof(Keys), data[1]));
                        count++;
                    }
                    else
                    {
                        audio.Add(data[0], int.Parse(data[1]));
                    }
                }
            }

            new MovementKeys(keys["Left"], keys["Right"], keys["Down"], keys["Rotate"], keys["Forcedrop"]);
            new AudioSettings(audio["Volume"], audio["Music"]);

        }

    }

    public struct MovementKeys
    {
        public static Keys LEFT;
        public static Keys RIGHT;
        public static Keys DOWN;
        public static Keys ROTATE;
        public static Keys FORCEDROP;
        public static Dictionary<string, Keys> CONTROLS = new Dictionary<string, Keys>();

        public MovementKeys(Keys left, Keys right, Keys down, Keys rotate, Keys forcedrop)
        {
            LEFT = left;
            RIGHT = right;
            DOWN = down;
            ROTATE = rotate;
            FORCEDROP = forcedrop;
            createDic();
        }

        private void createDic()
        {
            CONTROLS.Clear();
            CONTROLS.Add("Left", LEFT);
            CONTROLS.Add("Right", RIGHT);
            CONTROLS.Add("Down", DOWN);
            CONTROLS.Add("Rotate", ROTATE);
            CONTROLS.Add("Forcedrop", FORCEDROP);
        }
    }

    public struct AudioSettings
    {
        public static int VOL;
        public static int MUSIC;
        public static Dictionary<string, int> AUDIO = new Dictionary<string, int>();

        public AudioSettings(int volume, int music)
        {
            VOL = volume;
            MUSIC = music;
            createDic();
        }

        private void createDic()
        {
            AUDIO.Clear();
            AUDIO.Add("Volume", VOL);
            AUDIO.Add("Music", MUSIC);
        }
    }
}

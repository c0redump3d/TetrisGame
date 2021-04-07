using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TetrisGame.Main;
using TetrisGame.Other;

namespace TetrisGame.Settings
{
    public partial class ChangeSettingsForm : Form
    {

        string[] currentKeys = new string[5];
        int[] currentAudio = new int[2];
        bool keysChanged = false;
        bool audioChanged = false;
        Font hoogfont12;
        Font hoogfont18;
        Font hoogfont24;
        Dictionary<string, Keys> keys = new Dictionary<string, Keys>();
        Dictionary<string, int> audio = new Dictionary<string, int>();

        public ChangeSettingsForm()
        {
            InitializeComponent();

            hoogfont12 = new Font(InstanceManager.getMainForm().fonts.Families[0], 10.0F); // setup 18pt font
            hoogfont18 = new Font(InstanceManager.getMainForm().fonts.Families[0], 18.0F); // setup 18pt font
            hoogfont24 = new Font(InstanceManager.getMainForm().fonts.Families[0], 24.0F); // setup 24pt font

            foreach (var control in Controls)
            {
                Label lab;
                if (control.GetType() == typeof(Label))
                {
                    lab = (Label)control;
                    lab.Font = hoogfont24;
                }
            }

            foreach (var control in Controls)
            {
                Button but;
                if (control.GetType() == typeof(Button))
                {
                    but = (Button)control;
                    but.Font = hoogfont18;
                }
            }

            this.BackgroundImage = BlockUtils.SetOpacity(Properties.Resources.settingsback, 0.2F);

        }

        private void ChangeSettingsForm_Load(object sender, EventArgs e)
        {
            this.Icon = Properties.Resources.tetrisico; // set icon
            readSettings();
            leftButton.Text = currentKeys[0];
            rightButton.Text = currentKeys[1];
            downButton.Text = currentKeys[2];
            rotateButton.Text = currentKeys[3];
            forceDropButton.Text = currentKeys[4];
        }

        private void ChangeSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (keysChanged)
                new MovementKeys(keys["Left"], keys["Right"], keys["Down"], keys["Rotate"], keys["Forcedrop"]);
            if (audioChanged)
                new AudioSettings(audio["Volume"], audio["Music"]);

            if (keysChanged || audioChanged)
            {
                InstanceManager.getGameSettings().saveSettings();
                Debug.debugMessage("Saving settings file...", 1, false);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = ((Button)sender);

            if (button == musicButton)
            {
                if (currentAudio[1] == 1)
                    currentAudio[1] = 0;
                else
                    currentAudio[1] = 1;

                audioChanged = true;
                musicButton.Text = currentAudio[1] == 1 ? "On" : "Off";
                updateDictionaries();
                return;
            }

            disableAllButtons();
            button.Focus();
            button.Text = "Press a key";
        }

        private void button_KeyPress(object sender, PreviewKeyDownEventArgs e)
        {
            Button button = ((Button)sender);

            char keyChar = new KeysConverter().ConvertToString(e.KeyCode).ToCharArray()[0];

            if (button.Text == "Press a key")
            {
                if (isButtonBound(keyChar))
                {
                    MessageBox.Show("Button already bound!");
                    button.Enabled = false;
                    button.Enabled = true;
                    button.Text = currentKeys[button.TabIndex - 1];
                    enableAllButtons();
                    return;
                }

                button.Text = "" + char.ToUpper(keyChar);
                currentKeys[button.TabIndex - 1] = "" + char.ToUpper(keyChar);
                keysChanged = true;
                enableAllButtons();
            }

            updateDictionaries();
        }

        private void audioTrackBar_Scroll(object sender, EventArgs e)
        {
            audioLabel.Text = "Audio (" + (((TrackBar)sender).Value * 10) + "%)";
            currentAudio[0] = (((TrackBar)sender).Value * 10);

            audioChanged = true;
            updateDictionaries();
        }

        private void disableAllButtons()
        {
            foreach(var control in Controls)
            {
                Button but;
                if (control.GetType() == typeof(Button))
                {
                    but = (Button)control;
                    if (but.Focused)
                    {
                        but.Font = hoogfont12;
                        continue;
                    }
                    but.Enabled = false;
                }
            }
        }

        private void enableAllButtons()
        {
            foreach (var control in Controls)
            {
                Button but;
                if (control.GetType() == typeof(Button))
                {
                    but = (Button)control;
                    but.Font = hoogfont18;
                    but.Enabled = true;
                }
            }
        }

        private void readSettings()
        {
            currentKeys[0] = MovementKeys.LEFT.ToString();
            currentKeys[1] = MovementKeys.RIGHT.ToString();
            currentKeys[2] = MovementKeys.DOWN.ToString();
            currentKeys[3] = MovementKeys.ROTATE.ToString();
            currentKeys[4] = MovementKeys.FORCEDROP.ToString();
            currentAudio[0] = AudioSettings.VOL;
            currentAudio[1] = AudioSettings.MUSIC;
            musicButton.Text = currentAudio[1] == 1 ? "On" : "Off";
            audioTrackBar.Value = currentAudio[0] / 10;
            audioLabel.Text = "Audio (" + (audioTrackBar.Value * 10) + "%)";
        }

        private bool isButtonBound(char key)
        {
            foreach (string check in currentKeys)
            {
                if (char.ToUpper(key) == char.Parse(check))
                {
                    return true;
                }
            }

            return false;
        }

        private void updateDictionaries()
        {
            keys.Clear();
            audio.Clear();
            keys.Add("Left", (Keys)Enum.Parse(typeof(Keys), currentKeys[0]));
            keys.Add("Right", (Keys)Enum.Parse(typeof(Keys), currentKeys[1]));
            keys.Add("Down", (Keys)Enum.Parse(typeof(Keys), currentKeys[2]));
            keys.Add("Rotate", (Keys)Enum.Parse(typeof(Keys), currentKeys[3]));
            keys.Add("Forcedrop", (Keys)Enum.Parse(typeof(Keys), currentKeys[4]));
            audio.Add("Volume", currentAudio[0]);
            audio.Add("Music", currentAudio[1]);
        }

    }
}

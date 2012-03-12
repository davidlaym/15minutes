using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _15minutes
{
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
            ReadOptions();
        }

        private void ReadOptions()
        {
            OnTop = Properties.Settings.Default.OnTopAllways;
            OnTopRunning = Properties.Settings.Default.OnTopRunning;
            SoundTickTack = Properties.Settings.Default.SoundTickTack;
            SoundAlarm = Properties.Settings.Default.SoundAlarm;
        }

        public bool OnTop { get { return chkOnTop.Checked; } set { chkOnTop.Checked = value; } }
        public bool OnTopRunning { get { return chkOnTopRunning.Checked; } set { chkOnTopRunning.Checked = value; } }
        public bool SoundTickTack { get { return chkSoundTickTack.Checked; } set { chkSoundTickTack.Checked = value; } }
        public bool SoundAlarm { get { return chkSoundAlarm.Checked; } set { chkSoundAlarm.Checked = value; } }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            Properties.Settings.Default.OnTopAllways = OnTop;
            Properties.Settings.Default.OnTopRunning = OnTopRunning;
            Properties.Settings.Default.SoundAlarm = SoundAlarm;
            Properties.Settings.Default.SoundTickTack = SoundTickTack;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

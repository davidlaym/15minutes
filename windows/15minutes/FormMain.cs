﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Media;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace _15minutes
{
    public enum State
    {
        SettingTime, Running, Paused, Finished
    }

    public partial class FormMain : Form
    {
        TimeSpan DefaultTotalTime = new TimeSpan(0, 15, 0);
        TimeSpan TotalTime;
        TimeSpan RemainingTime;
        State CurrentState;
        DateTime StartTime;
        int FlashCountRemaining;
        private NotifyIcon notifyIcon;
        Color BgColor = System.Drawing.Color.White;
        private SoundPlayer ticks = new SoundPlayer(Properties.Resources.ticking);
        private SoundPlayer alarm = new SoundPlayer(Properties.Resources.alarm);

        public void SetTime(int hours, int minutes, int seconds)
        {
            SetTime(new TimeSpan(hours, minutes, seconds));
        }

        public void SetTime(TimeSpan time)
        {
            TotalTime = time;
            DefaultTotalTime = time;
            this.Invalidate();
        }

        public FormMain()
        {
            InitializeComponent();

            this.label5min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label5min.MouseLeave += new EventHandler(label_MouseLeave);
            this.label15min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label15min.MouseLeave += new EventHandler(label_MouseLeave);
            this.label25min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label25min.MouseLeave += new EventHandler(label_MouseLeave);
            this.label45min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label45min.MouseLeave += new EventHandler(label_MouseLeave);
            this.labelWebSite.MouseEnter += new EventHandler(label_MouseEnter);
            this.labelWebSite.MouseLeave += new EventHandler(label_MouseLeave);
            this.labelOther.MouseEnter += new EventHandler(label_MouseEnter);
            this.labelOther.MouseLeave += new EventHandler(label_MouseLeave);
            this.DoubleBuffered = true;

            this.toolTip1 = new ToolTip(this.components);
            toolTip1.SetToolTip(labelWebSite, "http://blog.kowalczyk.info/software/15minutes/");
            var ass = Assembly.GetExecutingAssembly();
            //string[] names = ass.GetManifestResourceNames();
            Stream strm = ass.GetManifestResourceStream("_15minutes.HourGlass.ico");
            this.Icon = new Icon(strm);

            notifyIcon = new NotifyIcon(this.components);
            notifyIcon.Icon = this.Icon;
            notifyIcon.DoubleClick += new EventHandler(NotifyIcon_ClickOrDoubleClick);
            notifyIcon.Click += new EventHandler(NotifyIcon_ClickOrDoubleClick);
            SwitchToSettingTimeState();
        }


        public bool IsWin7OrGreater()
        {
            System.OperatingSystem osInfo = System.Environment.OSVersion;
            if (osInfo.Platform != System.PlatformID.Win32NT)
                return false;
            if (osInfo.Version.Major >= 6 && osInfo.Version.Minor >= 1)
                return true;
            return false;
        }

        public void FormMain_Resize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                SetResidentMode(true, true);
            }
        }

        public void SetResidentMode(bool resident, bool activate)
        {
            if (resident)
            {
                if (!IsWin7OrGreater())
                {
                    Hide();
                    notifyIcon.Visible = true;
                    ShowInTaskbar = false;
                }
            }
            else
            {
                if (!IsWin7OrGreater())
                {
                    notifyIcon.Visible = false;
                    ShowInTaskbar = true;
                }

                this.Show();
                this.Size = new Size(298, 152);
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                if (activate)
                {
                    this.Activate();
                    this.Focus();
                }
                this.TopMost = true;
                this.BringToFront();
                this.TopMost = false;
            }
        }

        protected void NotifyIcon_ClickOrDoubleClick(Object sender, System.EventArgs e)
        {
            SetResidentMode(false, true);
        }

        protected void SetLabelsVisible(bool visible)
        {
            label5min.Visible = visible;
            label15min.Visible = visible;
            label25min.Visible = visible;
            label45min.Visible = visible;
            labelOther.Visible = visible;
            labelWebSite.Visible = visible;
            lblOptions.Visible = visible;
        }

        public void SetBackColor(Color color)
        {
            this.BackColor = color;
            label5min.BackColor = color;
            label15min.BackColor = color;
            label25min.BackColor = color;
            label45min.BackColor = color;
            labelOther.BackColor = color;
            labelWebSite.BackColor = color;
            lblOptions.BackColor = color;
        }

        public void SwitchToSettingTimeState()
        {
            CurrentState = State.SettingTime;

            TotalTime = DefaultTotalTime;
            timer.Stop();

            SetLabelsVisible(true);
            buttonStartOk.Text = "Start";
            buttonStartOk.Visible = true;

            buttonPauseResume.Visible = false;
            buttonStop.Visible = false;
            ticks.Stop();
            alarm.Stop();
            SetBackColor(this.BgColor);
            this.Invalidate();
        }

        public void SwitchToRunningState()
        {
            CurrentState = State.Running;

            SetLabelsVisible(false);
            SetBackColor(Color.FromArgb(0xfc, 0xff, 0xa2));
            buttonStartOk.Visible = false;

            buttonPauseResume.Visible = true;
            buttonPauseResume.Text = "Pause";

            buttonStop.Visible = true;

            StartTime = DateTime.Now;
            CalcRemaining();
            timer.Interval = 1000;
            timer.Start();
            if(Properties.Settings.Default.SoundTickTack)
            {
                ticks.PlayLooping();
            }
            
            this.Invalidate();
        }

        public void SwitchToPausedState()
        {
            CalcRemaining();
            TotalTime = RemainingTime;

            CurrentState = State.Paused;
            this.BackColor = Color.White;

            SetLabelsVisible(false);

            buttonStartOk.Visible = false;

            buttonPauseResume.Visible = true;
            buttonStop.Visible = true;

            timer.Stop();
            ticks.Stop();
            buttonPauseResume.Text = "Resume";
            this.Invalidate();
        }

        public void SwitchToFinishedState()
        {
            CurrentState = State.Finished;

            SetLabelsVisible(false);

            buttonStartOk.Visible = true;
            buttonStartOk.Text = "Ok";

            buttonPauseResume.Visible = false;
            buttonStop.Visible = false;

            FlashCountRemaining = 20;
            timer.Stop();
            ticks.Stop();
            timer.Interval = 200;
            timer.Start();
            if(Properties.Settings.Default.SoundAlarm)
                alarm.Play();

            SetResidentMode(false, false);
            this.Invalidate();
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = System.Drawing.Color.Yellow;
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            Control c = sender as Control;
            c.BackColor = this.BgColor;
        }

        private void label5min_Click(object sender, EventArgs e)
        {
            SetTime(0, 5, 0);
        }

        private void label15min_Click(object sender, EventArgs e)
        {
            SetTime(0, 15, 0);
        }

        private void label25min_Click(object sender, EventArgs e)
        {
            SetTime(0, 25, 0);
        }

        private void label45min_Click(object sender, EventArgs e)
        {
            SetTime(0, 45, 0);
        }

        private void labelOther_Click(object sender, EventArgs e)
        {
            using (DurationDialog d = new DurationDialog())
            {
                d.Value = (int)DefaultTotalTime.TotalMinutes;

                if (d.ShowDialog(this) != DialogResult.OK)
                    return;

                SetTime(TimeSpan.FromMinutes(d.Value));
            }
        }

        private void buttonStartOk_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.SettingTime)
            {
                SwitchToRunningState();
            }
            else
            {
                Debug.Assert(CurrentState == State.Finished);
                SwitchToSettingTimeState();
            }
        }

        private bool CalcRemaining()
        {
            DateTime curr = DateTime.Now;
            TimeSpan passed = curr - StartTime;
            if (passed > TotalTime)
                RemainingTime = new TimeSpan(0, 0, 0);
            else
                RemainingTime = TotalTime - passed;
            return passed > TotalTime;
        }

        private string GetTimeString()
        {
            TimeSpan timeToShow = RemainingTime;
            if (CurrentState == State.SettingTime)
                timeToShow = TotalTime;
            string s = String.Format("{0:D2} : {1:D2}", timeToShow.Minutes + 60 * timeToShow.Hours, timeToShow.Seconds);
            return s;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (CurrentState == State.Running)
            {
                bool shouldStop = CalcRemaining();
                if (shouldStop)
                    SwitchToFinishedState();
                else if (notifyIcon.Visible)
                    notifyIcon.Text = GetTimeString();
            }
            else
            {
                Debug.Assert(CurrentState == State.Finished);
                if (this.BackColor == Color.White)
                {
                    this.BackColor = Color.Red;
                }
                else
                {
                    this.BackColor = Color.White;
                    FlashCountRemaining -= 1;
                    if (FlashCountRemaining <= 0)
                        SwitchToSettingTimeState();
                }
            }
            this.Invalidate(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            CheckOnTop();
            using (var font = new Font("Segoe UI", 38, FontStyle.Bold))
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = this.ClientRectangle;
                int dx = rect.Width;
                int dy = rect.Height - buttonStartOk.Height;
                string s = this.GetTimeString();
                SizeF strSize = g.MeasureString(s, font);

                float x = (dx - strSize.Width) / 2;
                float y = (dy - strSize.Height) / 2;
                PointF pos = new PointF(x, y);
                g.DrawString(s, font, Brushes.Black, pos);
            }
            base.OnPaint(e);
        }

        private void CheckOnTop()
        {
            if(Properties.Settings.Default.OnTopAllways)
                this.TopMost = true;
            else if (Properties.Settings.Default.OnTopRunning && CurrentState == State.Running)
                this.TopMost = true;
            else
                this.TopMost = false;

        }

        private void buttonPauseResume_Click(object sender, EventArgs e)
        {
            if (CurrentState == State.Running)
            {
                SwitchToPausedState();
            }
            else
            {
                Debug.Assert(CurrentState == State.Paused);
                SwitchToRunningState();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            SwitchToSettingTimeState();
        }

        private void labelWebSite_Click(object sender, EventArgs e)
        {
            // this is a bit.ly link to:
            // "http://blog.kowalczyk.info/software/15minutes/index.html?from15minutes"
            Process.Start("http://bit.ly/eElvh");
        }

        private void lblOptions_Click(object sender, EventArgs e)
        {
            using (var dlg = new OptionsDialog())
            {
                dlg.ShowDialog(this);
            }            
        }

      


        
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private NotifyIcon notifyIcon;

        public void SetTime(int hours, int minutes, int seconds)
        {
            TotalTime = new TimeSpan(hours, minutes, seconds);
            DefaultTotalTime = new TimeSpan(hours, minutes, seconds);
            this.Invalidate();
        }

        public FormMain()
        {
            InitializeComponent();
            this.Resize += new EventHandler(FormMain_Resize);

            this.label5min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label5min.MouseLeave += new EventHandler(label_MouseLeave);
            this.label15min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label15min.MouseLeave += new EventHandler(label_MouseLeave);
            this.label30min.MouseEnter += new EventHandler(label_MouseEnter);
            this.label30min.MouseLeave += new EventHandler(label_MouseLeave);
            this.labelWebSite.MouseEnter += new EventHandler(label_MouseEnter);
            this.labelWebSite.MouseLeave += new EventHandler(label_MouseLeave);
            this.DoubleBuffered = true;

            notifyIcon = new NotifyIcon(this.components);
            notifyIcon.Icon = this.Icon;
            notifyIcon.DoubleClick += new EventHandler(NotifyIcon_ClickOrDoubleClick);
            notifyIcon.Click += new EventHandler(NotifyIcon_ClickOrDoubleClick);
            MyLayout();
            SwitchToSettingTimeState();
        }

        // we have to manually layout things because layout generated in
        // the GUI designer is different on XP vs. Windows 7
        protected void MyLayout()
        {
            this.SuspendLayout();
            Rectangle cr = this.ClientRectangle;
            int dx = cr.Width;
            int dy = cr.Height;
            int buttonDy = this.buttonStartOk.Height;
            Debug.Assert(buttonDy == this.buttonPauseResume.Height);
            Debug.Assert(buttonDy == this.buttonStop.Height);
            this.buttonStartOk.Dock = DockStyle.None;
            this.buttonStartOk.Location = new Point(0, dy - buttonDy);
            this.buttonStartOk.Size = new Size(dx, buttonDy);

            this.buttonStop.Location = new Point(0, dy - buttonDy);
            this.buttonStop.Size = new Size(dx / 2, buttonDy);

            this.buttonPauseResume.Location = new Point(dx / 2, dy - buttonDy);
            this.buttonPauseResume.Size = new Size(dx / 2, buttonDy);

            int txtDx = this.labelWebSite.Width;
            int txtDy = this.labelWebSite.Height;
            Debug.Assert(txtDy == this.label5min.Height);
            Debug.Assert(txtDy == this.label15min.Height);
            Debug.Assert(txtDy == this.label30min.Height);

            this.labelWebSite.Location = new Point(dx - txtDx, dy - buttonDy - txtDy - 2);

            txtDx = this.label5min.Width;
            this.label5min.Location = new Point(dx - txtDx, 4);

            txtDx = this.label15min.Width;
            this.label15min.Location = new Point(dx - txtDx, 4 + txtDy + 2);

            txtDx = this.label30min.Width;
            this.label30min.Location = new Point(dx - txtDx, 4 + txtDy + 2 + txtDy + 2);

            this.ResumeLayout();
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
                SetResidentMode(true);
            }
        }

        public void SetResidentMode(bool resident)
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
                this.Activate();
                this.Focus();
                this.BringToFront();
            }
        }

        protected void NotifyIcon_ClickOrDoubleClick(Object sender, System.EventArgs e)
        {
            SetResidentMode(false);
        }

        protected void SetLabelsVisible(bool visible)
        {
            label5min.Visible = visible;
            label15min.Visible = visible;
            label30min.Visible = visible;
            labelWebSite.Visible = visible;
        }

        public void SwitchToSettingTimeState()
        {
            CurrentState = State.SettingTime;

            TotalTime = DefaultTotalTime;
            timer.Stop();

            SetLabelsVisible(true);
            buttonStartOk.Text = "Start countdown";
            buttonStartOk.Visible = true;

            buttonPauseResume.Visible = false;
            buttonStop.Visible = false;

            this.BackColor = SystemColors.Control;
            this.Invalidate();
        }

        public void SwitchToRunningState()
        {
            CurrentState = State.Running;

            SetLabelsVisible(false);

            buttonStartOk.Visible = false;

            buttonPauseResume.Visible = true;
            buttonPauseResume.Text = "Pause";

            buttonStop.Visible = true;

            StartTime = DateTime.Now;
            CalcRemaining();
            timer.Interval = 1000;
            timer.Start();
            this.Invalidate();
        }

        public void SwitchToPausedState()
        {
            CalcRemaining();
            TotalTime = RemainingTime;

            CurrentState = State.Paused;

            SetLabelsVisible(false);

            buttonStartOk.Visible = false;

            buttonPauseResume.Visible = true;
            buttonStop.Visible = true;

            timer.Stop();
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

            timer.Stop();
            timer.Interval = 200;
            timer.Start();

            SetResidentMode(false);
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
            c.BackColor = System.Drawing.SystemColors.Control;
        }

        private void label5min_Click(object sender, EventArgs e)
        {
            SetTime(0, 5, 0);
        }

        private void label15min_Click(object sender, EventArgs e)
        {
            SetTime(0, 15, 0);
        }

        private void label30min_Click(object sender, EventArgs e)
        {
            SetTime(0, 30, 0);
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
            string s = String.Format("{0:D2} : {1:D2} : {2:D2}", timeToShow.Hours, timeToShow.Minutes, timeToShow.Seconds);
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
                }
            }
            this.Invalidate(true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (var font = new Font("Arial", 24, FontStyle.Bold))
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
            Process.Start("http://blog.kowalczyk.info/software/15minutes");
        }
    }
}
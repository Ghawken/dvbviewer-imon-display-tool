﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.ComponentModel;
using iMon.DisplayApi;

namespace DVBViewer_iMonDisplayPlugin
{
    partial class DisplayHandler : BackgroundWorker
    {
        private Semaphore semReady;
        private Semaphore semWork;

        private iMonWrapperApi imon;
        private bool lcd;
        private bool vfd;
        private object displayLock = new object();

        private object queueLock = new object();
        private List<Text> queue;
        private int position;

        private Dictionary<iMonLcdIcons, bool> icons;

        private System.Timers.Timer discRotation;

        public DisplayHandler(iMonWrapperApi imon)
        {
            if (imon == null)
            {
                throw new ArgumentNullException("imon");
            }

            this.imon = imon;
            this.imon.StateChanged += stateChanged;
            this.queue = new List<Text>();            

            this.icons = new Dictionary<iMonLcdIcons, bool>(Enum.GetValues(typeof(iMonLcdIcons)).Length);
            foreach (iMonLcdIcons icon in Enum.GetValues(typeof(iMonLcdIcons)))
            {
                this.icons.Add(icon, false);
            }

            this.discRotation = new System.Timers.Timer();
            this.discRotation.AutoReset = true;
            this.discRotation.Interval = 1000;
            this.discRotation.Elapsed += discRotationElapsed;

            this.WorkerReportsProgress = false;
            this.WorkerSupportsCancellation = true;

            this.semReady = new Semaphore(0, 1);
            this.semWork = new Semaphore(0, 1);
        }

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            while (!this.CancellationPending)
            {                
                this.semReady.WaitOne();

                Logging.Log("Display Handler", "Start working");

                if (this.lcd)
                {
                    foreach (KeyValuePair<iMonLcdIcons, bool> icon in this.icons)
                    {
                        this.imon.LCD.Icons.Set(icon.Key, icon.Value);
                    }
                }

                if (this.queue.Count > 0)
                {
                    this.display(this.queue[0]);

                    if (this.queue.Count > 1)
                    {
                        this.position = 1;
                    }
                }

                while (!this.CancellationPending && (this.lcd || this.vfd))
                {
                    this.semWork.WaitOne();

                    lock (this.queueLock)
                    {
                        if (this.position >= this.queue.Count)
                        {
                            this.position = 0;
                        }

                        this.display(this.queue[this.position]);

                        if (this.queue.Count > this.position)
                        {
                            this.position += 1;
                        }
                    }
                }

                Logging.Log("Display Handler", "Stop working");
            }

            Logging.Log("Display Handler", "Cancelled");

            this.imon.LCD.ScrollFinished -= lcdScrollFinished;
        }

        public void SetText(string text)
        {
            this.SetText(text, text, string.Empty, 0);
        }

        public void SetText(string text, int delay)
        {
            this.SetText(text, text, string.Empty, delay);
        }

        public void SetText(string lcd, string vfdUpper, string vfdLower)
        {
            this.SetText(lcd, vfdUpper, vfdLower, 0);
        }

        public void SetText(string lcd, string vfdUpper, string vfdLower, int delay)
        {
            lock (this.queueLock)
            {
                Logging.Log("Display Handler", "Setting text to \"" + lcd + "\"");

                this.queue.Clear();
                this.queue.Add(new Text(lcd, vfdUpper, vfdLower, delay));
                this.position = 0;

                this.update();
            }
        }

        public void AddText(string text)
        {
            this.AddText(text, text, string.Empty, 0);
        }

        public void AddText(string text, int delay)
        {
            this.AddText(text, text, string.Empty, delay);
        }

        public void AddText(string lcd, string vfdUpper, string vfdLower)
        {
            this.AddText(lcd, vfdUpper, vfdLower, 0);
        }

        public void AddText(string lcd, string vfdUpper, string vfdLower, int delay)
        {
            lock (this.queueLock)
            {
                Logging.Log("Display Handler", "Adding text \"" + lcd + "\" to the queue");

                this.queue.Add(new Text(lcd, vfdUpper, vfdLower, delay));               

                if (this.queue.Count == 1)
                {
                    this.update();
                }
            }
        }

        public void SetProgress(int position, int total)
        {
            if (this.lcd && position >= 0)
            {
                this.imon.LCD.SetProgress(position, total);
            }
        }

        public void SetProgress(TimeSpan position, TimeSpan total)
        {
            if (this.lcd)
            {
                this.imon.LCD.SetProgress(Convert.ToInt32(position.TotalMilliseconds), Convert.ToInt32(total.TotalMilliseconds));
            }
        }

        public void SetIcon(iMonLcdIcons icon, bool show)
        {
            this.icons[icon] = show;            

            if (this.lcd)
            {
                Logging.Log("Display Handler", "Setting LCD icon " + icon + " to " + show);

                this.imon.LCD.Icons.Set(icon, show);                
            }
        }

        public void SetIcons(IEnumerable<iMonLcdIcons> iconList, bool show)
        {
            foreach (iMonLcdIcons icon in iconList)
            {
                if (this.lcd)
                {
                    Logging.Log("Display Handler", "Setting LCD icon " + icon + " to " + show);
                }

                this.icons[icon] = show;
            }

            if (this.lcd)
            {
                this.imon.LCD.Icons.Set(iconList, show);                
            }
        }

        public void HideAllIcons()
        {
            foreach (iMonLcdIcons icon in Enum.GetValues(typeof(iMonLcdIcons)))
            {
                this.icons[icon] = false;
            }

            if (this.lcd)
            {
                Logging.Log("Display Handler", "Hiding all LCD icons");

                this.imon.LCD.Icons.HideAll();
            }
        }

        public void ShowDisc(bool bottomCircle)
        {
            this.PauseDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomCenter,
                                                                     iMonLcdIcons.DiscBottomRight, iMonLcdIcons.DiscMiddleLeft,
                                                                     iMonLcdIcons.DiscMiddleRight, iMonLcdIcons.DiscTopLeft,
                                                                     iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscTopRight };
            if (bottomCircle)
            {
                iconList.Add(iMonLcdIcons.DiscCircle);
            }

            this.SetIcons(iconList, true);
        }

        public void HideDisc()
        {
            this.PauseDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomCenter,
                                                                     iMonLcdIcons.DiscBottomRight, iMonLcdIcons.DiscMiddleLeft,
                                                                     iMonLcdIcons.DiscMiddleRight, iMonLcdIcons.DiscTopLeft,
                                                                     iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscTopRight,
                                                                     iMonLcdIcons.DiscCircle };

            this.SetIcons(iconList, false);
        }

        public void RotateDisc(bool bottomCircle)
        {
            this.HideDisc();

            List<iMonLcdIcons> iconList = new List<iMonLcdIcons>() { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                                     iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft };
            if (bottomCircle)
            {
                iconList.Add(iMonLcdIcons.DiscCircle);
            }

            this.SetIcons(iconList, true);

            this.discRotation.Start();
        }

        public void PauseDisc()
        {
            this.discRotation.Stop();
        }

        private void update()
        {
            try
            {
                this.semWork.Release();
            }
            catch (SemaphoreFullException)
            { }
        }

        private void stateChanged(object sender, iMonStateChangedEventArgs e)
        {
            lock (this.displayLock)
            {
                if (e.IsInitialized)
                {
                    iMonDisplayType display = this.imon.DisplayType;
                    if ((display & iMonDisplayType.LCD) == iMonDisplayType.LCD)
                    {
                        this.imon.LCD.ScrollFinished += lcdScrollFinished;
                        this.lcd = true;
                    }
                    if ((display & iMonDisplayType.VFD) == iMonDisplayType.VFD)
                    {
                        this.vfd = true;
                    }

                    this.semReady.Release();
                }
                else
                {
                    this.lcd = false;
                    this.vfd = false;

                    this.update();
                }
            }
        }

        private void lcdScrollFinished(object sender, EventArgs e)
        {
            //ToDo: App window freezes if this Thread-sleep occurs
            Thread.Sleep(Properties.Settings.Default.scrollDelay * 1000);

            Logging.Log("Display Handler", "Scrolling finished");

            lock (this.queueLock)
            {
                if (this.position >= this.queue.Count)
                {
                    this.position = 0;
                }

                if (this.queue.Count == 0)
                {
                    return;
                }

                this.update();
            }
        }        

        private void discRotationElapsed(object sender, ElapsedEventArgs e)
        {
            List<iMonLcdIcons> hideIcons = new List<iMonLcdIcons>();
            List<iMonLcdIcons> showIcons = new List<iMonLcdIcons>();
            if (this.icons[iMonLcdIcons.DiscBottomLeft])
            {
                hideIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                        iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft });
                showIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomCenter, iMonLcdIcons.DiscMiddleRight, 
                                                        iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscMiddleLeft });
            }
            else
            {
                hideIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomCenter, iMonLcdIcons.DiscMiddleRight, 
                                                        iMonLcdIcons.DiscTopCenter, iMonLcdIcons.DiscMiddleLeft });
                showIcons.AddRange(new iMonLcdIcons[] { iMonLcdIcons.DiscBottomLeft, iMonLcdIcons.DiscBottomRight, 
                                                        iMonLcdIcons.DiscTopRight, iMonLcdIcons.DiscTopLeft });
            }

            this.SetIcons(hideIcons, false);
            this.SetIcons(showIcons, true);
        }

        private void display(Text text)
        {
            lock (this.displayLock)
            {
                if (this.lcd)
                {
                    Logging.Log("Display Handler", "LCD.SetText: " + text.Lcd);

                    this.imon.LCD.SetText(text.Lcd.Substring(0, text.Lcd.Length < 256 ? text.Lcd.Length : 257));
                }
                if (this.vfd)
                {
                    Logging.Log("Display Handler", "VFD.SetText: " + text.VfdUpper + "; " + text.VfdLower);

                    this.imon.VFD.SetText(text.VfdUpper, text.VfdLower);
                }

                if (text.Delay > 0)
                {
                    Logging.Log("Display Handler", "Showing text for " + text.Delay + "ms");

                    Thread.Sleep(text.Delay);
                }
            }
        }

        public void ShowStereoAudioIcons(bool show)
        {
            List<iMonLcdIcons> stereoIconList = new List<iMonLcdIcons>() { iMonLcdIcons.SpeakerFrontLeft , iMonLcdIcons.SpeakerFrontRight };
            this.SetIcons(stereoIconList, show);
        }

        public void Show_DD51_AudioIcons(bool show)
        {
            List<iMonLcdIcons> stereoIconList = new List<iMonLcdIcons>() { iMonLcdIcons.SpeakerFrontLeft , iMonLcdIcons.SpeakerFrontRight , iMonLcdIcons.SpeakerCenter,
                                                                           iMonLcdIcons.SpeakerRearLeft , iMonLcdIcons.SpeakerRearRight , iMonLcdIcons.SpeakerCenter };
            this.SetIcons(stereoIconList, show);
        }
    }
}

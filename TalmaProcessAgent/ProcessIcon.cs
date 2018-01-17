using HermesProcessAgent.Properties;
using HermesProcessAgent.Utility;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace HermesProcessAgent
{
    public partial class ProcessIcon : Form
    {
        private NotifyIcon ni;

        private Process myProcess;

        private System.Timers.Timer actionTimer;

        private System.Timers.Timer updateTimer;

        private int interval = 3;

        public ProcessIcon()
        {
            this.ni = new NotifyIcon();
        }

        private string ArrayToString(string[] args)
        {
            string str = "";
            string[] strArrays = args;
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                str = string.Concat(str, strArrays[i], " ");
            }
            return str;
        }

        private bool CheckIfProcessAlive()
        {
            return !this.myProcess.HasExited;
        }

        public void Display()
        {
            this.ni.MouseClick += new MouseEventHandler(this.ni_MouseClick);
            //this.ni.Icon =  Resources.HPA;
            this.ni.Text = "Hermes Process Agent";
            //this.ni.Visible = true;
            //this.ni.ContextMenuStrip = (new ContextMenus()).Create();
            this.actionTimer = new System.Timers.Timer();
            this.actionTimer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
            this.actionTimer.Interval = (double)(this.interval * 1000);
            this.actionTimer.Enabled = true;
            this.updateTimer = new System.Timers.Timer();
            this.updateTimer.Elapsed += new ElapsedEventHandler(this.OnUpdateTimedEvent);
            this.updateTimer.Interval = 1000;
            this.updateTimer.Enabled = true;
            this.RunProcess();
        }

        public void Dispose()
        {
            this.ni.Visible = false;
            this.ni.Dispose();
        }

        public void HideIcon()
        {
            this.ni.Visible = false;
        }

        private void ni_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (this.myProcess != null)
            {
                if (!this.CheckIfProcessAlive())
                {
                    this.RunProcess();
                }
            }
        }

        private void OnUpdateTimedEvent(object source, ElapsedEventArgs e)
        {
            if (this.myProcess != null)
            {
                if (!this.CheckIfProcessAlive())
                {
                    this.ni.Text = "Hermes Process Agent - Waiting for interval timeout";
                }
            }
        }

        public void ProcessArguments(string[] args)
        {
            MessageBox.Show(this.ArrayToString(args));
        }

        private void RunProcess()
        {
            string settingsValue = General.GetSettingsValue("FileName");  // filename = C:\SCALES\node\x64\node.exe
            string str = General.GetSettingsValue("Arguments");             // arguments = C:\SCALES\scripts\server.js
            string settingsValue1 = General.GetSettingsValue("CheckInterval"); // checkinterval=10

            if ((settingsValue == null ? true : !File.Exists(settingsValue)))
            {
                MessageBox.Show("Error - Missing definition 'FileName' in ScaleWebAgent.ini file or file does not exist.", "Hermes Process Agent", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                this.myProcess = General.IsProcessOpen(Path.GetFileName(settingsValue));
                if (this.myProcess != null)
                {
                    //AutoClosingMessageBox.Show(string.Concat(Path.GetFileName(settingsValue), " is currently running and will be shut down and reloaded in 10 seconds"), "Warning - Hermes Process Agent", 10000);
                    this.myProcess.Kill();
                    Thread.Sleep(500);
                }
                this.ni.Text = string.Concat("Hermes Process Agent - Running ", Path.GetFileName(settingsValue));
                int num = 0;
                int.TryParse(settingsValue1, out num);
                if ((num == this.interval ? false : num > 0))
                {
                    this.interval = num;
                    this.actionTimer.Interval = (double)(this.interval * 1000);
                }
                this.myProcess = new Process();
                try
                {
                    this.myProcess.StartInfo.UseShellExecute = false;
                    this.myProcess.StartInfo.CreateNoWindow = true;
                    this.myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    this.myProcess.StartInfo.FileName = settingsValue;
                    if (str != null)
                    {
                        this.myProcess.StartInfo.Arguments = str;
                    }
                    this.myProcess.Start();
                }
                catch (Exception exception1)
                {
                    Exception exception = exception1;
                    MessageBox.Show(string.Concat("Error - Can not start target FileName. ", exception.Message), "Hermes Process Agent", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                this.ni.Text = string.Concat("Hermes Process Agent - ", Path.GetFileName(settingsValue), " is running");
            }
        }
    }
}

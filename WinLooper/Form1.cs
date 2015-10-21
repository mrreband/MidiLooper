using System.Threading;
using MidiLooper;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLooper
{
    public partial class WinLooper : Form
    {
        public WinLooper()
        {
            InitializeComponent();
        }

        private bool isRunning = false;
        private Looper l = new Looper(2, 4);
        private Clock c = Clock.GetClock();
        private List<ToggleBox> toggleBoxes;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            c.ClockChanged += ClockChanged;
            toggleBoxes = new List<ToggleBox>(); 
            addToggleBoxes(l.MeasureCount, l.BeatCount);
        }

        private void addToggleBoxes(float measureCount, float beatCount)
        {                      
            var totalBeats = measureCount * beatCount;

            //remove excess boxes
            for (int i = toggleBoxes.Count - 1; i >= totalBeats; i--)
            {
                this.pnlToggleBoxArea.Controls.Remove(toggleBoxes[i]);
                toggleBoxes.Remove(toggleBoxes[i]);
            }

            //add new boxes
            for (int i = toggleBoxes.Count; i < totalBeats; i++)
            {
                toggleBoxes.Add(addToggleBox(50 + i * 30, 50));
            }
        }

        private ToggleBox addToggleBox(int left, int top)
        {
            var tb = new ToggleBox(left, top);
            this.pnlToggleBoxArea.Controls.Add(tb);
            return tb;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                Stop();
            }
            else 
            { 
                Start(); 
            }
        }

        private void Start()
        {
            c.Start();
            btnStartStop.Text = "Stop";
            isRunning = true;
        }

        private void Stop()
        {
            c.Stop();
            btnStartStop.Text = "Start";
            isRunning = false;
        }

        private void ClockChanged(Object sender, EventArgs e)
        {
            if (isRunning)
            {
                var clock = (Midi.Clock)sender;
                UpdateUI(clock.Time.ToString());
            }
        }

        delegate void SetTextCallback(string text);
        private void UpdateUI(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblCurrentTime.InvokeRequired && isRunning)
            {
                try
                {
                    var d = new SetTextCallback(UpdateUI);
                    this.Invoke(d, new object[] { text });
                }
                catch (ObjectDisposedException) { }
            }
            else
            {
                var currentTime = Math.Round(Convert.ToDecimal(text), 2);
                var currentMeasure = Math.Floor(currentTime);
                var currentBeat = Math.Floor((currentTime % 1) * 4);
                this.lblCurrentTime.Text = currentTime.ToString();
                this.lblCurrentMeasure.Text = currentMeasure.ToString();
                this.lblCurrentBeat.Text = currentBeat.ToString();

                var currentPosition = Convert.ToInt16(currentMeasure * 4 + currentBeat);
                var activeBox = toggleBoxes[currentPosition];
                activeBox.Activate();
                if (currentPosition >= 1)
                {
                    var previousBox = toggleBoxes[currentPosition - 1];
                    previousBox.Deactivate();
                }
                else
                {
                    var previousBox = toggleBoxes[toggleBoxes.Count - 1];
                    previousBox.Deactivate();
                }
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            c.ClockChanged -= ClockChanged;
            Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            c.Reset();
            this.lblCurrentTime.Text = "0";
            this.lblCurrentMeasure.Text = "0";
            this.lblCurrentBeat.Text = "0";
            var activeBox = (from ToggleBox t in toggleBoxes where t.IsActive == true select t).FirstOrDefault();
            activeBox.Deactivate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            var intbox = (NumericUpDown)sender;
            l.SetMeasureCount(Convert.ToInt32(intbox.Value));
            addToggleBoxes(l.MeasureCount, l.BeatCount);
        }

        private void bpmBox_ValueChanged(object sender, EventArgs e)
        {
            var bpmBox = (NumericUpDown)sender;
            c.SetBPM(Convert.ToInt32(bpmBox.Value));
        }

    }
}

using System.Threading;
using MidiLooper;
using Midi;

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
        private List<ToggleBox> toggleBoxes;

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            l.c.ClockChanged += ClockChanged;
            toggleBoxes = new List<ToggleBox>(); 
            AddToggleBoxes(l.MeasureCount, l.BeatCount);
            AddMidiDevices();
        }

        private void AddMidiDevices()
        {
            this.dropDownMidiDevices.Items.Clear();
            var outputDevices = MidiIO.GetAvailableDevices();

            foreach (var outputDevice in outputDevices)
            {
                this.dropDownMidiDevices.Items.Add(outputDevice.Name);
            }
        }

        private void AddToggleBoxes(float measureCount, float beatCount)
        {
            AddToggleBoxRow(measureCount: measureCount, beatCount: beatCount, pitch: Pitch.C4);
        }

        private void AddToggleBoxRow(float measureCount, float beatCount, Pitch pitch)
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
                toggleBoxes.Add(addToggleBox(50 + i * 30, 50, pitch));
            }
        }

        private ToggleBox addToggleBox(int left, int top, Pitch pitch)
        {
            var tb = new ToggleBox(left, top, pitch);
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
            l.c.Start();
            btnStartStop.Text = "Stop";
            isRunning = true;
        }

        private void Stop()
        {
            l.c.Stop();
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
                var currentTime = Convert.ToDecimal(text);

                var currentTimeDisplayed = Math.Round(Convert.ToDecimal(text), 2);
                var currentMeasure = Math.Floor(currentTime);
                var currentBeat = Math.Floor((currentTime % 1) * 4);
                this.lblCurrentTime.Text = currentTimeDisplayed.ToString();
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

                if (activeBox.Checked)
                {                    
                    l.Schedule(Channel.Channel1, activeBox.pitch, 100, (float)currentTime, (float)noteLengthBox.Value);
                }
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            l.c.ClockChanged -= ClockChanged;
            Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            l.c.Reset();
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
            AddToggleBoxes(l.MeasureCount, l.BeatCount);
        }

        private void bpmBox_ValueChanged(object sender, EventArgs e)
        {
            var bpmBox = (NumericUpDown)sender;
            l.c.SetBPM(Convert.ToInt32(bpmBox.Value));
        }

        private void dropDownMidiDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (ComboBox)sender;
            var deviceName = dropDown.SelectedItem.ToString();
            l.SetOutputDevice(deviceName);
        }

    }
}

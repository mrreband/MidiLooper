using MidiUtility;
using Midi;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WinLooper
{
    public partial class WinLooper : Form
    {
        public WinLooper()
        {
            InitializeComponent();
        }

        private bool IsRunning = false;
        private MidiLooper l = new MidiLooper(2, 4);
        private List<ToggleBox> toggleBoxes;

        /// <summary>
        /// Form load initialization
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            l.c.ClockChanged += ClockChanged;
            toggleBoxes = new List<ToggleBox>(); 
            AddToggleBoxes(l.MeasureCount, l.BeatCount);
            AddMidiDevices();
        }

        /// <summary>
        /// Get a list of all available MIDI devices, and add them to the drop down list. 
        /// </summary>
        private void AddMidiDevices()
        {
            this.dropDownMidiDevices.Items.Clear();
            var outputDevices = MidiIO.GetAvailableDevices();

            foreach (var outputDevice in outputDevices)
            {
                this.dropDownMidiDevices.Items.Add(outputDevice.Name);
            }
        }

        /// <summary>
        /// Add all ToggleBoxes
        /// </summary>
        /// <param name="measureCount"></param>
        /// <param name="beatCount"></param>
        private void AddToggleBoxes(float measureCount, float beatCount)
        {
            AddToggleBoxRow(measureCount: measureCount, beatCount: beatCount, pitch: Pitch.C4);
        }

        /// <summary>
        /// Add a row of ToggleBoxes
        /// </summary>
        /// <param name="measureCount"></param>
        /// <param name="beatCount"></param>
        /// <param name="pitch"></param>
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

        /// <summary>
        /// Add a ToggleBox to the grid
        /// </summary>
        /// <param name="left">Left Position in the grid</param>
        /// <param name="top">Top Position in the grid</param>
        /// <param name="pitch">Pitch of the note to play when active</param>
        /// <returns>Newly created ToggleBox object</returns>
        private ToggleBox addToggleBox(int left, int top, Pitch pitch)
        {
            var tb = new ToggleBox(left, top, pitch);
            this.pnlToggleBoxArea.Controls.Add(tb);
            return tb;
        }

        /// <summary>
        /// Toggle start / stop state
        /// </summary>
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (IsRunning)
                Stop();
            else
                Start();
        }

        /// <summary>
        /// Start the sequencer.
        /// </summary>
        private void Start()
        {
            l.c.Start();
            btnStartStop.Text = "Stop";
            IsRunning = true;
        }

        /// <summary>
        /// Stop the sequencer.
        /// </summary>
        private void Stop()
        {
            l.c.Stop();
            btnStartStop.Text = "Start";
            IsRunning = false;
        }

        /// <summary>
        /// Event handler for updating the UI as the clock progresses. 
        /// </summary>
        private void ClockChanged(Object sender, EventArgs e)
        {
            if (IsRunning)
            {
                var clock = (Midi.Clock)sender;
                UpdateUI(clock.Time.ToString());
            }
        }

        /// <summary>
        /// Update the UI as the clock progresses.  
        /// 
        /// Change the color of boxes if they occur at the current clock time. 
        /// If the current clock time coincides with the checkbox time, schedule a midi event.
        /// </summary>
        /// <param name="text"></param>
        delegate void SetTextCallback(string text);
        private void UpdateUI(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblCurrentTime.InvokeRequired && IsRunning)
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

        /// <summary>
        /// Reset Button event handler - initialize all inputs. 
        /// </summary>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Stop();
            l.c.Reset();
            this.lblCurrentTime.Text = "0";
            this.lblCurrentMeasure.Text = "0";
            this.lblCurrentBeat.Text = "0";
            var activeBox = (from ToggleBox t in toggleBoxes where t.IsActive == true select t).FirstOrDefault();
            if (activeBox != null) 
                activeBox.Deactivate();
        }

        /// <summary>
        /// Measure Box change handler - redraw the correct number of toggle boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void measureBox_ValueChanged(object sender, EventArgs e)
        {
            var intbox = (NumericUpDown)sender;
            l.SetMeasureCount(Convert.ToInt32(intbox.Value));
            AddToggleBoxes(l.MeasureCount, l.BeatCount);
        }

        /// <summary>
        /// Clock BPM change handler - change the clock to the newly selected BPM
        /// </summary>
        private void bpmBox_ValueChanged(object sender, EventArgs e)
        {
            var bpmBox = (NumericUpDown)sender;
            l.c.SetBPM(Convert.ToInt32(bpmBox.Value));
        }

        /// <summary>
        /// Midi Device change handler - set the newly selected output device. 
        /// </summary>
        private void dropDownMidiDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dropDown = (ComboBox)sender;
            var deviceName = dropDown.SelectedItem.ToString();
            l.SetOutputDevice(deviceName);
        }

        /// <summary>
        /// Cleanup - stop the clock before closing
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            l.c.ClockChanged -= ClockChanged;
            Stop();
        }
    }
}

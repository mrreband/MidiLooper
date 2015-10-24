using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Midi;

namespace MidiLooper
{
    public class Looper
    {
        public float MeasureCount { get; private set; }
        public float BeatCount { get; private set; }
        private OutputDevice OutputDevice;

        private int currentMeasure = 0;
        public Clock c = Clock.GetClock();

        public Looper(int measureCount, int beatCount)
        {
            SetMeasureCount(measureCount);
            SetBeatCount(beatCount);
            c.ClockChanged += CheckClock;
        }

        public void SetMeasureCount(int measureCount)
        {
            MeasureCount = measureCount;
        }

        public void SetBeatCount(int beatCount)
        {
            BeatCount = beatCount;
        }

        public void SetOutputDevice(string deviceName)
        {
            if (OutputDevice != null) OutputDevice.Close();
            OutputDevice = MidiIO.GetOutputDevice(deviceName);
            OutputDevice.Open();
        }

        private void CheckClock(Object sender, EventArgs e)
        {
            var clock = (Midi.Clock)sender;
            var currentTime = clock.Time;
            currentMeasure = Convert.ToInt16(Math.Floor(currentTime));

            if (currentTime >= MeasureCount - 0.01F)
            {
                c.Reset();
            }            
        }

        public void Schedule(Channel channel, Pitch pitch, int velocity, float time, float noteLength)
        {
            if (OutputDevice == null) return;
            var msg = new NoteOnMessage(OutputDevice, channel, pitch, velocity, time);
            c.Schedule(OutputDevice, msg, noteLength);
        }

        public void UnSchedule()
        {

        }
    }
}

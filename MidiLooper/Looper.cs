using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MidiLooper
{
    public class Looper
    {
        public float MeasureCount { get; private set; }
        public float BeatCount { get; private set; }

        private int currentMeasure = 0;
        private Clock c = Clock.GetClock();

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
    }
}

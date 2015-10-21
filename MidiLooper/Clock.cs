using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Midi;
using System.Threading;

namespace MidiLooper
{
    public class Clock
    {
        #region singleton code
        private static Clock singleClock = new Clock(120);
        private Clock(int bpm) { SetBPM(bpm); }
        public static Clock GetClock() { return singleClock; }
        #endregion

        private Midi.Clock clock = new Midi.Clock(120);
        
        public event EventHandler ClockChanged;
        private float previousTime = 0;
        private Task t;     //for starting the clock in its own thread

        #region public methods
        public void Start() 
        {
            t = new Task(StartClock);
            t.Start();
        }

        public void Stop()
        {
            if (clock.IsRunning)
                clock.Stop();
        }

        public void Reset() {
            if (clock.IsRunning)
            {
                clock.Stop();
                clock.Reset();
                clock.Start();
            }
            else 
            { 
                clock.Reset();
            }
            ClockChanged(this.clock, EventArgs.Empty);
        }

        public void SetBPM(int bpm)
        {
            clock.BeatsPerMinute = bpm;
        }
        #endregion

        private void StartClock()
        {
            if (!clock.IsRunning)
                clock.Start();

            while (clock.IsRunning)
            {
                var currentTime = clock.Time;
                if (currentTime != previousTime)
                {
                    ClockChanged(this.clock, EventArgs.Empty);
                }
                previousTime = currentTime;
            }
        }
    }
}

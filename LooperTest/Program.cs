﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MidiUtility;

namespace LooperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock c = Clock.GetClock();
            c.SetBPM(60);

            MidiUtility.MidiLooper l = new MidiUtility.MidiLooper(2,4);
            //c.ClockChanged += l.CheckClock; 
            
            Observer o = new Observer();
            c.ClockChanged += o.ClockChanged;

            c.Start();
            Thread.Sleep(10000);
            c.Stop();

            Console.WriteLine("done");
            Console.ReadKey();
        }

        static void test()
        { }
    }

    public class Observer
    {
        public void ClockChanged(Object sender, EventArgs e)
        {
            var clock = (Midi.Clock)sender;
            Console.WriteLine(clock.Time);
        }
    }

}

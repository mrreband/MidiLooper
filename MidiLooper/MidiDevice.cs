using System;
using System.Text;
using System.Threading.Tasks;
using Midi;

namespace MidiUtility
{
    class MidiDevice
    {
        public OutputDevice OutputDevice;

        public MidiDevice(string deviceName)
        {
            OutputDevice = MidiIO.GetOutputDevice(deviceName);
        }

        public void ConnectOutputDevice() 
        {
            OutputDevice.Open();
        }

        public void DisconnectOutputDevice() 
        {
            OutputDevice.Close();
        }

        public void NoteOn(Channel channel, Pitch pitch, int velocity)
        {
            OutputDevice.SendNoteOn(channel, pitch, velocity);
        }

        public void NoteOff(Channel channel, Pitch pitch, int velocity)
        {
            OutputDevice.SendNoteOff(channel, pitch, velocity); //what is velocity for here?  
        }

        
        
        //public static void listen(InputDevice inputDevice)
        //{
        //    inputDevice.Open();
        //    inputDevice.NoteOn += new InputDevice.NoteOnHandler(NoteOn);
        //    inputDevice.StartReceiving(null);  // Note events will be received in another thread
        //    Console.ReadKey();  // This thread waits for a keypress
        //    inputDevice.Close();
        //}

  

    }
}

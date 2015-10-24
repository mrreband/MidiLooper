using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Midi
{
    public class MidiIO
    {
        public static IReadOnlyCollection<OutputDevice> GetAvailableDevices()
        {
            return OutputDevice.InstalledDevices;
        }

        public static OutputDevice GetOutputDevice(string deviceName)
        {
            return (from OutputDevice o in OutputDevice.InstalledDevices where o.Name.ToLower() == deviceName.ToLower() select o).FirstOrDefault();
        }

        public static InputDevice GetInputDevice(string deviceName)
        {
            throw new NotImplementedException();
        }
    }
}

using Launchpad.Core.Enums;
using Launchpad.Core.Midi;
using static Launchpad.Core.Midi.Structs;

namespace Launchpad.Core
{
    public class LaunchpadDevice
    {
        private const string LaunchpadProductName = "Launchpad";

        private readonly InputPort inputPort;
        private readonly OutputPort outputPort;

        private MIDIINCAPS midiInCaps;
        private MIDIOUTCAPS midiOutCaps;

        public LaunchpadDevice()
        {
            inputPort = new InputPort();
            outputPort = new OutputPort();
        }

        public bool OpenIn()
        {
            int midiInNumber;
            if (TryGetInDev(out midiInNumber))
            {
                return inputPort.Open(midiInNumber);
            }
            return false;
        }

        public bool CloseIn()
        {
            return inputPort.Close();
        }

        public bool OpenOut()
        {
            int midiOutNumber;
            if (TryGetOutDev(out midiOutNumber))
            {
                return outputPort.Open(midiOutNumber);
            }
            return false;
        }

        public bool CloseOut()
        {
            return outputPort.Close();
        }

        public void AddGridButtonPressedHandler(OutputPort.OnGridButtonPressedHandler handler)
        {
            outputPort.OnGridButtonPressed += handler;
        }

        public void AddAutomapButtonPressedHandler(OutputPort.OnAutomapButtonPressedHandler handler)
        {
            outputPort.OnAutomapButtonPressed += handler;
        }

        private bool TryGetInDev(out int midiNumber)
        {
            for (midiNumber = 0; midiNumber < InputPort.InputCount; midiNumber++)
            {
                InputPort.GetDeviceInfo(midiNumber, out midiInCaps);
                if (midiInCaps.szPname.Contains(LaunchpadProductName))
                {
                    return true;
                }
            }

            return false;
        }
        private bool TryGetOutDev(out int midiOutNumber)
        {
            for (midiOutNumber = 0; midiOutNumber < OutputPort.OutputCount; midiOutNumber++)
            {
                OutputPort.GetDeviceInfo(midiOutNumber, out midiOutCaps);
                if (midiOutCaps.szPname.Contains(LaunchpadProductName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
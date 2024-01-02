using Launchpad.Core.Midi;
using Launchpad.Core.Enums;
using System.Runtime.InteropServices;

namespace Launchpad.Core
{
    public class InputPort
    {
        private Midi.MidiIn.MidiInProc midiInProc;
        private IntPtr handle;

        public delegate void OnGridButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<int> e);

        public event OnGridButtonPressedHandler OnGridButtonPressed;

        public delegate void OnAutomapButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e);

        public event OnAutomapButtonPressedHandler OnAutomapButtonPressed;

        public InputPort()
        {
            midiInProc = new Midi.MidiIn.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int InputCount
        {
            get { return Midi.MidiIn.MidiInGetNumDevs(); }
        }

        public static void GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Structs.MIDIINCAPS();
            Midi.MidiIn.MidiInGetDevCaps(id, ref midiInCaps, Marshal.SizeOf(midiInCaps));
        }

        public bool Close()
        {
            bool result = Midi.MidiIn.MidiInClose(handle)
                == Midi.MidiIn.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Midi.MidiIn.MidiInOpen(
                out handle,
                id,
                midiInProc,
                nint.Zero,
                Midi.MidiIn.CALLBACK_FUNCTION)
                    == Midi.MidiIn.MMSYSERR_NOERROR;
        }

        public bool Start()
        {
            return Midi.MidiIn.MidiInStart(handle)
                == Midi.MidiIn.MMSYSERR_NOERROR;
        }

        public bool Stop()
        {
            return Midi.MidiIn.MidiInStop(handle)
                == Midi.MidiIn.MMSYSERR_NOERROR;
        }

        public int OutShortMsg(int dwMsg)
        {
            return Midi.MidiIn.MidiOutShortMsg(handle, dwMsg);
        }

        private void MidiProc(IntPtr hMidiIn,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2)
        {
            //Console.WriteLine($"hMidiIn: {hMidiIn}, wMsg: {wMsg}, dwInstance: {dwInstance}, dwParam1: {((byte)dwParam1).ToString()}, dwParam2: {dwParam2}");

            if (LaunchpadOutputMessageParser.TryParse(dwParam1, out LaunchpadButtonPressedEventArgs<AutomapButtons> launchpadOutputMessageAutomapEventArgs))
            {
                OnAutomapButtonPressed?.Invoke(this, launchpadOutputMessageAutomapEventArgs);
            }
            else if (LaunchpadOutputMessageParser.TryParse(dwParam1, out LaunchpadButtonPressedEventArgs<int> launchpadOutputMessageIntEventArgs))
            {
                OnGridButtonPressed?.Invoke(this, launchpadOutputMessageIntEventArgs);
            }
        }
    }
}
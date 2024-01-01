using Launchpad.Core;
using Launchpad.Core.Enums;
using Launchpad.Midi.Native;
using System.Runtime.InteropServices;

namespace Launchpad.Midi
{
    public class InputPort
    {
        private Native.Methods.MidiInProc midiInProc;
        private IntPtr handle;

        public delegate void OnGridButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<int> e);

        public event OnGridButtonPressedHandler OnGridButtonPressed;

        public delegate void OnAutomapButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e);

        public event OnAutomapButtonPressedHandler OnAutomapButtonPressed;

        public InputPort()
        {
            midiInProc = new Methods.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int InputCount
        {
            get { return Methods.midiInGetNumDevs(); }
        }

        public static void GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Structs.MIDIINCAPS();
            Methods.midiInGetDevCaps(id, ref midiInCaps, Marshal.SizeOf(midiInCaps));
        }

        public bool Close()
        {
            bool result = Methods.midiInClose(handle)
                == Methods.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Methods.midiInOpen(
                out handle,
                id,
                midiInProc,
                IntPtr.Zero,
                Methods.CALLBACK_FUNCTION)
                    == Methods.MMSYSERR_NOERROR;
        }

        public bool Start()
        {
            return Methods.midiInStart(handle)
                == Methods.MMSYSERR_NOERROR;
        }

        public bool Stop()
        {
            return Methods.midiInStop(handle)
                == Methods.MMSYSERR_NOERROR;
        }

        public int OutShortMsg(int dwMsg)
        {
            return Methods.midiOutShortMsg(handle, dwMsg);
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
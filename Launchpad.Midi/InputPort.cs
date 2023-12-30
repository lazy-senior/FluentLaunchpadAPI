using System.Runtime.InteropServices;

namespace Launchpad.Midi
{
    public class InputPort
    {
        private Native.Methods.MidiInProc midiInProc;
        private IntPtr handle;

        public InputPort()
        {
            midiInProc = new Native.Methods.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int InputCount
        {
            get { return Native.Methods.midiInGetNumDevs(); }
        }

        public static string GetDeviceInfo(int id)
        {
            var caps = new Native.Structs.MIDIINCAPS();
            caps = new Native.Structs.MIDIINCAPS();
            Native.Methods.midiInGetDevCaps(id, ref caps, Marshal.SizeOf(caps));
            return caps.ToString();
        }   

        public bool Close()
        {
            bool result = Native.Methods.midiInClose(handle)
                == Native.Methods.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Native.Methods.midiInOpen(
                out handle,
                id,
                midiInProc,
                IntPtr.Zero,
                Native.Methods.CALLBACK_FUNCTION)
                    == Native.Methods.MMSYSERR_NOERROR;
        }

        public bool Start()
        {
            return Native.Methods.midiInStart(handle)
                == Native.Methods.MMSYSERR_NOERROR;
        }

        public bool Stop()
        {
            return Native.Methods.midiInStop(handle)
                == Native.Methods.MMSYSERR_NOERROR;
        }

        private void MidiProc(IntPtr hMidiIn,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2)
        {
            // Receive messages here
        }
    }
}

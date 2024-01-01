using Launchpad.Midi.Native;
using System.Runtime.InteropServices;

namespace Launchpad.Midi
{
    public class OutputPort
    {
        //TODO: Split MidiInProc into MidiInProc and MidiOutProc

        private Native.Methods.MidiInProc midiOutProc;
        private IntPtr handle;

        public OutputPort()
        {
            midiOutProc = new Native.Methods.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int OutputCount
        {
            get { return Native.Methods.midiInGetOutDevs(); }
        }

        public static void GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Native.Structs.MIDIINCAPS();
            Native.Methods.midiInGetDevCaps(id, ref midiInCaps, Marshal.SizeOf(midiInCaps));
        }

        public bool Close()
        {
            bool result = Native.Methods.midiOutClose(handle)
                == Native.Methods.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Native.Methods.midiOutOpen(
                out handle,
                id,
                midiOutProc,
                IntPtr.Zero,
                Native.Methods.CALLBACK_FUNCTION)
                    == Native.Methods.MMSYSERR_NOERROR;
        }

        public int OutShortMsg(int dwMsg)
        {
            return Native.Methods.midiOutShortMsg(handle, dwMsg);
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
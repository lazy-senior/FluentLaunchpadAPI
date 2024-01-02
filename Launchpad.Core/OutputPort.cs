using System.Runtime.InteropServices;

namespace Launchpad.Core
{
    public class OutputPort
    {
        //TODO: Split MidiInProc into MidiInProc and MidiOutProc

        private Midi.MidiIn.MidiInProc midiOutProc;
        private IntPtr handle;

        public OutputPort()
        {
            midiOutProc = new Midi.MidiIn.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int OutputCount
        {
            get { return Midi.MidiIn.midiInGetOutDevs(); }
        }

        public static void GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Midi.Structs.MIDIINCAPS();
            Midi.MidiIn.midiInGetDevCaps(id, ref midiInCaps, Marshal.SizeOf(midiInCaps));
        }

        public bool Close()
        {
            bool result = Midi.MidiIn.midiOutClose(handle)
                == Midi.MidiIn.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Midi.MidiIn.midiOutOpen(
                out handle,
                id,
                midiOutProc,
                IntPtr.Zero,
                Midi.MidiIn.CALLBACK_FUNCTION)
                    == Midi.MidiIn.MMSYSERR_NOERROR;
        }

        public int OutShortMsg(int dwMsg)
        {
            return Midi.MidiIn.midiOutShortMsg(handle, dwMsg);
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
using Launchpad.Core.Enums;
using System.Runtime.InteropServices;
using Launchpad.Core.Midi.Constants;

namespace Launchpad.Core.Midi
{
    public class InputPort
    {
        private MidiIn.MidiInProc midiInProc;
        private nint handle;

        public InputPort()
        {
            midiInProc = new MidiIn.MidiInProc(MidiProc);
            handle = nint.Zero;
        }

        public static int InputCount
        {
            get { return MidiIn.MidiInGetNumDevs(); }
        }

        public static bool GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Structs.MIDIINCAPS();
            return MidiIn.MidiInGetDevCaps(
                id,
                ref midiInCaps,
                Marshal.SizeOf(midiInCaps))
                == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        public bool Close()
        {
            bool result = MidiIn.MidiInClose(handle)
                == (int)MMSYSTEM.MMSYSERR.NOERROR;
            handle = nint.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return MidiIn.MidiInOpen(
                out handle,
                id,
                midiInProc,
                nint.Zero,
                (int)MMSYSTEM.CALLBACK.FUNCTION)
                    == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        public bool Start()
        {
            return MidiIn.MidiInStart(handle)
                 == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        public bool Stop()
        {
            return MidiIn.MidiInStop(handle)
                 == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        private void MidiProc(nint hMidiIn,
            int wMsg,
            nint dwInstance,
            int dwParam1,
            int dwParam2)
        {

        }
    }
}
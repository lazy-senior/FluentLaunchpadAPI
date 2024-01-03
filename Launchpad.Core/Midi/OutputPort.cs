using Launchpad.Core.Enums;
using Launchpad.Core.Midi.Constants;
using System.Runtime.InteropServices;
using static Launchpad.Core.Midi.Structs;

namespace Launchpad.Core.Midi
{
    public class OutputPort
    {
        //TODO: Split MidiInProc into MidiInProc and MidiOutProc

        private MidiOut.MidiOutProc midiOutProc;
        private nint handle;


        public delegate void OnGridButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<int> e);

        public event OnGridButtonPressedHandler OnGridButtonPressed;

        public delegate void OnAutomapButtonPressedHandler(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e);

        public event OnAutomapButtonPressedHandler OnAutomapButtonPressed;

        public OutputPort()
        {
            handle = nint.Zero;

            midiOutProc = new MidiOut.MidiOutProc(MidiProc);

            OnGridButtonPressed += DefaultOnGridButtonPressed;
            OnAutomapButtonPressed += DefaultOnAutomapButtonPressed;
        }

        public static int OutputCount
        {
            get { return MidiOut.midiOutGetNumDevs(); }
        }

        public static bool GetDeviceInfo(int id, out MIDIOUTCAPS midiOutCaps)
        {
            midiOutCaps = new MIDIOUTCAPS();
            return MidiOut.midiOutGetDevCaps(
                id,
                ref midiOutCaps,
                Marshal.SizeOf(midiOutCaps))
                    == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        public bool Close()
        {
            bool result = MidiOut.midiOutClose(handle) == (int)MMSYSTEM.MMSYSERR.NOERROR;
            handle = nint.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return MidiOut.midiOutOpen(
                out handle,
                id,
                midiOutProc,
                nint.Zero,
                (int)MMSYSTEM.CALLBACK.FUNCTION)
                    == (int)MMSYSTEM.MMSYSERR.NOERROR;
        }

        public int OutShortMsg(int dwMsg)
        {
            return MidiOut.midiOutShortMsg(handle, dwMsg);
        }

        private void MidiProc(nint hMidiIn,
            int wMsg,
            nint dwInstance,
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

        private void DefaultOnAutomapButtonPressed(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e)
        {
            Console.WriteLine("OnAutomapButtonPressed:" + e.MessageType.ToString() + " " + e.Key.ToString() + " " + e.Velocity.ToString());
        }

        private void DefaultOnGridButtonPressed(object sender, LaunchpadButtonPressedEventArgs<int> e)
        {
            Console.WriteLine("OnGridButtonPressed:" + e.MessageType.ToString() + " " + e.Key + " " + e.Velocity.ToString());
        }
    }
}
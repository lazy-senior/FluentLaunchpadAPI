using System.Runtime.InteropServices;

namespace Launchpad.Core.Midi
{
    internal static partial class MidiOut
    {
        /*
            void CALLBACK MidiOutProc(
               HMIDIOUT  hmo,
               UINT      wMsg,
               DWORD_PTR dwInstance,
               DWORD_PTR dwParam1,
               DWORD_PTR dwParam2
            );
        */

        internal delegate void MidiOutProc(
            IntPtr hmo,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2);

        [DllImport("winmm.dll")]
            IntPtr hmo);

        [DllImport("winmm.dll")]
        internal static extern int midiOutOpen(
            out IntPtr phmo,
            int uDeviceID,
            MidiOutProc dwCallback,
            IntPtr dwInstance,
            int fdwOpen);

        [DllImport("winmm.dll")]
        internal static extern int midiOutShortMsg(
            IntPtr hMidiOut,
            int dwMsg);


        [DllImport("winmm.dll")]
        internal static extern int midiOutGetNumDevs();

        [DllImport("winmm.dll")]
        internal static extern int midiOutGetDevCaps(
            int uDeviceID,                  //  UINT         uDeviceID,s
            ref Structs.MIDIOUTCAPS pmoc,   //  LPMIDIOUTCAPS pmic,
            int cbmoc);


    }
}
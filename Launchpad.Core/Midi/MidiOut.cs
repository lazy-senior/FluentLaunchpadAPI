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
        internal static extern int MidiInGetNumDevs();

        [DllImport("winmm.dll")]
        internal static extern int MidiInGetOutDevs();

        [DllImport("winmm.dll")]
        internal static extern int MidiInGetDevCaps(
            int uDeviceID,                  //  UINT         uDeviceID,s
            ref Structs.MIDIINCAPS pmic,    //  LPMIDIINCAPS pmic,
            int cbmic);                     //  UINT         cbmic

        [DllImport("winmm.dll")]
        internal static extern int MidiInClose(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int MidiInOpen(
            out IntPtr lphMidiIn,
            int uDeviceID,
            MidiInProc dwCallback,
            IntPtr dwCallbackInstance,
            int dwFlags);

        [DllImport("winmm.dll")]
        internal static extern int MidiOutClose(
            IntPtr hmo);

        [DllImport("winmm.dll")]
        internal static extern int MidiOutOpen(
            out IntPtr phmo,
            int uDeviceID,
            MidiInProc dwCallback,
            IntPtr dwInstance,
            int fdwOpen);

        [DllImport("winmm.dll")]
        internal static extern int MidiInStart(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int MidiInStop(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int MidiOutShortMsg(
            IntPtr hMidiOut,
            int dwMsg);
    }
}
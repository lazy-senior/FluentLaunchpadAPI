using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Midi.Native
{
    internal static class Methods
    {
        internal const int MMSYSERR_NOERROR = 0;
        internal const int CALLBACK_FUNCTION = 0x00030000;

        internal delegate void MidiInProc(
            IntPtr hMidiIn,
            int wMsg,
            IntPtr dwInstance,
            int dwParam1,
            int dwParam2);

        [DllImport("winmm.dll")]
        internal static extern int midiInGetNumDevs();

        [DllImport("winmm.dll")]
        internal static extern int midiInGetOutDevs();

        [DllImport("winmm.dll")]
        internal static extern int midiInGetDevCaps(
            int uDeviceID,                  //  UINT         uDeviceID,
            ref Structs.MIDIINCAPS pmic,    //  LPMIDIINCAPS pmic,
            int cbmic);                     //  UINT         cbmic

        [DllImport("winmm.dll")]
        internal static extern int midiInClose(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int midiInOpen(
            out IntPtr lphMidiIn,
            int uDeviceID,
            MidiInProc dwCallback,
            IntPtr dwCallbackInstance,
            int dwFlags);

        [DllImport("winmm.dll")]
        internal static extern int midiInStart(
            IntPtr hMidiIn);

        [DllImport("winmm.dll")]
        internal static extern int midiInStop(
            IntPtr hMidiIn);

        #region winmm.dll:midiInMessage
        /*
            MMRESULT midiInMessage(
                
                
                DWORD_PTR dw1,
                DWORD_PTR dw2
            );
        */
        #endregion
        [DllImport("winmm.dll")]
        internal static extern int midiInMessage(
            IntPtr hMidiIn,                 //  HMIDIIN   hmi,
            uint uMsg,                      //  UINT      uMsg,
                                            //  DWORD_PTR dw1,
                                            //  DWORD_PTR dw2
    }
}

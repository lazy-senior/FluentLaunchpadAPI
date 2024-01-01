using System.Runtime.InteropServices;

namespace Launchpad.Midi.Native
{
    public class Structs
    {
        /*
            Constant windows::Win32::Media::MAXPNAMELEN
            pub const MAXPNAMELEN: u32 = 32u32;
        */
        internal const int MAXPNAMELEN = 32;

        /*
            typedef struct midiincaps_tag {
              WORD    wMid;
              WORD    wPid;
              VERSION vDriverVersion;
              char    szPname[MAXPNAMELEN];
              DWORD   dwSupport;
            } MIDIINCAPS, *PMIDIINCAPS, *NPMIDIINCAPS, *LPMIDIINCAPS;
        */

        public struct MIDIINCAPS
        {
            public Int16 wMid;
            public Int16 wPid;
            public int vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAXPNAMELEN)]
            public string szPname;

            public int dwSupport;

            public override string ToString()
            {
                return $"wMid: {wMid}, wPid: {wPid}, vDriverVersion: {vDriverVersion}, szPname: {szPname}, dwSupport: {dwSupport}";
            }
        }
    }
}
using System.Runtime.InteropServices;

namespace Launchpad.Core.Midi
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

        /*
            typedef struct midioutcaps_tag {
              WORD    wMid;
              WORD    wPid;
              VERSION vDriverVersion;
              char    szPname[MAXPNAMELEN];
              WORD    wTechnology;
              WORD    wVoices;
              WORD    wNotes;
              WORD    wChannelMask;
              DWORD   dwSupport;

        */

        public struct MIDIOUTCAPS
        {
            public Int16 wMid;
            public Int16 wPid;
            public int vDriverVersion;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = (int)MAXPNAMELEN)]
            public string szPname;

            public Int16 wTechnology;
            public Int16 wVoices;
            public Int16 wNotes;
            public Int16 wChannelMask;
            public int dwSupport;

            public override string ToString()
            {
                return $"wMid: {wMid}, wPid: {wPid}, vDriverVersion: {vDriverVersion}, szPname: {szPname}, wTechnology: {wTechnology}, wVoices: {wVoices}, wNotes: {wNotes}, wChannelMask: {wChannelMask}, dwSupport: {dwSupport}";
            }
        }
    }
}
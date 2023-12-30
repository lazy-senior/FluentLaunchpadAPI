﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Midi.Native
{
    internal class Structs
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
        internal struct MIDIINCAPS
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
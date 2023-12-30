﻿using System.Runtime.InteropServices;
using Launchpad.Midi.Native;
namespace Launchpad.Midi
{
    public class InputPort
    {
        private Native.Methods.MidiInProc midiInProc;
        private IntPtr handle;

        public InputPort()
        {
            midiInProc = new Native.Methods.MidiInProc(MidiProc);
            handle = IntPtr.Zero;
        }

        public static int InputCount
        {
            get { return Native.Methods.midiInGetNumDevs(); }
        }

        public static void GetDeviceInfo(int id, out Structs.MIDIINCAPS midiInCaps)
        {
            midiInCaps = new Native.Structs.MIDIINCAPS();
            Native.Methods.midiInGetDevCaps(id, ref midiInCaps, Marshal.SizeOf(midiInCaps));
        }   

        public bool Close()
        {
            bool result = Native.Methods.midiInClose(handle)
                == Native.Methods.MMSYSERR_NOERROR;
            handle = IntPtr.Zero;
            return result;
        }

        public bool Open(int id)
        {
            return Native.Methods.midiInOpen(
                out handle,
                id,
                midiInProc,
                IntPtr.Zero,
                Native.Methods.CALLBACK_FUNCTION)
                    == Native.Methods.MMSYSERR_NOERROR;
        }

        public bool Start()
        {
            return Native.Methods.midiInStart(handle)
                == Native.Methods.MMSYSERR_NOERROR;
        }

        public bool Stop()
        {
            return Native.Methods.midiInStop(handle)
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
            Console.WriteLine($"hMidiIn: {hMidiIn}, wMsg: {wMsg}, dwInstance: {dwInstance}, dwParam1: {dwParam1}, dwParam2: {dwParam2}");
        }
    }
}

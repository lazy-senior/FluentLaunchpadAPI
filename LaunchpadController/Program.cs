using Launchpad.Core.Commands;
using Launchpad.Core.Enums;
using Launchpad.Midi;
using Launchpad.Midi.Native;

internal class Program
{
    private static void Main(string[] args)
    {
        /*
        
        TODO: Move to Test project

        var midiOutput = LaunchpadWriteCommand
            .TurnOn(16 * 1 + 1)
            .Green(LEDBrightness.Full)
            .Red(LEDBrightness.Full)
            .ToByteArray();

        Console.WriteLine("Command:" + midiOutput[0]);
        Console.WriteLine("Key:" + midiOutput[1]);
        Console.WriteLine("Velocity:" + midiOutput[2]);


        midiOutput = LaunchpadWriteCommand
            .TurnOn(16 * 1 + 1)
            .Green(LEDBrightness.Full)
            .Red(LEDBrightness.Full)
            .Reset()
            .ToByteArray();

        Console.WriteLine("Command:" + midiOutput[0]);
        Console.WriteLine("Key:" + midiOutput[1]);
        Console.WriteLine("Velocity:" + midiOutput[2]);

        midiOutput = LaunchpadWriteCommand
            .Reset()
            .ToByteArray();

        Console.WriteLine("Command:" + midiOutput[0]);
        Console.WriteLine("Key:" + midiOutput[1]);
        Console.WriteLine("Velocity:" + midiOutput[2]);

        midiOutput = LaunchpadWriteCommand
            .GridMappingMode(GridMappingMode.DrumRackLayout)
            .ToByteArray();

        Console.WriteLine("Command:" + midiOutput[0]);
        Console.WriteLine("Key:" + midiOutput[1]);
        Console.WriteLine("Velocity:" + midiOutput[2]);
        */


        var midiIn = new InputPort();
        var midiInCaps = new Structs.MIDIINCAPS();
        var midiNumber = 0;
        var writeCommand = LaunchpadWriteCommand
                .TurnOn(16 * 1 + 1)
                .Green(LEDBrightness.Full)
                .Red(LEDBrightness.Full)
                .ToByteArray();

        for (;midiNumber < InputPort.InputCount; midiNumber++)
        {
            InputPort.GetDeviceInfo(midiNumber, out midiInCaps);
            if (midiInCaps.szPname.Contains("Launchpad"))
            {
                break;
            }
        }

        Console.WriteLine($"Device {midiNumber}:{midiInCaps.ToString()}");

        var openReturnCode = midiIn.Open(midiNumber);
        var startReturnCode = midiIn.Start();

        Console.WriteLine($"OpenReturnCode: {openReturnCode}");
        Console.WriteLine($"StartReturnCode: {startReturnCode}");
        

        Console.ReadLine();

        midiIn.Close();
    }

}

// Generate test class for LaunchpadWriteCommand
// Path: LaunchpadWriteCommandTest.cs

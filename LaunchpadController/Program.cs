using Launchpad.Core.Commands;
using Launchpad.Core.Enums;
using Launchpad.Midi;

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

        Console.WriteLine($"Input devices: {InputPort.InputCount}");

        for (int i = 0; i < InputPort.InputCount; i++)
        {
            Console.WriteLine($"Device {i}:{InputPort.GetDeviceInfo(i)}");
        }
    }

}

// Generate test class for LaunchpadWriteCommand
// Path: LaunchpadWriteCommandTest.cs

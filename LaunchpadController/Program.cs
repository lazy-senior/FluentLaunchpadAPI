using Launchpad.Core.Commands;
using Launchpad.Core.Enums;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

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


    }

}


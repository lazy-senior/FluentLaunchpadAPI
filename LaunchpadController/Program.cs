using Launchpad.Core;
using Launchpad.Core.Enums;
using Launchpad.Core.Enums.LED;
using Launchpad.Core.Fluent.Commands;
using Launchpad.Core.Midi;

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

        var launchpad = new LaunchpadDevice();
        
        var writeCommand = LaunchpadWriteCommand
                .TurnOn(16 * 1 + 1)
                .Green(Brightness.Full)
                .Red(Brightness.Full)
                .ToByteArray();

        launchpad.AddGridButtonPressedHandler(MidiOut_OnGridButtonPressed);
        launchpad.AddAutomapButtonPressedHandler(MidiOut_OnAutomapButtonPressed);

        if (!launchpad.OpenOut())
        {
            Console.WriteLine("Launchpad-Device not found");
        }

        Console.ReadLine();

        launchpad.CloseOut();
    }

    private static void MidiOut_OnAutomapButtonPressed(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e)
    {
        if(e.Key == AutomapButtons.Mixer && e.Velocity == InputMessageVelocity.KeyDown)
        {
            Console.WriteLine("Mixer-Button pressed down");
        }
    }

    private static void MidiOut_OnGridButtonPressed(object sender, LaunchpadButtonPressedEventArgs<int> e)
    {
        throw new NotImplementedException();
    }
}

// Generate test class for LaunchpadWriteCommand
// Path: LaunchpadWriteCommandTest.cs
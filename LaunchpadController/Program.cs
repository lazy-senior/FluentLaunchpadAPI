using Launchpad.Core;
using Launchpad.Core.Enums;
using Launchpad.Core.Enums.LED;
using Launchpad.Core.Fluent.Commands;
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
                .Green(Brightness.Full)
                .Red(Brightness.Full)
                .ToByteArray();

        for (; midiNumber < InputPort.InputCount; midiNumber++)
        {
            InputPort.GetDeviceInfo(midiNumber, out midiInCaps);
            if (midiInCaps.szPname.Contains("Launchpad"))
            {
                break;
            }
        }

        Console.WriteLine($"Device {midiNumber}:{midiInCaps.ToString()}");

        midiIn.OnGridButtonPressed += MidiIn_OnGridButtonPressed;
        midiIn.OnAutomapButtonPressed += MidiIn_OnAutomapButtonPressed;

        var openReturnCode = midiIn.Open(midiNumber);
        var startReturnCode = midiIn.Start();

        Console.WriteLine($"OpenReturnCode: {openReturnCode}");
        Console.WriteLine($"StartReturnCode: {startReturnCode}");

        Console.ReadLine();

        midiIn.Close();
    }

    private static void MidiIn_OnAutomapButtonPressed(object sender, LaunchpadButtonPressedEventArgs<AutomapButtons> e)
    {
        Console.WriteLine("OnAutomapButtonPressed:" + e.MessageType.ToString() + " " + e.Key.ToString() + " " + e.Velocity.ToString());
    }

    private static void MidiIn_OnGridButtonPressed(object sender, LaunchpadButtonPressedEventArgs<int> e)
    {
        Console.WriteLine("OnGridButtonPressed:" + e.MessageType.ToString() + " " + e.Key + " " + e.Velocity.ToString());
    }
}

// Generate test class for LaunchpadWriteCommand
// Path: LaunchpadWriteCommandTest.cs
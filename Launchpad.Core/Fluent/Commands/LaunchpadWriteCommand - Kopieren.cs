using Launchpad.Core.Enums;
using Launchpad.Core.Commands;
using Launchpad.Core.Fluent.Commands.Interfaces;

namespace Launchpad.Core.Fluent.Commands
{
    public sealed class LaunchpadReadCommand : LaunchpadCommandBase
    {
        private LaunchpadReadCommand() : base()
        {
        }

        public static LaunchpadLEDCommand TurnOn(int key) => new LaunchpadLEDCommand(OutputMessageType.NoteOn, key);

        public static ILaunchpadCommand TurnOff(int key) => new LaunchpadWriteCommand(OutputMessageType.NoteOff, key);

        public new static ILaunchpadCommand Reset() => new LaunchpadWriteCommand(OutputMessageType.ControllerChange);

        public static ILaunchpadCommand GridMappingMode(GridMappingMode gridMappingMode) => new LaunchpadWriteCommand(OutputMessageType.ControllerChange, 0, (int)gridMappingMode);
    }
}
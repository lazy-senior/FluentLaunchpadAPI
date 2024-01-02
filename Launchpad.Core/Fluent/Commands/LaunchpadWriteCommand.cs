using Launchpad.Core.Enums;
using Launchpad.Core.Fluent.Commands.Interfaces;

namespace Launchpad.Core.Fluent.Commands
{
    public sealed class LaunchpadWriteCommand : LaunchpadCommandBase
    {
        private LaunchpadWriteCommand(OutputMessageType messageType) : base(messageType)
        {
        }

        private LaunchpadWriteCommand(OutputMessageType messageType, int key) : base(messageType, key)
        {
        }

        private LaunchpadWriteCommand(OutputMessageType messageType, int key, int velocity) : base(messageType, key, velocity)
        {
        }

        public static LaunchpadLEDCommand TurnOn(int key) => new LaunchpadLEDCommand(OutputMessageType.NoteOn, key);

        public static LaunchpadLEDCommand TurnOff(int key) => new LaunchpadLEDCommand(OutputMessageType.NoteOff, key);

        public new static ILaunchpadCommand Reset() => new LaunchpadWriteCommand(OutputMessageType.ControllerChange);

        public static ILaunchpadCommand GridMappingMode(GridMappingMode gridMappingMode) => new LaunchpadWriteCommand(OutputMessageType.ControllerChange, 0, (int)gridMappingMode);
    }
}
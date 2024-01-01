using Launchpad.Core.Commands.Interfaces;
using Launchpad.Core.Enums;

namespace Launchpad.Core.Commands
{
    public sealed class LaunchpadWriteCommand : LaunchpadCommandsBase
    {
        private LaunchpadWriteCommand(InputMessageType messageType) : base(messageType)
        {
        }

        private LaunchpadWriteCommand(InputMessageType messageType, int key) : base(messageType, key)
        {
        }

        private LaunchpadWriteCommand(InputMessageType messageType, int key, int velocity) : base(messageType, key, velocity)
        {
        }

        public static LaunchpadLEDCommands TurnOn(int key) => new LaunchpadLEDCommands(InputMessageType.NoteOn, key);

        public static ILaunchpadCommandsBase TurnOff(int key) => new LaunchpadWriteCommand(InputMessageType.NoteOff, key);

        public new static ILaunchpadCommandsBase Reset() => new LaunchpadWriteCommand(InputMessageType.ControllerChange);

        public static ILaunchpadCommandsBase GridMappingMode(GridMappingMode gridMappingMode) => new LaunchpadWriteCommand(InputMessageType.ControllerChange, 0, (int)gridMappingMode);
    }
}
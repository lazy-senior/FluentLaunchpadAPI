using Launchpad.Core.Commands.Interfaces;
using Launchpad.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Commands
{
    public sealed class LaunchpadWriteCommand: LaunchpadCommandsBase
    {
        private LaunchpadWriteCommand(MessageType messageType) : base(messageType) { }
        private LaunchpadWriteCommand(MessageType messageType, int key) : base(messageType, key) { }
        private LaunchpadWriteCommand(MessageType messageType, int key, int velocity) : base(messageType, key, velocity) { }

        public static LaunchpadLEDCommands TurnOn(int key) => new LaunchpadLEDCommands(MessageType.NoteOn, key);
        public static ILaunchpadCommandsBase TurnOff(int key) => new LaunchpadWriteCommand(MessageType.NoteOff, key);
        public static new ILaunchpadCommandsBase Reset() => new LaunchpadWriteCommand(MessageType.ControllerChange);
        public static ILaunchpadCommandsBase GridMappingMode(GridMappingMode gridMappingMode) => new LaunchpadWriteCommand(MessageType.ControllerChange, 0, (int) gridMappingMode);


    }
}

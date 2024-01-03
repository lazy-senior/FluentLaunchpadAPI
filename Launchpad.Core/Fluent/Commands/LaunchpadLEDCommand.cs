using Launchpad.Core.Enums;
using Launchpad.Core.Enums.LED;

namespace Launchpad.Core.Fluent.Commands
{
    public class LaunchpadLEDCommand : LaunchpadCommandBase
    {
        internal LaunchpadLEDCommand(OutputMessageType messageType, int key) : base(messageType, key)
        {
            _command[2] = (byte)VelocityFlags.Normal;
        }

        #region ILaunchpadLEDCommands

        public LaunchpadLEDCommand Green(Brightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)Colors.Green);
            return this;
        }

        public LaunchpadLEDCommand Red(Brightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)Colors.Red);
            return this;
        }

        public LaunchpadLEDCommand Clear()
        {
            _command[2] |= 1 << (int)Colors.Clear;
            return this;
        }

        public LaunchpadLEDCommand Copy()
        {
            _command[2] |= 1 << (int)Colors.Copy;
            return this;
        }

        public LaunchpadLEDCommand Flash()
        {
            _command[2] += (int)VelocityFlags.Flash;
            return this;
        }

        #endregion ILaunchpadLEDCommands
    }
}
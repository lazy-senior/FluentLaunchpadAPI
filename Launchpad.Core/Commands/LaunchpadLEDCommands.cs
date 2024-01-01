using Launchpad.Core.Enums;
using Launchpad.Core.Enums.LED;

namespace Launchpad.Core.Commands
{
    public class LaunchpadLEDCommands : LaunchpadCommandsBase
    {
        internal LaunchpadLEDCommands(InputMessageType messageType, int key) : base(messageType, key)
        {
            _command[2] = (byte)VelocityFlags.Normal;
        }

        #region ILaunchpadLEDCommands

        public LaunchpadLEDCommands Green(Brightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)Colors.Green);
            return this;
        }

        public LaunchpadLEDCommands Red(Brightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)Colors.Red);
            return this;
        }

        public LaunchpadLEDCommands Clear()
        {
            _command[2] |= 1 << (int)Colors.Clear;
            return this;
        }

        public LaunchpadLEDCommands Copy()
        {
            _command[2] |= 1 << (int)Colors.Copy;
            return this;
        }

        public LaunchpadLEDCommands Flash()
        {
            _command[2] += (int)VelocityFlags.Flash;
            return this;
        }

        #endregion ILaunchpadLEDCommands
    }
}
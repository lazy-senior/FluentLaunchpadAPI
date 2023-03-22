using Launchpad.Core.Commands.Interfaces;
using Launchpad.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Commands
{
    public class LaunchpadLEDCommands: LaunchpadCommandsBase
    {
        internal LaunchpadLEDCommands(MessageType messageType, int key): base(messageType, key)
        {
            _command[2] = (byte)LEDVelocityFlags.Normal;
        }

        #region ILaunchpadLEDCommands

        public LaunchpadLEDCommands Green(LEDBrightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)LEDVelocityBits.Green);
            return this;
        }

        public LaunchpadLEDCommands Red(LEDBrightness brightness)
        {
            _command[2] |= (byte)((int)brightness << (int)LEDVelocityBits.Red);
            return this;
        }

        public LaunchpadLEDCommands Clear()
        {
            _command[2] |= 1 << (int)LEDVelocityBits.Clear;
            return this;
        }

        public LaunchpadLEDCommands Copy()
        {
            _command[2] |= 1 << (int)LEDVelocityBits.Copy;
            return this;
        }

        public LaunchpadLEDCommands Flash()
        {
            _command[2] += (int)LEDVelocityFlags.Flash;
            return this;
        }
        #endregion
    }
}

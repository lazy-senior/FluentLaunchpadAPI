using Launchpad.Core.Commands.Interfaces;
using Launchpad.Core.Enums;

namespace Launchpad.Core.Commands
{
    public class LaunchpadCommandsBase : ILaunchpadCommandsBase
    {
        protected byte[] _command;

        protected LaunchpadCommandsBase()
        {
            _command = new byte[4];
        }

        protected LaunchpadCommandsBase(InputMessageType messageType) : this()
        {
            _command[0] = (byte)messageType;
        }

        protected LaunchpadCommandsBase(InputMessageType messageType, int key) : this(messageType)
        {
            _command[1] = (byte)key;
        }

        protected LaunchpadCommandsBase(InputMessageType messageType, int key, int velocity) : this(messageType, key)
        {
            _command[2] = (byte)velocity;
        }

        public ILaunchpadCommandsBase Reset()
        {
            _command = new byte[] { (int)InputMessageType.ControllerChange, 0, 0 };
            return this;
        }

        public byte[] ToByteArray()
        {
            return _command;
        }

        public int ToInt()
        {
            return _command[0] << 16 | _command[1] << 8 | _command[2];
        }
    }
}
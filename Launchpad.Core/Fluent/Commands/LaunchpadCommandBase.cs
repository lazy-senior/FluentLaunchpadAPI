using Launchpad.Core.Enums;
using Launchpad.Core.Fluent.Commands.Interfaces;

namespace Launchpad.Core.Fluent.Commands
{
    public class LaunchpadCommandBase : ILaunchpadCommand
    {
        protected byte[] _command;

        protected LaunchpadCommandBase()
        {
            _command = new byte[4];
        }

        protected LaunchpadCommandBase(OutputMessageType messageType) : this()
        {
            _command[0] = (byte)messageType;
        }

        protected LaunchpadCommandBase(OutputMessageType messageType, int key) : this(messageType)
        {
            _command[1] = (byte)key;
        }

        protected LaunchpadCommandBase(OutputMessageType messageType, int key, int velocity) : this(messageType, key)
        {
            _command[2] = (byte)velocity;
        }

        public ILaunchpadCommand Reset()
        {
            _command = new byte[] { (int)OutputMessageType.ControllerChange, 0, 0 };
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
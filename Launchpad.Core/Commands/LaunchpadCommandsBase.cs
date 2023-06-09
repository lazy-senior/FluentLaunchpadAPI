﻿using Launchpad.Core.Commands.Interfaces;
using Launchpad.Core.Enums;

namespace Launchpad.Core.Commands
{
    public class LaunchpadCommandsBase: ILaunchpadCommandsBase
    {
        protected byte[] _command;

        protected LaunchpadCommandsBase()
        {
            _command = new byte[3];
        }
        protected LaunchpadCommandsBase(MessageType messageType): this()
        {
            _command[0] = (byte)messageType;
        }
        protected LaunchpadCommandsBase(MessageType messageType, int key): this(messageType)
        {
            _command[1] = (byte)key;
        }
        protected LaunchpadCommandsBase(MessageType messageType, int key, int velocity): this(messageType, key)
        {
            _command[2] = (byte)velocity;
        }

        public ILaunchpadCommandsBase Reset()
        {
            _command = new byte[] { (int)MessageType.ControllerChange, 0, 0 };
            return this;
        }

        public byte[] ToByteArray()
        {
            return _command;
        }
    }
}
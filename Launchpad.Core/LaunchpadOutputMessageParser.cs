using Launchpad.Core.Enums;
using System;

namespace Launchpad.Core
{
	public class LaunchpadOutputMessageParser
	{

		public const int GRID_KEY_MIN = 0x00;
		public const int GRID_KEY_MAX = 0x78;

		public const int AUTOMAP_KEY_MIN = 0x68;
		public const int AUTOMAP_KEY_MAX = 0x6F;

		public static bool TryParse(int bytes, out LaunchpadOutputMessageEventArgs launchpadOutputMessageEventArgs)
		{
			launchpadOutputMessageEventArgs = new();
			byte[] intBytes = BitConverter.GetBytes(bytes);
			return TryParse(intBytes[0], intBytes[1], intBytes[2], out launchpadOutputMessageEventArgs);
		}

		public static bool TryParse(int command, int key, int velocity, out LaunchpadOutputMessageEventArgs launchpadOutputMessageEventArgs)
		{
			launchpadOutputMessageEventArgs = new();

			if (Enum.GetName(typeof(OutputMessageType), command) == null)
			{
				Console.WriteLine($"Command not found:{command}");
				return false;
			}

			if (Enum.GetName(typeof(OutputMessageVelocity), velocity) == null)
			{
                Console.WriteLine($"Velocity not found:{velocity}");
                return false;
			}

			
			var outputMessageType = (OutputMessageType)command;
			var outputMessageVelocity = (OutputMessageVelocity)velocity;
			var outputMessageKey = key;

			if ((outputMessageType == OutputMessageType.GridButtonPress && (key < GRID_KEY_MIN || key > GRID_KEY_MAX)) ||
				(outputMessageType == OutputMessageType.AutomapButtonPress && (key < AUTOMAP_KEY_MIN || key > AUTOMAP_KEY_MAX)))
			{
				return false;
			}

			launchpadOutputMessageEventArgs = new LaunchpadOutputMessageEventArgs()
			{
				MessageType = outputMessageType,
				Key = outputMessageKey,
				Velocity = outputMessageVelocity
			};

			return true;
		}
	}
}

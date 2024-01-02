using Launchpad.Core.Enums;

namespace Launchpad.Core
{
    public class LaunchpadOutputMessageParser
    {
        public const int GRID_KEY_MIN = 0x00;
        public const int GRID_KEY_MAX = 0x78;

        public const int AUTOMAP_KEY_MIN = 0x68;
        public const int AUTOMAP_KEY_MAX = 0x6F;

        public static bool TryParse<T>(int bytes, out LaunchpadButtonPressedEventArgs<T> launchpadOutputMessageEventArgs)
        {
            launchpadOutputMessageEventArgs = new();
            byte[] intBytes = BitConverter.GetBytes(bytes);
            return TryParse(intBytes[0], intBytes[1], intBytes[2], out launchpadOutputMessageEventArgs);
        }

        public static bool TryParse<T>(int command, int key, int velocity, out LaunchpadButtonPressedEventArgs<T> launchpadOutputMessageEventArgs)
        {
            launchpadOutputMessageEventArgs = new();
            T outputMessageKey = default;

            if (Enum.GetName(typeof(InputMessageType), command) == null)
            {
                Console.WriteLine($"Command not found:{command}");
                return false;
            }

            if (Enum.GetName(typeof(InputMessageVelocity), velocity) == null)
            {
                Console.WriteLine($"Velocity not found:{velocity}");
                return false;
            }

            var outputMessageType = (InputMessageType)command;
            var outputMessageVelocity = (InputMessageVelocity)velocity;

            if (typeof(T) == typeof(int) && outputMessageType == InputMessageType.GridButtonPress)
            {
                if (key < GRID_KEY_MIN || key > GRID_KEY_MAX)
                {
                    return false;
                }
                outputMessageKey = (T)(object)key;
            }
            else if (typeof(T) == typeof(AutomapButtons) && outputMessageType == InputMessageType.AutomapButtonPress)
            {
                if (key < AUTOMAP_KEY_MIN || key > AUTOMAP_KEY_MAX)
                {
                    return false;
                }
                outputMessageKey = (T)(object)(AutomapButtons)key;
            }
            else
            {
                return false;
            }

            launchpadOutputMessageEventArgs = new LaunchpadButtonPressedEventArgs<T>()
            {
                MessageType = outputMessageType,
                Key = outputMessageKey,
                Velocity = outputMessageVelocity
            };

            return true;
        }
    }
}
using Launchpad.Core.Enums;

namespace Launchpad.Core
{
    public class LaunchpadButtonPressedEventArgs<T> : EventArgs
    {
        public InputMessageType MessageType { get; set; }
        public T? Key { get; set; }
        public InputMessageVelocity Velocity { get; set; }
    }
}
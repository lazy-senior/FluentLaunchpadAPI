using Launchpad.Core.Enums;

namespace Launchpad.Core
{
    public class LaunchpadButtonPressedEventArgs<T> : EventArgs
    {
        public OutputMessageType MessageType { get; set; }
        public T? Key { get; set; }
        public OutputMessageVelocity Velocity { get; set; }
    }
}
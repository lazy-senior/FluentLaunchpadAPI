namespace Launchpad.Core.Fluent.Commands.Interfaces
{
    public interface ILaunchpadCommand
    {
        public byte[] ToByteArray();

        public int ToInt();
    }
}
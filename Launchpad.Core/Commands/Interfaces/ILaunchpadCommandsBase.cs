namespace Launchpad.Core.Commands.Interfaces
{
    public interface ILaunchpadCommandsBase
    {
        public byte[] ToByteArray();

        public int ToInt();
    }
}
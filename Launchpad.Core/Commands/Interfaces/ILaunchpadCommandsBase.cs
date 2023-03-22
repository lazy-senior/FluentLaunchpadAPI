using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Commands.Interfaces
{
    public interface ILaunchpadCommandsBase
    {
        public byte[] ToByteArray();
    }
}

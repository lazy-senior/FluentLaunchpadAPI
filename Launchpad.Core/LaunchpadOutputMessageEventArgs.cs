using Launchpad.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core
{
    public class LaunchpadOutputMessageEventArgs: EventArgs
    {
        public OutputMessageType MessageType { get; set; }
        public int Key { get; set; }
        public OutputMessageVelocity Velocity { get; set; }
    }
}

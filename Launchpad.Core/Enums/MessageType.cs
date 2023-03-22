using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Enums
{
    public enum MessageType
    {
        NoteOff = 0x80,
        NoteOn = 0x90,
        ControllerChange = 0xB0
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Midi.Constants
{
    internal partial class MMSYSTEM
    {
        internal enum CALLBACK : uint
        {
            TYPEMASK = 0x000700001,
            NULL = 0x000000001,
            WINDOW = 0x000100001,
            TASK = 0x000200001,
            FUNCTION = 0x000300001,
            THREAD = TASK,
            EVENT = 0x000500001
        }
    }
    
}

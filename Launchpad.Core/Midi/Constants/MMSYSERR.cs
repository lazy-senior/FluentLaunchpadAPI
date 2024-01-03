﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launchpad.Core.Midi.Constants
{
    internal partial class MMSYSTEM
    {
        public enum MMSYSERR : uint
        {
            NOERROR = 0,
            ERROR = 1,
            BADDEVICEID = 2,
            NOTENABLED = 3,
            ALLOCATED = 4,
            INVALHANDLE = 5,
            NODRIVER = 6,
            NOMEM = 7,
            NOTSUPPORTED = 8,
            BADERRNUM = 9,
            INVALFLAG = 10,
            INVALPARAM = 11,
            HANDLEBUSY = 12,
            INVALIDALIAS = 13,
            BADDB = 14,
            KEYNOTFOUND = 15,
            READERROR = 16,
            WRITEERROR = 17,
            DELETEERROR = 18,
            VALNOTFOUND = 19,
            NODRIVERCB = 20,
            MOREDATA = 21,
            LASTERROR = 21,
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.helpers
{
    public class IDHelper
    {
        public static long ID()
        {
            return ((DateTimeOffset)DateTime.Now.ToUniversalTime()).ToUnixTimeMilliseconds();
        }
    }
}

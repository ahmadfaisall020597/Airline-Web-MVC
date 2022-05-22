using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class Chat
    {

        public long ID { get; set; }
        public string Message { get; set; }

        public int SenderType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class Action
    {
        public int ActionID { get; set; }

        public ConsoleKey ActionKey { get; set; }
        public string ActionName { get; set; }
    }
}

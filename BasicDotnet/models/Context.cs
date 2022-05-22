using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.models
{
    public class Context
    { 
        public long ID { get; set; }

        public List<Dialog> Dialogs { get; set; }
        public List<Response> Responses { get; set; }
        public string ContextName { get; internal set; }

        public Context() { 
            
            this.Dialogs = new List<Dialog>();

            this.Responses = new List<Response>();


        }
    }

}

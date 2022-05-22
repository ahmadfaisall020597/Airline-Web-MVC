using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Context
{
    public class ContextsListView
    {

        private services.ContextService _contextService;


        //dependency injection
        public ContextsListView(services.ContextService contextService)
        {
            _contextService = contextService;
        }

        public void PrintContextsList()
        {
            var _contexts = _contextService.GetContexts();

            if (_contexts.Count > 0)
            {
                Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
                Console.WriteLine("List Contexts");
                for (int i = 0; i < _contexts.Count; i++)
                {
                    ContextViewHelper.printContext(_contexts[i]);
                }
            }
            else
            {
                Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
                Console.WriteLine("Contexts belum ada");
                Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
            }
           
        }




    }
}

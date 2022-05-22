using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Context
{
    public  class ContextViewHelper
    {
        public static  void printContext(models.Context context)
        {
            
            Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
            Console.WriteLine("Contexts:");
            Console.WriteLine("- " + context.ContextName);
            printDialogs(context.Dialogs);
            printResponses(context.Responses);
            Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
        }

        private static void printDialogs(List<models.Dialog> dialogs)
        {
            Console.WriteLine("Dialogs:");
            if(dialogs.Count ==0)
            {
                Console.WriteLine("Dialogs still empty");

            } else
            {
                for (int i = 0; i < dialogs.Count; i++)
                {
                    Console.WriteLine("\t- " + dialogs[i].Conversation);

                }

            }
            
            Console.WriteLine();
        }

        private static void printResponses(List<models.Response> responses)
        {
            Console.WriteLine("Responses:");
            if(responses.Count == 0)
            {
                Console.WriteLine("Responses still empty");

            } else
            {
                for (int i = 0; i < responses.Count; i++)
                {
                    Console.WriteLine("\t- " + responses[i].Text);

                }

            }
           
            Console.WriteLine();
        }

    }
}

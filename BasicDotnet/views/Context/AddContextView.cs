using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Context
{
    public class AddContextView
    {

        private services.ContextService _contextService;

        public AddContextView(services.ContextService contextService)
        {
            _contextService = contextService;
        }


        public void PrintView()
        {

           
            Console.Clear();
            Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
            Console.WriteLine("Add New Context");
            Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));

            var _tempContext = new models.Context();
            
            while (true)
            {
                Console.Write("Context Name:");
                _tempContext.ContextName = Console.ReadLine();
                if(!string.IsNullOrEmpty(_tempContext.ContextName))
                {
                    break;
                }
            }

            ContextViewHelper.printContext(_tempContext);

            while (true)
            { 
                
                Console.Write("Enter Dialog [Or Type exit]:");

                var dialog = Console.ReadLine();
                if (!string.IsNullOrEmpty(dialog))
                {
                    if(dialog == "exit")
                    {
                        break;
                    }

                    var _dialog = new models.Dialog();
                    _dialog.Conversation = dialog;
                    _tempContext.Dialogs.Add(_dialog);

                }

                ContextViewHelper.printContext(_tempContext);
                Console.WriteLine();

            }


            while (true)
            {  
                Console.Write("Enter Response [Or Type exit]:");

                var resp = Console.ReadLine();
                if (!string.IsNullOrEmpty(resp))
                {
                    if (resp == "exit")
                    {
                        break;
                    }
                    _tempContext.Responses.Add(new models.Response()
                    {
                        Text = resp
                    });

                }

                ContextViewHelper.printContext(_tempContext);
                Console.WriteLine();

            }

            try
            {
                
                _ = _contextService.AddNewContext(_tempContext.ContextName,
               _tempContext.Dialogs,
               _tempContext.Responses);
                Console.WriteLine("Context Added Successfully");

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Chatbot
{
    public class ChatbotActionView
    {

        private services.ChatbotActionService _chatbotActionService;

        public ChatbotActionView(services.ChatbotActionService chatbotActionService)
        {
            _chatbotActionService = chatbotActionService;
        }

        public void PrintActions()
        {
            var actions = _chatbotActionService.GetActions();
            for (int i=0;i<actions.Count;i++)
            {
                Console.WriteLine("{0}",actions[i].ActionName);
            }


            
        }

    }
}

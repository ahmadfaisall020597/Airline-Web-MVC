using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Chatbot
{
    public class Chatbot
    {

        //services
        private services.ContextService _contextService;
        private services.ChatService _chatService;
        private services.ChatbotActionService _chatbotActionService;

        //views
        private ChatbotActionView _chatbotActionView;
        private Context.ContextsListView _contextsListView;
        private Context.AddContextView _addContextView;
        private Chat.ChatsListView _chatsListView;



        public Chatbot()
        {

            _contextService = new services.ContextService();
            _chatbotActionService = new services.ChatbotActionService();
            _chatService = new services.ChatService(_contextService);


            _chatbotActionView = new ChatbotActionView(_chatbotActionService);
            _contextsListView = new Context.ContextsListView(_contextService);
            _addContextView = new Context.AddContextView(_contextService);
            _chatsListView = new Chat.ChatsListView(_chatService);

            var loop = true;
            while(loop)
            {
                Console.Clear();

                _contextsListView.PrintContextsList();
                
                _chatbotActionView.PrintActions();

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.F1:
                        _addContextView.PrintView();
                        break;

                    case ConsoleKey.F2:
                        _chatsListView.PrintChatsList();
                        break;

                    case ConsoleKey.Escape:
                        loop = false;
                        break;
                }
                Console.ReadKey();
            }


        }


    }
}

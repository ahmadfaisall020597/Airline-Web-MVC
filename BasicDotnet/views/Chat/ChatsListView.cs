using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.views.Chat
{
    public class ChatsListView
    {
        private services.ChatService _chatService;
        public ChatsListView(services.ChatService chatService)
        {
            _chatService = chatService;

        }

        public void PrintChatsList()
        {

            while(true)
            {
                Console.Clear();
                Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));
                Console.WriteLine("Chats List");
                Console.Write(helpers.ConsoleFormatter.MakeLine(60, "-", true));

                var _chats = _chatService.GetChats();
                for (int i = 0; i < _chats.Count; i++)
                {
                    var _chat = _chats[i];
                    if (_chat.SenderType == services.ChatService.SENDER_TYPE_USER)
                    {

                        var field = helpers.ConsoleFormatter.field(60,
                            _chat.Message,
                            helpers.ConsoleFormatter.ALIGN_RIGHT,
                            ' ',
                            "");

                        var row = helpers.ConsoleFormatter.row(new string[]{
                            field
                        });

                        Console.Write(row);

                    } else if (_chat.SenderType == services.ChatService.SENDER_TYPE_BOT)
                    {

                        var field = helpers.ConsoleFormatter.field(60,
                            _chat.Message,
                            helpers.ConsoleFormatter.ALIGN_LEFT,
                            ' ',
                            "");

                        var row = helpers.ConsoleFormatter.row(new string[]{
                            field
                        });

                        Console.Write(row);
                    }
                }

                Console.Write("\nType Your Message[type exit to exit]:");
                var input = Console.ReadLine(); 
                if(!string.IsNullOrEmpty(input))
                {
                    if(input=="exit")
                    {
                        break;
                    } else
                    {
                        _chatService.SendChat(input);
                    }
                }

            }
        }
    }
}

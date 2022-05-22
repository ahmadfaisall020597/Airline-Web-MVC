using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.services
{
    public class ChatService
    {

        public const int SENDER_TYPE_USER = 1;
        public const int SENDER_TYPE_BOT = 2;

        public List<models.Chat> _chats = new List<models.Chat>();

        private ContextService _contextService;
        public ChatService(ContextService contextService)
        {
            _contextService = contextService;
        }

        private Exception? validateSendChat(string message)
        {
            if(string.IsNullOrEmpty(message))
            {
                throw new Exception("chat_message_is_required");
            }
            return null;
        }

        public List<models.Chat> GetChats()
        {
            return _chats;
        }

        public void SendChat(string message)
        {
            validateSendChat(message);

            models.Chat _chat = new models.Chat();
            _chat.Message = message;
            _chat.ID = helpers.IDHelper.ID();
            _chat.SenderType = SENDER_TYPE_USER;
            _chats.Add(_chat);


            //calculate reply

            _chat = new models.Chat();
            _chat.Message = _contextService.CalculateReply(message);
            _chat.ID = helpers.IDHelper.ID();
            _chat.SenderType = SENDER_TYPE_BOT;
            _chats.Add(_chat);

        }
    }
}

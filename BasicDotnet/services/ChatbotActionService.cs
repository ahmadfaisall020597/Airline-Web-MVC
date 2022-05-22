using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.services
{
    public class ChatbotActionService
    {

        public const int ACTION_ADD_NEW_CONTEXT = 1;
        public const int ACTION_SEND_CHAT = 2;
        public const int ACTION_EXIT = 3;

        private List<models.Action> _actions = new List<models.Action>();

        public List<models.Action> GetActions()
        {
            return _actions;
        }


        //constructor
        public ChatbotActionService()
        {
            _actions.Add(new models.Action()
            {
                ActionID = ACTION_ADD_NEW_CONTEXT,
                ActionKey = ConsoleKey.F1,
                ActionName = "F1. Add New Context"

            });
            _actions.Add(new models.Action()
            {
                ActionID = ACTION_SEND_CHAT,
                ActionKey = ConsoleKey.F2,
                ActionName = "F2. Send Chat"
            });

            _actions.Add(new models.Action()
            {
                ActionID = ACTION_SEND_CHAT,
                ActionKey = ConsoleKey.Escape,
                ActionName = "Esc. Exit"
            });

        }
    }
}

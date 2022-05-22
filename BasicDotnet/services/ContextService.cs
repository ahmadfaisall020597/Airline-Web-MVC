using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.services
{
    public class ContextService
    {

        private List<models.Context> _contexts = new List<models.Context>();
        
        public List<models.Context> Contexts
        {
            get
            {
                return _contexts;
            }
        }

        public List<models.Context> GetContexts()
        {
            return _contexts;
        }

        private Exception? validateAddNewContext(string contextName,
            List<models.Dialog> dialogs,
            List<models.Response> responses)
        {
            if(string.IsNullOrEmpty(contextName))
            {
                throw new Exception("context_name_is_required");
            }


            if(dialogs==null)
            {
                throw new Exception("dialogs_is_required");
            }
            foreach(models.Dialog dialog in dialogs)
            {
                if (string.IsNullOrEmpty(dialog.Conversation))
                {
                    throw new Exception("dialog_conversion_is_required");
                }
            }

            if(responses == null)
            {
                throw new Exception("responses_is_required");
            }

            foreach(models.Response response in responses)
            {
                if(string.IsNullOrEmpty(response.Text))
                {
                    throw new Exception("response_text_is_required");
                }
            }

            return null;

        }

        public long? AddNewContext(string contextName,
            List<models.Dialog> dialogs,
            List<models.Response> responses)
        {

            validateAddNewContext(contextName,
                dialogs,
                responses);

           
            models.Context _context = new models.Context();
            _context.ContextName = contextName;
            _context.ID = helpers.IDHelper.ID();
            _context.Dialogs = dialogs;
            _context.Responses = responses;

            _contexts.Add(_context);

            return _context.ID;


        }


        public string CalculateReply(string input)
        {
            /*
            -salam
                - met pagi
                - met sore
                - met sore sore

                - selamat pagi pak
                - selamat sore pak
                - selamat malam pak

            -tanya kabar
                - apa kabar
                - gimana kabar mu ?
                - kamu baik baik saja kan
            */

            Dictionary<string, Dictionary<string, int>> _contextsCount = new Dictionary<string, Dictionary<string, int>>();

            for (int i=0;i<_contexts.Count;i++)
            {
                var _context = _contexts[i];
                Dictionary<string, int> _wordsCount = new Dictionary<string, int>();

                for (int j=0;j<_context.Dialogs.Count;j++)
                {
                    var _dialog = _context.Dialogs[j];
                    var _conversations = _dialog.Conversation.Split(" ");
                    
                    foreach (var word in _conversations)
                    {
                        var wordLower = word.ToLower();
                        if(_wordsCount.ContainsKey(wordLower))
                        {
                            _wordsCount[wordLower] = _wordsCount[wordLower] + 1;
                        } else
                        {
                            _wordsCount[wordLower] = 1;
                        }
                    }

                }

                _contextsCount[_context.ContextName] = _wordsCount;

            }


            var inputs = input.ToLower().Split(" ");


            string maxContext = findMaxContext(inputs,
                _contextsCount);


            string reply = "";
            for (int i=0;i<_contexts.Count;i++)
            {
                if(_contexts[i].ContextName == maxContext)
                {
                    var responseIndex = getResponseIndex(_contexts[i], inputs);

                    reply = _contexts[i].Responses[responseIndex].Text;

                    break;
                }
            }

            if (reply == "")
            {
                reply = "Bot tidak mengerti maksud percakapan Anda";
            }

            return reply;

        }

        private string findMaxContext(
            string[] inputs, 
            Dictionary<string, Dictionary<string, int>> _contextsCount)

        {

            Dictionary<string, int> _findCount = new Dictionary<string, int>();
            for (int i = 0; i < inputs.Length; i++)
            {
                foreach (var _contextCnt in _contextsCount)
                {
                    var _context2 = _contextCnt.Key;
                    var _wordsCount = _contextCnt.Value;


                    foreach (var _wordCnt in _wordsCount)
                    {
                        if (inputs[i] == _wordCnt.Key)
                        {
                            if (_findCount.ContainsKey(_context2))
                            {
                                _findCount[_context2] = _findCount[_context2] + _wordCnt.Value;
                            }
                            else
                            {
                                _findCount[_context2] = _wordCnt.Value;
                            }
                        }

                    }
                }

            }

            int max = 0;
            string maxContext = "";
            foreach (var _fCount in _findCount)
            {
                if (_fCount.Value > max)
                {
                    max = _fCount.Value;
                    maxContext = _fCount.Key;
                }
            }


            return maxContext;
        }

        public int getResponseIndex(models.Context _context,
            string[] inputs)
        {
            /*
             * input : met pagi
             
              - selamat pagi pak
              - selamat sore pak
               - selamat malam pak
             */

            Dictionary<int, Dictionary<string, int>> _responsesCount = new Dictionary<int, Dictionary<string, int>>();
            

            for (int j = 0; j < _context.Responses.Count; j++)
            {
                var _response = _context.Responses[j];
                var _texts = _response.Text.Split(" ");
                Dictionary<string, int> _wordsCount = new Dictionary<string, int>();

                foreach (var word in _texts)
                {
                    var wordLower = word.ToLower();
                    if (_wordsCount.ContainsKey(wordLower))
                    {
                        _wordsCount[wordLower] = _wordsCount[wordLower] + 1;
                    }
                    else
                    {
                        _wordsCount[wordLower] = 1;
                    }
                }

                _responsesCount[j] = _wordsCount;
            }



            Dictionary<int, int> _findCount = new Dictionary<int, int>();
            for (int i = 0; i < inputs.Length; i++)
            {
                var _input = inputs[i];
                foreach (var _respCount in _responsesCount)
                {

                    var wordsCount = _respCount.Value;
                    foreach (var wordCnt in wordsCount)
                    {
                        if(wordCnt.Key == _input)
                        {
                            if (_findCount.ContainsKey(_respCount.Key))
                            {
                                _findCount[_respCount.Key] = _findCount[_respCount.Key] + wordCnt.Value;
                            } else
                            {
                                _findCount[_respCount.Key] = wordCnt.Value;
                            }
                            
                        }
                    }
                    
                }
            }


            int max = 0;
            int maxIndex = -1;
            foreach (var _fCount in _findCount)
            {
                if (_fCount.Value > max)
                {
                    max = _fCount.Value;
                    maxIndex = _fCount.Key;
                }
            }

            if(max == -1)
            {
                Random rnd = new Random();
                max = rnd.Next(0, _context.Responses.Count - 1);
            }

            return max;

        }

    }




}

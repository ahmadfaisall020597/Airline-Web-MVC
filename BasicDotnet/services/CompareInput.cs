using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.services
{
    internal class CompareInput
    {
        private string _input;

        private Dictionary<string, int> _output = new Dictionary<string, int>();
        public CompareInput(string input)
        {
            _input = input;
        }

        /*
         input => split 
        bapak/ibu, apa kabar?

        bapak => 1
        ibu => 
        apa
        kabar

        kemudian dicomparen dengan dict word count
        met => 2
        bapak => 1

         */
        public Dictionary<string, int> Compare(Dictionary<string, int> wordCounts)
        {
            var splitText = Splitter.SplitInput(_input);

            _output.Clear();

            for (int i=0;i<splitText.Length;i++)
            {
                var _input = splitText[i]; 
                foreach (var cnt in wordCounts)
                {
                    if(cnt.Key == _input)
                    {
                        addOutput(cnt.Key, cnt.Value);
                    }
                }
            }

            return _output;

        }

        public void PrintOutput()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Compare Input:");
            Console.WriteLine("=====================================");
            foreach (KeyValuePair<string, int> cnt in _output)
            {
                Console.WriteLine("{0}={1}", cnt.Key, cnt.Value);
            }
            Console.WriteLine("=====================================");
        }

        private void addOutput(string key, int value)
        {
            if(_output.ContainsKey(key))
            {
                _output[key] = _output[key] + value;
            } else
            {
                _output[key] = value;
            }
        }
    }
}

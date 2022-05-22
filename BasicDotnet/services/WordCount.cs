using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BasicDotnet.services
{
    public class WordCount
    {

        Dictionary<string, int> _count = new Dictionary<string, int>();
        /*
         * map =>
         * 
         * met => 2
         * bapak => 1
         */

        public Dictionary<string, int>? Count(string text)
        {
            var splitText = Splitter.SplitInput(text);

            _count.Clear();

            for (int i = 0; i < splitText.Length; i++) {

                var _split = splitText[i];
                if (_count.ContainsKey(splitText[i]))
                {
                    _count[_split] = _count[_split] + 1;

                } else
                {
                    _count[_split] = 1;
                }
            }
            return _count;
        }


        public void PrintCount()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("Word Count:");
            Console.WriteLine("=====================================");
            foreach (KeyValuePair<string, int> cnt in _count)
            {
                Console.WriteLine("{0}={1}", cnt.Key, cnt.Value);
                
            }
            Console.WriteLine("=====================================");
        }
    }
}

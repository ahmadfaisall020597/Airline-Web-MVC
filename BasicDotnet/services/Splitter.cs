using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BasicDotnet.services
{
    internal class Splitter
    {
        public static string[] SplitInput(string input)
        {
            string pattern = @"[\/\\\?,-_\s\&\n\r]+";
            Regex rg = new Regex(pattern);
            var results = rg.Split(input);

            List<string> filter = new List<string>();
            foreach(string result in results)
            {
                if(!string.IsNullOrEmpty(result))
                {
                    filter.Add(result);
                }
            }
            return filter.ToArray();
        }

        public static string[] SplitLine(string input)
        {
            string pattern = @"[\r\n]+";
            Regex rg = new Regex(pattern);
            var results = rg.Split(input);

            List<string> filter = new List<string>();
            foreach (string result in results)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    filter.Add(result);
                }
            }
            return filter.ToArray();
        }
    }
}

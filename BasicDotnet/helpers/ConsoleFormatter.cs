using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDotnet.helpers
{
    public class ConsoleFormatter
    {
        public const int ALIGN_LEFT = 1;
        public const int ALIGN_RIGHT = 2;
        public const int ALIGN_CENTER = 3;

        public static string field(int length, string value, int align, char emptySpace,
          string endDelimiter)
        {
            if (align == ALIGN_LEFT)
            {
                return value.PadRight(length, emptySpace) + endDelimiter;

            } else if (align == ALIGN_RIGHT)
            {
                return value.PadLeft(length, emptySpace) + endDelimiter;

            } else if (align == ALIGN_CENTER)
            {
                int lenPad = (length / 2) - (value.Length / 2);
                length = length + lenPad - 2;
                var padLeft = value.PadLeft(length, emptySpace);

                length = length + lenPad + 2;
                var padRight = padLeft.PadRight(length, emptySpace);
                return padRight + endDelimiter;
            }
            
            return "";
        }

        public static string row(string[] fields)
        {
            StringBuilder _row = new StringBuilder();
            foreach (string field in fields)
            {
                _row.Append(field);
            }
            return _row.Append("\n").ToString();
        }

        public static string MakeLine(int length, string character, bool newLine)
        {
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                line.Append(character);
            }
            if (newLine)
            {
                line.Append("\n");
            }
            return line.ToString();
        }

    }
}

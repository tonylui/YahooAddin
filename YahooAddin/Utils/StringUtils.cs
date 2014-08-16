using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooAddin.Utils
{
    public class StringUtils
    {
        public static string withDoubleQuotes(string input)
        {
            return "\"" + input + "\"";
        }

        public static List<string> withDoubleQuotes(List<string> input)
        {
            List<string> result = new List<string>();
            foreach (var item in input)
            {
                result.Add(withDoubleQuotes(item));
            }

            return result;
        }
    }
}

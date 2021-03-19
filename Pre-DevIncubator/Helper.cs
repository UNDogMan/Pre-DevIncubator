using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre_DevIncubator
{
    public static class Helper
    {
        public static void PrintAllToConsole<T>(this IEnumerable<T> ts)
        {
            foreach(T t in ts)
            {
                Console.WriteLine(t.ToString());
            }
        }

        public static string FirstLetterToUpperCase(this string input)
        {
            return input.First().ToString().ToUpper() + input.Substring(1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_predicate
{
    class Program
    {
        static bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        static void Main(string[] args)
        {
            Predicate<string> isUpper = IsUpperCase;
            Console.WriteLine(isUpper("Ana are mere"));

            //Predicate with anonymous method
            Predicate<string> lower = delegate (string s) { return s.Equals(s.ToLower()); };
            bool result = lower("hello");
            Console.WriteLine(result);

            //Predicate delegate with lambda expression
            Predicate<string> isUp = s => s.Equals(s.ToUpper());
            bool result1 = isUp("hello world!!");
        }
    }
}

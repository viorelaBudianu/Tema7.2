using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AfterLINQCourse
{

    //Problem 1. StringBuilder.Substring
    //Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder and has the same functionality as Substring in the class String.
    public static class StringBuilderExtension
    {
        public static StringBuilder SubstringExtention(this StringBuilder builder, int index, int length)
        {
            var result = new StringBuilder();
            result.Append(builder.ToString().Substring(index, length));
            return result;

        }
    }

    //Problem 2. IEnumerable extensions
    //Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.
    public static 


    class Program
    {


        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder("Ana are mere", 20);
            Console.WriteLine(s);
            Console.WriteLine(s.SubstringExtention(1,9));
        }
    }
}

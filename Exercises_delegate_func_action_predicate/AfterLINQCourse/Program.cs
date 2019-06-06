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
    public static class IEnumerableExtension
    {
        public static dynamic Sum<T>(this IEnumerable<T> elements)
        {
            dynamic sum = default(T);

            foreach (T item in elements)
                sum += item;

            return sum;
        }
        public static dynamic Product<T>(this IEnumerable<T> elements)
        {
            dynamic prod = 1;

            foreach (T item in elements)
                prod *= item;

            return prod;
        }

        public static dynamic Average<T>(this IEnumerable<T> elements)
        {
            return elements.Sum() / elements.Count();
        }

        public static T Min<T>(this IEnumerable<T> elements)
        {
            dynamic min = long.MaxValue;

            foreach (T item in elements)
                if (item < min)
                    min = item;

            return min;
        }

        public static T Max<T>(this IEnumerable<T> elements)
        {
            dynamic max = long.MinValue;

            foreach (T item in elements)
                if (item > max)
                    max = item;

            return max;
        }

        public static int Count<T>(this IEnumerable<T> elements)
        {
            int count = 0;

            foreach (T item in elements)
                count++;

            return count;
        }
    }


    class Program
    {


        static void Main(string[] args)
        {
            StringBuilder s = new StringBuilder("Ana are mere", 20);
            Console.WriteLine(s);
            Console.WriteLine(s.SubstringExtention(1,9));

            //Test for problem 3

            //test for problem 4

            //Problem 5. Order students-Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.Rewrite the same with LINQ.

            //Problem 6 Divisible by 7 and 3 - Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.Use the built-in extension methods and lambda expressions.Rewrite the same with LINQ.


        }
    }
}

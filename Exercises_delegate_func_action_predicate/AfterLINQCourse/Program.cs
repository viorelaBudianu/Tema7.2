using Exercises_delegate_func_action_predicate;
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

    //Problem 7 - Using delegates write a class Timer that can execute certain method at each t seconds.

    public delegate void Timer(int seconds);
       





    class Program
    {
        public static Random rnd = new Random();
        public static string GenerateFN()
        {
            string FN = string.Empty;

            if ((rnd.Next() & 1) == 0)
            {
                FN += "06";
            }

            while (FN.Length < 6)
            {
                FN = FN.Insert(0, rnd.Next(0, 10).ToString());
            }

            return FN;
        }
        public static string GeneratePhoneNumber()
        {
            string s = "07";
            int digitsLeft = 8;
            
            for (int i = digitsLeft; i >= 0; i--)
            {
                s += rnd.Next(0, 10);
            }

            return s;
        }

        static void Main(string[] args)
        {
            // TestProblem1();

            List<Student> students = new List<Student>
            {
                 new Student("Alex", "Budianu", 24,  GenerateFN(), GeneratePhoneNumber(), 3, "alex.budianu@gmail.com"),
                new Student("Vio", "Budianu", 24, GenerateFN(), GeneratePhoneNumber(), 2, "vio.budianu@gmail.com"),
                new Student("Ana", "Ionescu", 20,  GenerateFN(), GeneratePhoneNumber(), 3, "ana@gmail.com"),
                new Student("Emi", "Budianu", 21, GenerateFN(), GeneratePhoneNumber(), 2, "emi.budianu@gmail.com"),
                new Student("Florin", "Leonte", 17,  GenerateFN(),GeneratePhoneNumber(), 4, "florinl@gmail.com"),
                new Student("Tatiana", "Daud", 32,  GenerateFN(), GeneratePhoneNumber(), 4, "tati.d@gmail.com"),
                new Student("Ion", "Bogdanovici", 18, GenerateFN(), GeneratePhoneNumber(), 2, "ion@gmail.com"),
                new Student("Larisa", "Andronescu", 19, GenerateFN(), GeneratePhoneNumber(), 3, "larisa.andronache@gmail.com"),
                new Student("Ana", "Andronache", 25,  GenerateFN(), GeneratePhoneNumber(), 4, "aana@gmail.com"),
                new Student("Darius", "Bute", 24, GenerateFN(), GeneratePhoneNumber(), 4, "darius@gmail.com"),
                new Student("Tudor", "Pop", 29, GenerateFN(), GeneratePhoneNumber(), 3, "bogt@gmail.com"),
                new Student("Bogdan", "Tutu", 41, GenerateFN(), GeneratePhoneNumber(), 2, "alex.budianu@gmail.com"),
                new Student("Maria", "Anton", 32, GenerateFN(),GeneratePhoneNumber(), 2, "amaria@gmail.com"),
                new Student("Alex", "Balan", 20, GenerateFN(), GeneratePhoneNumber(), 3, "alex@gmail.com"),
                new Student("Gabi", "Vasilescu", 22,  GenerateFN(), GeneratePhoneNumber(), 4, "Gvasilescu@gmail.com"),
                new Student("Andrei", "Popescu", 30,  GenerateFN(), GeneratePhoneNumber(), 3, "andrei@gmail.com")

            };




            //Test for problem 3 -first name is before its last name alphabetically
            TestProblem3(students);

            //test for problem 4 - all students with age between 18 and 24
            TestProblem4(students);

            //Problem 5. Order students-Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.Rewrite the same with LINQ.
            TestProblem5(students);

            //Problem 6 Divisible by 7 and 3 - Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.Use the built-in extension methods and lambda expressions.Rewrite the same with LINQ.
            int[] numbers = new int[]{ 42,63,21,12, 3, 312, 432, 54353, 3245, 234, 53, 234, 345, 345, 234, 345, 23432, 35, 2324, 2442, 42345, 553 };
            var divisible = from n in numbers
                            where (n % 3 == 0 && n % 7 == 0)
                            select n;
            Console.WriteLine("Numbers divisible by 7 and 3");
            foreach (var a in divisible)
            {
                Console.WriteLine(a);
            }


            //Problem 9 - Select only the students that are from group number 2.  Use LINQ query.Order the students by FirstName.
            var grTwo = from st in students
                        where st.GroupNumber == 2
                        select st;
            var orderGrTwo = grTwo.OrderBy(x => x.FirstName);
            //or
            var orderGrTwo2 = from st in grTwo
                              orderby st.FirstName
                              select st;

            //Problem 10

        }

        public static void Time(int second)
        {

        }

        private static void TestProblem5(List<Student> students)
        {
            Console.WriteLine("Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.Rewrite the same with LINQ.");
            var StudentsOrdered = students.OrderByDescending(x => x.FirstName).ThenByDescending(y => y.LastName);
            foreach (var i in StudentsOrdered)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName}");
            }
        }

        private static void TestProblem4(List<Student> students)
        {
            Console.WriteLine("all students with age between 18 and 24");
            foreach (var a in Student.AgeRange(students, 18, 24))
            {
                Console.WriteLine(a.FirstName + " " + a.LastName + " " + a.Age);
            }
        }

        private static void TestProblem3(List<Student> students)
        {
            var stud = Student.FirstBeforeLast(students);
            foreach (var s in stud)
            {
                Console.WriteLine($"{s.LastName} {s.FirstName}");
            }
        }

        private static void TestProblem1()
        {
            StringBuilder s = new StringBuilder("Ana are mere", 20);
            Console.WriteLine(s);
            Console.WriteLine(s.SubstringExtention(1, 9));
        }
    }
}

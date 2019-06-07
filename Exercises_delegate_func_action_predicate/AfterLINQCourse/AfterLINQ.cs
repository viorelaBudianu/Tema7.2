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

    partial class AfterLINQ
    {
        public static Random rnd = new Random();
        public static string GenerateFN06()
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
        public static string GenerateFN()
        {
            string FN = string.Empty;
                        
            while (FN.Length < 6)
            {
                FN = FN.Insert(0, rnd.Next(0, 10).ToString());
            }

            return FN;
        }
        public static string GeneratePhoneNumber1()
        {
            string s = "+35907";
            int digitsLeft = 7;
            
            for (int i = digitsLeft; i >= 0; i--)
            {
                s += rnd.Next(0, 10);
            }

            return s;
        }
        public static string GeneratePhoneNumber()
        {
            string s = "+4007";
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
                 new Student("Alex", "Budianu", 24,  GenerateFN(), GeneratePhoneNumber(), 3, "alex.budianu@gmail.bg"),
                new Student("Vio", "Budianu", 24, GenerateFN06(), GeneratePhoneNumber(), 2, "vio.budianu@gmail.com"),
                new Student("Ana", "Ionescu", 20,  GenerateFN(), GeneratePhoneNumber1(), 3, "ana@gmail.com"),
                new Student("Emi", "Budianu", 21, GenerateFN(), GeneratePhoneNumber(), 2, "emi.budianu@yahoo.ro"),
                new Student("Florin", "Leonte", 17,  GenerateFN06(),GeneratePhoneNumber1(), 4, "florinl@gmail.com"),
                new Student("Tatiana", "Daud", 32,  GenerateFN(), GeneratePhoneNumber(), 4, "tati.d@gmail.com"),
                new Student("Ion", "Bogdanovici", 18, GenerateFN(), GeneratePhoneNumber1(), 2, "ion@yahoo.com"),
                new Student("Larisa", "Andronescu", 19, GenerateFN06(), GeneratePhoneNumber(), 3, "larisa.andronache@gmail.com"),
                new Student("Ana", "Andronache", 25,  GenerateFN(), GeneratePhoneNumber1(), 4, "aana@gmail.com"),
                new Student("Darius", "Bute", 24, GenerateFN(), GeneratePhoneNumber(), 4, "darius@yahoo.com"),
                new Student("Tudor", "Pop", 29, GenerateFN06(), GeneratePhoneNumber1(), 3, "bogt@gmail.com"),
                new Student("Bogdan", "Tutu", 41, GenerateFN(), GeneratePhoneNumber(), 2, "alex.budianu@gmail.com"),
                new Student("Maria", "Anton", 32, GenerateFN06(),GeneratePhoneNumber1(), 2, "amaria@gmail.bg"),
                new Student("Alex", "Balan", 20, GenerateFN(), GeneratePhoneNumber(), 3, "alex@gmail.com"),
                new Student("Gabi", "Vasilescu", 22,  GenerateFN06(), GeneratePhoneNumber(), 4, "Gvasilescu@gmail.bg"),
                new Student("Andrei", "Popescu", 30,  GenerateFN(), GeneratePhoneNumber(), 3, "andrei@gmail.com")

            };
            students[1].AddMark(6);
            students[1].AddMark(7.4);
            students[0].AddMark(6);
            students[1].AddMark(5);
            students[1].AddMark(6);
            students[0].AddMark(6.1);
            students[1].AddMark(4);
            students[4].AddMark(6);
            students[1].AddMark(5.2);
            students[0].AddMark(6);
            students[1].AddMark(8.9);
            students[4].AddMark(5);
            students[5].AddMark(8.4);
            students[5].AddMark(6);

            List<Group> Groups = new List<Group>();
            Groups.Add(new Group(2, "Mathematics"));
            Groups.Add(new Group(3, "Latin"));
            Groups.Add(new Group(4, "Informatics"));


            //Test for problem 3 -first name is before its last name alphabetically
            TestProblem3(students);

            //test for problem 4 - all students with age between 18 and 24
            TestProblem4(students);

            //Problem 5. Order students-Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending order.Rewrite the same with LINQ.
            TestProblem5(students);

            //Problem 6 Divisible by 7 and 3 - Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.Use the built-in extension methods and lambda expressions.Rewrite the same with LINQ.
            int[] numbers = new int[] { 42, 63, 21, 12, 3, 312, 432, 54353, 3245, 234, 53, 234, 345, 345, 234, 345, 23432, 35, 2324, 2442, 42345, 553 };
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

            //Problem 10 - Implement the previous using the same query expressed with extension methods.
            var sampleWithExtensions = students.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName).ToList();


            //Problem 11. Extract students by email. Extract all students that have email in abv.bg. Use string methods and LINQ.
            var studentWithAbv = from student in students
                                 where student.Email.Substring(student.Email.IndexOf("@"), student.Email.Length - student.Email.IndexOf("@")) == "gmail.bg"
                                 select student;

            //Problem 12. Extract students by phone.Extract all students with phones in Sofia.Use LINQ
            Problem12(students);

            //Problem 13.Extract students by marks. Select all students that have at least one mark Excellent(6) into a new anonymous class that has properties – FullName and Marks. Use LINQ.
            var annonymousStudents = from student in students
                                     where student.Marks.Contains(6)
                                     select new
                                     {
                                         FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                                         Marks = student.Marks,

                                     };


            //Problem 14. Extract students with two marks.Write down a similar program that extracts the students with exactly two marks "2".Use extension methods.
            var TwoMarks = students.Where(x => x.Marks.Count == 2);
            foreach (var a in TwoMarks.ToList())
            {
                Console.WriteLine(a.FirstName);
            }

            //Problem 15. Extract marks.Extract all Marks of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
            var Marks6 = from s in students
                         where s.FN.Substring(s.FN.Length - 2) == "06"
                         select new
                         {
                             Markss = s.Marks,
                             Name = s.FirstName + " " + s.LastName
                         };


            //Problem 16. Groups-Create a class Group with properties GroupNumber and DepartmentName.Introduce a property GroupNumber in the Student class.
            //Extract all students from "Mathematics" department.Use the Join operator.
            var MathStudents = from s in students
                               join d in Groups on s.GroupNumber equals d.GroupNumber

                               where d.DepartmentName == "Mathematics"
                               select new
                               {
                                   MathStudent = s
                               };
            Console.WriteLine("Students in Math department");
            foreach (var i in MathStudents.ToList())
            {
                Console.WriteLine(i.MathStudent.FirstName + " " + i.MathStudent.LastName);
            }
            var MathGroup = Groups.Where(x => x.DepartmentName == "Mathematics");
            var MathStudents2 = students.Join(MathGroup, student => student.GroupNumber, group => group.GroupNumber, (student, group) => student);


            //Problem 17. Longest string-Write a program to return the string with maximum length from an array of strings.Use LINQ.
            var strings = new string[] { "animalut", "piscinacutrambulina", "CeaMaiLungaTemaDeLaWantsome" };

            var longest = (from str in strings
                           orderby str.Length descending
                           select str).ToArray()[0];

            Console.WriteLine(longest);


            //Problem 18. Grouped by GroupNumber-Create a program that extracts all students grouped by GroupNumber and then prints them to the console.Use LINQ.
            var groupGroupNumber = from s in students
                                   group s by s.GroupNumber;

            Console.WriteLine("Grouped by GroupNumber");
            foreach (var e in groupGroupNumber)
            {
                Console.WriteLine(e.Key);
                foreach(var y in e)
                {
                    Console.WriteLine(y.FirstName + " " + y.LastName);
                }
            }


            //Problem 19. Grouped by GroupName extensions.Rewrite the previous using extension methods.
            var groupedStudentsExtensions = students.GroupBy(s => s.GroupNumber);

            Console.WriteLine("\n\n\n\n Grouping by GroupNumber using extensions:\n");

            foreach (var group in groupedStudentsExtensions)
            {
                foreach (var student in group)
                {
                    Console.WriteLine(student);
                }
            }
            }

        private static void Problem12(List<Student> students)
        {
            var studentPhoneSofia = students.Where(x => (x.Tel.Substring(x.Tel.IndexOf("+"), 4)) == "+359");
            Console.WriteLine("Extract students by phone.Extract all students with phones in Sofia.Use LINQ");
            foreach (var a in studentPhoneSofia.ToList())
            {
                Console.WriteLine($"Phone:{a.Tel} Name:{a.FirstName} {a.LastName}");
            }

            var studentWithPhoneInSofia = from s in students
                                          where s.Tel.Substring(0, 4) == "+359"
                                          select s;
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

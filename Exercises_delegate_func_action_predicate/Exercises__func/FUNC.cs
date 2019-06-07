using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises__func
{
    class FUNC
    {
        public delegate int SomeOperation(int i, int j);
        static void Main(string[] args)
        {
            SomeOperation add = new SomeOperation(Sum); // sau mai puteam SomeOperation add=Sum;
            int result = add(10, 20);
            Console.WriteLine(result);

            Func<int, int, int> adauga = Sum;
            int rezultat = adauga(32, 21);
            Console.WriteLine(rezultat);

            //Func with Anonymous Method
            Func<int> RandomNumber = delegate ()
             {
                 Random random = new Random();
                 return random.Next(1, 100);
             };
            var r = RandomNumber;
            int an=r();
            Console.WriteLine("Random Number "+r); //System.Func`1[System.Int32]
            Console.WriteLine("Random Number1 " + an);
            //Func with lambda expression
            Func<int> getRandomNumber = () => new Random().Next(1, 100);

            var a = getRandomNumber; 
            Console.WriteLine("Random Number2: "+a());

            //Or Func with lambda expression 2

            Func<int, int, int> Suma = (x, y) => x + y;
            int b = Suma(12, 14);
            
            Func<string, int, string[]> extractMeth = delegate (string s, int i)
            {
                char[] delimiters = new char[] { ' ' };
                return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            };

            string title = "The Scarlet Letter";
            // Use Func instance to call ExtractWords method and display result
            foreach (string word in extractMeth(title, 2))
                Console.WriteLine(word);
            foreach (string word in extractMeth(title, 4))
                Console.WriteLine(word);
        }

        static int Sum(int x, int y)
        {
            return x + y;
        }
    }
}

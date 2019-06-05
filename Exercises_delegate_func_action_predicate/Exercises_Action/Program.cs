using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Action
{
    class Program
    {
        // Delegate
        public delegate void Print(int val);
        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }
        static void Main(string[] args)
        {
            Print p = new Print(ConsolePrint); // Print p=ConsolePrint;
            p(78);
            //Action delegate
            Action<int> printAction = ConsolePrint; // sau Action<int> printActionDel = new Action<int>(ConsolePrint);
            printAction(12);

            //Anonymous method with Action Delegate
            Action<int> PrintMethod = delegate (int i)
               {
                   Console.WriteLine($"Numarul intreg {i}");
               };
            PrintMethod(23);

            //Lambda expression with Action delegate
            Action<int> printActionLambda = i => Console.WriteLine(i);
            printActionLambda(98);
        }
    }
}

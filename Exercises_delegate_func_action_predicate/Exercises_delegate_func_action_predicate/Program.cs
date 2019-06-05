using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_delegate_func_action_predicate
{
    class Program
    {
        public delegate void Print(int value);
        static void Main(string[] args)
        {
            // Print delegate points to PrintNumber
            Print printDel = PrintNumber;  //sau mai puteam Print printDel = new Print(PrintNumber);

            printDel(100000);
            printDel(200);

            // Print delegate points to PrintMoney
            printDel = PrintMoney;
            Console.WriteLine("Normal delegate");
            printDel(10000);
            printDel(200);
            //Delegate parameter
            Console.WriteLine("Delegate parameter");
            PrintHelper(printDel, 988);
            PrintHelper(new Print(PrintNumber), 923);
            //Multicast
            Console.WriteLine("Multicast delegate");
            printDel += PrintHexadecimal;
            printDel(678);
            printDel += printDel;
            printDel(678);
            printDel -= PrintMoney;
            printDel(678);
        }
        //Multicast Delegate - un delegat care pointeaza mai multe metode, + adauga functie, - elimina functie
        public static void PrintHexadecimal(int dec)
        {
            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }

        //Delegate parameter
        public static void PrintHelper(Print delegateFunc, int numToPrint)
        {
            delegateFunc(numToPrint);
        }
        public static void PrintNumber(int num)
        {
            Console.WriteLine("Number {0,-12:N0}",num);
        }
        public static void PrintMoney(int money)
        {
            Console.WriteLine("Money: {0:C}", money);
        }
    }
}

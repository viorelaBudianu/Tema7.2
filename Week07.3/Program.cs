namespace Week07._3
{
    using System;

    /*
     * read number
     * print with red for odd number
     * print with blue for even number
     */

    internal class Program
    {
        public delegate void Print(int value);

        public delegate void OtherDelegate(int a, int b);

        private static void Main(string[] args)
        {
            Print printDelegate;

            printDelegate = PrintWithRed;

            printDelegate(100);

            printDelegate = PrintWithBlue;

            printDelegate(200);
        }

        public static void PrintWithRed(int value)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Value: {value}");
        }

        public static void PrintWithBlue(int value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Value: {value}");
        }

        public static void PrintWithGreen(int value)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Value: {value}");
        }
    }
}

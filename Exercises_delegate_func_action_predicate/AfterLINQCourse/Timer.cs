using System;
using System.Threading;

namespace AfterLINQCourse
{






    partial class AfterLINQ
    {
        //Problem 7 - Using delegates write a class Timer that can execute certain method at each t seconds.

        public class Timer
        {
            delegate void TimerDelegate(int i);
            public void Print(int t)
            {

                Console.WriteLine($"The Console will stay active for {t} seconds");
                Thread.Sleep(t);
                Environment.Exit(0);
            }
        }
    }
}

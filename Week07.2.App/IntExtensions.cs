namespace Week07._2.App
{
    public static class IntExtensions
    {
        // first param - extension type
        // 
        public static bool IsGreaterThan(this int number, int compareTo)
        {
            return number > compareTo;
        }

        public static bool IsNegative(this int number)
        {
            return number < 0;
        }
    }
}
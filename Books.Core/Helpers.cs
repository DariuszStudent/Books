using System;

namespace Books.Core
{
    public static class Helpers
    {
        public static int JustInts()
        {
            var userNumber = default(int);
            while (!int.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Musisz podać liczbę!");
            }
            return userNumber;
        }

        public static decimal JustDecimals()
        {
            var userNumber = default(decimal);
            while (!decimal.TryParse(Console.ReadLine(), out userNumber))
            {
                Console.WriteLine("Musisz podać liczbę!");
            }
            return userNumber;
        }
    }
}

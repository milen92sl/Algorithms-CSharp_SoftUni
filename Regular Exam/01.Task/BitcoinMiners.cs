using System;

namespace _01.Task
{
    public class BitcoinMiners
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int x = int.Parse(Console.ReadLine());

            long ways = CalculateWays(n, x);

            Console.WriteLine(ways);
        }

        private static long CalculateWays(int n, int x)
        {
            long numerator = Factorial(n);
            long denominator = Factorial(x) * Factorial(n - x);
            long ways = numerator / denominator;

            return ways;
        }

        private static long Factorial(int number)
        {
            if (number == 0 || number == 1)
                return 1;

            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
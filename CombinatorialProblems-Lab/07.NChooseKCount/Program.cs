using System;

namespace _07.NChooseKCount
{
    internal class Program
    {
        private static int n;
        private static int k;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            k = int.Parse(Console.ReadLine());

            Console.WriteLine(GetBinom(n, k)); 
        }

        private static long GetBinom(int n, int k)
        {
            if (n <= 1 || k == 0 || k == n)
            {
                return 1;
            }

            return GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);
        }
    }
}

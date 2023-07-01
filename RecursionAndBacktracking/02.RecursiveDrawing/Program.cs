using System;

namespace _02.RecursiveDrawing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintResult(n);
        }

        private static void PrintResult(int n)
        {
            if (n <= 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            PrintResult(n-1);

            Console.WriteLine(new string('#', n));
        }
    }
}

using System;

namespace _04.RecursiveFactorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(CalcFactRecursively(input));
        }

        private static int CalcFactRecursively(int input)
        {
            if (input == 0)
            {
                return 1;
            }

            int result = input * CalcFactRecursively(input - 1);

            return result;
        }
    }
}

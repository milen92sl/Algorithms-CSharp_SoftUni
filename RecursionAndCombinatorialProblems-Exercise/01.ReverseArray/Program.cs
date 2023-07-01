using System;

namespace _01.ReverseArray
{
    internal class Program
    {
        private static string[] input;
        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(" ");

            GetSolution(0);
        }

        private static void GetSolution(int idx)
        {
            if (idx >= input.Length / 2)
            {
                Console.WriteLine(string.Join(" ", input));
                return;
            }

            SwapElements(idx);
            GetSolution(idx + 1);
            
        }

        private static void SwapElements(int idx)
        {
            var temp = input[idx];
            input[idx] = input[input.Length - idx - 1];
            input[input.Length - idx - 1] = temp;
        }
    }
}

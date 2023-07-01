using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(GetSum(input, 0));
            
        }

        private static int GetSum(int[] input, int index)
        {
            if (index >= input.Length)
            {
                return 0;
            }

            return input[index] + GetSum(input, index + 1);
        }
    }
}

using System;
using System.Linq;

namespace _03.BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            BubbleSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void BubbleSort(int[] input)
        {

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 1; j < input.Length - i; j++)
                {
                    if (input[j - 1] > input[j])
                    {
                        Swap(input, j - 1, j);
                    }
                }
            }
        }

        private static void Swap(int[] input, int i, int j)
        {
            var temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}

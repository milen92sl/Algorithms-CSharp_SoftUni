using System;
using System.Linq;

namespace _04.InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            InsertionSort(input);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void InsertionSort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int j = i;

                while (j > 0 && input[j] < input[j -1])
                {
                    Swap(input, j);
                    j--;
                }
            }
        }

        private static void Swap(int[] input, int j)
        {
            var temp = input[j];
            input[j] = input[j - 1];
            input[j - 1] = temp;
        }
    }
}

using System;
using System.Linq;

namespace _02.SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SelectionSort(input, 0);
            Console.WriteLine(string.Join(" ", input));
        }

        private static void SelectionSort(int[] input, int v)
        {
            for (int i = v; i < input.Length; i++)
            {
                int minIndex = i;

                for (int j = minIndex + 1; j < input.Length; j++)
                {
                    if (input[j] < input[minIndex])
                    {
                        minIndex = j;
                    }
                }

                Swap(input, i, minIndex);
            }
        }

        private static void Swap(int[] input, int i, int minIndex)
        {
            var temp = input[i];
            input[i] = input[minIndex];
            input[minIndex] = temp;
        }
    }
}

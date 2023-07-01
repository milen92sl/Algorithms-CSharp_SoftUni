using System;
using System.Linq;

namespace _05.Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Quicksort(input, 0, input.Length - 1);

            Console.WriteLine(string.Join(" ", input));
        }

        private static void Quicksort(int[] input, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx )
            {
                return;
            }

            int pivotIdx = startIdx;
            int leftIdx = startIdx + 1;
            int rightIdx = endIdx;

            while (leftIdx <= rightIdx)
            {
                if (input[leftIdx] > input[pivotIdx] && input[rightIdx] < input[pivotIdx])
                {
                    Swap(input, leftIdx, rightIdx);
                }

                if (input[leftIdx] <= input[pivotIdx])
                {
                    leftIdx++;
                }
                else if (input[rightIdx] >= input[pivotIdx])
                {
                    rightIdx--;
                }
            }

            Swap( input, pivotIdx, rightIdx);

            bool isLeftSubArraySmaller = rightIdx - 1 - startIdx < endIdx - (rightIdx + 1);

            if (isLeftSubArraySmaller)
            {
                Quicksort(input, startIdx, rightIdx - 1);
                Quicksort(input, rightIdx + 1, endIdx);
            }
            else
            {
                Quicksort(input, rightIdx + 1, endIdx);
                Quicksort(input, startIdx, rightIdx - 1);
            }
        }

        private static void Swap(int[] input, int leftIdx, int rightIdx)
        {
            var temp = input[leftIdx];
            input[leftIdx] = input[rightIdx];
            input[rightIdx] = temp;
        }
    }
}

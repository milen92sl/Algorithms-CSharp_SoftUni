using System;
using System.Linq;

namespace _06.MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var sorted = MergeSort(input);

            Console.WriteLine(string.Join(" ", sorted));
        }

        private static int[] MergeSort(int[] input)
        {
            if (input.Length == 1)
            {
                return input;
            }

            int midIdx = input.Length / 2;
            int[] leftHalf = input.Take(midIdx).ToArray();
            int[] rightHalf = input.Skip(midIdx).ToArray();

            return MergeArrays(MergeSort(leftHalf), MergeSort(rightHalf));
        }

        private static int[] MergeArrays(int[] left, int[] right)
        {
            int[] sorted = new int[left.Length + right.Length];
            int sortedIdx = 0;
            int leftIdx = 0;
            int rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    sorted[sortedIdx++] = left[leftIdx++];
                }
                else
                {
                    sorted[sortedIdx++] = right[rightIdx++];
                }
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                sorted[sortedIdx++] = right[rightIdx++];
            }



            for (int i = leftIdx; i < left.Length; i++)
            {
                sorted[sortedIdx++] = left[leftIdx++];
            }


            return sorted;
        }
    }
}

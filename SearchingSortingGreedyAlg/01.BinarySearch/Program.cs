using System;
using System.Linq;

namespace _01.BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(input, number));
        }

        private static int BinarySearch(int[] input, int number)
        {
            int start = 0;
            int end = input.Length - 1;
            
            while (start <= end)
            {
                int mid = (start + end) / 2;

                int element = input[mid];

                if (element == number)
                {
                    return mid;
                }
                else if (element > number)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return -1;
        }
    }
}

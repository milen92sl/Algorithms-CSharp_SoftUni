using System;
using System.Linq;

namespace _03.SumWithUnlimitedCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var target = int.Parse(Console.ReadLine());

            Console.WriteLine(CountSums(numbers, target));
        }

        private static int CountSums(int[] numbers, int target)
        {
            var sums = new int[target + 1];

            sums[0] = 1;

            foreach (var num in numbers)
            {
                for (int i = num; i <= target; i++)
                {
                    sums[i] += sums[i - num];
                }
            }

            return sums[target];
        }
    }
}

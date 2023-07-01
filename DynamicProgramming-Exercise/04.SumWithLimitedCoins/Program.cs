using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumWithLimitedCoins
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
            var counter = 0;
            var sums = new HashSet<int> { 0 };

            foreach (var number in numbers)
            {
                var newSums = new HashSet<int>();

                foreach (var sum in sums)
                {
                    var newSum = sum + number;

                    if (newSum == target)
                    {
                        counter += 1;
                    }

                    newSums.Add(newSum);
                }

                sums.UnionWith(newSums);
            }

            return counter;
        }

    }
}

using System;
using System.Collections.Generic;

namespace _001.SubsetSum_RepeatingNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };
            var target = 17;

            var sums = new bool[target + 1];
            sums[0] = true;

            for (int i = 0; i < sums.Length; i++)
            {
                if (!sums[i])
                {
                    continue;
                }

                foreach (var num in nums)
                {
                    var newSum = i + num;

                    if (newSum > target)
                    {
                        continue;
                    }

                    sums[newSum] = true;

                }
            }

            Console.WriteLine(sums[target]);

            var subset = new List<int>();

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prevSum = target - num;

                    if (prevSum >= 0 && sums[prevSum])
                    {
                        subset.Add(num);
                        target = prevSum;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", subset));
            
        }
    }
}

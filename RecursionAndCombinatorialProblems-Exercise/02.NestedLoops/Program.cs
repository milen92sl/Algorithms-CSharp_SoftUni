using System;

namespace _02.NestedLoops
{
    internal class Program
    {
        private static int[] combinations;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            combinations = new int[n];

            GetCombinations(0);
        }

        private static void GetCombinations(int idx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = 1; i <= combinations.Length; i++)
            {
                combinations[idx] = i;

                GetCombinations(idx + 1);
            }
        }
    }
}

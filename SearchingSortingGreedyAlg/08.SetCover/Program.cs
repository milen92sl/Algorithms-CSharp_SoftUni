using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SetCover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToHashSet();

            int n = int.Parse(Console.ReadLine());

            var sets = new List<int[]>();

            for (int i = 0; i < n; i++)
            {
                int[] currSet = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                sets.Add(currSet);
            }

            var usedSets = new List<int[]>();

            while (universe.Count > 0)
            {
                int[] currSet = sets
                    .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                    .FirstOrDefault();

                usedSets.Add(currSet);
                sets.Remove(currSet);

                foreach (var item in currSet)
                {
                    universe.Remove(item);
                }
            }

            Console.WriteLine($"Sets to take ({usedSets.Count}):");

            foreach (var item in usedSets)
            {
                Console.WriteLine(string.Join(", ", item));
            }
        }
    }
}

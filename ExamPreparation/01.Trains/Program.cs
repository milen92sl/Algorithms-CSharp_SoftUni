using System;
using System.Linq;

namespace _01.Trains
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arrival = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();

            var departure = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(FindMinPlatforms(arrival, departure));
        }

        private static int FindMinPlatforms(double[] arrival, double[] departure)
        {
            var arIdx = 0;
            var depIdx = 0;
            var currPlatforms = 0;
            var minPlatforms = 0;

            while (arIdx < arrival.Length)
            {
                if (arrival[arIdx] < departure[depIdx])
                {
                    arIdx++;
                    currPlatforms++;
                    minPlatforms = Math.Max(currPlatforms, minPlatforms);
                }
                else
                {
                    depIdx++;
                    currPlatforms--;
                    
                }
            }

            return minPlatforms;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SumOfCoins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .OrderByDescending(x => x));

            int target = int.Parse(Console.ReadLine());
            var usedCoins = new Dictionary<int, int>();
            int coinsCount = 0;
            

            while (target > 0 && coins.Count > 0)
            {
                int currCoin = coins.Dequeue();
                int count = target / currCoin;

                if (count == 0)
                {
                    continue;
                }

                usedCoins[currCoin]= count;
                coinsCount += count;

                target %= currCoin;

            }


            if (target > 0)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }

            Console.WriteLine($"Number of coins to take: {coinsCount}");

            foreach (var item in usedCoins)
            {
                Console.WriteLine($"{item.Value} coin(s) with value {item.Key}");
            }
        }
    }
}

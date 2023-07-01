using System;
using System.Linq;

namespace _03.VariationsWithoutRepetition
{
    internal class Program
    {
        private static string[] variations;
        private static string[] input;
        private static bool[] used;
        private static int slots;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ');
            slots = int.Parse(Console.ReadLine());
            
            variations = new string[slots];
            used = new bool[input.Length];

            Variations(0);
        }

        private static void Variations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return; 
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = input[i];
                    Variations(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}

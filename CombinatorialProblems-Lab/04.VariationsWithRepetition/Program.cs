using System;

namespace _04.VariationsWithRepetition
{
    internal class Program
    {
        private static string[] variations;
        private static string[] input;
        private static int slots;

        static void Main(string[] args)
        {
            input = Console.ReadLine().Split(' ');
            slots = int.Parse(Console.ReadLine());

            variations = new string[slots];

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

                variations[index] = input[i];
                Variations(index + 1);
            }
        }
    }
}

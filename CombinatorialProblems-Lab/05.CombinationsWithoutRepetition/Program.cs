using System;

namespace _05.CombinationsWithoutRepetition
{
    
    internal class Program
    {
        private static string[] elements;
        private static string[] combinations;
        private static int slots;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            slots = int.Parse(Console.ReadLine());
            combinations = new string[slots];

            Combinatios(0, 0);
        }

        private static void Combinatios(int index, int elementIndex)
        {
            if (index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = elementIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];

                Combinatios(index + 1, i + 1);
            }
        }
    }
}

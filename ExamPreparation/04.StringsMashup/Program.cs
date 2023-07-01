using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.StringsMashup
{
    internal class Program
    {
        private static List<char> input;
        private static char[] output;
        private static int slots;

        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            input = new List<char>();

            foreach (var item in input1.OrderBy(x => x))
            {
                input.Add(item);
            }

            slots = int.Parse(Console.ReadLine());
            output = new char[slots];

            MashUp(0, 0);
        }

        private static void MashUp(int index, int elementindex)
        {
            if (index >= output.Length)
            {
                Console.WriteLine(string.Join("", output));
                return;
            }

            for (int i = elementindex; i < input.Count; i++)
            {
                output[index] = input[i];

                MashUp(index + 1, i);
            }
        }


    }
}

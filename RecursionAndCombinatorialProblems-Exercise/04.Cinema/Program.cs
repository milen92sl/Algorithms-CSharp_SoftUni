using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _04.Cinema
{
    internal class Program
    {
        private static List<string> nonStaticPeople;
        private static string[] people;
        private static bool[] locked;
        static void Main(string[] args)
        {
            nonStaticPeople = Console.ReadLine().Split(", ").ToList();
            people = new string[nonStaticPeople.Count];
            locked= new bool[nonStaticPeople.Count];

            string cmd;

            while ((cmd = Console.ReadLine()) != "generate")
            {
                var cmdArg = cmd.Split(" - ");

                string person = cmdArg[0];
                int index = int.Parse(cmdArg[1]) - 1;

                people[index] = person;
                locked[index] = true;

                nonStaticPeople.Remove(person);
            }

            GetPermutations(0);


        }

        private static void GetPermutations(int idx)
        {
            if (idx >= nonStaticPeople.Count)
            {
                PrintPermutation();
                return;
            }

            GetPermutations(idx + 1);

            for (int i = idx + 1; i < nonStaticPeople.Count; i++)
            {
                SwapElements(idx, i);
                GetPermutations(idx + 1);
                SwapElements(idx, i);
            }

        }

        private static void PrintPermutation()
        {
            var peopleIndex = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < people.Length; i++)
            {
                if (locked[i])
                {
                    sb.Append($"{people[i]} ");
                }
                else
                {
                    sb.Append($"{nonStaticPeople[peopleIndex++]} ");
                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void SwapElements(int first, int second)
        {
            var temp = nonStaticPeople[first];
            nonStaticPeople[first] = nonStaticPeople[second];
            nonStaticPeople[second] = temp;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Exam_prep
{
    public class SuperSet
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            if (input != null)
            {
                List<string> inputList = new List<string>(input.Split(','));
                PrintSuperSet(inputList);
            }
        }
        static void PrintSuperSet(List<string> list)
        {
            List<List<string>> subsets = new List<List<string>>();

            for (int r = 0; r <= list.Count; r++)
            {
                GenerateCombinations(list, r, new List<string>(), subsets);
            }

            foreach (List<string> subset in subsets)
            {
                Console.WriteLine(string.Join("", subset).Trim());
            }
        }

        static void GenerateCombinations(List<string> list, int r, List<string> current, List<List<string>> subsets)
        {
            if (r == 0)
            {
                subsets.Add(new List<string>(current));
                return;
            }

            int startIndex = current.Count > 0 ? list.IndexOf(current[current.Count - 1]) + 1 : 0;

            for (int i = startIndex; i <= list.Count - r; i++)
            {
                current.Add(list[i]);
                GenerateCombinations(list, r - 1, current, subsets);
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}

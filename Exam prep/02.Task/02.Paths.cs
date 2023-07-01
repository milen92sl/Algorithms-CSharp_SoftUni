using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_prep
{
    public class Paths
    {
        private static List<int>[] graph;
        private static HashSet<int> steps;

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());

            graph = new List<int>[nodesCount];

            FillGraph();

            for (int node = 0; node < graph.Length - 1; node++)
            {
                steps = new HashSet<int>();
                DFS(node);
            }
        }

        private static void FillGraph()
        {
            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
            }
        }

        private static void DFS(int node)
        {
            steps.Add(node);

            if (node == graph.Length - 1)
            {
                Console.WriteLine(string.Join(' ', steps));
                return;
            }

            foreach (int child in graph[node])
            {
                DFS(child);
                steps.Remove(child);
            }
        }
    }
}
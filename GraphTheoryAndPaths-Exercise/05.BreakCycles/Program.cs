using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BreakCycles
{
    internal class Program
    {
        public class Edges
        {
            public string First { get; set; }
            public string Second { get; set; }

        }

        private static Dictionary<string, List<string>> graph;
        private static List<Edges> edges;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            graph= new Dictionary<string, List<string>>();
            edges = new List<Edges>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(" -> ");


                var node = input[0];
                var childrens = input[1]
                    .Split(" ")
                    .ToList();

                graph[node] = childrens;

                foreach (var child in childrens)
                {
                    edges.Add(new Edges { First = node, Second = child });
                }
            }

            edges = edges
                .OrderBy(x => x.First)
                .ThenBy(x => x.Second)
                .ToList();

            var removedEdges = new List<Edges>();

            foreach (var edge in edges)
            {
                var remove = graph[edge.First].Remove(edge.Second) && graph[edge.Second].Remove(edge.First);

                if (!remove)
                {
                    continue;
                }

                if (BFS(edge.First, edge.Second))
                {
                    removedEdges.Add(edge);
                }
                else
                {
                    graph[edge.First].Add(edge.Second);
                    graph[edge.Second].Add(edge.First);
                }
            }

            Console.WriteLine($"Edges to remove: {removedEdges.Count}");

            foreach (var edge in removedEdges)
            {
                Console.WriteLine($"{edge.First} - {edge.Second}");
            }
        }

        private static bool BFS(string start, string destination)
        {
            var queue = new Queue<string>();
            queue.Enqueue(start);

            var visited= new HashSet<string> { start };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == destination)
                {
                    return true;
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }

            return false;

        }
    }
}

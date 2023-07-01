using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _01.DistanceBetweenVertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph; 
        static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine());
            int pairs = int.Parse(Console.ReadLine());

            graph= new Dictionary<int, List<int>>();

            for (int i = 0; i < nodes; i++)
            {
                var input = Console.ReadLine()
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);

                var node = int.Parse(input[0]);

                if (input.Length == 1)
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = input[1]
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine()
                    .Split('-');

                var firstNode = int.Parse(pair[0]);
                var secondNode = int.Parse(pair[1]);

                var steps = BFS(firstNode, secondNode);

                Console.WriteLine($"{{{firstNode}, {secondNode}}} -> {steps}");
            }

        }

        private static int BFS(int firstNode, int secondNode)
        {
            var queue = new Queue<int>();
            queue.Enqueue(firstNode);

            var visited = new HashSet<int>() { firstNode };
            var parent = new Dictionary<int, int>() { { firstNode, -1} };

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == secondNode)
                {
                    return GetSteps(secondNode, parent);
                }

                foreach (var child in graph[node])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                    visited.Add(child);
                    parent[child] = node;
                }
            }

            return -1;

        }

        private static int GetSteps(int secondNode, Dictionary<int, int> parent)
        {
            var steps = 0;
            var node = secondNode;

            while (node != -1)
            {
                node = parent[node];
                steps++;
            }

            return steps - 1;
        }
    }
}

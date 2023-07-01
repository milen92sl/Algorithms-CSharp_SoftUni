using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShortestPath
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] parent;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            graph = new List<int>[n + 1];
            visited = new bool[graph.Length];
            parent= new int[graph.Length];

            Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int i = 0; i < e; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int from = line[0];
                int to = line[1];

                graph[from].Add(to);
                graph[to].Add(from);
            }

            int start = int.Parse(Console.ReadLine());
            int destination = int.Parse(Console.ReadLine());

            BFS(start, destination);
        }

        private static void BFS(int startNode, int destination)
        {
            var que = new Queue<int>();
            que.Enqueue(startNode);

            visited[startNode] = true;

            while (que.Count > 0)
            {
                var node = que.Dequeue();

                if (node == destination)
                {
                    var path = GetPath(destination);

                    Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                    Console.WriteLine(string.Join(" ", path));
                    break;
                }

                foreach (var child in graph[node])
                {
                    if (!visited[child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        que.Enqueue(child);
                    }
                }
            }
        }

        private static Stack<int> GetPath(int destination)
        {
            var path = new Stack<int>();

            var idx = destination;

            while (idx != -1)
            {
                path.Push(idx);
                idx = parent[idx]; 
            }
            return path;
        }
    }
}

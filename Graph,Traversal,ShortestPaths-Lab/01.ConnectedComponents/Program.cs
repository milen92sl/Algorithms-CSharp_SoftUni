using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _01.ConnectedComponents
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];

            for (int node = 0; node < graph.Length; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node]= new List<int>();
                }
                else
                {
                    graph[node]= line.Split(" ").Select(int.Parse).ToList();
                }

            }

            for (int node = 0; node < graph.Length; node++)
            {
                var component = new List<int>();
                DFS(node, component);

                if (component.Count > 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(" ", component)}");
                }
  
            }
        }

        private static void DFS(int node, List<int> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node]= true;

            foreach (var children in graph[node])
            {
                DFS(children, component);
            }

            component.Add(node);
 
        }
    }
}

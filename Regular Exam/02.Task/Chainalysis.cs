using System;
using System.Collections.Generic;

namespace _02.Task
{
    public class Chainalysis
    {
        public static int CountGroups(List<Tuple<string, string, int>> transactions)
        {
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

            // Build the graph
            foreach (var transaction in transactions)
            {
                string sender = transaction.Item1;
                string receiver = transaction.Item2;

                if (!graph.ContainsKey(sender))
                {
                    graph[sender] = new HashSet<string>();
                }

                if (!graph.ContainsKey(receiver))
                {
                    graph[receiver] = new HashSet<string>();
                }

                graph[sender].Add(receiver);
                graph[receiver].Add(sender);
            }

            HashSet<string> visited = new HashSet<string>();
            int groupCount = 0;

            // Traverse the graph using DFS to find groups
            foreach (var node in graph.Keys)
            {
                if (!visited.Contains(node))
                {
                    groupCount++;
                    DFS(node, graph, visited);
                }
            }

            return groupCount;
        }

        private static void DFS(string node, Dictionary<string, HashSet<string>> graph, HashSet<string> visited)
        {
            visited.Add(node);

            foreach (var neighbor in graph[node])
            {
                if (!visited.Contains(neighbor))
                {
                    DFS(neighbor, graph, visited);
                }
            }
        }

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Tuple<string, string, int>> transactions = new List<Tuple<string, string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] transactionData = Console.ReadLine().Split();
                string sender = transactionData[0];
                string receiver = transactionData[1];
                int amount = int.Parse(transactionData[2]);

                transactions.Add(Tuple.Create(sender, receiver, amount));
            }

            int numGroups = CountGroups(transactions);
            Console.WriteLine(numGroups);
        }
    }
}

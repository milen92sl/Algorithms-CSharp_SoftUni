using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace _06.ConnectingCables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var positions = Enumerable.Range(1, input.Length).ToArray();

            var matrix = new int[input.Length + 1, input.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (input[row - 1] == positions[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        matrix[row, col] = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                    }
                }
            }

            Console.WriteLine($" Maximum pairs connected: {matrix[input.Length, positions.Length]}");
        }
    }
}

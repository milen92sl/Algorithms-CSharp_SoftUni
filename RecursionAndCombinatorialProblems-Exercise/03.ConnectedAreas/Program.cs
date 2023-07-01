using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ConnectedAreas
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }
    internal class Program
    {
        private static char[,] matrix;
        private static List<Area> areas;
        private const char VisitedChar = 'v';
        private static int size;

        static void Main(string[] args)
        {
            int row = int.Parse(Console.ReadLine());
            int col = int.Parse(Console.ReadLine());

            matrix = new char[row, col];
            areas= new List<Area>();

            for (int i = 0; i < row; i++)
            {
                string ColEl = Console.ReadLine();

                for (int j = 0; j < col; j++)
                {
                    matrix[i, j] = ColEl[j];
                }
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    size = 0;
                    ExploreMatrix(i, j);

                    if (size != 0)
                    {
                        areas.Add(new Area { Row = i, Col = j, Size = size });
                    }
                }
            }

            Console.WriteLine($"Total areas found: {areas.Count}");

            var sorted = areas.OrderByDescending(x => x.Size)
                .ThenBy(x => x.Row)
                .ThenBy(x => x.Col)
                .ToList();

            for (int i = 0; i < sorted.Count; i++)
            {
                Console.WriteLine($"Area #{i + 1} at ({sorted[i].Row}, {sorted[i].Col}), size: {sorted[i].Size}");
            }

        }

        private static void ExploreMatrix(int row, int col)
        {
            if (IsOutside(row, col) || IsWall(row, col) || IsVisisted(row, col))
            {
                return;
            }

            size += 1;
            matrix[row, col] = VisitedChar;

            ExploreMatrix(row - 1, col); 
            ExploreMatrix(row + 1, col); 
            ExploreMatrix(row, col + 1); 
            ExploreMatrix(row, col - 1); 
        }

        private static bool IsVisisted(int row, int col)
        {
            return matrix[row, col] == VisitedChar;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1);
        }
    }
}

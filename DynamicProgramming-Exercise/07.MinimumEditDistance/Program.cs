using System;

namespace _07.MinimumEditDistance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int replaceCost = int.Parse(Console.ReadLine());
            int insertCost = int.Parse(Console.ReadLine());
            int deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1,0] + deleteCost;
            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + insertCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (str1[row-1] == str2[col-1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        var replace = matrix[row - 1, col - 1] + replaceCost;
                        var insert = matrix[row, col - 1] + insertCost;
                        var delete = matrix[row-1, col] + deleteCost;

                        matrix[row, col] = Math.Min(Math.Min(replace,delete), insert);
                    }
                }
            }

            Console.WriteLine($"Minimum edit distance: {matrix[str1.Length,str2.Length]}");
        }
    }
}

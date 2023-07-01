using System;

namespace _03.GeneratingVectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            PrintRecursiveResult(arr, 0);

        }

        private static void PrintRecursiveResult(int[] arr, int n)
        {
            if (n >= arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    arr[n] = i;
                    PrintRecursiveResult(arr, n+1);
                }
            }
        }
    }
}

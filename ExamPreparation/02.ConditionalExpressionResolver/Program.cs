using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace _02.ConditionalExpressionResolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            Console.WriteLine(Expression(input,0));
        }

        private static int Expression(char[] input, int idx)
        {
            if (char.IsDigit(input[idx]))
            {
                return input[idx] - '0';
            }

            if (input[idx] == 't')
            {
                return Expression(input, idx + 2);
            }

            var foundConditions = 0;

            for (int i = idx + 2; i < input.Length; i++)
            {
                var currSymbol = input[i];

                if (currSymbol == '?')
                {
                    foundConditions++;
                }
                else if (currSymbol == ':')
                {
                    foundConditions--;

                    if (foundConditions < 0)
                    {
                        return Expression(input, i + 1);
                    }
                }
            }

            throw new InvalidOperationException();
        }
    }
}

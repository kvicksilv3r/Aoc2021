using System;
using System.IO;

namespace Aoc2021Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\day1.txt");

            Console.Write("Part 1 results: ");
            PartOne(input);

            Console.Write("Part 2 results: ");
            PartTwo(input);

            Console.ReadLine();
        }

        static void PartOne(string[] input)
        {
            var increases = 0;

            for (int index = 1; index < input.Length; index++)
            {
                var prevValue = Convert.ToInt32(input[index - 1]);
                var currentValue = Convert.ToInt32(input[index]);
                if (prevValue < currentValue)
                {
                    increases++;
                }
            }

            Console.WriteLine(increases);
        }

        static void PartTwo(string[] input)
        {
            var increases = 0;
            var lastMessurement = int.MaxValue;

            for (int index = 0; index < input.Length - 2; index++)
            {
                var a = Convert.ToInt32(input[index]);
                var b = Convert.ToInt32(input[index + 1]);
                var c = Convert.ToInt32(input[index + 2]);

                var sum = a + b + c;

                if (lastMessurement < sum)
                {
                    increases++;
                }

                lastMessurement = sum;
            }

            Console.WriteLine(increases);
        }
    }
}

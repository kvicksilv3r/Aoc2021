using System;
using System.IO;

namespace Aoc2021Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\day1.txt");

            PartOne(input);
            PartTwo(input);

            Console.WriteLine();
            var p2 = new ProgramV2();
            p2.Fun();

            Console.WriteLine();
            var p3 = new ProgramV3();
            p3.Fun();

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

            Console.WriteLine($"Part 1 results v1: {increases}");
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

            Console.WriteLine($"Part 2 results v1: {increases}");
        }
    }
}

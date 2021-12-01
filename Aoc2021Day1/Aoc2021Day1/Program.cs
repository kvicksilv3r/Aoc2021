using System;
using System.Net;

namespace Aoc2021Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines(@"C:\Users\Dogge\Documents\Aoc 2021 Day1.txt");

            Console.WriteLine("Part 1 results: ");
            PartOne(input);

            Console.WriteLine("Part 2 results: ");
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

            Console.Write(increases.ToString());
        }

        static void PartTwo(string[] input)
        {
            var increases = 0;
            var lastMessurement = 99999;

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

            Console.Write(increases.ToString());
        }
    }
}

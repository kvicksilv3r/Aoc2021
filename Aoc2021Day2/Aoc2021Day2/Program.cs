using System;
using System.IO;

namespace Aoc2021Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            StepOne();
            StepTwo();
        }

        private static void StepOne()
        {
            var inputs = File.ReadAllLines(@"..\..\..\day2.txt");
            var depth = 0;
            var horizontal = 0;

            foreach (var instruction in inputs)
            {
                var split = instruction.Split(" ");

                var numerical = int.Parse(split[1]);

                switch (split[0])
                {
                    case "forward":
                        horizontal += numerical;
                        break;

                    case "down":
                        depth += numerical;
                        break;

                    case "up":
                        depth -= numerical;
                        break;
                }
            }
            Console.WriteLine($"Step 1 total distance: {horizontal * depth}");
        }

        private static void StepTwo()
        {
            var inputs = File.ReadAllLines(@"..\..\..\day2.txt");
            var depth = 0;
            var horizontal = 0;
            var aim = 0;

            foreach (var instruction in inputs)
            {
                var split = instruction.Split(" ");

                var numerical = int.Parse(split[1]);

                switch (split[0])
                {
                    case "forward":
                        horizontal += numerical;
                        depth += numerical * aim;
                        break;

                    case "down":
                        aim += numerical;
                        break;

                    case "up":
                        aim -= numerical;
                        break;
                }
            }
            Console.WriteLine($"Step 2 total distance: {horizontal * depth}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2021Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            var rawInput = File.ReadAllLines(@"..\..\..\day3.txt");

            var bitLength = rawInput[0].Length;
            var rawGamma = "";
            var rawEpsilon = "";

            for (int width = 0; width < bitLength; width++)
            {
                var totalCount = 0;

                for (int height = 0; height < rawInput.Length; height++)
                {
                    totalCount += int.Parse(rawInput[height].Substring(width, 1));
                }

                if (totalCount > rawInput.Length / 2)
                {
                    rawGamma += 1;
                    rawEpsilon += 0;
                }

                else
                {
                    rawGamma += 0;
                    rawEpsilon += 1;
                }
            }

            int intGamma = Convert.ToInt32(rawGamma, 2);
            var intEpsilon = Convert.ToInt32(rawEpsilon, 2);

            Console.WriteLine($"Part 1: {intGamma * intEpsilon}");
        }

        private static void PartTwo()
        {
            var rawInput = File.ReadAllLines(@"..\..\..\day3.txt").ToList();
            var oxygen = OxygenSolver(rawInput, 0);
            var carbonDioxide = CarbonSolver(rawInput, 0);

            Console.WriteLine("Value of oxygen: " + oxygen);
            Console.WriteLine("Value of carbondioxide: " + carbonDioxide);
            Console.WriteLine("Part 2 : " + oxygen * carbonDioxide);
        }

        private static int OxygenSolver(List<string> inputs, int searchIndex)
        {
            if (inputs.Count == 1)
            {
                return Convert.ToInt32(inputs[0], 2);
            }

            int totalCount = 0;
            int numberToFind = 0;

            //find number
            for (int height = 0; height < inputs.Count; height++)
            {
                totalCount += int.Parse(inputs[height].Substring(searchIndex, 1));
            }

            if (totalCount >= inputs.Count / 2)
            {
                numberToFind = 1;
            }

            else
            {
                numberToFind = 0;
            }

            var queue = new Queue<string>();
            //purge numbers

            for (int height = 0; height < inputs.Count; height++)
            {
                if (int.Parse(inputs[height].Substring(searchIndex, 1)) == numberToFind)
                {
                    queue.Enqueue(inputs[height]);
                }
            }

            return OxygenSolver(queue.ToList(), searchIndex + 1);
        }

        private static int CarbonSolver(List<string> inputs, int searchIndex)
        {
            if (inputs.Count == 1)
            {
                return Convert.ToInt32(inputs[0], 2);
            }

            int totalCount = 0;
            int numberToFind = 0;

            for (int height = 0; height < inputs.Count; height++)
            {
                totalCount += int.Parse(inputs[height].Substring(searchIndex, 1));
            }

            if (totalCount < inputs.Count / 2)
            {
                numberToFind = 1;
            }

            else
            {
                numberToFind = 0;
            }

            var queue = new Queue<string>();

            for (int height = 0; height < inputs.Count; height++)
            {
                if (int.Parse(inputs[height].Substring(searchIndex, 1)) == numberToFind)
                {
                    queue.Enqueue(inputs[height]);
                }
            }

            return CarbonSolver(queue.ToList(), searchIndex + 1);
        }
    }
}

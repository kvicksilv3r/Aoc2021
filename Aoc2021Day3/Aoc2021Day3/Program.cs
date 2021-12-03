using System;
using System.IO;

namespace Aoc2021Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            PartOne();
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
    }
}

using System;
using System.IO;
using System.Linq;

namespace AoC2021Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var crabs = File.ReadAllText(@"..\..\..\day7.txt").Split(',').Select(x => Convert.ToInt32(x)).ToArray();
            Solve(crabs, false);
            Solve(crabs, true);
        }

        private static void Solve(int[] crabs, bool partTwo)
        {
            int[] positions = new int[crabs.Max()];

            //Compare every crab position vs every reasonable position (0 to max crab position)
            for (int i = 0; i < crabs.Max(); i++)
            {
                for (int o = 0; o < crabs.Length; o++)
                {
                    var fuel = Math.Abs(i - crabs[o]);

                    if (partTwo)
                    {
                        fuel = (fuel * fuel) - fuel;
                        fuel /= 2;
                        fuel += Math.Abs(i - crabs[o]);
                    }

                    positions[i] += fuel;
                }
            }

            var lowestFuel = positions.Where(x => x > 0).Min();

            Console.WriteLine($"Part {(partTwo ? 2 : 1)} fuel: {lowestFuel}");
        }
    }
}

//PART 1 - 333755 RIGHT ANSWER, FIRST TRY
//PART 2 - 94017638 RIGHT ANSWER, FIRST TRY
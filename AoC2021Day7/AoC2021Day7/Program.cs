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

            int[] positions = new int[crabs.Max()];

            for (int i = 0; i < crabs.Max(); i++)
            {
                for (int o = 0; o < crabs.Length; o++)
                {
                    positions[i] += Math.Abs(crabs[o] - i);
                }
            }

            var smallest = positions.Where(x => x > 0).Min();

            Console.WriteLine(smallest);
        }
    }
}

//PART 1 - 333755 RIGHT ANSWER, FIRST TRY
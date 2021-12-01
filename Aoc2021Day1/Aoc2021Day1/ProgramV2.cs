using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2021Day1
{
    public class ProgramV2
    {
        //Trying some funk just for fun! :D 
        public void Fun()
        {
            var inputs = File.ReadAllLines(@"..\..\..\day1.txt").Select(s => Convert.ToInt32(s)).ToList();

            PartOneV2(inputs);
            PartTwoV2(inputs);
        }

        static void PartOneV2(List<int> input)
        {
            var increases = 0;

            for (int index = 1; index < input.Count; index++)
            {
                var prevValue = input[index - 1];
                var currentValue = input[index];

                if (prevValue < currentValue)
                {
                    increases++;
                }
            }

            Console.WriteLine($"Part 1 results v2: {increases}");
        }

        static void PartTwoV2(List<int> input)
        {
            var increases = 0;

            for (int index = 0; index < input.Count - 2; index++)
            {
                var sum = input.GetRange(index, 3).Sum();
                var last = input.GetRange((int)MathF.Max(0, index - 1), 3).Sum();

                if (last < sum)
                {
                    increases++;
                }
            }

            Console.WriteLine($"Part 2 results v2: {increases}");
        }
    }
}

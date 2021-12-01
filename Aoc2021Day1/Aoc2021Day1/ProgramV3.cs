using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aoc2021Day1
{
    public class ProgramV3
    {
        // How many lines can I remove?
        public void Fun()
        {
            var inputs = File.ReadAllLines(@"..\..\..\day1.txt").Select(s => Convert.ToInt32(s)).ToList();
            int increases = 0, increases2 = 0;
            for (int index = 1; index < inputs.Count; index++)
            {
                increases += (inputs[index - 1] < inputs[index]) ? 1 : 0;
                if (index < inputs.Count - 2)
                    increases2 += (inputs.GetRange((int)MathF.Max(0, index - 1), 3).Sum() < inputs.GetRange(index, 3).Sum()) ? 1 : 0;
            }
            Console.WriteLine($"Part 1 results v3: {increases} \nPart 2 results v3: {increases2}");
        }
    }
}

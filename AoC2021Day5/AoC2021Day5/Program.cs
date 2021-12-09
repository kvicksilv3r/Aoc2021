using System;
using System.IO;
using System.Linq;

namespace AoC2021Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\day5.txt").ToArray();

            int[,] lineSegments = new int[1000, 1000];
            bool part1 = false;

            foreach (var cable in input)
            {
                var cleaned = cable.Replace(" ", "").Replace(">", "");
                var p1 = cleaned.Split('-')[0];
                var p2 = cleaned.Split('-')[1];

                var x1 = int.Parse(p1.Split(',')[0]);
                var y1 = int.Parse(p1.Split(',')[1]);
                var x2 = int.Parse(p2.Split(',')[0]);
                var y2 = int.Parse(p2.Split(',')[1]);

                if (part1)
                {
                    if (x1 != x2 && y1 != y2)
                    {
                        continue;
                    }
                }

                int[] seeker = new int[] { x1, y1 };
                lineSegments[seeker[0], seeker[1]]++;

                while (seeker[0] != x2 || seeker[1] != y2)
                {
                    seeker[0] = MoveTowards(seeker[0], x2, 1);
                    seeker[1] = MoveTowards(seeker[1], y2, 1);

                    lineSegments[seeker[0], seeker[1]]++;
                }
            }

            var overlaps = 0;

            for (int i = 0; i < lineSegments.GetLength(0); i++)
            {
                for (int j = 0; j < lineSegments.GetLength(1); j++)
                {

                    if (lineSegments[i, j] >= 2)
                    {
                        overlaps++;
                    }
                }
            }

            Console.WriteLine($"Total overlaps: {overlaps}");
        }

        static public int MoveTowards(int current, int target, int maxDelta)
        {
            if (Math.Abs(target - current) <= maxDelta)
                return (int)target;
            return (int)(current + Math.Sign(target - current) * maxDelta);
        }
    }
}

// PART 2 - 8796 TOO LOW
// PART 2 - 21387 TOO LOW
// PART 2 - 21466 JUST RIGHT

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

            foreach (var cable in input)
            {
                var cleaned = cable.Replace(" ", "").Replace(">", "");
                var p1 = cleaned.Split('-')[0];
                var p2 = cleaned.Split('-')[1];

                var x1 = int.Parse(p1.Split(',')[0]);
                var y1 = int.Parse(p1.Split(',')[1]);
                var x2 = int.Parse(p2.Split(',')[0]);
                var y2 = int.Parse(p2.Split(',')[1]);

                if (x1 != x2 && y1 != y2)
                {
                    continue;
                }

                var xSmall = (int)MathF.Min(x1, x2);
                var xBig = (int)MathF.Max(x1, x2);

                var ySmall = (int)MathF.Min(y1, y2);
                var yBig = (int)MathF.Max(y1, y2);

                for (int x = xSmall; x <= xBig; x++)
                {
                    for (int y = ySmall; y <= yBig; y++)
                    {
                        lineSegments[x, y]++;
                    }
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
            Console.WriteLine(overlaps);
        }
    }
}

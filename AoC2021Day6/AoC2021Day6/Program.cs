using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace AoC2021Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var allFish = File.ReadAllText(@"..\..\..\day6.txt").Split(',').Select(x => Convert.ToInt32(x)).ToList();
            var chrono = new Stopwatch();

            chrono.Start();

            long[] fishBuckets = new long[10];
            long fishCount = allFish.Count;

            for (int i = 0; i < allFish.Count; i++)
            {
                fishBuckets[allFish[i]]++;
            }

            for (int day = 0; day < 256; day++)
            {
                fishBuckets[9] = fishBuckets[0];
                fishCount += fishBuckets[0];

                for (int i = 0; i < 8; i++)
                {
                    fishBuckets[i] = fishBuckets[i + 1];
                }

                fishBuckets[6] += fishBuckets[9];
                fishBuckets[8] = fishBuckets[9];
            }

            chrono.Stop();
            Console.WriteLine($"There are {fishCount} fish in v2");
            Console.WriteLine($"Fish was simulated in {chrono.Elapsed.Ticks * 100} nanoseconds");
        }
    }
}

//PART 1 - 153002 TOO LOW
//PART 1 - 362346 JUST RIGHT
//PART 2 - 16145419163 TOO LOW
//PART 2 - 1639643057051 JUST RIGHT
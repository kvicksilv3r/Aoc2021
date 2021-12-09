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
            var allFish = File.ReadAllText(@"..\..\..\example6.txt").Split(',').Select(x => Convert.ToInt32(x)).ToList();
            int fishBaby = 8;
            int fishReset = 6;
            var chrono = new Stopwatch();

            chrono.Start();

            for (int day = 0; day < 256; day++)
            {
                var fishCount = allFish.Count;
                for (int fish = 0; fish < fishCount; fish++)
                {
                    allFish[fish]--;
                    if (allFish[fish] < 0)
                    {
                        allFish.Add(fishBaby);
                        allFish[fish] = fishReset;
                    }
                }
            }

            chrono.Stop();

            Console.WriteLine($"Fish was simulated in {chrono.ElapsedMilliseconds} ms");
            Console.WriteLine($"There are {allFish.Count} fish");
        }
    }
}

//PART 1 - 153002 TOO LOW
//PART 1 - 362346 JUST RIGHT
//PART 1 - 29 ms sim
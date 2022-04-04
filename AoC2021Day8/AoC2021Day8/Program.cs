using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2021Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            var matches = new int[] { 2, 4, 3, 7 };
            var inputs = File.ReadAllLines(@"..\..\..\day8.txt").Select(x => x.Split('|')[1]).Select(z => z.Trim()).Select(y => y.Split(' ')).Where(q => matches.Contains(q.Length)).Count();// .ToList();

            foreach (var input in inputs)
            {
                foreach (var thing in input)
                {
                    if (matches.Contains(thing.Length))
                    {
                        counter++;
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}

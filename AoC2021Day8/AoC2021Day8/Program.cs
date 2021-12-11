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
            var inputs = File.ReadAllLines(@"..\..\..\day8.txt");
            int counter = 0;
            var matches = new int[] { 2, 4, 3, 7 };

            foreach (var input in inputs)
            {
                var s = input.Split('|')[1];
                var p = s.Split(' ');

                for (int i = 0; i < p.Length; i++)
                {
                    if (p[i] != "" || p[i] != " ")
                    {
                        if (matches.Contains(p[i].Length))
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}

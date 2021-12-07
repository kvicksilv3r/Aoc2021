using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AoC2021Day4
{
    class BingoBoard
    {
        public BingoBoard()
        {
            values = new List<int>();
        }
        public List<int> values;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\day4.txt").ToArray();

            var rolls = input[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();

            List<BingoBoard> boards = new List<BingoBoard>();
            BingoBoard b = new BingoBoard();

            //parse boards
            for (int i = 2; i < input.Length; i++)
            {
                var a = input[i];
                if (input[i] == "")
                {
                    boards.Add(b);
                    b = new BingoBoard();
                    continue;
                }
                b.values.AddRange(input[i].Trim(',').Split(' ').Where(x => !string.IsNullOrEmpty(x)).Select(x => Convert.ToInt32(x)).ToList());
            }
            boards.Add(b);

            //solve
            for (int roll = 5; roll < rolls.Count; roll++)
            {
                for (int board = 0; board < boards.Count; board++)
                {
                    int winningScore = Solve(boards[board], rolls.GetRange(0, roll));

                    if (winningScore != 0)
                    {
                        Console.WriteLine($"Board {board} won at roll number {roll} with value {rolls[roll]}");
                        Console.WriteLine(winningScore * rolls[roll]);
                        break;
                    }
                }
            }

            Console.ReadLine();
        }

        private static int Solve(BingoBoard bingoBoard, List<int> rolls)
        {
            var horizontal = 0;
            var vertical = 0;

            for (int i = 0; i < 5; i++)
            {
                horizontal = 0;
                vertical = 0;

                for (int o = 0; o < 5; o++)
                {
                    if (rolls.Contains(bingoBoard.values[i * 5 + o]))
                    {
                        horizontal++;
                        if (horizontal > 4)
                        {
                            return bingoBoard.values.Where(x => !rolls.Contains(x)).Sum();
                        }
                    }

                    else
                    {
                        horizontal = 0;

                    }

                    if (rolls.Contains(bingoBoard.values[i + o * 5]))
                    {
                        vertical++;
                        if (vertical > 4)
                        {
                            return bingoBoard.values.Where(x => !rolls.Contains(x)).Sum();
                        }
                    }

                    else
                    {
                        vertical = 0;
                    }
                }
            }
            return 0;
        }
    }
}

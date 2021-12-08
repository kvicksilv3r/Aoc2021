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
            hasWon = false;
        }
        public List<int> values;
        public bool hasWon;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"..\..\..\day4.txt").ToArray();

            var bingoBalls = input[0].Split(",").Select(x => Convert.ToInt32(x)).ToList();

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
            for (int ballIndex = 5; ballIndex < bingoBalls.Count; ballIndex++)
            {
                for (int board = 0; board < boards.Count; board++)
                {
                    int winningScore = Solve(boards[board], bingoBalls.GetRange(0, ballIndex + 1));

                    if (winningScore != 0 && !boards[board].hasWon)
                    {

                        boards[board].hasWon = true;
                        Console.WriteLine($"Board {board} won at roll number {ballIndex} with value {bingoBalls[ballIndex]}");
                        Console.WriteLine(winningScore * bingoBalls[ballIndex]);
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

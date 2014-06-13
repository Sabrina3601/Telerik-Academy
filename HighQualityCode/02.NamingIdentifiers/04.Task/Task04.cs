using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mine
{
    public class Mines
    {
        public class Score
        {
            string name;
            int score;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public int Scores
            {
                get { return score; }
                set { score = value; }
            }

            public Score() { }

            public Score(string name, int score)
            {
                this.Name = name;
                this.Scores = score;
            }
        }

        static void Main(string[] args)
        {
            string comands = string.Empty;
            char[,] field = CreateField();
            char[,] bombs = SetBomb();
            int counter = 0;
            bool boom = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool flag = true;
            const int MARKS = 35;
            bool secondFlag = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
                    " Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
                    Dumpp(field);
                    flag = false;
                }
                Console.Write("Daj red i kolona : ");
                comands = Console.ReadLine().Trim();
                if (comands.Length >= 3)
                {
                    if (int.TryParse(comands[0].ToString(), out row) &&
                    int.TryParse(comands[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        comands = "turn";
                    }
                }
                switch (comands)
                {
                    case "top":
                        Statistic(champions);
                        break;
                    case "restart":
                        field = CreateField();
                        bombs = SetBomb();
                        Dumpp(field);
                        boom = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                Move(field, bombs, row, col);
                                counter++;
                            }
                            if (MARKS == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                Dumpp(field);
                            }
                        }
                        else
                        {
                            boom = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna Komanda\n");
                        break;
                }
                if (boom)
                {
                    Dumpp(bombs);
                    Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
                        "Daj si niknejm: ", counter);
                    string nickname = Console.ReadLine();
                    Score PlayerScore = new Score(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(PlayerScore);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Scores < PlayerScore.Scores)
                            {
                                champions.Insert(i, PlayerScore);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Name.CompareTo(firstPlayer.Name));
                    champions.Sort((Score firstPlayer, Score secondPlayer) => secondPlayer.Scores.CompareTo(firstPlayer.Scores));
                    Statistic(champions);

                    field = CreateField();
                    bombs = SetBomb();
                    counter = 0;
                    boom = false;
                    flag = true;
                }
                if (secondFlag)
                {
                    Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
                    Dumpp(bombs);
                    Console.WriteLine("Daj si imeto, batka: ");
                    string name = Console.ReadLine();
                    Score scores = new Score(name, counter);
                    champions.Add(scores);
                    Statistic(champions);
                    field = CreateField();
                    bombs = SetBomb();
                    counter = 0;
                    secondFlag = false;
                    flag = true;
                }
            }
            while (comands != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Statistic(List<Score> scores)
        {
            Console.WriteLine("\nTo4KI:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} kutii",
                        i + 1, scores[i].Name, scores[i].Name);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("prazna klasaciq!\n");
            }
        }

        private static void Move(char[,] field,
            char[,] bombs, int row, int col)
        {
            char countBombs = CountBombs(bombs, row, col);
            bombs[row, col] = countBombs;
            field[row, col] = countBombs;
        }

        private static void Dumpp(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int row = 0; row < boardRows; row++)
            {
                for (int col = 0; col < boardColumns; col++)
                {
                    board[row, col] = '?';
                }
            }

            return board;
        }

        private static char[,] SetBomb()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> createRandom = new List<int>();
            while (createRandom.Count < 15)
            {
                Random random = new Random();
                int generate = random.Next(50);
                if (!createRandom.Contains(generate))
                {
                    createRandom.Add(generate);
                }
            }

            foreach (int random in createRandom)
            {
                int col = (random / cols);
                int row = (random % cols);
                if (row == 0 && random != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void Calculate(char[,] field)
        {
            int cols = field.GetLength(0);
            int rows = field.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (field[row, col] != '*')
                    {
                        char count = CountBombs(field, row, col);
                        field[row, col] = count;
                    }
                }
            }
        }

        private static char CountBombs(char[,] bomb, int row, int col)
        {
            int count = 0;
            int rows = bomb.GetLength(0);
            int cols = bomb.GetLength(1);

            if (row - 1 >= 0)
            {
                if (bomb[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (bomb[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (bomb[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (bomb[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (bomb[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (bomb[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (bomb[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < row) && (col + 1 < col))
            {
                if (bomb[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}

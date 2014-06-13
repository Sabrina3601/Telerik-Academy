using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class GameFiled
    {
        const string file = "bomberman.bm";
        const int MAX_WIDTH = 41;
        const int MAX_HEIGHT = 32;
        static Position playerFieldPosition = new Position(1, 1);// top  left position for playerField
        static char[,] playerField = new char[MAX_HEIGHT, MAX_WIDTH];
        static ConsoleColor playerFieldBackgroundColor = ConsoleColor.Black;
        static ConsoleColor playerFieldForegroundColor = ConsoleColor.Gray;
        const char brick = (char)0x2588; // brick char­­

        static void InitPlayerField(char[,] matrix)
        {
            // console settings
            Console.CursorVisible = false;
            Console.BackgroundColor = playerFieldBackgroundColor;
            Console.ForegroundColor = playerFieldForegroundColor;

            // Create map
            //left and right border
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = brick;
                matrix[i, matrix.GetLength(1) - 1] = brick;
            }

            //top and bottom border
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = brick;
                matrix[matrix.GetLength(0) - 1, i] = brick;
            }

            // inside bricks
            for (int i = 3; i < matrix.GetLength(0) - 2; i += 4)
            {
                for (int j = 4; j < matrix.GetLength(1) - 2; j += 6)
                {
                    matrix[i, j] = brick;
                    matrix[i + 1, j] = brick;
                    matrix[i + 1, j + 1] = brick;
                    matrix[i, j + 1] = brick;
                    matrix[i + 1, j + 2] = brick;
                    matrix[i, j + 2] = brick;
                }
            }

            // FILLING UP matrix[,] with EMPTY SPACES
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != brick)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
        }

        static void DrawPlayerField(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.SetCursorPosition(playerFieldPosition.col + j, playerFieldPosition.row + i);
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static void InitGame()
        {
            Console.Clear();
            Console.ResetColor();
            Console.Title = "BOMBERMAN GAME";
            System.Console.SetWindowSize(80, 40); // fixed console widnows size

            InitPlayerField(playerField);
            DrawPlayerField(playerField);
        }

        public GameFiled()
        {
            InitGame();
        }
    }
}

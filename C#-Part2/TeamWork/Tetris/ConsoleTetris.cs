using System;
using System.Threading;

namespace Tetris
{
    class ConsoleTetris
    {
        public static Block bigBlock;
        public static Block brickPlayer1;
        public static Block brickPlayer2;
        public static Block brickPlayer1Next;
        public static Block brickPlayer2Next;
        public static int score = 0;
        public static int level = 1;
        public static int millisecond = 0;
        public static int countPrint = 0;
        public static int thread = 1;
        public static bool isGamePaused = false;
        public static Block nextBrick;

        public enum PlayerStartPosition
        {
            PlayerOne = 2, PlayerTwo = 10
        }

        static void PauseTetris()
        {
            if (isGamePaused)
            {
                thread = 1;
                isGamePaused = false;
            }
            else
            {
                thread = 1000;
                isGamePaused = true;
            }
        }

        static void ResetTetris()
        {
            Console.Clear();
            SetGameField();
            brickPlayer1 = GenerateRandomBlock(PlayerStartPosition.PlayerOne);
            brickPlayer1.Print();
            score = 0;
            thread = 1;

        }
        static void PrintStatus()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            PrintOnPosition(34, 1, string.Format("Score: {0, 7}", score));
            PrintOnPosition(34, 3, string.Format("Level: {0, 7}", level));
            PrintOnPosition(34, 5, "R (Reset)");
            PrintOnPosition(34, 7, "P (Pause)");
            PrintOnPosition(33, 11, "|");
            PrintOnPosition(45, 11, "|");
            PrintOnPosition(33, 12, "|");
            PrintOnPosition(45, 12, "|");
            PrintOnPosition(33, 13, "|");
            PrintOnPosition(45, 13, "|");
            PrintOnPosition(33, 14, "|");
            PrintOnPosition(45, 14, "|");
            PrintOnPosition(33, 15, "|");
            PrintOnPosition(45, 15, "|");
            PrintOnPosition(34, 10, "-----------");
            PrintOnPosition(34, 16, "-----------");

        }

        static void PrintOnPosition(int x, int y, string s, ConsoleColor color = ConsoleColor.White)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(s);
        }
        static void Left(Block inp)
        {
            inp.blockPositionX--;

            if (Block.OverlapBlocks(inp, bigBlock))
            {
                inp.blockPositionX++;
            }
            else
            {
                inp.blockPositionX++;
                inp.Clear();
                inp.blockPositionX--;
                inp.Print();
                Sounds.SFX(Sounds.SoundEffects.Move);
            }
        }

        static void Right(Block inp)
        {
            inp.blockPositionX++;

            if (Block.OverlapBlocks(inp, bigBlock))
            {
                inp.blockPositionX--;
            }
            else
            {
                inp.blockPositionX--;
                inp.Clear();
                inp.blockPositionX++;
                inp.Print();
                Sounds.SFX(Sounds.SoundEffects.Move);
            }
        }

        static void Down(Block inp)
        {
            inp.blockPositionY++;

            if (Block.OverlapBlocks(inp, bigBlock))
            {
                inp.blockPositionY--;
                //brickPlayer1 = GenerateRandomBlock();
                brickPlayer1 = nextBrick;
                brickPlayer1.Print();
                bigBlock = bigBlock + inp;
                nextBrick = GenerateRandomBlock(PlayerStartPosition.PlayerOne);
                PrintNextBrick();
            }
            else
            {
                inp.blockPositionY--;
                inp.Clear();
                inp.blockPositionY++;
                inp.Print();
                Sounds.SFX(Sounds.SoundEffects.Move);
            }
        }
        static void Gameover(Block inp)
        {
            if (Block.OverlapBlocks(inp, bigBlock) == true)
            {
                if (bigBlock.blockRows == Console.WindowHeight)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    PauseTetris(); // pause doesn't work!
                    PrintOnPosition(12, 12, "Game Over!");      
                }
            }         
        }
        
        static void Drop(Block inp)
        {
            while (Block.OverlapBlocks(inp, bigBlock) == false)
            {
                score += level * 2; // Bonus score

                inp.blockPositionY++;
                if (Block.OverlapBlocks(inp, bigBlock) == true)
                {
                    inp.blockPositionY--;
                    //brickPlayer1 = GenerateRandomBlock();
                    brickPlayer1 = nextBrick;
                    bigBlock = bigBlock + inp;
                    nextBrick = GenerateRandomBlock(PlayerStartPosition.PlayerOne);
                    PrintNextBrick();
                }
                else
                {
                    inp.blockPositionY--;
                    inp.Clear();
                    inp.blockPositionY++;
                    inp.Print();
                    Sounds.SFX(Sounds.SoundEffects.Move);
                }
            }
        }
        static Block Rotate(Block inp)
        {
            if (inp.blockCols != inp.blockRows) // If it's The O-Tetrimino there's no sence in rotating it
            {
                inp.Clear();
                int[,] newBlock = GenerateRotatedBlockData(inp);
                Block jnp = new Block(inp.blockPositionX, inp.blockPositionY, newBlock);

                //// Try to move the block a bit so it can be rotated. Only valid for the I-Tetrimino!
                //if (Block.OverlapBlocks(jnp, bigBlock)) 
                //{
                //    if (jnp.blockCols > 3)
                //    {
                //        jnp.blockPositionX = jnp.blockPositionX - 2; ;
                //    }
                //}

                if (Block.OverlapBlocks(jnp, bigBlock))
                {
                    inp.Print();
                    return inp;
                }
                else
                {
                    Sounds.SFX(Sounds.SoundEffects.Move);
                    jnp.Print();
                    return jnp;
                }
            }
            return inp;
        }

        static int[,] GenerateRotatedBlockData(Block inp)
        {
            int[,] newBlock = new int[inp.block.GetLength(1), inp.block.GetLength(0)];
            int newColumn, newRow = 0;
            for (int oldColumn = inp.block.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
            {
                newColumn = 0;
                for (int oldRow = 0; oldRow < inp.block.GetLength(0); oldRow++)
                {
                    newBlock[newRow, newColumn] = inp.block[oldRow, oldColumn];
                    newColumn++;
                }
                newRow++;
            }
            return newBlock;
        }

        static void KeyboardReading()
        {
            while (Console.KeyAvailable)
            {
                Console.SetCursorPosition(34, 0);
                Console.ForegroundColor = (ConsoleColor)0;
                Console.BackgroundColor = (ConsoleColor)0;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        Left(brickPlayer1);
                        break;
                    case ConsoleKey.RightArrow:
                        Right(brickPlayer1);
                        break;
                    case ConsoleKey.DownArrow:
                        Down(brickPlayer1);
                        score += level * 1;  // Bonus score
                        break;
                    case ConsoleKey.Spacebar:
                        Drop(brickPlayer1);
                        break;
                    case ConsoleKey.R:
                        ResetTetris();
                        break;
                    case ConsoleKey.P:
                        PauseTetris();
                        break;
                    case ConsoleKey.C:
                    case ConsoleKey.UpArrow:
                        brickPlayer1 = Rotate(brickPlayer1);
                        break;
                    default:
                        break;
                }
            }
        }

        static bool Delay(int level)
        {
            int millisecondNow = DateTime.Now.Millisecond;

            int delay = (21 - level) * 26;

            if (millisecondNow > millisecond)
            {
                if (millisecondNow - millisecond > delay)
                {
                    millisecond = millisecondNow;
                    return false;
                }
            }
            else
                if (millisecondNow - millisecond + 1000 > delay)
                {
                    millisecond = millisecondNow;
                    return false;
                }


            return true;
        }

        public static Block GenerateRandomBlock(PlayerStartPosition player)
        {
            string[] randomColor = { "Gray", "Blue", "Green", "Cyan", "Red", "Magenta", "Yellow",
        "DarkBlue","DarkGreen","DarkMagenta","DarkCyan","DarkRed","DarkYellow"}; // Colors allowed to be used
            Random randomGen = new Random(); // new random instance
            int pos = (int)player;
            int color = (int)Enum.Parse(typeof(ConsoleColor), randomColor[randomGen.Next(0, 12)]); // pick random color from the array
            int pieceType = randomGen.Next(0, 6); // generate random piece
            // Theese are the official Tetris block types
            switch (pieceType)
            {
                case 0:
                    return new Block(pos, 0, new int[,] { { color, color }, { color, color } }); // The O-Tetrimino
                case 1:
                    return new Block(pos, 0, new int[,] { { color, 0, 0 }, { color, color, color } }); // The J-Tetrimino
                case 2:
                    return new Block(pos, 0, new int[,] { { 0, 0, color }, { color, color, color } }); // The L-Tetrimino
                case 3:
                    return new Block(pos, 0, new int[,] { { 0, color, color }, { color, color, 0 } }); // The S-Tetrimino
                case 4:
                    return new Block(pos, 0, new int[,] { { color, color, 0 }, { 0, color, color } }); // The Z-Tetrimino
                case 5:
                    return new Block(pos, 0, new int[,] { { color, color, color, color } }); // The I-Tetrimino
                case 6:
                    return new Block(pos, 0, new int[,] { { 0, color, 0 }, { color, color, color } }); // The T-Tetrimino
                default:
                    return new Block(pos, 0, new int[,] { { 0, color, 0 }, { color, color, color } }); // The T-Tetrimino is default
            }
        }

        static void PrintNextBrick()
        {
            if (countPrint == 10)
            {
                score += 100 * level; //bonus score
                countPrint = 0;
            }
            score += 17 * level;
            countPrint++;

            const int nextBrickX = 36 / 2;
            const int nextBrickY = 12;

            // Clear space for next Brick

            for (int y = 11; y < 16; y++)
            {
                for (int x = 34; x < 44; x++)
                {
                    Console.BackgroundColor = (ConsoleColor)0;
                    Console.SetCursorPosition(x, y);
                    Console.Write("  ");
                }
            }
            Gameover(brickPlayer1);
            nextBrick.Print(nextBrickX, nextBrickY);
        }

        static void CheckForComplateLines()
        {

        }

        static void Main()
        {
            SetGameField();
            brickPlayer1 = GenerateRandomBlock(PlayerStartPosition.PlayerOne);
            nextBrick = GenerateRandomBlock(PlayerStartPosition.PlayerOne);

            PrintNextBrick();
            brickPlayer1.Print();
            //Sounds.Music();

            do
            {
                if (Delay(level) == false)
                {
                    Down(brickPlayer1);
                    PrintStatus();
                }
                KeyboardReading();
                Thread.Sleep(thread);
            } while (true);
        }

        private static void SetGameField()
        {
            Console.Title = "Console Tetris";
            Console.WindowHeight = 25;
            Console.WindowWidth = 50;
            Console.BufferHeight = Console.WindowHeight; // remove the scroll bars
            Console.BufferWidth = Console.WindowWidth; // remove the scroll bars
            Console.CursorVisible = false;

            //intro

            Console.Write(@"Tetris for the Dauntless || C# Console Tetris by Kunglao Team
=======================================

Controls:
[→]         Move Block Right
[←]         Move Block Left
[↑]         Rotate block counterclockwise
[↓]         Push block down 1 Unit
[SPACE]     Drop Block
[C]         Turn Block
[S]         Change direction of block rotation
[R]         Reset
[P]         Pause

[ESC]       Exit Game

Press a Key to start
");
            Console.ReadKey(true);
            Console.Clear();
            // end of intro


            bigBlock = new Block(0, 0, new int[16, 25]);

            for (int i = 0; i < 25; i++)
            {
                bigBlock[0, i] = 15;
                bigBlock[15, i] = 15;
            }
            for (int i = 0; i < 16; i++)
            {
                bigBlock[i, 24] = 15;
            }

            bigBlock.Print();
        }
    }
}

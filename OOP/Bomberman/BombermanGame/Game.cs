// MAIN GAME CODE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BombermanGame
{
    [Serializable()]
    class TestGame
    {
        const string file = "bomberman.bm";
        const int MAX_WIDTH = 41;
        const int MAX_HEIGHT = 31;
        static Position playerFieldPosition = new Position(12, 0);// top  left position for playerField
        static char[,] playerField = new char[MAX_HEIGHT, MAX_WIDTH];
        static ConsoleColor playerFieldBackgroundColor = ConsoleColor.Gray;
        static ConsoleColor playerFieldForegroundColor = ConsoleColor.Blue;
        const char brick = (char)0x2588; // old brick char -> '#'
        // bomberman
        static Man bomberman = new Man(new Position(1, 1));
        static Position bombermanPositionOld = new Position(1, 1);
        //const int bombermanDeffLives = 3;

        // bombs
        const int bombermanBombsMax = 3;
        static int bombermanBombsCounter = 0;

        static int seconds = 0;
        const int maxScore = 10000;

        static List<Bomb> bombList = new List<Bomb>();
        static List<Gad> gadsList = new List<Gad>();
        static System.Threading.Timer secondsCounter;

        static bool restartGame = false;
        static void PrintInfo()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            int x = playerFieldPosition.col + MAX_WIDTH + 2;
            int y = playerFieldPosition.row;
            Console.SetCursorPosition(x, y);
            Console.Write("Score: {0}", maxScore - seconds * 10);
            Console.SetCursorPosition(x, y + 2);
            Console.Write("Lifes: {0}", bomberman.lifes);
            Console.SetCursorPosition(x, y + 4);
            Console.Write("Gads: {0}", gadsList.Count);
            Console.SetCursorPosition(x, y + 6);
            Console.Write("Time from start");
            Console.SetCursorPosition(x, y + 7);
            Console.Write("{0} seconds", seconds);
        }
        static void PrintLegend()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            int x = playerFieldPosition.col + MAX_WIDTH + 2;
            int y = playerFieldPosition.row + 9;
            Console.SetCursorPosition(x, y);
            Console.Write("Controls:");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("Move - Arrow Keys");
            Console.SetCursorPosition(x, y + 3);
            Console.Write("Place Bombs - Spacebar");
            Console.SetCursorPosition(x, y + 5);
            Console.Write("S - save game and exit");
            Console.SetCursorPosition(x, y + 6);
            Console.Write("L - load last game");
            Console.SetCursorPosition(x, y + 7);
            Console.Write("N - new game      ");
        }
        static void LogoPrint()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(new string('#', 9)); Console.Write(new string(' ', 16)); Console.Write(new string('*', 1));
            Console.WriteLine();
            Console.Write(new string('#', 2));
            Console.Write(new string('.', 6));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 14)); Console.Write(new string('*', 3));
            Console.WriteLine();
            Console.Write(new string('#', 2));
            Console.Write(new string('.', 7));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 12)); Console.Write(new string('*', 5));
            Console.WriteLine();
            Console.Write(new string('#', 2));
            Console.Write(new string('.', 7));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 7)); Console.Write(new string('*', 15));
            Console.WriteLine();

            Console.Write(new string('#', 2));
            Console.Write(new string('.', 6));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 9)); Console.Write(new string('*', 13));
            Console.WriteLine();

            Console.Write(new string('#', 9)); Console.Write(new string(' ', 11)); Console.Write(new string('*', 11));
            Console.WriteLine();

            Console.Write(new string('#', 2));
            Console.Write(new string('.', 6));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 9)); Console.Write(new string('*', 13));
            Console.WriteLine();

            Console.Write(new string('#', 2));
            Console.Write(new string('.', 7));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 7)); Console.Write(new string('*', 15));
            Console.WriteLine();

            Console.Write(new string('#', 2));
            Console.Write(new string('.', 7));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 12)); Console.Write(new string('*', 5));
            Console.WriteLine();

            Console.Write(new string('#', 2));
            Console.Write(new string('.', 6));
            Console.Write(new string('#', 2)); Console.Write(new string(' ', 14)); Console.Write(new string('*', 3));
            Console.WriteLine();

            Console.Write(new string('#', 9)); Console.Write(new string(' ', 16)); Console.Write(new string('*', 1));
            Console.WriteLine();
        }
        static void DropTheBomb(Bomb newBomb)
        {
            playerField[newBomb.position.row, newBomb.position.col] = newBomb.body;
            Console.BackgroundColor = newBomb.background;
            Console.ForegroundColor = newBomb.foreground;
            Console.SetCursorPosition(newBomb.position.col + playerFieldPosition.col, newBomb.position.row + playerFieldPosition.row);
            Console.Write(newBomb.body);// print bomb
            // make sound effect
            Console.Beep(3500, 25);
        }
        static void CheckBombs()
        {
            for (int i = 0; i < bombList.Count; i++)
            {
                Bomb current = bombList[i];
                current.delay--;
                if (current.delay < 0)
                {
                    DetonationBombs(current);

                    if (!current.enemyBomb)
                    {
                        bombermanBombsCounter--;
                    }
                    // remove bomb
                    bombList.RemoveAt(i);
                }
                else
                {
                    bombList[i] = current;
                }
            }
        }
        static void DetonationBombs(Bomb myBomb)
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            //blow up bombs code here
            const char detonationSymbol = '*';
            int x = myBomb.position.col + playerFieldPosition.col;
            int y = myBomb.position.row + playerFieldPosition.row;


            for (int i = 1; i <= myBomb.power; i++)// down
            {
                if (playerField[myBomb.position.row + i, myBomb.position.col] == brick)
                    break;
                // print detonationSymbol;
                Console.SetCursorPosition(x, y + i);
                Console.Write(detonationSymbol);
                CheckForGad(myBomb.position.row + i, myBomb.position.col);
            }
            for (int i = 1; i <= myBomb.power; i++)// up
            {
                if (playerField[myBomb.position.row - i, myBomb.position.col] == brick)
                    break;
                // print detonationSymbol;
                Console.SetCursorPosition(x, y - i);
                Console.Write(detonationSymbol);
                CheckForGad(myBomb.position.row - i, myBomb.position.col);
            }
            for (int i = 1; i <= myBomb.power; i++)// left
            {
                if (playerField[myBomb.position.row, myBomb.position.col - i] == brick)
                    break;
                // print detonationSymbol;
                Console.SetCursorPosition(x - i, y);
                Console.Write(detonationSymbol);
                CheckForGad(myBomb.position.row, myBomb.position.col - i);
            }
            for (int i = 1; i <= myBomb.power; i++)// right
            {
                if (playerField[myBomb.position.row, myBomb.position.col + i] == brick)
                    break;
                // print detonationSymbol;
                Console.SetCursorPosition(x + i, y);
                Console.Write(detonationSymbol);
                CheckForGad(myBomb.position.row, myBomb.position.col + i);
            }

            //for (int k = 1; k < 6; k++)
            {
                Console.Beep(2000, 400);
                //  Thread.Sleep(20);
            }

            Console.BackgroundColor = playerFieldBackgroundColor;
            Console.ForegroundColor = playerFieldForegroundColor;

            for (int i = 1; i <= myBomb.power; i++)// down
            {
                if (playerField[myBomb.position.row + i, myBomb.position.col] == brick)
                    break;
                Console.SetCursorPosition(x, y + i);
                Console.Write(' ');
            }
            for (int i = 1; i <= myBomb.power; i++)// up
            {
                if (playerField[myBomb.position.row - i, myBomb.position.col] == brick)
                    break;
                Console.SetCursorPosition(x, y - i);
                Console.Write(' ');
            }
            for (int i = 1; i <= myBomb.power; i++)// left
            {
                if (playerField[myBomb.position.row, myBomb.position.col - i] == brick)
                    break;
                Console.SetCursorPosition(x - i, y);
                Console.Write(' ');
            }
            for (int i = 1; i <= myBomb.power; i++)// right
            {
                if (playerField[myBomb.position.row, myBomb.position.col + i] == brick)
                    break;
                Console.SetCursorPosition(x + i, y);
                Console.Write(' ');
            }

            // erase bomb
            playerField[myBomb.position.row, myBomb.position.col] = ' ';
            Console.SetCursorPosition(myBomb.position.col + playerFieldPosition.col, myBomb.position.row + playerFieldPosition.row);
            Console.BackgroundColor = playerFieldBackgroundColor;
            Console.ForegroundColor = playerFieldForegroundColor;
            Console.Write(' ');// erase old position
            DrawBomberman();
            CheckForGad(myBomb.position.row, myBomb.position.col);
            DrawBomberman();
        }
        static void CheckForGad(int y, int x)
        {
            if (restartGame)
                return;

            if (playerField[y, x] == bomberman.body)
            {
                bomberman.lifes--;
                Console.Beep(4000, 750);
                if (bomberman.lifes <= 0)
                {// GAME OVER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    PrintInfo();
                    bomberman.foreground = ConsoleColor.Black;
                    DrawBomberman();
                    DialogResult res = MessageBox.Show("GAME OVER!\nDo you want to start a new game?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {// start new game 
                        restartGame = true;
                        //InitGame();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                //Search Gad in colection
                for (int i = 0; i < gadsList.Count; i++)
                {
                    Gad current = gadsList[i];
                    if (current.position.row == y && current.position.col == x)
                    {
                        gadsList.RemoveAt(i);
                        playerField[y, x] = ' ';
                    }
                }
                if (gadsList.Count <= 0)
                {
                    DialogResult res = MessageBox.Show("YOU ARE WINNER!\nDo you want a new game?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {// start new game 
                        restartGame = true;
                        //InitGame();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }


        }
        static void InitPlayerField(char[,] matrix)
        {
            // CONSOLE SETTINGS
            Console.CursorVisible = false;
            Console.BackgroundColor = playerFieldBackgroundColor;
            Console.ForegroundColor = playerFieldForegroundColor;

            // FILLING UP matrix[,] ARRAY
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = brick;
                matrix[i, matrix.GetLength(1) - 1] = brick;
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = brick;
                matrix[matrix.GetLength(0) - 1, i] = brick;
            }

            for (int i = 2; i < matrix.GetLength(0); i += 2)
            {
                for (int j = 2; j < matrix.GetLength(1); j += 2)
                {
                    matrix[i, j] = brick;
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
        static void DrawBomberman()
        {
            Console.CursorVisible = false;

            if (playerField[bombermanPositionOld.row, bombermanPositionOld.col] == bomberman.body)
            {
                playerField[bombermanPositionOld.row, bombermanPositionOld.col] = ' ';
                Console.SetCursorPosition(bombermanPositionOld.col + playerFieldPosition.col, bombermanPositionOld.row + playerFieldPosition.row);
                Console.BackgroundColor = playerFieldBackgroundColor;
                Console.ForegroundColor = playerFieldForegroundColor;
                Console.Write(' ');// erase old position
            }

            if (playerField[bomberman.position.row, bomberman.position.col] == ' ')
            {
                playerField[bomberman.position.row, bomberman.position.col] = bomberman.body;
                Console.SetCursorPosition(bomberman.position.col + playerFieldPosition.col, bomberman.position.row + playerFieldPosition.row);
                Console.BackgroundColor = bomberman.background;
                Console.ForegroundColor = bomberman.foreground;
                Console.Write(bomberman.body);// print bomberman
            }

            bombermanPositionOld = bomberman.position;
        }
        static void ErasePosition(int y, int x)
        {
            playerField[y, x] = ' ';
            Console.SetCursorPosition(x + playerFieldPosition.col, y + playerFieldPosition.row);
            Console.BackgroundColor = playerFieldBackgroundColor;
            Console.ForegroundColor = playerFieldForegroundColor;
            Console.Write(' ');// erase old position
        }
        static void PrintGad(Gad gad)
        {
            playerField[gad.position.row, gad.position.col] = gad.body;
            Console.SetCursorPosition(gad.position.col + playerFieldPosition.col, gad.position.row + playerFieldPosition.row);
            Console.BackgroundColor = gad.background;
            Console.ForegroundColor = gad.foreground;
            Console.Write(gad.body);// print bomberman
        }
        static void MoveGads()
        {
            for (int i = 0; i < gadsList.Count; i++)
            {
                Gad current = gadsList[i];

                if (current.moveCount >= current.speed)
                {   // move UP
                    if (current.dir == direction.up)
                    {
                        if (playerField[current.position.row - 1, current.position.col] == ' ' || playerField[current.position.row - 1, current.position.col] == bomberman.body)
                        {   // erase old position
                            ErasePosition(current.position.row, current.position.col);
                            //move to new positon
                            current.position.row--;
                            CheckForGad(current.position.row, current.position.col);
                            PrintGad(current);
                        }
                        else
                        {
                            current.dir = direction.down;
                        }
                    }
                    else if (current.dir == direction.down)
                    {
                        if (playerField[current.position.row + 1, current.position.col] == ' ' || playerField[current.position.row + 1, current.position.col] == bomberman.body)
                        {   // erase old position
                            ErasePosition(current.position.row, current.position.col);
                            //move to new positon
                            current.position.row++;
                            CheckForGad(current.position.row, current.position.col);
                            PrintGad(current);
                        }
                        else
                        {
                            current.dir = direction.up;
                        }
                    }
                    else if (current.dir == direction.left)
                    {
                        if (playerField[current.position.row, current.position.col - 1] == ' ' || playerField[current.position.row, current.position.col - 1] == bomberman.body)
                        {   // erase old position
                            ErasePosition(current.position.row, current.position.col);
                            //move to new positon
                            current.position.col--;
                            CheckForGad(current.position.row, current.position.col);
                            PrintGad(current);
                        }
                        else
                        {
                            current.dir = direction.right;
                        }
                    }
                    else if (current.dir == direction.right)
                    {
                        if (playerField[current.position.row, current.position.col + 1] == ' ' || playerField[current.position.row, current.position.col + 1] == bomberman.body)
                        {   // erase old position
                            ErasePosition(current.position.row, current.position.col);
                            //move to new positon
                            current.position.col++;
                            CheckForGad(current.position.row, current.position.col);
                            PrintGad(current);
                        }
                        else
                        {
                            current.dir = direction.left;
                        }
                    }
                    current.moveCount = 0;
                }
                else
                {
                    current.moveCount++;
                }
                gadsList[i] = current;
                DrawBomberman();
            }

        }
        static void CaptureKey()
        {

            if (!Console.KeyAvailable)
            {
                return;
            }
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);// = Console.ReadKey();
            while (Console.KeyAvailable)// read all buffer
            {
                pressedKey = Console.ReadKey(true);
            }
            bool keyPress = false;

            if (pressedKey.Key == ConsoleKey.LeftArrow && playerField[bomberman.position.row, bomberman.position.col - 1] == ' ')
            {
                bomberman.position.col--;
                keyPress = true;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow && playerField[bomberman.position.row, bomberman.position.col + 1] == ' ')
            {
                bomberman.position.col++;
                keyPress = true;
            }
            else if (pressedKey.Key == ConsoleKey.UpArrow && playerField[bomberman.position.row - 1, bomberman.position.col] == ' ')
            {
                bomberman.position.row--;
                keyPress = true;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow && playerField[bomberman.position.row + 1, bomberman.position.col] == ' ')
            {
                bomberman.position.row++;
                keyPress = true;
            }
            else if (pressedKey.Key == ConsoleKey.Spacebar)
            {
                if (bombermanBombsCounter < bombermanBombsMax)
                {
                    Position pos;
                    pos.col = bomberman.position.col;
                    pos.row = bomberman.position.row;
                    Bomb myBomb = new Bomb(pos);
                    bombList.Add(myBomb);
                    DropTheBomb(myBomb);
                    bombermanBombsCounter++;
                }
            }
            else if (pressedKey.Key == ConsoleKey.N)
            {
                DialogResult res = MessageBox.Show("Do you want to start new game?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    InitGame();
            }
            else if (pressedKey.Key == ConsoleKey.S)
            {
                DialogResult res = MessageBox.Show("Do you want to save game and exit?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {// save game code here 
                    SaveGame();
                    Environment.Exit(0);
                }
            }
            else if (pressedKey.Key == ConsoleKey.L)
            {
                DialogResult res = MessageBox.Show("Do you want to load last saved game?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {// load game from file  
                    LoadGame();
                }
            }

            if (keyPress)
            {
                DrawBomberman();
                Console.Beep(1000, 50);
            }
        }
        static void SaveGame()
        {
            List<Object> objList = new List<object>();
            objList.Add(playerField);
            objList.Add(bomberman);
            objList.Add(bombList);
            objList.Add(gadsList);
            objList.Add(seconds);
            //objList.Add();

            IOSerialization.Serialize(file, objList);
        }
        static void LoadGame()
        {
            Console.Clear();
            Console.ResetColor();
            LogoPrint();
            InitPlayerField(playerField);
            DrawPlayerField(playerField);
            PrintLegend();

            List<Object> objList = new List<object>();
            objList = (List<Object>)IOSerialization.Deserialize(file);

            foreach (var item in objList)
            {
                if (item is char[,])
                {
                    playerField = (char[,])item;
                }
                if (item is Man)
                {
                    bomberman = (Man)item;
                }
                if (item is List<Gad>)
                {
                    gadsList = (List<Gad>)item;
                }
                if (item is List<Bomb>)
                {
                    bombList = (List<Bomb>)item;
                }
                if (item is int)
                {
                    seconds = (int)item;
                }
            }
            bombermanPositionOld = bomberman.position;
            DrawBomberman();
        }
        static void InitGame()
        {
            Console.Clear();
            Console.ResetColor();
            Console.Title = "BOMBERMAN GAME";

            LogoPrint();
            InitPlayerField(playerField);
            DrawPlayerField(playerField);
            PrintLegend();

            bomberman = new Man(new Position(1, 1));
            // gad init
            gadsList.Clear();
            Gad gad = new Gad(new Position(7, 7), 1);
            gad.dir = direction.up;
            gadsList.Add(gad);

            gad.position.row = 11;
            gad.position.col = 11;
            gad.dir = direction.down;
            gadsList.Add(gad);

            gad.position.row = 27;
            gad.position.col = 27;
            gad.dir = direction.up;
            gadsList.Add(gad);

            gad.position.row = 27;
            gad.position.col = 31;
            gad.dir = direction.down;
            gadsList.Add(gad);

            gad.position.row = 9;
            gad.position.col = 17;
            gad.dir = direction.left;
            gadsList.Add(gad);

            gad.position.row = 9;
            gad.position.col = 29;
            gad.dir = direction.right;
            gadsList.Add(gad);

            gad.position.row = 29;
            gad.position.col = 25;
            gad.dir = direction.left;
            gadsList.Add(gad);

            gad.position.row = 25;
            gad.position.col = 3;
            gad.dir = direction.right;
            gadsList.Add(gad);

            DrawBomberman();
            bombList.Clear();
            bombermanBombsCounter = 0;
            seconds = 0;
            restartGame = false;
        }
        static void TimerCallback(Object o)
        {
            seconds++;
        }
        static void Main()
        {
            InitGame();

            secondsCounter = new System.Threading.Timer(TimerCallback, null, 0, 1000);

            while (true)// game main loop
            {
                // get input here
                CaptureKey();
                // do something 
                MoveGads();
                CheckBombs();
                // draw view           
                PrintInfo();

                if (seconds >= maxScore / 10)
                {// GAME OVER
                    PrintInfo();
                    bomberman.foreground = ConsoleColor.Black;
                    DrawBomberman();
                    DialogResult res = MessageBox.Show("TIME IS OVER! YOU LOSE!\nDo you want a new game?", "BOMBERMAN GAME", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        restartGame = true;
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

                if (restartGame)
                    InitGame();

                Thread.Sleep(100);
            }
        }
    }
}

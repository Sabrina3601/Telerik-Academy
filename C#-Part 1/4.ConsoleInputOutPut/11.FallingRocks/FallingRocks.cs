using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

struct Rock
{
    public int x;
    public int y;
    public char r;
    public ConsoleColor color;
    public string strDraw;
}
class FallingRocks
{
    static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(c);
    }
     static void PrintOnDwarfPosition(int x, int y, string strDraw, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(strDraw);
    }

    static void PrintStringOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
    }
    static char[] rocksChar = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '-' }; //symols of rocks
    static ConsoleColor[] rockColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

    static void Main()
    {
        int playfieldWidth = 30;
        int livesCount = 5;
        int score = 0;
        int hardGame = 150;
        Console.BufferHeight = Console.WindowHeight = 30;//size of field
        Console.BufferWidth = Console.WindowWidth = 60;//size of field
        Console.Title = "Falling Rocks";
        
        Rock user = new Rock();// dwarf 
        user.x = 15;
        user.y = Console.WindowHeight - 1;
        user.strDraw = "(0)";
        user.color = ConsoleColor.White ;
        
        Random randomGenerator = new Random();// random generation
        List<Rock> rocks = new List<Rock>(); //list of rocks

        
        while (true)
        {
            bool hitted = false;
            {
                Rock newRock = new Rock();// rocks settings
                newRock.x = randomGenerator.Next(0, playfieldWidth);
                int y = randomGenerator.Next(rocksChar.Length);
                newRock.color = rockColors[randomGenerator.Next(1, 16)];
                newRock.y = 0;
                newRock.r = rocksChar[y];
                rocks.Add(newRock);    
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (user.x - 1 >= 0)
                    {
                        user.x = user.x - 1; //move left
                    }
                }

                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (user.x + 1 < playfieldWidth)
                    {
                        user.x = user.x + 1; //move right
                    }
                }

            }
            List<Rock> newList = new List<Rock>();
           
            for (int i = 0; i < rocks.Count; i++)
            {
                Rock oldRock = rocks[i];
                Rock newRock = new Rock();
                newRock.x = oldRock.x;
                newRock.y = oldRock.y + 1;
                newRock.r = oldRock.r;
                newRock.color = oldRock.color;
                score++;
                if (newRock.y == user.y && newRock.x == user.x || newRock.y == user.y && newRock.x == user.x + 1 || newRock.y == user.y && newRock.x == user.x + 2)
                {
                    livesCount--;
                    hitted = true;
                    if (livesCount<=0)
                    {
                        PrintStringOnPosition(40, 10, "GAME OVER!!!", ConsoleColor.Red);
                        PrintStringOnPosition(35, 12, "Press [enter] to exit...", ConsoleColor.Red);
                        Console.ReadLine();
                        return;
                    }
                }
                if (newRock.y<Console.WindowHeight)
                {
                    newList.Add(newRock);    
                }
            }
            rocks = newList;

            Console.Clear();

            PrintOnDwarfPosition(user.x, user.y, user.strDraw, user.color); //print dwarf
            foreach (Rock rock in rocks)
            {
               
                    PrintOnPosition(rock.x, rock.y, rock.r, rock.color); //print rocks
                
                
            }
            if (hitted)
            {
                PrintOnDwarfPosition(user.x, user.y, "(X)", ConsoleColor.Red);
            }
            
                PrintStringOnPosition(40, 10, "Lives: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(40, 11, "Score: " + score, ConsoleColor.White);

                Thread.Sleep(hardGame); //slow the game;
        }
    }
}


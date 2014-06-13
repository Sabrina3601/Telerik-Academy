using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());


            BigInteger firstScore = 0;
            BigInteger secondScore = 0;

            bool firstPlayerWin = false;
            bool secondPlayerWin = false;

            BigInteger firstPlayerCountWin = 0;
            BigInteger secondPlayerCountWin = 0;

            for (int i = 0; i < n; i++)
            {
                BigInteger firstPlayer = 0;
                BigInteger secondPlayer = 0;
                BigInteger countZFirst = 0;
                BigInteger countZSecond = 0;

                BigInteger countYfirst = 0;
                BigInteger countYSecond = 0;

                bool winFirst = false;
                bool winSecond = false;

                for (int j = 0; j < 3; j++)
                {
                    string card = Console.ReadLine();
                    switch (card)
                    {
                        case "2":
                            firstPlayer += 10;
                            break;
                        case "3":
                            firstPlayer += 9;
                            break;
                        case "4":
                            firstPlayer += 8;
                            break;
                        case "5":
                            firstPlayer += 7;
                            break;
                        case "6":
                            firstPlayer += 6;
                            break;
                        case "7":
                            firstPlayer += 5;
                            break;
                        case"8":
                            firstPlayer += 4;
                            break;
                        case "9":
                            firstPlayer += 3;
                            break;
                        case "10":
                            firstPlayer += 2;
                            break;
                        case"A":
                            firstPlayer += 1;
                            break;
                        case"J":
                            firstPlayer += 11;
                            break;
                        case"Q" :
                            firstPlayer += 12;
                            break;
                        case"K":
                            firstPlayer += 13;
                            break;
                        case "Z":
                            countZFirst++;
                            if (countZFirst == 1)
                            {
                                firstScore = firstScore * 2;
                            }
                            else if (countZFirst == 2)
                            {
                                firstScore = firstScore * 4;
                            }
                            else if (countZFirst == 3)
                            {
                                firstScore = firstScore * 8;
                            }
                            break;
                        case"Y":
                            countYfirst++;
                            if (countYfirst == 1)
                            {
                                firstScore = firstScore - 200;
                            }
                            else if (countYfirst == 2)
                            {
                                firstScore = firstScore - 400;
                            }
                            else if (countYfirst == 3)
                            {
                                firstScore = firstScore -600;
                            }
                            break;
                        case "X":
                            winFirst = true;
                            break;
                        default:
                            break;
                    }
                }

                //second
                for (int j = 0; j < 3; j++)
                {
                    string card = Console.ReadLine();
                    switch (card)
                    {
                        case "2":
                            secondPlayer += 10;
                            break;
                        case "3":
                            secondPlayer += 9;
                            break;
                        case "4":
                            secondPlayer += 8;
                            break;
                        case "5":
                            secondPlayer += 7;
                            break;
                        case "6":
                            secondPlayer += 6;
                            break;
                        case "7":
                            secondPlayer += 5;
                            break;
                        case "8":
                            secondPlayer += 4;
                            break;
                        case "9":
                            secondPlayer += 3;
                            break;
                        case "10":
                            secondPlayer += 2;
                            break;
                        case "A":
                            secondPlayer += 1;
                            break;
                        case "J":
                            secondPlayer += 11;
                            break;
                        case "Q":
                            secondPlayer += 12;
                            break;
                        case "K":
                            secondPlayer += 13;
                            break;
                        case "Z":
                            countZSecond++;
                            if (countZSecond == 1)
                            {
                                secondScore = secondScore * 2;
                            }
                            else if (countZSecond == 2)
                            {
                                secondScore = secondScore * 4;
                            }
                            else if (countZSecond == 3)
                            {
                                secondScore = secondScore * 8;
                            }
                            break;
                        case "Y":
                            countYSecond++;
                            if (countYSecond == 1)
                            {
                                secondScore = secondScore - 200;
                            }
                            else if (countYSecond == 2)
                            {
                                secondScore = secondScore - 400;
                            }
                            else if (countYSecond == 3)
                            {
                                secondScore = secondScore - 600;
                            }
                            break;
                        case "X":
                            winSecond = true;
                            break;
                        default:
                            break;
                    }
                }
                if (winSecond== true && winFirst == true)
                {
                    firstScore += 50;
                    secondScore += 50;
                }
                
                if (firstPlayer > secondPlayer)
                {
                    firstScore += firstPlayer;
                    firstPlayerCountWin++;
                }
                else if (firstPlayer < secondPlayer)
                {
                    secondPlayerCountWin++;
                    secondScore += secondPlayer;
                }

                if (winFirst == true && winSecond == false)
                {
                    firstPlayerWin = true;
                    break;
                }
                if (winSecond == true && winFirst == false)
                {
                    secondPlayerWin = true;
                    break;
                }
            }
            if (firstPlayerWin == true)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (secondPlayerWin == true)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else
            {
                if (firstScore > secondScore)
                {
                    Console.WriteLine("First player wins!");
                    Console.WriteLine("Score: " + firstScore);
                    Console.WriteLine("Games won: " + firstPlayerCountWin);
                }
                else if (firstScore < secondScore)
                {
                    Console.WriteLine("Second player wins!");
                    Console.WriteLine("Score: " + secondScore);
                    Console.WriteLine("Games won: " + secondPlayerCountWin);
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                    Console.WriteLine("Score: " + firstScore);
                }
            }
           
            
        }
    }
}

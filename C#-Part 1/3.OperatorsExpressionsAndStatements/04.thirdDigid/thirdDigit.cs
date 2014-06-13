using System;

class thirdDigid
{
    static void Main()
    {
        Console.WriteLine("Enter a number with more than 4 digit");
        int getNumber = int.Parse(Console.ReadLine());
        int getDigit = getNumber / 100; // get third digid by devided 100
        bool result = getDigit % 10 == 7; // now check 7 is it third digit 
        Console.WriteLine("7 is the third digit: "+ result);
    }
}


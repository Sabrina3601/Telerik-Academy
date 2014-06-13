using System;

class selectBitsToExchange
{
    static void Main()
    {
        Console.WriteLine("Enter a number");
        uint n = uint.Parse(Console.ReadLine());

        Console.WriteLine("Enter how bit to get");
        uint k = uint.Parse(Console.ReadLine());

        Console.WriteLine("Enter a bit position");
        int p = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter another bit position");
        int q = int.Parse(Console.ReadLine());

        string checkNumber = Convert.ToString(n, 2).PadLeft(32, '0');
        Console.WriteLine(checkNumber);

        uint maskNumber = 1;

        for (int i = 0; i < k; i++)
        {
            maskNumber = maskNumber + maskNumber + 1; // that is my logic to change mask bits. If you want to get 3 bit you should use a number 7, becouse 7 convert in bit is 0111
        }

        uint maskFirst = (maskNumber << p) & n;
        uint maskSecond = (maskNumber << q) & n;

        if (p<q)// check which of bit position is bigger
        {
            uint changeFirst = maskFirst << (q-p);
            uint changeSeocnd = maskSecond >> (q-p);

            uint unitMask = changeFirst | changeSeocnd;
            n = (~(maskNumber << p) & n);
            n = (~(maskNumber << q) & n);
            uint result = unitMask | n;
            string checkChangeNumber = Convert.ToString(result, 2).PadLeft(32, '0');
            Console.WriteLine(checkChangeNumber);
            Console.WriteLine(result);
        }
        else
        {
            uint elseChangeFirst = maskFirst >> (p-q);
            uint elseChangeSeocnd = maskSecond << (p-q);

            uint elseUnitMask = elseChangeFirst | elseChangeSeocnd;
            n = (~(maskNumber << p) & n);
            n = (~(maskNumber << q) & n);
            uint elseResult = elseUnitMask | n;
            string checkChangeNumber = Convert.ToString(elseResult, 2).PadLeft(32, '0');
            Console.WriteLine(checkChangeNumber);
            Console.WriteLine(elseResult);
        }
    }
}

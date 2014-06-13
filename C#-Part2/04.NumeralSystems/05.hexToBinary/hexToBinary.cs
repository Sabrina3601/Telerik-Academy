//Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class hexToBinary
{

    static string toBinary(string hexNum)
    {
        string binary = "";
        for (int i = 0; i < hexNum.Length; i++)
        {
            
            if (hexNum[i] == 'A') binary += Convert.ToString(10, 2); //change a hex Value with theire decimal number 
            else if (hexNum[i] == 'B') binary += Convert.ToString(11, 2);//and i use ToString to convert directly in binary
            else if (hexNum[i] == 'C') binary += Convert.ToString(12, 2);
            else if (hexNum[i] == 'D') binary += Convert.ToString(13, 2);
            else if (hexNum[i] == 'E') binary += Convert.ToString(14, 2);
            else if (hexNum[i] == 'F') binary += Convert.ToString(15, 2);
            else binary += Convert.ToString(int.Parse(hexNum[i].ToString()), 2).PadLeft(4,'0');
        }
        return binary;
    }
    static void Main()
    {
        Console.Write("Enter a hex number:");
        string hexNum = Console.ReadLine();

        Console.WriteLine(toBinary(hexNum));
    }
}


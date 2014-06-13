using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

class Sample
{
    static void Main()
    {

       //object  asd = 3*3;

       //Console.WriteLine(asd);
        char[] input = Convert.ToString(Console.ReadLine()).ToCharArray();
        object save = 0;
        for (int i = 0; i < input.Length; i++)
       {
           save = (object)input[i];
        }
        Console.WriteLine(save);

        /*//char[] convertInput = .ToCharArray();
        char [] save = {'*', '%', '+','-','(',')','0','1','2','3','4','5','6','7','8','9'};
        Console.WriteLine(input);

        int saveMath;
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < save.Length; j++)
            {
                if (input[i] == save[j])
                {
                    Console.WriteLine(Convert.ToInt32(input[i]);
                }
            }
        }*/
    }
}
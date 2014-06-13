using System;

class MyAge
{
    static void Main()
    {
        Console.WriteLine("How old are you?");
        int age = int.Parse(Console.ReadLine())+10;
        
        Console.WriteLine("After 10 years your age will be " + age);
    }
}

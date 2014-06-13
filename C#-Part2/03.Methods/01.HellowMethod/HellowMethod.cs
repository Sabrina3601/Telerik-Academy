//Write a method that asks the user for his name and prints “Hello, <name>”
//(for example, “Hello, Peter!”). Write a program to test this method.

using System;

class HellowMethod
{
    static void Hellow(string name)
    {
        Console.WriteLine("Hellow " + name);
    }

    static void Main()
    {
        Console.WriteLine("What is your namer?");
        string name = Console.ReadLine();

        Hellow(name);
    }
}


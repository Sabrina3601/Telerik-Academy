using System;

class BooleanGender
{
    static void Main()
    {
        bool isFemale;
        Console.WriteLine("What is your gender: f/m");
        string answer = Console.ReadLine();
        if (answer == "f" || answer == "F")
        {
            isFemale = true;
            Console.WriteLine(isFemale);
        }
        else
        {
            isFemale = false;
            Console.WriteLine(isFemale);
        }
    }
}


using System;

class Information
{
    static void Main()
    {
        Console.WriteLine("If you want to see my homewrok press y/n.");
        string answer = Console.ReadLine();

        if (answer == "y")
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            System.Diagnostics.Process.Start("explorer.exe", path + @"\telerik-homework.pdf");
        }
        else
        {
            Console.WriteLine("Thank you!");
        }
    }
}

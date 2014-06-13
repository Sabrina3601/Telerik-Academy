//Write a program that parses an URL address given in the format:
//and extracts from it the [protocol], [server] and [resource] elements.
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted
        //[protocol] = "http"
		//[server] = "www.devbg.org"
		//[resource] = "/forum/index.php"

using System;

class urlAddress
{
    static void Main()
    {
        string url = Console.ReadLine();
        string[] splitUrl = url.Split('/');
        string protokol = "[protocol] = " + splitUrl[0].Trim().Remove(splitUrl[0].Length-1);
        string server = "[serve] = " + splitUrl[2].Trim();
        string resource = "[resource] = ";
        for (int i = 3; i < splitUrl.Length; i++)
        {
           resource += "/" + splitUrl[i].Trim();
        }
        Console.WriteLine(protokol);
        Console.WriteLine(server);
        Console.WriteLine(resource);

    }
}


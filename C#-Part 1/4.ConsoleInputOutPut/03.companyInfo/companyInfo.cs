using System;

class companyInfo
{
    static void Main()
    {
        string companyName, address, phone, fax, web, firstname, lastname, age, managerPhone;

        Console.WriteLine("Enter Company name:");
        companyName = Console.ReadLine();

        Console.WriteLine("Enter address of company:");
        address = Console.ReadLine();

        Console.WriteLine("Enter phone number:");
        phone = Console.ReadLine();

        Console.WriteLine("Enter fax:");
        fax = Console.ReadLine();

        Console.WriteLine("Enter website:");
        web = Console.ReadLine();

        Console.WriteLine("Enter manager first name of company:");
        firstname = Console.ReadLine();

        Console.WriteLine("Enter last name:");
        lastname = Console.ReadLine();

        Console.WriteLine("Enter manager age:");
        age = Console.ReadLine();

        Console.WriteLine("Enter manager phone number:");
        managerPhone = Console.ReadLine();
        // print all information
        Console.WriteLine("Company information:\n Name:{0} \n Adress: {1} \n Phone: {2} \n Fax: {3} \n Website: {4}",companyName, address, phone, fax, web);
        Console.WriteLine("Manager Info: \n First Name: {0} \n Last Name: {1} \n Age: {2} \n Phone: {3}", firstname, lastname, age, managerPhone);
    }
}


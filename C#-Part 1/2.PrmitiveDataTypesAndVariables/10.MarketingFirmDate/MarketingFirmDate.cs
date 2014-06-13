using System;

class MarketingFirmDate
{
    static void Main()
    {
        string firstName, familyName;
        byte age;
        char gender;
        int idNumber, uniqueNumber;

        firstName = "Ivan";
        familyName = "Ivanov";
        age = 21;
        gender = 'm';
        idNumber = 2139;
        uniqueNumber = 75256489;

        Console.WriteLine("Personal information about " + firstName + " " + familyName + ", " + age + ", gender:" + gender + " with id number " + idNumber + " and unique number " + uniqueNumber + ".");
    }
}

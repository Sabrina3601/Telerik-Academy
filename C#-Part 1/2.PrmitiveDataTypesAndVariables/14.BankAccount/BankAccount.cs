using System;

class BankAccount
{
    static void Main()
    {
        string firstName, middleName, lastName, bankName, iBan, bicCode;
        decimal moneyBalance;
        ulong FirstCreditCart, SecondCreditCart, ThirdCreditCart;

        firstName = "Ivan";
        middleName = "Ivanov";
        lastName = "Ivanonv";

        moneyBalance = 2213421m;
        bankName = "ProCredit Bank";
        iBan = "BG0158GE556CE2010";
        bicCode = "BICBG1205";
        FirstCreditCart = 5626465132192316;
        SecondCreditCart = 321651321633235;
        ThirdCreditCart = 8562123156169131;

        Console.WriteLine("{0} {1} {2} your balance is {3} in our bank {4}. Informtion about our account: IBAN: {5}, BICCODE: {6}, and your Credit Cart numbers are: {7}, {8}, {9}", firstName, middleName, lastName, moneyBalance, bankName, iBan, bicCode, FirstCreditCart, SecondCreditCart, ThirdCreditCart);


    }
}
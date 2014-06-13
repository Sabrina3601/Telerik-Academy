using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
//Customers could be individuals or companies.
//All accounts have customer, balance and interest rate (monthly based). 
//Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
//All accounts can calculate their interest amount for a given period (in months). 
//In the common case its is calculated as follows: number_of_months * interest_rate.

namespace _02.BankSystem
{
    class Test
    {
        static void Main()
        {
            Account[] accounts = new Account[]
            {
                new DepositAccount(new Customer("Ivan","Ivanonv"),1000m,4,12),
                new DepositAccount(new Customer("Asen","Ivanonv"),2000m,8,6),
                new DepositAccount(new Customer("Kiro","Asenov"),8000m,12,8),
            };

            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1} - interest amount = {2}", account.Customer.FirstName, account.Customer.LastName, account.CalculateInterestAmount());
            }

            //deposit accc test
            Console.WriteLine();
            DepositAccount depositAcc = new DepositAccount(new CompaniesCustumer("Borislav", "Bliznashki"), 1000m, 3, 6);
            depositAcc.DepositMoney(1000m);
            depositAcc.DrawMoneyBank(200m);
            Console.WriteLine("{0} {1} balance: {2}",depositAcc.Customer.FirstName, depositAcc.Customer.LastName,depositAcc.Balance);
     
            //loan acc test
            LoanAccount loanAcc = new LoanAccount( new IndividualCustumers("Konstantin", "Hadjiev"), 15000m, 12, 12);
            loanAcc.DepositMoney(11000m);
            Console.WriteLine("{0} {1} balance: {2}", loanAcc.Customer.FirstName, loanAcc.Customer.LastName, loanAcc.Balance);

            //mortgage acc test
            MortgageAccount mortgageAcc = new MortgageAccount(new CompaniesCustumer("Viktor", "Pavlov"), 5000m, 1, 6);
            mortgageAcc.DepositMoney(10000m);
            Console.WriteLine("{0} {1} balance: {2}", mortgageAcc.Customer.FirstName, mortgageAcc.Customer.LastName, mortgageAcc.Balance);
        }
    }
}

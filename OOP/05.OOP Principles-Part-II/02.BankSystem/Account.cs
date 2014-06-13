using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystem
{
    public abstract class Account
    {
        public Customer Customer { get; set; }
        public decimal Balance { get; set; }
        public int InterestRate { get; set; }
        public int DepositPeriod { get; set; }

        public Account(Customer customer, decimal balance, int interestRate , int depositPeriod)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.DepositPeriod = depositPeriod;
        }

        public abstract int CalculateInterestAmount();
    }
}

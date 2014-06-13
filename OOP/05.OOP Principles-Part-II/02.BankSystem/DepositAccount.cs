using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystem
{
    public class DepositAccount : Account, IDepositble, IDrawable
    {
        public DepositAccount(Customer customer, decimal balance, int interestRate, int depositPeriod)
            : base(customer, balance, interestRate, depositPeriod)
        {
        }

        public void DepositMoney(decimal deposit)
        {
            Balance += deposit;
        }

        public void DrawMoneyBank(decimal drawMoney)
        {
            Balance -= drawMoney;
        }

        public override int CalculateInterestAmount()
        {
            if (this.Balance <= 1000)
            {
                return 0;
            }
            else
            {
                return (int)(InterestRate * DepositPeriod);
            }
           
        }
    }
}

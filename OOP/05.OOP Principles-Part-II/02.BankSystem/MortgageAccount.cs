using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystem
{
    class MortgageAccount :Account, IDepositble
    {
        public MortgageAccount(CompaniesCustumer customer, decimal balance, int interestRate, int depositPeriod)
            : base(customer, balance, interestRate, depositPeriod)
        {
        }
        
        public void DepositMoney(decimal deposit)
        {
            Balance += deposit;
        }

        public override int CalculateInterestAmount()
        {
            if (this.Customer is CompaniesCustumer && this.DepositPeriod <= 12)
            {
                return (int)((this.DepositPeriod * this.InterestRate) / 2M);
            }
            else if (this.DepositPeriod <= 6 && this.Customer is IndividualCustumers)
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

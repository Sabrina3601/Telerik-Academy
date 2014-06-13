using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystem
{
    public class LoanAccount : Account,IDepositble
    {

        public LoanAccount(Customer customer, decimal balance, int interestRate, int depositPeriod)
            : base(customer, balance, interestRate, depositPeriod)
        {
        }
        
        public void DepositMoney(decimal deposit)
        {
            Balance += deposit;
        }

        public override int CalculateInterestAmount()
        {
            if (this.DepositPeriod <= 3 && Customer is IndividualCustumers)
            {
                return 0;
            }
            else if (this.DepositPeriod <= 2 && Customer is CompaniesCustumer)
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

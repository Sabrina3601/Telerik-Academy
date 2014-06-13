using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankSystem
{
    public class IndividualCustumers :Customer
    {
        public IndividualCustumers(string firstName, string lastName)
            : base(firstName,lastName)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Task1
{
    class Bool
    {
        const int MAX_COUNT = 6;

        class BoolChecker
        {
            internal void BoolCheck(bool inputVar)
            {
                string inputVarToString = inputVar.ToString();
                Console.WriteLine(inputVarToString);
            }
        }

        public static void Main()
        {
            Bool.BoolChecker instance = new Bool.BoolChecker();
            instance.BoolCheck(true);
        }
    }

}

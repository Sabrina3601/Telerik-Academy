using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    class GSMCallHistoryTest
    {
        static void Main()
        {
            Gsm myPhone = new Gsm("Galaxy", "Samsung");
            Call newCallFirst = new Call("0888123456", 15);
            Call newCallSecond = new Call("0888123456", 20);
            Call newCallThird = new Call("0888123456", 30);
            // add calls information
            myPhone.AddCall(newCallFirst);
            myPhone.AddCall(newCallSecond);
            myPhone.AddCall(newCallThird);
            PrintCallHistory(myPhone.GetCallHistory());//print call history
            //print total Price of the calls
            Console.WriteLine("Total Price of the calls is: {0}",myPhone.CalculateTotalPrice(0.37f));

            int longest = 0;
            int index = 0;
            int lastIndex = 0;
            foreach (var item in myPhone.GetCallHistory())
            {
                if (item.Duration > longest)
                {
                    longest = item.Duration;
                    lastIndex = index;
                }
                index++;
            }
            myPhone.DeleteCall(lastIndex);
            Console.WriteLine("Total Price of the calls is: {0}", myPhone.CalculateTotalPrice(0.37f));
            myPhone.ClearCallHistory();
            PrintCallHistory(myPhone.GetCallHistory());
        }

        private static void PrintCallHistory(List<Call> CallHistory)
        {
            if (CallHistory.Count == 0)
            {
                Console.WriteLine("Call history is empty!");
                return;
            }
            Console.WriteLine("Calls in call history:");
            foreach (var call in CallHistory)
            {
                Console.WriteLine("Number: {0}, Call Duration: {1}sec, Date: {2} ", call.NumberDialed, call.Duration, call.Date);
            }
        }
        
    }
}

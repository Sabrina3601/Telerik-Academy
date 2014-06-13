using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace _07.TimerMethod
{
    public class Timer
    {
        public delegate void MethodToExecute();
        public MethodToExecute method;

        public void Start(int intervalInSeconds, int totalTimeInSeconds)
        {
            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(totalTimeInSeconds);
            while (start <= end)
            {
                method();
                Thread.Sleep(intervalInSeconds * 1000);
                start = DateTime.Now;
            }
        }
    }

    class timerMethod
    {
        public static void DateAndTime()
        {
            Console.WriteLine(DateTime.Now);
        }

        static void Main()
        {
            Timer timer = new Timer();
            timer.method = DateAndTime;
            timer.Start(1, 10);
        }
    }
}

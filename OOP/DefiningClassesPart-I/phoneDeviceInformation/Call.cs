using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    class Call
    {
        private DateTime date;
        private DateTime time;
        private string numberDialed;
        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value;}
        }

        public string NumberDialed
        {
            get { return numberDialed; }
            set{ numberDialed = value;}
        }

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Call(string number, int getDuration)
        {
            date = DateTime.Today;
            time = DateTime.Now;
            numberDialed = number;
            duration = getDuration;
        }
    }
}

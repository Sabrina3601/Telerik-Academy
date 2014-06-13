using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    public enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
    class Battery
    {
        private string model;
        private double? idle;
        private double? talks;
        private BatteryType batteryType;

        public string Model
        {
            // getter of the property Model
            get { return this.model;}
            // setter of the property Model
            set { this.model = value; }

        }
        
        public double? Idle 
        {
            get { return this.idle;}
            set { this.idle = value; }
        }

        public double? Talks 
        {
            get { return this.talks;}
            set { this.talks = value; }
        }
        public BatteryType batteryTypes
        {
            get { return this.batteryType; }
            set { this.batteryType = value; }
        }
        //Default constructor
        public Battery()
            : this(null, null, null,BatteryType.LiIon)
        {
        }

        public Battery(string getModel) : this(null,null,null,BatteryType.LiIon)
        {
            this.model = getModel;
        }

        //Constructors with parameters
        public Battery(string getModel, double? getIdle, double? getTalks,BatteryType batteryType)
        {
            this.model = getModel;
            this.idle = getIdle;
            this.talks = getTalks;
            this.batteryType = batteryType;
        }

        //public void Print()
        //{
        //    Console.WriteLine("Model: {0}", this.Model);
        //    Console.WriteLine("Idle: {0}", this.Idle);
        //    Console.WriteLine("Tals: {0}", this.Talks);
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    class Gsm
    {
        private string model;
        private string manafacturer;
        private decimal? price;
        private string owner;
        private static Gsm iPhone4S;
        private List<Call> callHistory;

        //properties
        public string Model
        {
            get { return this.model; }//getter
            set { this.model = value; }//setter
        }

        public string Manafacturer
        {
            get { return this.manafacturer; }
            set { this.manafacturer = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
        public Gsm IPhone4S
        {
            get { return this.IPhone4S; }
        }

        public static Gsm CreateIphone()
        {
            iPhone4S = new Gsm("Iphone 4S", "Apple");
            return iPhone4S;
        }

        public List<Call> CallHistory
        {
            get { return callHistory; }
            set { callHistory = value; }
        }

        public Gsm()
            : this(null, null, null, null)
        {
        }

        public Gsm(string getModel, string getManafacture):this(null,null,null,null)
        {
            this.model = getModel;
            this.manafacturer = getManafacture;
        }
        public Gsm(string getModel, string getManafacture, decimal? getPrice, string getOwner)
        {
            this.model = getModel;
            this.manafacturer = getManafacture;
            this.price = getPrice;
            this.owner = getOwner;
            this.CallHistory = new List<Call>();
        }

        //Add, Delete and Clear CallHistory methods
        public void AddCall(Call newCall)
        {
            this.CallHistory.Add(newCall);
        }
        public void DeleteCall(Call myCall) // remove given call
        {
            this.CallHistory.Remove(myCall);
        }
        public void DeleteCall(int index) // remove at given index
        {
            this.CallHistory.RemoveAt(index);
        }
        public void ClearCallHistory()
        {
            this.CallHistory.Clear();
        }
        public List<Call> GetCallHistory()
        {
            return this.CallHistory;
        }

        // calculate total price of the calls in the CallHistory with given price per minute
        public float CalculateTotalPrice(float pricePerMinute)
        {
            float totalPrice = 0;
            foreach (var call in CallHistory)
            {
                totalPrice += call.Duration * pricePerMinute / 60;
            }
            return totalPrice;
        } 

        //call battery and display info
        public Battery BatteryInfo = new Battery();
        public Display DisplayInfo = new Display();

       //override ToString
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Model: " + this.model);
            sb.AppendLine("Manufacturer: " + this.manafacturer);
            sb.AppendLine("Price: " + this.price + "lv");
            sb.AppendLine("Owner: " + this.owner);
            sb.AppendLine("Battery model: " + BatteryInfo.Model);
            sb.AppendLine("Hours idle: " + BatteryInfo.Idle);
            sb.AppendLine("Hours talks: " + BatteryInfo.Talks);
            sb.AppendLine("Battery type: " + BatteryInfo.batteryTypes);
            sb.AppendLine("Display size: " + DisplayInfo.Size);
            sb.AppendLine("Display colors: " + DisplayInfo.Colors);

            return sb.ToString();
            
        }
        //public void Print()
        //{
        //    Console.WriteLine("Manafacturer: {0}", this.Manafacturer);
        //    Console.WriteLine("Model: {0}", this.Model);
        //    Console.WriteLine("Owner: {0}", this.Owner);
        //    Console.WriteLine("Price: {0} EUR", this.Price);
        //}
    }
}

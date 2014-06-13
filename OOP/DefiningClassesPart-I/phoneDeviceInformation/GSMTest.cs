using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.phoneDeviceInformation
{
    class GSMTest
    {
        static void TestGsm()
        {
            Gsm[] gsmArr = new Gsm[5];   
            string[] models = { "Nokia", "Samsung", "HTC", "Iphone", "Sony" };
            int[] prices = { 100, 300, 500, 600, 900 };
            string[] owners = { "Martin", "Alex", "Antonela", "Ivan", "Spas" };
            string[] manifacturers = { "China", "BG", "Japan", "USA", "Tailand" };

            for (int i = 0; i < gsmArr.Length; i++)
            {
                gsmArr[i] = new Gsm(models[i], manifacturers[i], prices[i], owners[i]);
                Console.WriteLine("Diplay all information:");
                Console.WriteLine(gsmArr[i].ToString());
            }
            Console.WriteLine(Gsm.CreateIphone());
            
        }
        
    }
}

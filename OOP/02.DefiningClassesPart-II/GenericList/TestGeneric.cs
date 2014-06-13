using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface
    | AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
 
public class VersionAttribute : System.Attribute
{
    public int Major { get; private set; }
    public int Minor { get; private set; }
 
    public VersionAttribute(int major, int minor)
    {
        this.Major = major;
        this.Minor = minor;
    }
}
[VersionAttribute(4, 11)]

    class TestGeneric
    {

        static void Main()
        {
            GenericList<int> list = new GenericList<int>();
            list.Add(2);
            list.Add(20);
            list.Add(15);
            list.InsetElement(1,22);
            Console.WriteLine(list.ToString());
            int min = list.Min();
            int max = list.Max();
            Console.WriteLine(min);
            Console.WriteLine(max);
            list.Clear();
            Console.WriteLine(list.ToString());
            
        }
    
    }
}

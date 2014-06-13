using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Implement an extension method Substring(int index, int length) for the class StringBuilder 
//that returns new StringBuilder and has the same functionality as Substring in the class String.


namespace _01.SubstringBuilder
{
    public static class StringBuilderFunctionality
    {

        public static StringBuilder SubStringBuilder(this StringBuilder sb, int index, int lenght)
        {
            string temp = sb.ToString();
            temp = temp.Substring(index, lenght);
            sb.Clear();
            sb.Append(temp);
            return sb;
        }

        public static StringBuilder SubStringBuilder(this StringBuilder sb, int index)
        {
            string temp = sb.ToString();
            temp = temp.Substring(index);
            sb.Clear();
            sb.Append(temp);
            return sb;
        }
    }

    class SubStringBuilderTest
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Let's test it");
            StringBuilder sbSubString = sb.SubStringBuilder(2,3);
            Console.WriteLine(sbSubString.ToString());
        }
    }
}

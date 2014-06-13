//Write a method that adds two positive integer numbers represented as arrays of digits
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Numerics;

class representNumber
{

    static BigInteger SumIt(BigInteger firstNum, BigInteger secNum)
    {
        string first = firstNum.ToString();
        string second = secNum.ToString();
        BigInteger result = 0;
        if (second.Length> first.Length)
        {
            string save;
            save = second;
            second = first;
            first = save;
        }
         if (first.Length > second.Length || first.Length == second.Length)
        {
            int minus = first.Length - second.Length;
            string zero = new string('0', minus);
            string[] strSum = new string[first.Length];
            second = zero + second;
            int sum = 0;
            int count = 0;
            for (int i = first.Length-1; i >= 0; i--)
            {
                sum += (int.Parse(first[i].ToString()) + int.Parse(second[i].ToString()));
                if (count == 1)
                {
                    sum += 1;
                }
                if (sum == 10)
                {
                    if (first.Length != 1)
                    { 
                        strSum[i] = "0";
                        if (count == 0)
                        {
                            count++;
                        }  
                    }
                    else
                    {
                        strSum[i] = sum.ToString();
                    }
                    
                }
                else if (sum > 10)
                {   

                    strSum[i] = (sum % 10).ToString();
                    if (count == 0)
                    {
                        count++;
                    }                   
                }
                else
                {
                    strSum[i] = sum.ToString();
                    count = 0;
                }
                sum = 0;
            }
            
            string strResult = "";
            for (int i = 0; i <= strSum.Length-1; i++)
            {
                strResult += strSum[i];
            }
             if (count == 1)
            {
                strResult = "1" + strResult;
            }
            result = BigInteger.Parse(strResult.ToString());
        }
        
        return result;
    }
    static void Main()
    {
        BigInteger firstNum = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNum = BigInteger.Parse(Console.ReadLine());
        Console.WriteLine(  SumIt(firstNum, secondNum) );

    }
}


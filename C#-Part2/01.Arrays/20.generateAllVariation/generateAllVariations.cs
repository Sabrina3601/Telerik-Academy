

using System;

class AllVariations
{
    static int N = int.Parse(Console.ReadLine());
    static int K = int.Parse(Console.ReadLine());
    static int[] loops = new int[N];
    static int[] combLoop;

    static void Main()
    {
        Variations(0,1);
    }

    static void Variations(int currentK, int start)
    {
        if (currentK == N)
        {
            Print();
            return;
        }
        else
        {
            for (int i = start; i <= K; i++)
            {
                loops[currentK] = i;
                Variations(currentK + 1 , start+1);
            }
        }
    }

    static void Print()
    {

     
        for (int i = 0; i < N; i++)
        { 
            Console.Write(loops[i] + " ");
        }
        Console.WriteLine();
    }

    

   
}


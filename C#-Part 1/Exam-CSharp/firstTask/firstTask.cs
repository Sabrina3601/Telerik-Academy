using System;

class firstTask
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        
        if (N>1 && N <40)
        {
            int height = 6 + ((N - 3) / 2) * 3;
            Console.Write(new string('.', N));
            Console.Write("*");
             Console.Write(new string('.', N));
             Console.WriteLine();

             Console.Write(new string('.', N-1));
             Console.Write("***");
             Console.Write(new string('.', N-1));
             Console.WriteLine();


            for (int i = 2; i < N; i++)
            {
                int save = N - i;
                Console.Write(new string('.', N - i));
                Console.Write("*");
                Console.Write(new string('.', N - (save + 1)));
                Console.Write("*");
                Console.Write(new string('.', N - (save + 1)));
                Console.Write("*");
                Console.Write(new string('.', N-i));
                Console.WriteLine();
            }
            Console.Write(new string('*',(N*2)+1));
            Console.WriteLine();
            int bottom = height - (N + 1);
            
           /* for (int i = 1; i <= bottom -1; i++)
            {
                if (bottom == 2)
                {
                    bottom--;
                }
                Console.Write(new string('.', i));
                Console.Write("*");
                Console.Write(new string('.', bottom - (i-1)));
                Console.Write("*");
                Console.Write(new string('.', bottom - (i - 1)));
                Console.Write("*");
                Console.Write(new string('.', i));
                Console.WriteLine();
                if (bottom == 1)
                {
                    bottom++;
                }
               
            }
            int dot = ((((N*2)+1)-5)/2);
            if (bottom==2)
            {
                dot+= 1;
            }
            //Console.WriteLine(bottom);
            Console.Write(new string('.', dot));
            Console.Write(new string('*', N));
            Console.Write(new string('.', dot));*/
            int increase = 1;
            int other = (height / 3);
            for (int i = (height / 3) -1; i > 0; i--)
            {

                Console.Write(new string('.', increase));
                Console.Write("*");
                Console.Write(new string('.', N - (increase+1)));
                Console.Write("*");
                Console.Write(new string('.', N - (increase + 1)));
                Console.Write("*");
                Console.Write(new string('.', increase));
                Console.WriteLine();
                increase++;
                other++;
            }
           
            
                Console.Write(new string('.', bottom));
                Console.Write(new string('*', N));
                Console.Write(new string('.', bottom));
            
        }
    }
}


using System;

    class Program
    {
        static void Main()
        {
            string number = Console.ReadLine();

            

           char[] numberArray = Convert.ToString(number).ToCharArray();
            //Console.WriteLine(numberArray);

            int lenghtNumber = number.Length;

            int sum = 0;
            int amount = 0;
            
            for (int i = 0; i < lenghtNumber; i++)
            {
                if (i%2==1)
                {
                    if (numberArray[i] == '!' || number[i] == '@' || number[i] == '$' || number[i] == '^' || number[i] == '&'
                        && number[i] == '*' || number[i] == '(' || number[i] == ')' || number[i] == '&' || number[i] == '-' || number[i] == '+'
                        && number[i] == '=' || number[i] == '_' || number[i] == '|' || number[i] == '\\' || number[i] == '}' || number[i] == ']'
                        || number[i] == '{' || number[i] == '[' || number[i] == ';' || number[i] == ':' || number[i] == '"' || number[i] == '/'
                        || number[i] == '>' || number[i] == '<' || number[i] == '?' || number[i] == ',' || number[i] == '.' || number[i] == 'a'
                        || number[i] == 'b' || number[i] == '*' || number[i] == 'c' || number[i] == 'd' || number[i] == 'e' || number[i] == 'f'
                        || number[i] == 'g' || number[i] == 'h' || number[i] == 'i' || number[i] == 'j' || number[i] == 'k' || number[i] == 'l'
                        || number[i] == 'm' || number[i] == 'n' || number[i] == 'o' || number[i] == 'p' || number[i] == 'q' || number[i] == 'r'
                        || number[i] == 's' || number[i] == 't' || number[i] == 'u' || number[i] == 'v' || number[i] == 'w' || number[i] == 'x'
                        || number[i] == 'y' || number[i] == 'z' || number[i] == 'A' || number[i] == 'B' || number[i] == 'C' || number[i] == 'D'
                        || number[i] == 'E' || number[i] == 'F' || number[i] == 'G' || number[i] == 'H' || number[i] == 'I' || number[i] == 'G'
                        || number[i] == 'K' || number[i] == 'L' || number[i] == 'M' || number[i] == 'N' || number[i] == 'M' || number[i] == 'O'
                        || number[i] == 'P' || number[i] == 'Q' || number[i] == 'R' || number[i] == 'S' || number[i] == 'T' || number[i] == 'U'
                        || number[i] == 'V' || number[i] == 'W' || number[i] == 'X' || number[i] == 'Y' || number[i] == 'Z')
                    {
                        continue;
                    }
                    else
                    {
                        string num = Convert.ToString(number[i]);
                        int convert = int.Parse(num);
                        sum += convert;
                        amount++;
                    }
                }
            }
            Console.WriteLine(amount + " " + sum);
            
        }
    }


using System;
using System.Collections.Generic;

namespace SimpleList
{

    class Program
    {
        public static void Main(string[] args)
        {

            PrimeNumbers objPN = new PrimeNumbers();
            objPN.Reverse = false;
            objPN.EndPGM = false;

            while (objPN.EndPGM == false)
            {
                Console.Clear();

                Console.WriteLine("Algorithm to find the Prime Numbers");
                Console.WriteLine(" ");

                Console.WriteLine("What is the maximum number?");
                var UserNumber = Console.ReadLine();

                Console.WriteLine("Show the numbers in reverse order? Y=Yes");
                var userOption = Console.ReadLine();

                if (userOption == "Y" || userOption == "y")
                {
                    objPN.Reverse = true;
                }

                try
                {
                    objPN.MaxNumber = Int32.Parse(UserNumber);
                    objPN.DisplayPrimeNumbers();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Do you want to exit? Y=Yes");
                    userOption = Console.ReadLine();

                    if (userOption == "Y" || userOption == "y")
                    {
                        objPN.EndPGM = true;
                    }
                }
                catch (SystemException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("User Input Invalid");
                    Console.ReadLine();
                }
                
            }
        }
    }
}

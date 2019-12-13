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
            objPN.Range = false;

            while (objPN.EndPGM == false)
            {
                Console.Clear();

                Console.WriteLine("Algorithm to find the Prime Numbers");

                Console.WriteLine(" ");
                Console.WriteLine("Do you want to define a range of numbers? Y=Yes");
                var userOption = Console.ReadLine();

                if (userOption == "Y" || userOption == "y")
                {
                    objPN.Range = true;
                    Console.WriteLine(" ");
                    Console.WriteLine("What is the minimum number of your range?");
                    var UserMinNumber = Console.ReadLine();
                    try
                    {
                        objPN.MinNumber = Int32.Parse(UserMinNumber);
                    }
                    catch (SystemException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("User Input Invalid. No Range will be used.");
                        Console.ReadLine();
                    }

                }

                Console.WriteLine(" ");
                Console.WriteLine("What is the maximum number?");
                var UserNumber = Console.ReadLine();

                try
                {
                    objPN.MaxNumber = Int32.Parse(UserNumber);

                    if ((objPN.Range == true) & (objPN.ValidRange() == false))
                    {
                        Console.WriteLine("Invalid Range! Try again.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Show the numbers in reverse order? Y=Yes");
                        userOption = Console.ReadLine();

                        objPN.Reverse = false;
                        if (userOption.ToLower() == "y" || userOption.ToLower() == "yes")
                        {
                            objPN.Reverse = true;
                        }

                        Console.WriteLine("Do you want to use Speed format?");
                        userOption = Console.ReadLine();

                        objPN.SpeedUp = false;
                        if (userOption == "Y" || userOption == "y")
                        {
                            objPN.SpeedUp = true;
                        }

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

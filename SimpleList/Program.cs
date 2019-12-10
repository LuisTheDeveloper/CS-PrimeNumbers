using System;
using System.Collections.Generic;

namespace SimpleList
{

    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Algorithm to find the Prime Numbers starting at 2");
            Console.WriteLine(" ");

            PrimeNumbers objPN = new PrimeNumbers();

            Console.WriteLine("What is the maximum number?");
            var UserNumber = Console.ReadLine();

            objPN.MaxNumber =  Int32.Parse(UserNumber);
            objPN.DisplayPrimeNumbers();
            Console.ReadLine();

        }
    }
}

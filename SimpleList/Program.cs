using System;
using System.Collections.Generic;

public class SamplesArrayList
{

    public static void Main(string[] args)
    {
        int wTemp = 0;
        
        IList<int> intList = new List<int>();

        var PrimeNumbers = new List<int>();
        var NonPrimeNumbers = new List<int>();

        Console.WriteLine("Algorithm to find the Prime Numbers starting at 2");
        Console.WriteLine(" ");

        Console.WriteLine("What is the maximum number?");
        var UserNumber = Console.ReadLine();


        try
        {
            var MaxNumber = Int32.Parse(UserNumber);
            Console.WriteLine($"Displaying Prime Numbers from 2 to {MaxNumber}");

            //Let's add all the integers numbers to the List
            for (int i = 2; i <= MaxNumber; i++)
            {
                if (!PrimeNumbers.Contains(i) & !NonPrimeNumbers.Contains(i))
                {
                    PrimeNumbers.Add(i);
                }  

                for (int j = i; j <= MaxNumber; j++)
                {
                    if (j % i != 0)
                    {
                        if ((!NonPrimeNumbers.Contains(j) & !PrimeNumbers.Contains(j)))
                        {
                            PrimeNumbers.Add(j);
                        }
                        
                    }
                    else
                    {
                        if (PrimeNumbers.Contains(j) & j!=i)
                        {
                            PrimeNumbers.Remove(j);
                            NonPrimeNumbers.Add(j);
                        }
                        else
                        {
                            if ((j % i == 0) & (j != i) & !NonPrimeNumbers.Contains(j))
                            {
                                NonPrimeNumbers.Add(j);
                            }
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine(PrimeNumbers.Count);
            Console.WriteLine();

            do
            {
                Console.WriteLine(PrimeNumbers[wTemp]);
                wTemp = ++wTemp;
            }
            while (wTemp < PrimeNumbers.Count);


        }
        //catch (FormatException)
        catch (SystemException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("User Input Invalid");
            Console.ReadLine();
        }

    }

}

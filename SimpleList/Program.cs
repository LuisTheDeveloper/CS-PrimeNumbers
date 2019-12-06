using System;
using System.Collections.Generic;

public class SamplesArrayList
{

    public static void Main(string[] args)
    {
        int wTemp = 0;
        
        IList<int> intList = new List<int>();

        var PrimeNumbers = new List<int>();

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
                for (int j = ++i; j < PrimeNumbers.Count; j++)
                {
                    if (j % i != 0)
                    {
                        PrimeNumbers.Add(j);
                    }
                }
            }
        }
        //catch (FormatException)
        catch (SystemException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("User Input Invalid");
            Console.ReadLine();
        }

        

        /*
        wTemp = (int)MaxNumber;

        for (int i = 2; i <= MaxNumber; i++)
        {
            PrimeNumbers.Add(i);
        }

        wTemp = 0;
        while (wTemp<PrimeNumbers.Count)
        {
            Console.Write($"{PrimeNumbers[wTemp]}");
            wTemp++;
            Console.Write("  ");
        }

        Console.WriteLine();

        wTemp = 0;
        for(int i=2; i<11;  i++)
        {
            for(int j=0; j<PrimeNumbers.Count; j++)
            {   
                if(PrimeNumbers[j] % i == 0 && PrimeNumbers[j] != i)
                {
                    PrimeNumbers.Remove(PrimeNumbers[j]);
                }
            }            

        }

        wTemp = 0;
        while (wTemp < PrimeNumbers.Count)
        {
            Console.Write($"{PrimeNumbers[wTemp]}");
            wTemp++;
            Console.Write("  ");
        }

        */


    }

}

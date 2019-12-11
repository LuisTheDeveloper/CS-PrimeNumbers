using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleList
{
    public class PrimeNumbers
    {
        public PrimeNumbers()
        {

        }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public bool Reverse { get; set; }
        public bool EndPGM { get; set; }
        public bool Range { get; set; }

        public bool SpeedUp { get; set; }
        public bool ValidRange()
        {
            if (MinNumber > MaxNumber)
            {
                return false;
            }
            return true;
        }
        public void DisplayPrimeNumbers()
        {
            int wTemp = 0;

            var PrimeNumbers = new List<int>();

            try
            {
                if (Range == false)
                {
                    MinNumber = 2;
                }
                Console.WriteLine($"Displaying Prime Numbers from {MinNumber} to {MaxNumber}");
                CalculatePrimeNumbers(PrimeNumbers);
                Console.WriteLine();
                Console.WriteLine($"There are {PrimeNumbers.Count} prime numbers");
                Console.WriteLine();

                if (Reverse == true)
                {
                    PrimeNumbers.Reverse();
                }

                do
                {
                    Console.Write(PrimeNumbers[wTemp]);
                    Console.Write(" ");
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

        private void CalculatePrimeNumbers(List<int> MyNumbers)
        {
            var NonPrimeNumbers = new List<int>();

            //Calculating 50% of the results
            var w50Part = (MinNumber + MaxNumber) / 2;
            //Calculating 25% and 75% of the results
            var w1 = MinNumber - w50Part;
            var w2 = Math.Abs(w1) / 2;
            var w25Part = MinNumber + w2;
            var w75Part = MaxNumber - w2;
            var wDif = MaxNumber - MinNumber;

            for (int i = MinNumber; i <= MaxNumber; i++)
            {
                if (SpeedUp == false & wDif > 1000)
                {
                    if (i == w25Part)
                    {
                        Console.WriteLine();
                        Console.WriteLine("25% of Prime Numbers are processed");
                    }
                    if (i == w50Part)
                    {
                        Console.WriteLine();
                        Console.WriteLine("50% of Prime Numbers are processed");
                    }
                    if (i == w75Part)
                    {
                        Console.WriteLine();
                        Console.WriteLine("75% of Prime Numbers are processed");
                        Console.WriteLine();
                    }
                }

                //Let's add all the integers numbers to the List
                if (!MyNumbers.Contains(i) & !NonPrimeNumbers.Contains(i))
                {
                    MyNumbers.Add(i);
                }

                for (int j = i; j <= MaxNumber; j++)
                {
                    if (j % i != 0)
                    {
                        if ((!NonPrimeNumbers.Contains(j) & !MyNumbers.Contains(j)))
                        {
                            MyNumbers.Add(j);
                        }

                    }
                    else
                    {
                        if (MyNumbers.Contains(j) & j != i)
                        {
                            MyNumbers.Remove(j);
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

        }



    }
}

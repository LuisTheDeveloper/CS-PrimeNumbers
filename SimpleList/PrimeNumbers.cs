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
        public int MaxNumber { get; set; }
        public bool Reverse { get; set; }
        public bool EndPGM { get; set; }
        public void DisplayPrimeNumbers()
        {
            int wTemp = 0;


            IList<int> intList = new List<int>();

            var PrimeNumbers = new List<int>();
            var NonPrimeNumbers = new List<int>();

            try
            {
                var MaxNum = MaxNumber;

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
                            if (PrimeNumbers.Contains(j) & j != i)
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
    }
}

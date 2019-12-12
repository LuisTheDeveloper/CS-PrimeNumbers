using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleList
{
    public class PrimeNumbers
    {
        public PrimeNumbers()
        {
            Reverse = false;
            SpeedUp = false;
            AllDone = false;
            LastIndex = 0;
        }
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public bool Reverse { get; set; }
        public bool EndPGM { get; set; }
        public bool Range { get; set; }

        public bool SpeedUp { get; set; }
        private int LastIndex { get; set; }
        private int Last25Index { get; set; }
        private int Last50Index { get; set; }
        private int Last75Index { get; set; }
        

        private bool AllDone { get; set; }

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

                if (SpeedUp == false)
                {
                    Console.WriteLine();
                    Console.WriteLine($"There are {PrimeNumbers.Count} prime numbers");
                }

                CalculatePrimeNumbers(PrimeNumbers);
                LastIndex = GetLastIndex(PrimeNumbers, 0);
                if (Reverse == true)
                {
                    PrimeNumbers.Reverse();
                }

                if (SpeedUp == true)
                {
                    DisplayCurrentPrimes(PrimeNumbers, 0, PrimeNumbers.IndexOf(PrimeNumbers.Count));
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("25% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, 0, Last25Index);
                    Thread.Sleep(3000);

                    Console.WriteLine();
                    Console.WriteLine("50% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, Last25Index, Last50Index);
                    Thread.Sleep(3000);

                    Console.WriteLine();
                    Console.WriteLine("75% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, Last50Index, Last75Index);
                    Thread.Sleep(3000);

                    Console.WriteLine();
                    Console.WriteLine("All of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, 0, LastIndex);
                    Thread.Sleep(3000);
                }

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

            for (int i = MinNumber; i <= MaxNumber; i++)
            {

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

                    if (SpeedUp == false & AllDone == false)
                    {
                        if (j == w25Part)
                        {
                            Last25Index = GetLastIndex(MyNumbers, 0);
                        }

                        if (j == w50Part)
                        {
                            Last50Index = GetLastIndex(MyNumbers, Last25Index);
                        }

                        if (j == w75Part)
                        {
                            Last75Index = GetLastIndex(MyNumbers, Last50Index);
                        }

                        if (j == MaxNumber)
                        {
                            LastIndex = GetLastIndex(MyNumbers, Last75Index);
                            AllDone = true;
                        }
                    }
                }
            }

        }

        private void DisplayCurrentPrimes(List<int> MyNumbers, int StartPos, int EndPos)
        {
            int wTemp = StartPos;

            do
            {
                Console.Write(MyNumbers[wTemp]);
                Console.Write(" ");
                wTemp = ++wTemp;
            }
            while (wTemp < EndPos);
            LastIndex = wTemp;
        }

        private int GetLastIndex(List<int> MyNumbers, int StartPos)
        {
            int wTemp = StartPos;
            do
            {
                wTemp = ++wTemp;
            }
            while (wTemp < MyNumbers.Count);
            return wTemp;
        }

        /* private int PrimeNumbersShow(List<int> MyNumbers)
        {
            if (SpeedUp == false & AllDone == false)
            {
                if (j == w25Part)
                {
                    Console.WriteLine();
                    Console.WriteLine("25% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(MyNumbers, 0);
                    Thread.Sleep(3000);
                }

                if (j == w50Part)
                {
                    //var wpos1 = GetPartOfList(MyNumbers);
                    Console.WriteLine();
                    Console.WriteLine("50% of Prime Numbers are processed");
                    Console.WriteLine();
                    var wPos = MyNumbers.IndexOf(w25Part);
                    DisplayCurrentPrimes(MyNumbers, LastIndex);
                    Thread.Sleep(3000);
                }

                if (j == w75Part)
                {
                    Console.WriteLine();
                    Console.WriteLine("75% of Prime Numbers are processed");
                    Console.WriteLine();
                    //var wPos = MyNumbers.IndexOf(w50Part);
                    DisplayCurrentPrimes(MyNumbers, LastIndex);
                    Thread.Sleep(3000);
                }

                if (j == MaxNumber)
                {
                    Console.WriteLine();
                    Console.WriteLine("All Prime Numbers have been processed");
                    Console.WriteLine();
                    //var wPos = MyNumbers.IndexOf(w75Part);
                    DisplayCurrentPrimes(MyNumbers, LastIndex);
                    AllDone = true;
                }
            }

            return 0;
        }*/

    }
}

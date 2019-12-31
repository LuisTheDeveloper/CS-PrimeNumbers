using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Common
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

            //Calculating 50% of the results
            var w50Part = (MinNumber + MaxNumber) / 2;
            //Calculating 25% and 75% of the results
            var w1 = MinNumber - w50Part;
            var w2 = Math.Abs(w1) / 2;
            var w25Part = MinNumber + w2;
            var w75Part = MaxNumber - w2;

            try
            {
                if (Range == false)
                {
                    MinNumber = 2;
                }

                Console.WriteLine($"Displaying Prime Numbers from {MinNumber} to {MaxNumber}");
                CalculatePrimeNumbers(PrimeNumbers);
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine($"There are {PrimeNumbers.Count} prime numbers");

                //CalculatePrimeNumbers(PrimeNumbers);
                LastIndex = GetLastIndex(PrimeNumbers, 0);
                Last50Index = LastIndex / 2;
                Last25Index = Last50Index / 2;
                Last75Index = Last50Index + Last25Index;

                if (Reverse == true)
                {
                    PrimeNumbers.Reverse();
                }

                if (SpeedUp == true)
                {
                    DisplayCurrentPrimes(PrimeNumbers, 0, 0);
                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("25% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, 0, Last25Index);
                    Console.WriteLine();
                    Thread.Sleep(2000);

                    Console.WriteLine();
                    Console.WriteLine("50% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, Last25Index, Last50Index);
                    Console.WriteLine();
                    Thread.Sleep(2000);

                    Console.WriteLine();
                    Console.WriteLine("75% of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, Last50Index, Last75Index);
                    Console.WriteLine();
                    Thread.Sleep(2000);

                    Console.WriteLine();
                    Console.WriteLine("All of Prime Numbers are processed");
                    Console.WriteLine();
                    DisplayCurrentPrimes(PrimeNumbers, Last75Index, 0);
                    Console.WriteLine();
                    Thread.Sleep(2000);
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
            int x25, x50, x75;

            x50 = MaxNumber / MinNumber;
            x25 = x50 / 2;
            x75 = x50 + x25;

            Console.WriteLine($"x25 is {x25}", x25);
            Console.WriteLine($"x50 is {x50}", x50);
            Console.WriteLine($"x75 is {x75}", x75);

            for (int i = MinNumber; i <= MaxNumber; i++)
            {                
                for (int j = 2; j<i;j++)
                {
                    if((i%j)!=0 & !NonPrimeNumbers.Contains(i))
                    {
                        if (!MyNumbers.Contains(i))
                            MyNumbers.Add(i);

                    }
                    else
                    {
                        if (MyNumbers.Contains(i))
                            MyNumbers.Remove(i);
                        NonPrimeNumbers.Add(i);
                        break;
                    }
                        
                }
            }


        }

        private void DisplayCurrentPrimes(List<int> MyNumbers, int StartPos, int EndPos)
        {
            int wTemp = StartPos;
            if (EndPos == 0)
            {
                EndPos = MyNumbers.Count;
            }

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
            wTemp = --wTemp;
            return wTemp;
        }

    }
}

namespace Lab0Basics
{
    /// <summary>
    /// Basics of C# activity solution
    /// Author: Donald Jans S. Uy (donaldjans.uy@edu.sait.ca)
    /// Date: September 15, 2023
    internal class Program
    {
        static void Main(string[] args)
        {
            /// defining initial variables for task 1
            int difference;

            /// callout function for low number
            int lownumber = userInputLN();
            /// callout function for high number and pass lownumber value
            int highnumber = userInputHN(lownumber);

            difference = highnumber - lownumber;

            /// int[] is data type declaration that its representing an array of integers
            /// new is used to create new instances 
            int[] numBetween = new int[difference];

            /// include the $ sign for interpolation 
            Console.WriteLine($"The difference between the low and high numbers is : {difference}");
             

            /// "for" proper syntax = for (initialization; condition; iteration)
            /// && is AND operator
            for (int n = lownumber, i = 0; n <= highnumber && i < difference; n++, i++)
            {
                numBetween[i] = n;

                ///Console.WriteLine($"the numbers between are: {numBetween[i]}");
            }

            /// StreamWriter is used to write integers data type for our array(numBetween)
            StreamWriter wNumbers = File.CreateText("numbers.txt");

            Console.WriteLine("Wrote to file: numbers.txt");
            /// loop continues as long as index doesn't exceed thelength of the array
            /// To have it reverse, we are setting the last value to index 0
            for (int iter = 0; iter < numBetween.Length ; iter++)
            {
                int numElemsIndx = numBetween.Length - 1 - iter;
                /// numElems formula is = length - 1 - (iter ++)
                wNumbers.WriteLine(numBetween[numElemsIndx]);
                ///Console.WriteLine($"the numbers between are: {numBetween[numElemsIndx]}");
            }

            wNumbers.Close();

            ///sum of elements inside the array
            int sumElemArray = 0;
            foreach (int num in numBetween) ///data type in array is integer
            {
                sumElemArray += num;
            }

            Console.WriteLine($"The total sum of the numbers inside the array is: {sumElemArray}");

            foreach (int num in numBetween)
            {
                if (PrimeNum(num))
                {
                    Console.WriteLine($"{num} is a prime number."); ///triggered if function returns true
                }
            }
        }

        static int userInputLN() 
        {
            int lnumber;

            Console.Write("Enter a low number: ");
            lnumber = int.Parse(Console.ReadLine());

            while (lnumber < 0)
            {
                Console.WriteLine("Low number must be a positive number: ");
                Console.Write("Enter a low number: ");
                lnumber = int.Parse(Console.ReadLine());
            }

            return lnumber;
        }

        static int userInputHN(int lownumber)
        {
            int hnumber;
            Console.Write("Enter a high number: ");
            hnumber = int.Parse(Console.ReadLine());


            while (hnumber < lownumber)
            {
                Console.WriteLine("High number must be a greather than low number: ");

                Console.Write("Enter a high number: ");
                hnumber = int.Parse(Console.ReadLine());
            }

            return hnumber;
        }


        /// reference :https://www.tutorialspoint.com/Chash-Program-to-check-if-a-number-is-prime-or-not 
        static bool PrimeNum(int num) /// returns boolean value 
        {
            int r = 0;                  /// set r as counter for modulus is equal 0
            for (int i = 2; i<=num; i++) /// i is defined for the divisor and I shouldn't exceed the dividend 
            {
                if (num % i == 0) /// Checking if remainder is 0
                {
                    r++; /// Adds value to the counter if remainder is 0
                }
            }
            if (r == 1) /// if counter is 1 the num value is prime
            { 
                return true; /// Boolean true is passed to the main and 
            }
            else
            {
                return false;
            }


        }
    }
}
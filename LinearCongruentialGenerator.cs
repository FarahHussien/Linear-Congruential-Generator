using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask
{
    public class LinearCongruentialGenerator
    {
        // our properties 'Input'
        public int Multiplier { get; set; } // Multiplier value => a
        public int Modulus { get; set; }    // Modulus value => m
        public int Increment { get; set; } // Increment value => c
        public int Seed { get; set; }      // Current seed value => Z0
        public int N { get; set; }         // Number of iterations

        public LinearCongruentialGenerator() { }
        public LinearCongruentialGenerator(int modulus, int multiplier, int increment, int seed, int n)
        {
            Modulus = modulus;
            Multiplier = multiplier;
            Increment = increment;
            Seed = seed; // Z0
            N = n;
        }

        // farah
        public List<int> LCG()
        {
            List<int> randomNumbers = new List<int>();

            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    randomNumbers.Add(Seed);
                }
                else
                {
                    Seed = (Multiplier * Seed + Increment) % Modulus;
                    randomNumbers.Add(Seed);
                }
            }

            return randomNumbers;
        }

        // Algorithm[1] - Cycle Length
        public int _CalculateLenOfCycle()
        {
            HashSet<int> seenNumbers = new HashSet<int>();
            int currentSeed = Seed;
            int cycleLength = 0;

            while (!seenNumbers.Contains(currentSeed))
            {
                seenNumbers.Add(currentSeed);
                currentSeed = (Multiplier * currentSeed + Increment) % Modulus;
                cycleLength++;

                // If the length exceeds Modulus, break to avoid infinite loop
                // untill first unique values "1st cycle"
                if (cycleLength > Modulus)
                {
                    break;
                }
            }
            return cycleLength;
        }

        // Algorithm[2] - Cycle Length
        public int CalculateLenOfCycle()
        {
            // fatma
            if (Modulus % 2 == 0 && Increment != 0)
            {
                // Cond#1: m is power of 2, c ≠ 0
                if (GreatestCommonDivisor(Increment, Modulus) == 1 && Multiplier % 4 == 1) // c & m is relatively primes => y3ni akbr rakm by2blo el 2sma 3leeh hwa 1
                {
                    // 12 13
                    return Modulus; // m
                }
            }
            // gehad & gui
            else if (Modulus % 2 == 0 && Increment == 0)
            {
                // Cond#2: m is power of 2, c = 0
                if (Seed % 2 == 1 && (Multiplier - 1) % 8 == 0) // seed is odd
                {
                    return Modulus / 4; // m/4
                }
            }
            // nada
            else if (IsPrime(Modulus) && Increment == 0)
            {
                // Cond#3: m is a prime number, c = 0
                if (Math.Pow(Multiplier, Modulus - 1) % Modulus == 1)
                {
                    return Modulus - 1;
                }
            }
            // mariem
            return _CalculateLenOfCycle();
        }

        private int GreatestCommonDivisor(int a, int b) // 12 14
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        /// <summary>
        ///  using "Euclidean Algorithm"
        ///  Used to check if two numbers are relatively prime (GCD(a, b) = 1)
        /// </summary>

        private bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}

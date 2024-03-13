using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedNumberGenerator
{
    internal class PrimeGenerator
    {
        private int UpperBound;
        private volatile bool StopRequested;
        private List<int> Numbers;

        public PrimeGenerator(int upperBound) { UpperBound = upperBound; StopRequested = false; Numbers = new List<int>(); }
        public void GeneratePrimes()
        {
            int current = 2;
            while (!StopRequested && (UpperBound == 0 || current <= UpperBound)) { if (IsPrime(current)) Numbers.Add(current); current++; }
        }
        public void Stop() { StopRequested = true; }
        public List<int> GetNumbers() { return Numbers; }
        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            if (num == 2) return true;
            if (num % 2 == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(num));

            for (int i = 3; i <= boundary; i += 2) if (num % i == 0) return false;
            return true;
        }
    }
}

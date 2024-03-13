using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedNumberGenerator
{
    internal class FibonacciGenerator
    {
        private int UpperBound;
        private volatile bool StopRequested;
        private List<int> Numbers;

        public FibonacciGenerator(int upperBound) { UpperBound = upperBound; StopRequested = false; Numbers = new List<int>(); }

        public void GenerateFibonacci()
        {
            int a = 0, b = 1, c;
            while (!StopRequested && (UpperBound == 0 || a <= UpperBound))
            {
                Numbers.Add(a);
                c = a + b; a = b; b = c;
            }
        }
        public List<int> GetNumbers() { return Numbers; }
        public void Stop() { StopRequested = true; }
    }
}

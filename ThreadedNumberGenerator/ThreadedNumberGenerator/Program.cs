using ThreadedNumberGenerator;

int choice;
bool exit = false;

Thread? primeThread = null;
Thread? fibThread = null;

PrimeGenerator? primeGenerator = null;
FibonacciGenerator? fibonacciGenerator = null;

while (!exit)
{
    Console.Clear();
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Generate Prime Numbers");
    Console.WriteLine("2. Generate Fibonacci Numbers");
    Console.WriteLine("3. Stop Prime Number Generation");
    Console.WriteLine("4. Stop Fibonacci Number Generation");
    Console.WriteLine("5. Exit");

    Console.Write(">>> ");
    choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Enter the upper bound for prime numbers generation >>> ");
            int primeUpperBound = int.Parse(Console.ReadLine());
            primeGenerator = new PrimeGenerator(primeUpperBound);
            primeThread = new Thread(primeGenerator.GeneratePrimes);
            Console.WriteLine("Starting prime number generation...");
            primeThread.Start();
            break;

        case 2:
            Console.Write("Enter the upper bound for Fibonacci numbers generation >>> ");
            int fibUpperBound = int.Parse(Console.ReadLine());
            fibonacciGenerator = new FibonacciGenerator(fibUpperBound);
            fibThread = new Thread(fibonacciGenerator.GenerateFibonacci);
            Console.WriteLine("Starting Fibonacci number generation...");
            fibThread.Start();
            break;

        case 3:
            if (primeThread != null)
            {
                primeGenerator.Stop();
                primeThread.Join();
                for (int i = 0; i < primeGenerator.GetNumbers().Count; i++) Console.Write(primeGenerator.GetNumbers()[i] + " ");
                Console.WriteLine("\nPrime number generation stopped");
                Thread.Sleep(10000);
            }
            else Console.WriteLine("Prime number generation is not running");
            break;

        case 4:
            if (fibThread != null)
            {
                fibonacciGenerator.Stop();
                fibThread.Join();
                for (int i = 0; i < fibonacciGenerator.GetNumbers().Count; i++) Console.Write(fibonacciGenerator.GetNumbers()[i] + " ");
                Console.WriteLine("\nFibonacci number generation stopped");
                Thread.Sleep(10000);
            }
            else Console.WriteLine("Fibonacci number generation is not running");
            break;

        case 5:
            exit = true;
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}
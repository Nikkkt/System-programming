using System;
using System.IO;
using System.Threading;

class Program
{
    static Mutex mutex = new Mutex();
    static string inputFile = "random_numbers.txt";
    static string firstOutputFile = "primes_from_random.txt";
    static string secondOutputFile = "primes_with_last_digit_7.txt";
    static string reportFile = "final_report.txt";

    static void Main(string[] args)
    {
        Thread t1 = new Thread(GenerateRandomNumbers);
        Thread t2 = new Thread(FindPrimes);
        Thread t3 = new Thread(FindPrimesWithLastDigit7);
        Thread t4 = new Thread(GenerateReport);

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
    }

    static void GenerateRandomNumbers()
    {
        mutex.WaitOne();
        Random rnd = new Random();
        using (StreamWriter writer = new StreamWriter(inputFile)) { for (int i = 0; i < 100; i++) writer.WriteLine(rnd.Next(1, 1000)); }
        mutex.ReleaseMutex();
    }

    static void FindPrimes()
    {
        mutex.WaitOne();
        using (StreamReader reader = new StreamReader(inputFile))
        {
            using (StreamWriter writer = new StreamWriter(firstOutputFile))
            {
                string line; while ((line = reader.ReadLine()) != null)
                {
                    int num = int.Parse(line);
                    if (IsPrime(num)) writer.WriteLine(num);
                }
                mutex.ReleaseMutex();
            }
        }
    }

    static void FindPrimesWithLastDigit7()
    {
        mutex.WaitOne();
        using (StreamReader reader = new StreamReader(firstOutputFile))
        using (StreamWriter writer = new StreamWriter(secondOutputFile))
        {
            string line;
            while ((line = reader.ReadLine()) != null) { int num = int.Parse(line); if (num % 10 == 7) writer.WriteLine(num); }
        }
        mutex.ReleaseMutex();
    }

    static bool IsPrime(int num)
    {
        if (num <= 1) return false;
        if (num == 2) return true;
        if (num % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(num); i += 2) if (num % i == 0) return false;
        return true;
    }

    static void GenerateReport()
    {
        mutex.WaitOne();
        using (StreamWriter writer = new StreamWriter(reportFile))
        {
            WriteReport(writer, inputFile);
            WriteReport(writer, firstOutputFile);
            WriteReport(writer, secondOutputFile);
        }
        mutex.ReleaseMutex();
    }

    static void WriteReport(StreamWriter writer, string filename)
    {
        writer.WriteLine($"File: {filename}");
        writer.WriteLine($"Number of numbers: {File.ReadLines(filename).Count()}");
        writer.WriteLine($"Size in bytes: {new FileInfo(filename).Length}");
        writer.WriteLine($"Contents:");
        foreach (string line in File.ReadAllLines(filename)) writer.WriteLine(line);
        writer.WriteLine();
    }
}

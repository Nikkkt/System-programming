using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTaskingAsyncUtility
{
    internal class Horse
    {
        public string Name { get; private set; }
        public int Distance { get; private set; }
        public DateTime FinishTime { get; private set; }

        public Horse(string name) { Name = name; Distance = 0; }

        public void Run()
        {
            int raceDistance = 100;
            Random rnd = new Random();

            while (Distance < raceDistance) { Thread.Sleep(rnd.Next(100, 500)); Distance++; }

            FinishTime = DateTime.Now;
            Console.WriteLine($"{Name} finished the race at {FinishTime}!");
        }
    }
}

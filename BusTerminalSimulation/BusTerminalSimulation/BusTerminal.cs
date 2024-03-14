using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTerminalSimulation
{
    internal class BusTerminal
    {
        private int maxBusCapacity;
        private int currentPeopleAtBusStop;
        private int currentPeopleOnBus;
        private bool isBusArriving;
        private readonly object busLock = new object();
        private List<string> stops;

        public BusTerminal(int maxBusCapacity, List<string> stops)
        {
            this.maxBusCapacity = maxBusCapacity;
            currentPeopleAtBusStop = 0;
            currentPeopleOnBus = 0;
            isBusArriving = false;
            this.stops = stops;
        }

        public void StartSimulation()
        {
            Random random = new Random();
            int stopIndex = 0;

            while (true)
            {
                int newPeople = random.Next(1, 10);

                SignalBusArrival();
                Thread.Sleep(5000);
                SimulatePeopleGettingOffBus(stops[stopIndex]);
                stopIndex = (stopIndex + 1) % stops.Count;

                if (stopIndex == 0)
                {
                    SimulatePeopleGettingOffBusAtLastStop();
                    Console.WriteLine("All stops reached");
                    break;
                }

                lock (busLock)
                {
                    currentPeopleOnBus += newPeople;
                    Console.WriteLine($"New people arrived at the bus stop: {newPeople}. Total people on bus: {currentPeopleOnBus}");
                }
            }
        }

        public void SignalBusArrival()
        {
            lock (busLock)
            {
                if (!isBusArriving)
                {
                    isBusArriving = true;
                    Thread busThread = new Thread(BoardPassengers);
                    busThread.Start();
                }
            }
        }

        public void BoardPassengers()
        {
            Console.WriteLine("Bus arrived at the terminal");

            lock (busLock)
            {
                int availableSeats = maxBusCapacity - currentPeopleOnBus;
                int passengersToBoard = Math.Min(currentPeopleAtBusStop, availableSeats);
                currentPeopleOnBus += passengersToBoard;
                currentPeopleAtBusStop -= passengersToBoard;

                Console.WriteLine($"Bus departing with {passengersToBoard} passengers. Total people on bus: {currentPeopleOnBus}\n");
                isBusArriving = false;
            }
        }

        public void SimulatePeopleGettingOffBus(string stop)
        {
            Random random = new Random();

            lock (busLock)
            {
                int peopleGettingOff = random.Next(0, currentPeopleOnBus + 1);
                currentPeopleOnBus -= peopleGettingOff;
                Console.WriteLine($"{peopleGettingOff} people got off the bus at {stop}. Total people on bus: {currentPeopleOnBus}");
            }
        }

        public void SimulatePeopleGettingOffBusAtLastStop()
        {
            lock (busLock)
            {
                Console.WriteLine($"All {currentPeopleOnBus} people got off the bus at the last stop");
                currentPeopleOnBus = 0;
            }
        }
    }
}
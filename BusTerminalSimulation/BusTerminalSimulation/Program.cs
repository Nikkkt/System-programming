using System;
using System.Collections.Generic;
using System.Threading;
using BusTerminalSimulation;

class Program
{
    static void Main(string[] args)
    {
        List<string> stops = new List<string>() { "Stop 1", "Stop 2", "Stop 3", "Stop 4", "Stop 5", "Stop 6", "Stop 7", "Stop 8", "Stop 9", "Stop 10" };
        BusTerminal terminal = new BusTerminal(maxBusCapacity: 20, stops: stops);
        terminal.StartSimulation();
    }
}

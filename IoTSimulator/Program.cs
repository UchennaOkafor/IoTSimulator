using Simulator.Module;
using System;

namespace IoTSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IoT Simulator";

            var simulator = new DeviceSimulator();
            simulator.RunSimulation();

            Console.ReadLine();
        }
    }
}
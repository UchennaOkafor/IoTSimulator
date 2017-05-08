using Simulator.Module;
using System;

namespace IoTSimulator
{
    class Program
    {
        //if device is off, do NOT send data. 

        //get a list of devices that are on, and simulate all of them

        //Thermostat attributes are temperate and humidity

        //var jss = new JavaScriptSerializer();
        //var json = jss.Serialize(new LightBulb());
        //var lb = jss.Deserialize<LightBulb>("{\"Temperate\":45,\"Id\":3}");

        static void Main(string[] args)
        {
            Console.Title = "IoT Simulator";

            var simulator = new DeviceSimulator();
            simulator.RunSimulation();

            Console.ReadLine();
        }
    }
}
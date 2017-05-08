using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IoTSimulator
{
    class Program
    {
        //if device is off, do NOT send data. 

        //get a list of devices that are on, and simulate all of them

        //Thermostat attributes are temperate and humidity
        static void Main(string[] args)
        {
            Console.Title = "IoT Simulator";

            var jss = new JavaScriptSerializer();
            var json = jss.Serialize(new LightBulb());
            var lb = jss.Deserialize<LightBulb>("{\"Temperate\":45,\"Id\":3}");

            var broker = new SimulatorBroker();
            var devices = broker.GetActiveDevices();

            Console.ReadLine();
        }
    }
}
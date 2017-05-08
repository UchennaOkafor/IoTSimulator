using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IoTSimulator.Simulator
{
    class DeviceSimulator
    {
        private bool stopped;
        private Device[] actualDevices;
        private SimulatorBroker broker;

        public DeviceSimulator()
        {
            broker = new SimulatorBroker();
        }

        public void RunSimulation()
        {
            var activeDevices = broker.GetActiveDevices();
            while (!stopped)
            {

            }
        }

        private Device[] CreateVirtualDevices(Device[] devices)
        {
            var virtualDevices = new List<Device>();
            foreach (Device device in virtualDevices)
            {
                switch (device.Type)
                {
                    case "Lightbulb":
                        virtualDevices.Add(new LightBulb()
                        {

                        });
                        break;

                    case "Thermostat":
                        virtualDevices.Add(new LightBulb()
                        {

                        });
                        break;

                    case "Fridge":
                        //new
                        break;
                }
            }

            return virtualDevices;
        }

        public void StopSimulation()
        {

        }
    }
}
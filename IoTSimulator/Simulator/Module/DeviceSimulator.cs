using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Timers;

namespace IoTSimulator.Simulator
{
    class DeviceSimulator
    {
        private Device[] currentActiveDevices;
        private SimulatorBroker broker;
        private Timer timer;

        public DeviceSimulator()
        {
            broker = new SimulatorBroker();
            timer = new Timer() { Interval = 1000 };
        }

        public void RunSimulation()
        {
            var activeDevices = broker.GetActiveDevices();

            timer.Elapsed += (s, e) =>
            {
                //Simulate stuff
                //Send stuff
            };

            timer.Start();
        }

        private List<Device> CreateVirtualDevices(Device[] devices)
        {
            var virtualDevices = new List<Device>();
            foreach (Device device in virtualDevices)
            {
                switch (device.Type)
                {
                    case "Lightbulb":
                        virtualDevices.Add(new LightBulb()
                        {
                            Id = device.Id
                        });
                        break;

                    case "Thermostat":
                        virtualDevices.Add(new Thermostat()
                        {
                            Id = device.Id
                        });
                        break;

                    case "Fridge":
                        virtualDevices.Add(new Fridge()
                        {
                            Id = device.Id
                        });
                        break;
                }
            }

            return virtualDevices;
        }

        public void StopSimulation()
        {
            timer.Stop();
        }
    }
}
using Simulator.Broker;
using Simulator.Base;
using System.Collections.Generic;
using System.Timers;

namespace Simulator.Module
{
    class DeviceSimulator
    {
        private IoTDevice[] currentActiveDevices;
        private SimulatorBroker broker;
        private Timer timer;

        public DeviceSimulator()
        {
            broker = new SimulatorBroker();
            timer = new Timer() { Interval = 1000 };
            UpdateVirtualDevices();
            broker.SendSimulatedData(currentActiveDevices);
        }

        public void RunSimulation()
        {
            timer.Elapsed += (s, e) =>
            {
                //Simulate stuff
                //Send stuff
            };

            timer.Start();
        }

        private void UpdateVirtualDevices()
        {
            var virtualDevices = new List<IoTDevice>();
            foreach (Device device in broker.GetActiveDevices())
            {
                switch (device.DeviceType)
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

            currentActiveDevices = virtualDevices.ToArray();
        }

        public void StopSimulation()
        {
            timer.Stop();
        }
    }
}
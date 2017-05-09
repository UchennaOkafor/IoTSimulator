using Simulator.Broker;
using Simulator.Base;
using System.Collections.Generic;
using System.Timers;

namespace Simulator.Module
{
    public class DeviceSimulator
    {
        private IoTDevice[] currentDevices;
        private SimulatorBroker broker;
        private Timer timer;

        public DeviceSimulator(int timerInterval)
        {
            broker = new SimulatorBroker();
            timer = new Timer() { Interval = timerInterval };
            UpdateVirtualDevices();

            timer.Elapsed += (s, e) =>
            {
                foreach (var device in currentDevices)
                {
                    device.SimulateNextReading();
                }

                broker.PostDeviceData(currentDevices);
            };
        }

        public void RunSimulation()
        {
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
                        virtualDevices.Add(new LightBulb() { Id = device.Id });
                        break;

                    case "Thermostat":
                        virtualDevices.Add(new Thermostat() { Id = device.Id });
                        break;

                    case "Fridge":
                        virtualDevices.Add(new Fridge() { Id = device.Id });
                        break;

                    case "Smart Meter":
                        virtualDevices.Add(new SmartMeter() { Id = device.Id });
                        break;
                }
            }

            currentDevices = virtualDevices.ToArray();
        }

        public void StopSimulation()
        {
            timer.Stop();
        }
    }
}
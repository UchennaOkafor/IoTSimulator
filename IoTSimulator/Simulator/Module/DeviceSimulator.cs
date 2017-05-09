using Simulator.Broker;
using Simulator.Base;
using System.Collections.Generic;
using System.Timers;
using System;

namespace Simulator.Module
{
    public class DeviceSimulator
    {
        private Random rand;
        private IoTDevice[] currentDevices;
        private SimulatorBroker broker;
        private Timer timer;

        public DeviceSimulator(int timerInterval)
        {
            rand = new Random();
            broker = new SimulatorBroker();
            timer = new Timer() { Interval = timerInterval };
            UpdateVirtualDevices();
        }

        public void RunSimulation()
        {
            timer.Elapsed += (s, e) =>
            {
                //Simulate stuff
                //Send stuff
                SimulateNext();
                broker.PostDeviceData(currentDevices);
            };

            timer.Start();
        }

        private void SimulateNext()
        {
            foreach (var device in currentDevices)
            {
                if (device is LightBulb)
                {
                    var lb = device as LightBulb;
                    lb.Luminance = rand.Next(1, 5);
                    lb.Current = rand.Next(1, 20);
                }
                else if (device is Thermostat)
                {

                }
                else if (device is Fridge)
                {

                }
            }
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
                            Id = device.Id,
                            Luminance = rand.Next(3, 5)
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

            currentDevices = virtualDevices.ToArray();
        }

        public void StopSimulation()
        {
            timer.Stop();
        }
    }
}
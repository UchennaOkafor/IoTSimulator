using Simulator.Broker;
using Simulator.Base;
using System.Collections.Generic;
using System.Timers;
using System;
using System.Linq;

namespace Simulator.Module
{
    public class DeviceSimulator
    {
        private List<IoTDevice> currentDevices;
        private SimulatorBroker broker;
        private Timer timer;

        public event DataSent OnDataSent;
        public delegate void DataSent(object sender, EventArgs e);

        public DeviceSimulator(int timerInterval)
        {
            timer = new Timer() { Interval = timerInterval };
            currentDevices = new List<IoTDevice>();
            broker = new SimulatorBroker();

            InitializeDevices();

            timer.Elapsed += (s, e) =>
            {
                foreach (var device in currentDevices)
                {
                    device.SimulateNextReading();
                }

                var newDevices = broker.PostDeviceData(currentDevices).ToList();

                foreach (var device in newDevices)
                {
                    //New device has been switched on since last time the program started
                    if (! currentDevices.Exists(d => d.Id == device.Id))
                    {
                        UpdateVirtualDevices(new Device[] { device }.ToList());
                    }
                }

                for (int i = 0; i < currentDevices.Count; i++)
                {
                    //Device no longer is turned on, so therefore remove it and don't simulate data for it
                    if (! newDevices.Exists(d => d.Id == currentDevices[i].Id))
                    {
                        currentDevices.RemoveAt(i);
                    }
                }

                OnDataSent?.Invoke(this, null);
            };
        }

        private void InitializeDevices()
        {
            UpdateVirtualDevices(broker.GetActiveDevices());
        }

        public void RunSimulation()
        {
            timer.Start();
        }

        private void UpdateVirtualDevices(List<Device> devices)
        {
            foreach (Device device in devices)
            {
                switch (device.DeviceType)
                {
                    case "Lightbulb":
                        currentDevices.Add(new LightBulb() { Id = device.Id });
                        break;

                    case "Thermostat":
                        currentDevices.Add(new Thermostat() { Id = device.Id });
                        break;

                    case "Fridge":
                        currentDevices.Add(new Fridge() { Id = device.Id });
                        break;

                    case "Smart Meter":
                        currentDevices.Add(new SmartMeter() { Id = device.Id });
                        break;
                }
            }
        }

        public void StopSimulation()
        {
            timer.Stop();
        }
    }
}
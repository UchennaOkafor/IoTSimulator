using Newtonsoft.Json;
using System;

namespace Simulator.Base
{
    public abstract class IoTDevice
    {
        private Random rand;

        [JsonIgnore]
        public int Id { get; set; }

        public IoTDevice()
        {
            rand = new Random();
        }

        public abstract void SimulateNextReading();

        protected double NextDouble(double minValue, double maxValue)
        {
            double number = rand.NextDouble() * (maxValue - minValue) + minValue;
            return double.Parse(number.ToString("#.0"));
        }

        protected int NextInt(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue);
        }

        protected bool NextBoolean()
        {
            return Convert.ToBoolean(rand.Next(0, 1));
        }
    }
}
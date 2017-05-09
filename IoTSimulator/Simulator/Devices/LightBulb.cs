using System;
using Newtonsoft.Json;

namespace Simulator.Base
{
    public class LightBulb : IoTDevice
    {
        [JsonProperty(PropertyName = "luminance")]
        public double Luminance { get; set; }


        [JsonProperty(PropertyName = "wattage")]
        public double Wattage { get; set; }


        private readonly int[] wattValues = new int[] {42, 240, 25, 40, 60, 75, 100, 80, 28, 42, 53, 70 };
        private readonly double[] currentValues = new double[] { 0.36, 0.54, 0.72, 0.90};

        public LightBulb()
        {
            double randCurrent = currentValues[NextInt(0, currentValues.Length)];
            Wattage = wattValues[NextInt(0, wattValues.Length)];
            Luminance = Wattage * randCurrent;
        }

        public override void SimulateNextReading()
        {
            int timesFactor = NextBoolean() ? 1 : -1;
            Luminance += NextDouble(2.0 * timesFactor, 2.1);
        }
    }
}

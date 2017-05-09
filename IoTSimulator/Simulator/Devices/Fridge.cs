using Newtonsoft.Json;

namespace Simulator.Base
{
    public class Fridge : IoTDevice
    {
        [JsonProperty(PropertyName = "fridge_temperature")]
        public double FridgeTemperature { get; set; }


        [JsonProperty(PropertyName = "freezer_temperature")]
        public double FreezerTemperature { get; set; }

        public Fridge()
        {
            FridgeTemperature = NextDouble(1.0, 5.0);
            FreezerTemperature = NextDouble(3.0, -20.0);
        }

        public override void SimulateNextReading()
        {
            int timesFactor = NextBoolean() ? 1 : -1;
            FridgeTemperature += NextDouble(1.0 * timesFactor, 1.2);
            FreezerTemperature += NextDouble(2.0 * timesFactor, 2.1);
        }
    }
}

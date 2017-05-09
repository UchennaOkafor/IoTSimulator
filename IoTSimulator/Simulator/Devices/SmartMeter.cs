using Newtonsoft.Json;

namespace Simulator.Base
{
    public class SmartMeter : IoTDevice
    {
        [JsonProperty(PropertyName = "electricity_used")]
        public double ElectricityUsed { get; set; }


        [JsonProperty(PropertyName = "gas_used")]
        public double GasUsed { get; set; }

        public SmartMeter()
        {
            ElectricityUsed = NextDouble(600.00, 800);
            GasUsed = NextDouble(800.00, 1000.00);
        }

        public override void SimulateNextReading()
        {
            ElectricityUsed += NextDouble(0.0, 10.0);
            GasUsed += NextDouble(0.0, 10.0);
        }
    }
}

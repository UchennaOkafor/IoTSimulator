using Newtonsoft.Json;

namespace Simulator.Base
{
    public class Thermostat : IoTDevice
    {
        [JsonProperty(PropertyName = "temperature")]
        public int Temperature { get; set; }


        [JsonProperty(PropertyName = "battery_level")]
        public int BatteryLevel { get; set; }
    }
}

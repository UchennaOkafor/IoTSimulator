using Newtonsoft.Json;

namespace Simulator.Base
{
    public class Fridge : IoTDevice
    {
        [JsonProperty(PropertyName = "top_temperature")]
        public int TopTemperature { get; set; }


        [JsonProperty(PropertyName = "bottom_temperature")]
        public int BottomTemperature { get; set; }
    }
}

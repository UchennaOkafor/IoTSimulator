using Newtonsoft.Json;

namespace Simulator.Base
{
    public class LightBulb : IoTDevice
    {
        [JsonProperty(PropertyName = "luminance")]
        public int Luminance { get; set; }


        [JsonProperty(PropertyName = "current")]
        public int Current { get; set; }
    }
}

using Newtonsoft.Json;

namespace Simulator.Base
{
    public class Device
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }


        [JsonProperty(PropertyName = "device_type")]
        public string DeviceType { get; set; }
    }
}
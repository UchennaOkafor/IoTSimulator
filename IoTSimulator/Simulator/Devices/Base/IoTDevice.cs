using Newtonsoft.Json;

namespace Simulator.Base
{
    public class IoTDevice
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
using System.Runtime.Serialization;

namespace IoTSimulator
{
    [DataContract]
    public class Device
    {
        public int Id { get; set; }

        public string Type { get; set; }
    }
}

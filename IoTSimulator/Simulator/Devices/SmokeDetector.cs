using System;
using Newtonsoft.Json;

namespace Simulator.Base
{
    class SmokeDetector : IoTDevice
    {
        [JsonProperty(PropertyName = "smoke_level")]
        public int SmokeLevel { get; set; }


        [JsonProperty(PropertyName = "battery_level")]
        public int BatteryLevel { get; set; }

        public override void SimulateNextReading()
        {
            throw new NotImplementedException();
        }
    }
}

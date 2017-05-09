using Newtonsoft.Json;

namespace Simulator.Base
{
    public class Thermostat : IoTDevice
    {
        [JsonProperty(PropertyName = "room_temperature")]
        public double RoomTemperature { get; set; }


        [JsonProperty(PropertyName = "battery_level")]
        public int BatteryLevel { get; set; }

        public Thermostat()
        {
            RoomTemperature = NextDouble(18, 24);
            BatteryLevel = NextInt(90, 100);
        }

        public override void SimulateNextReading()
        {
            int timesFactor = NextBoolean() ? 1 : -1;
            RoomTemperature += NextDouble(2.0 * timesFactor, 2.0);

            do
            {
                BatteryLevel += NextInt(-5, 3);
            } while (BatteryLevel > 100);
        }
    }
}

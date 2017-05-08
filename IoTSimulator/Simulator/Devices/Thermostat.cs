using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSimulator
{
    public class Thermostat : Device
    {
        public int Temperature { get; set; }

        public int BatteryLevel { get; set; }
    }
}

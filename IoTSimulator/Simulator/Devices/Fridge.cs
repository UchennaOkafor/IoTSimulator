using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTSimulator
{
    public class Fridge : Device
    {
        public int BottomTemperature { get; set; }

        public int TopTemperature { get; set; }
    }
}

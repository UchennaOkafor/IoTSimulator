using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace IoTSimulator
{
    public class LightBulb : Device
    {
        public int Luminance { get; set; }

        public int Current { get; set; }
    }
}

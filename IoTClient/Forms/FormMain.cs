using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator.Module;

namespace IoTClient.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            int timerInterval = 2000;
            var d = new DeviceSimulator(timerInterval);

            d.RunSimulation();
        }
    }
}

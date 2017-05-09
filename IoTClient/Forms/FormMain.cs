using System;
using Simulator.Module;
using System.Windows.Forms;

namespace IoTClient.Forms
{
    public partial class FormMain : Form
    {
        private DeviceSimulator simulator;

        public FormMain()
        {
            InitializeComponent();
            int timerInterval = 2000;
            simulator = new DeviceSimulator(timerInterval);
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            simulator.RunSimulation(); 
        }

        public void btnStop_Click(object sender, EventArgs e)
        {
            simulator.StopSimulation();
        }
    }
}
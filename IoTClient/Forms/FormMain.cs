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
            simulator = new DeviceSimulator(Convert.ToInt32(nudInterval.Value));
            simulator.OnDataSent += (o, e) =>
            {
                SetStatus("Data sent to server");
            };
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            simulator.RunSimulation();
            SetState(false);
            SetStatus("Working...");
        }

        public void btnStop_Click(object sender, EventArgs e)
        {
            simulator.StopSimulation();
            SetState(true);
            SetStatus("Idle...");
        }

        private void SetState(bool isActive)
        {
            btnStart.Enabled = isActive;
            btnStop.Enabled = ! isActive;
        }

        private void SetStatus(string text)
        {
            lblStatus.Text = $"[{DateTime.Now}] - Status: {text}";
        }

        private void nudInterval_ValueChanged(object sender, EventArgs e)
        {
            simulator.Interval = Convert.ToInt32(nudInterval.Value);
        }
    }
}
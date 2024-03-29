﻿using System;
using Simulator.Module;
using System.Windows.Forms;

namespace IoTClient.Forms
{
    public partial class FormMain : Form
    {
        private DeviceSimulator simulator;
        private int counter;

        public FormMain()
        {
            InitializeComponent();
            SetStatus("Ready...");
        }

        public void btnStart_Click(object sender, EventArgs e)
        {
            if (simulator == null)
            {
                simulator = new DeviceSimulator(Convert.ToInt32(nudInterval.Value));
                simulator.OnDataSent += (o, e2) =>
                {
                    SetStatus($"Simulated data {++counter} sent to server");
                };
            }

            simulator.RunSimulation();
            SetState(false);
            SetStatus("Warming up...");
            nudInterval.Enabled = false;
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
            lblStatus.Text = $"[{DateTime.Now}] - {text}";
        }
    }
}
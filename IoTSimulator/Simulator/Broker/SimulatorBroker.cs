using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Simulator.Base;

namespace Simulator.Broker
{
    public class SimulatorBroker
    {
        private HttpClient httpClient;
        private readonly string baseUrl;

        public SimulatorBroker()
        {
            baseUrl = "http://192.168.0.53:8000/things/api/";
            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public List<Device> GetActiveDevices()
        {
            return JsonConvert.DeserializeObject<List<Device>>(httpClient.GetStringAsync("active_devices").Result);
        }

        public Device[] PostDeviceData(List<IoTDevice> devices)
        {
            var jsonPayload = new List<Dictionary<string, object>>();

            foreach (var device in devices)
            {
                jsonPayload.Add(new Dictionary<string, object>()
                {
                    {"user_device_id", device.Id},
                    {"raw_data", JsonConvert.SerializeObject(device) }
                });
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(jsonPayload), Encoding.UTF8, "application/json");
            var activeDevicesJson = httpClient.PostAsync($"simulate", stringContent).Result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Device[]>(activeDevicesJson);
        }
    }
}
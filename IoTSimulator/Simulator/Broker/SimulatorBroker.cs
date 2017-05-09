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
        private readonly string apiKey, baseUrl;

        public SimulatorBroker()
        {
            apiKey = "Kappa";
            baseUrl = "http://localhost.:8000/things/api/";
            InitializeHttpClient();
        }

        private void InitializeHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("API-Key", apiKey);
        }

        public Device[] GetActiveDevices()
        {
            return JsonConvert.DeserializeObject<Device[]>(httpClient.GetStringAsync("active_devices").Result);
        }

        public bool PostDeviceData(IoTDevice[] devices)
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
            return httpClient.PostAsync($"simulate", stringContent).Result.IsSuccessStatusCode;       
        }
    }
}
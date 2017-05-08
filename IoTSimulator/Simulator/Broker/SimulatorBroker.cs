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

        public void SendSimulatedData(IoTDevice[] devices)
        {
            var body = new List<Dictionary<string, string>>();

            foreach (var device in devices)
            {
                body.Add(new Dictionary<string, string>()
                {
                    {"user_device_id", device.Id.ToString() },
                    {"raw_data", JsonConvert.SerializeObject(device) }
                });
            }

            var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var b = httpClient.PostAsync($"devices/simulate", stringContent).Result.IsSuccessStatusCode;       
        }
    }
}
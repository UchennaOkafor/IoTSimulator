using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace IoTSimulator
{
    public class SimulatorBroker
    {
        private HttpClient httpClient;
        private JavaScriptSerializer jss;
        private readonly string apiKey, baseUrl;

        public SimulatorBroker()
        {
            apiKey = "Kappa";
            baseUrl = "http://localhost.:8000/things/api/";
            jss = new JavaScriptSerializer();
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
            return jss.Deserialize<Device[]>(httpClient.GetStringAsync("active_devices").Result);
        }

        public bool CreateProjectSets(int projectId, List<int> setIds)
        {
            var body = new Dictionary<string, string>()
            {
                {"XY" , "HI"},
                //{"XY" , "Bye"},
            };

            return httpClient.PostAsync($"devices/simulate", new FormUrlEncodedContent(body)).Result.IsSuccessStatusCode;
        }

        public bool SendSimulatedData(Device device)
        {
            return true;
        }
    }
}
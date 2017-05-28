using MarsInfo.Entities.Weather;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Weather
{
    public class WeatherReportManagerExternal : IWeatherReportManager
    {
        HttpClient client;
        public BELatest Latest { get; private set; }

        public WeatherReportManagerExternal()
        {
            client = new HttpClient(new NativeMessageHandler());
            client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<BELatest> GetCurrentWeather()
        {
            Latest = new BELatest();
            var uri = new Uri("http://marsweather.ingenology.com/v1/latest/");
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Latest = JsonConvert.DeserializeObject<BELatest>(content);
                }
            }
            catch (Exception)
            {
            }
            return Latest;
        }
    }
}
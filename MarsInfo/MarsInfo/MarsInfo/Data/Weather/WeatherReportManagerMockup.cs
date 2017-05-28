using MarsInfo.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Weather
{
    class WeatherReportManagerMockup
    {
        public class CommentManagerMockup : IWeatherReportManager
        {
            BELatest _weather;

            public CommentManagerMockup()
            {
                _weather = new BELatest();
                _weather.report = new BEReport()
                {
                    terrestrial_date = "test1",
                    sol = 1,
                    ls = 1.0,
                    min_temp = 1.0,
                    min_temp_fahrenheit = 1.0,
                    max_temp = 1.0,
                    max_temp_fahrenheit = 1.0,
                    pressure = 1.0,
                    pressure_string = "pressure",
                    abs_humidity = 0.0,
                    wind_speed = 0.0,
                    wind_direction = "wind direction",
                    atmo_opacity = "atmo opacity",
                    season = "season",
                    sunrise = "sunrise",
                    sunset = "sunset"
                };
            }

            public BELatest AllWeatherReports
            {
                get
                {
                    return _weather;
                }
            }
            public async Task<BELatest> GetCurrentWeather()
            {
                return _weather;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Weather
{
    public class WeatherReportManagerFactory
    {
        private static IWeatherReportManager _current = null;

        public static IWeatherReportManager Current
        {
            get
            {
                if (_current == null)
                    _current = new WeatherReportManagerExternal();
                return _current;
            }
        }
    }
}
using MarsInfo.Entities.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Weather
{
    public interface IWeatherReportManager
    {
        Task<BELatest> GetCurrentWeather();
    }
}

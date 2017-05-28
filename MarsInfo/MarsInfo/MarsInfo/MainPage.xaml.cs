using MarsInfo.Data.Weather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarsInfo
{
    public partial class MainPage : ContentPage
    {
        IWeatherReportManager weatherMgr;

        public MainPage()
        {
            InitializeComponent();
            Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            weatherMgr = WeatherReportManagerFactory.Current;
        }
        protected override void OnAppearing()
        {
            RefreshWeatherGUI();
        }
        private async void RefreshWeatherGUI()
        {
            var weatherReport = await weatherMgr.GetCurrentWeather();
            if (weatherReport != null)
            {
                string sol = "Welcome to a " + weatherReport.report.atmo_opacity.ToString().ToLower() + " sol " + weatherReport.report.sol.ToString();

                txtMaxTemp.Text = weatherReport.report.max_temp.ToString() + "°";
                txtMinTemp.Text = weatherReport.report.min_temp.ToString() + "°";
                txtSol.Text = sol;
                txtSunrise.Text = weatherReport.report.sunrise;
                txtSunset.Text = weatherReport.report.sunset;
            }
        }
    }
}

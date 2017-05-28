using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MarsInfo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var tabs = new TabbedPage();
            tabs.Title = "Mars Explorer 1.0";
            tabs.Children.Add(new MainPage { Title = "Weather" });
            tabs.Children.Add(new CuriosityPage() { Title = "Curiosity" });

            MainPage = new NavigationPage(tabs);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

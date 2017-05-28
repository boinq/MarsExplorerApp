using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MarsInfo.Data.Database;
using System.IO;
using SQLite.Net;
using Xamarin.Forms;
using MarsInfo.Droid;

[assembly: Dependency(typeof(DBConnectionAndroid))]

namespace MarsInfo.Droid
{
    public class DBConnectionAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var fileName = "MarsDB.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroidN();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}
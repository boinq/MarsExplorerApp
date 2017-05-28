using MarsInfo.Entities.Curiosity;
using MarsInfo.Entities.Database;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarsInfo.Data.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
    public class MarsDatabase
    {
        #region Singleton pattern
        private static MarsDatabase instance;
        /// <summary>
        /// Returns the FriendsManager singleton object.
        /// </summary>
        /// <returns></returns>
        public static MarsDatabase GetInstance()
        {
            if (instance == null)
                instance = new MarsDatabase();

            return instance;
        }
        #endregion
        private SQLiteConnection _connection;

        public MarsDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();           
            _connection.CreateTable<BEDBSolCatalog>();
            _connection.CreateTable<BEDBImage>();
        }
        public IEnumerable<BEDBSolCatalog> GetSolCatalogs()
        {
            return (from t in _connection.Table<BEDBSolCatalog>()
                    select t).ToList();
        }
        public int Count { get { return GetSolCatalogs().Count(); } }

        public List<string> GetSols()
        {
            return (from t in _connection.Table<BEDBSolCatalog>()
                    select t.sol.ToString()).ToList();
        }
        public BESolCatalog GetSol(int solNr)
        {
            BESolCatalog result = new BESolCatalog();
            var solData = _connection.Table<BEDBSolCatalog>().Where(t => t.sol == solNr).FirstOrDefault();
            if (solData == null)
            {
                return result;
            }
            else
            {
                result = ParseSolFromDB(solData);
            }

            string solStr = solNr.ToString("D5"); // D5 means it converts 1706 to 01706 or 960 to 00960
            var images = (from i in _connection.Table<BEDBImage>() where i.sol == solStr select i).ToList();
            if (images != null)
            {
                foreach (var image in images)
                {
                    result.images.Add(ParseImageFromDB(image));
                }
            }
            return result;
        }
        private BEDBSolCatalog GetDBSol(int solNr)
        {
            return _connection.Table<BEDBSolCatalog>().FirstOrDefault(t => t.sol == solNr);
        }
        private BEImage ParseImageFromDB(BEDBImage input)
        {
            return new BEImage()
            {
                bucket = input.bucket,
                cameraModelComponentList = input.cameraModelComponentList,
                dateAdded = input.dateAdded,
                filterName = input.filterName,
                scaleFactor = input.scaleFactor,
                pdsLabelUrl = input.pdsLabelUrl,
                urlList = input.urlList,
                sclk = input.sclk,
                attitude = input.attitude,
                cameraPosition = input.cameraPosition,
                drive = input.drive,
                cameraModelType = input.cameraModelType,
                contributor = input.contributor,
                mastAz = input.mastAz,
                site = input.site,
                cameraVector = input.cameraVector,
                itemName = input.itemName,
                subframeRect = input.subframeRect,
                utc = input.utc,
                sol = input.sol,
                mastEl = input.mastEl,
                instrument = input.instrument,
                lmst = input.lmst,
                sampleType = input.sampleType,
                xyz = input.xyz
            };
        }
        private BEDBImage ParseImageToDB(BEImage input)
        {
            return new BEDBImage()
            {
                bucket = input.bucket,
                cameraModelComponentList = input.cameraModelComponentList,
                dateAdded = input.dateAdded,
                filterName = input.filterName,
                scaleFactor = input.scaleFactor,
                pdsLabelUrl = input.pdsLabelUrl,
                urlList = input.urlList,
                sclk = input.sclk,
                attitude = input.attitude,
                cameraPosition = input.cameraPosition,
                drive = input.drive,
                cameraModelType = input.cameraModelType,
                contributor = input.contributor,
                mastAz = input.mastAz,
                site = input.site,
                cameraVector = input.cameraVector,
                itemName = input.itemName,
                subframeRect = input.subframeRect,
                utc = input.utc,
                sol = input.sol,
                mastEl = input.mastEl,
                instrument = input.instrument,
                lmst = input.lmst,
                sampleType = input.sampleType,
                xyz = input.xyz
            };
        }
        private BESolCatalog ParseSolFromDB(BEDBSolCatalog input)
        {
            return new BESolCatalog()
            {
                type = input.type,
                most_recent = input.most_recent,
                sol = input.sol
            };
        }
        private BEDBSolCatalog ParseSolToDB(BESolCatalog input)
        {
            return new BEDBSolCatalog()
            {
                type = input.type,
                most_recent = input.most_recent,
                sol = input.sol
            };
        }
        public void DeleteSol(int solNr)
        {
            _connection.Delete<BEDBSolCatalog>(solNr);
        }
        public void AddSol(BESolCatalog inputCatalog)
        {
            var sol = ParseSolToDB(inputCatalog);
            _connection.Insert(sol);
            foreach (var image in inputCatalog.images)
            {
                var parsedImg = ParseImageToDB(image);
                _connection.Insert(parsedImg);
            }
        }
        public void DeleteAll()
        {
            _connection.DeleteAll<BEDBSolCatalog>();
            _connection.DeleteAll<BEDBImage>();
        }
        public BEDBSolCatalog UpdateSol(BEDBSolCatalog catalog)
        {
            _connection.Update(catalog);
            return GetDBSol(catalog.sol);
        }
    }
}

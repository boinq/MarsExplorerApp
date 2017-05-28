using MarsInfo.Data.Database;
using MarsInfo.Entities.Curiosity;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Curiosity
{
    public class CuriosityManagerExternal : ICuriosityManager
    {
        private HttpClient client;
        private MarsDatabase marsDB;
        public BECuriosityManifest Manifest { get; private set; }

        public CuriosityManagerExternal()
        {
            client = new HttpClient(new NativeMessageHandler());
            marsDB = MarsDatabase.GetInstance();
        }
        public async Task<BECuriosityManifest> GetManifest()
        {
            Manifest = new BECuriosityManifest();
            var uri = new Uri("http://mars.jpl.nasa.gov/msl-raw-images/image/image_manifest.json");

            string jsonStr = "";

            try
            {
                jsonStr = await client.GetStringAsync(uri);
                if (jsonStr != "")
                {
                    Manifest = JsonConvert.DeserializeObject<BECuriosityManifest>(jsonStr);
                    Manifest.sols = Manifest.sols.OrderByDescending(x => x.sol).ToList();
                }
            }
            catch (Exception)
            {

            }
            return Manifest;
        }
        public async Task<BESolCatalog> GetSolCatalog(BESol inputSol)
        {
            BESolCatalog result = new BESolCatalog();
            try
            {
                result = marsDB.GetSol(inputSol.sol);
                if (result.type == null)
                {
                    var response = await client.GetAsync(inputSol.catalog_url);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<BESolCatalog>(content);
                        marsDB.AddSol(result);
                    }
                }
            }
            catch (Exception)
            {

            }
            return result;
        }
    }
}
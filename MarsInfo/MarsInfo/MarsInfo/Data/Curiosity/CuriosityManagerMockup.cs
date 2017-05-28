using MarsInfo.Entities.Curiosity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Curiosity
{
    class CuriosityManagerMockup
    {
        public class CommentManagerMockup : ICuriosityManager
        {
            BECuriosityManifest _manifest;
            BESolCatalog _solCatalog;

            public CommentManagerMockup()
            {
                SetupMockManifest();
                SetupMockSol();
            }
            public BECuriosityManifest Manifest
            {
                get
                {
                    return _manifest;
                }
            }
            public BESolCatalog SolCatalog
            {
                get
                {
                    return _solCatalog;
                }
            }
            private void SetupMockManifest()
            {
                _manifest = new BECuriosityManifest();
                _manifest.sols.Add(new BESol()
                {
                    sol = 929,
                    num_images = 307,
                    catalog_url = "http://mars.jpl.nasa.gov/msl-raw-images/image/images_sol929.json",
                    last_updated = "2015-06-06T14:30:07Z"
                });
                _manifest.sols.Add(new BESol()
                {
                    sol = 930,
                    num_images = 351,
                    catalog_url = "http://mars.jpl.nasa.gov/msl-raw-images/image/images_sol930.json",
                    last_updated = "2015-07-01T15:00:06Z"
                });
                _manifest.sols.Add(new BESol()
                {
                    sol = 931,
                    num_images = 161,
                    catalog_url = "http://mars.jpl.nasa.gov/msl-raw-images/image/images_sol931.json",
                    last_updated = "2015-07-21T15:31:20Z"
                });
            }
            private void SetupMockSol()
            {
                _solCatalog = new BESolCatalog();
                _solCatalog.type = "msl-images-1.0";
                _solCatalog.most_recent = "2015-07-21T15:31:20Z";
                _solCatalog.sol = 931;
                _solCatalog.images.Add(new BEImage()
                {
                    bucket = "msl-raws",
                    cameraModelComponentList = "UNK",
                    dateAdded = "2015-03-21T21:30:39Z",
                    filterName = "UNK",
                    scaleFactor = "UNK",
                    pdsLabelUrl = "UNK",
                    urlList = "http://mars.jpl.nasa.gov/msl-raw-images/msss/00931/mcam/0931MR0040910020501798I01_DXXX.jpg",
                    sclk = "UNK",
                    attitude = "UNK",
                    cameraPosition = "UNK",
                    drive = "UNK",
                    cameraModelType = "UNK",
                    contributor = "MSSS",
                    mastAz = "UNK",
                    site = "UNK",
                    cameraVector = "UNK",
                    itemName = "0931MR0040910020501798I01_DXXX",
                    subframeRect = "UNK",
                    utc = "2015-03-20T12:51:34",
                    sol = "00931",
                    mastEl = "UNK",
                    instrument = "MAST_RIGHT",
                    lmst = "UNK",
                    sampleType = "thumbnail",
                    xyz = "UNK"
                });
                _solCatalog.images.Add(new BEImage()
                {
                    bucket = "msl-raws",
                    cameraModelComponentList = "UNK",
                    dateAdded = "2015-03-22T09:32:02Z",
                    filterName = "UNK",
                    scaleFactor = "UNK",
                    pdsLabelUrl = "UNK",
                    urlList = "http://mars.jpl.nasa.gov/msl-raw-images/msss/00931/mcam/0931MR0040910020501798D01_DXXX.jpg",
                    sclk = "UNK",
                    attitude = "UNK",
                    cameraPosition = "UNK",
                    drive = "UNK",
                    cameraModelType = "UNK",
                    contributor = "MSSS",
                    mastAz = "UNK",
                    site = "UNK",
                    cameraVector = "UNK",
                    itemName = "0931MR0040910020501798D01_DXXX",
                    subframeRect = "UNK",
                    utc = "2015-03-20T12:51:34",
                    sol = "00931",
                    mastEl = "UNK",
                    instrument = "MAST_RIGHT",
                    lmst = "UNK",
                    sampleType = "subframe",
                    xyz = "UNK"
                });
            }

            public async Task<BECuriosityManifest> GetManifest()
            {
                return _manifest;
            }

            public async Task<BESolCatalog> GetSolCatalog(BESol inputSol)
            {
                return _solCatalog;
            }
        }
    }
}

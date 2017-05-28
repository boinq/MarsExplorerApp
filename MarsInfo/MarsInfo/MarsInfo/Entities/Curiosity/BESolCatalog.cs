using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Entities.Curiosity
{
    public class BEImage
    {
        public string bucket { get; set; }
        public string cameraModelComponentList { get; set; }
        public string dateAdded { get; set; }
        public string filterName { get; set; }
        public string scaleFactor { get; set; }
        public string pdsLabelUrl { get; set; }
        public string urlList { get; set; }
        public string sclk { get; set; }
        public string attitude { get; set; }
        public string cameraPosition { get; set; }
        public string drive { get; set; }
        public string cameraModelType { get; set; }
        public string contributor { get; set; }
        public string mastAz { get; set; }
        public string site { get; set; }
        public string cameraVector { get; set; }
        public string itemName { get; set; }
        public string subframeRect { get; set; }
        public string utc { get; set; }
        public string sol { get; set; }
        public string mastEl { get; set; }
        public string instrument { get; set; }
        public string lmst { get; set; }
        public string sampleType { get; set; }
        public string xyz { get; set; }
        public override string ToString()
        {
            return sampleType;
        }
    }

    public class BESolCatalog
    {
        public BESolCatalog()
        {
            images = new List<BEImage>();
        }
        public string type { get; set; }
        public string most_recent { get; set; }
        public int sol { get; set; }
        public List<BEImage> images { get; set; }    
    }
}


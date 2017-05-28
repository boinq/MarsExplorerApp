using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Entities.Curiosity
{
    public class BESol
    {
        public int sol { get; set; }
        public int num_images { get; set; }
        public string catalog_url { get; set; }
        public string last_updated { get; set; }
    }

    public class BECuriosityManifest
    {
        public string type { get; set; }
        public int latest_sol { get; set; }
        public int num_images { get; set; }
        public string most_recent { get; set; }
        public List<BESol> sols { get; set; }        
    }
}

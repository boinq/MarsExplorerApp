using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Entities.Database
{
    public class BEDBSolCatalog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string type { get; set; }
        public string most_recent { get; set; }
        public int sol { get; set; }
        //public List<BEImage> images { get; set; }
    }
}

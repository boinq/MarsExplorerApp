using MarsInfo.Entities.Curiosity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Curiosity
{
    public interface ICuriosityManager
    {
        Task<BECuriosityManifest> GetManifest();
        Task<BESolCatalog> GetSolCatalog(BESol inputSol);
    }
}

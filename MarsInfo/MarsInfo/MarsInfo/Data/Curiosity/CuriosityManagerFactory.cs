using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsInfo.Data.Curiosity
{
    public class CuriosityManagerFactory
    {
        private static ICuriosityManager _current = null;

        public static ICuriosityManager Current
        {
            get
            {
                if (_current == null)
                    _current = new CuriosityManagerExternal();
                return _current;
            }
        }
    }
}

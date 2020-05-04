using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.HomeTask4
{
    class DinozavrException : Exception
    {
        
        public DinozavrException(string message)
        : base(message)
        { }
    }


    class WayOfTavelException : Exception
    {
        public WayOfTavelException(string message)
        : base(message)
        { }
    }
}

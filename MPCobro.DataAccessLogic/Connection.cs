using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MPCobro.DataAccessLogic
{
    public class Connection
    {
        /*
        protected string _cadena = ConfigurationManager
            .ConnectionStrings["ConnHelen"].ConnectionString;
        */
        protected string _cadena = ConfigurationManager
            .ConnectionStrings["Conn"].ConnectionString;
    }
}

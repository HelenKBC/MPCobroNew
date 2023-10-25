using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class Arrendatario
    {
        public int ArrendatarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Dui { get; set; }
        public string CorreoElectronico { get; set; }
    }
}
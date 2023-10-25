using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public int RolId { get; set; }
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string DUI { get; set; }
        public string CorreoElectronico { get; set; }

    }
}

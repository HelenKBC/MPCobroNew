using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class AsignacionLocal
    {
        public int AsignacionLocalId { get; set; }
        public int LocalId { get; set; }
        public int ArrendatarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        public decimal Monto { get; set; }


        
    }
}

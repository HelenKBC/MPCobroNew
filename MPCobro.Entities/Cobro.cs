using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class Cobro
    {
        public int CobroId { get; set; }
        public int EmpleadoId { get; set; }
        public int LocalId { get; set; }
        public DateTime FechaCobro { get; set; }
    }
}

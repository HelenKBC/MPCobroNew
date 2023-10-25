using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public string NombreUser { get; set; }
        public string Clave { get; set; }
    }
}

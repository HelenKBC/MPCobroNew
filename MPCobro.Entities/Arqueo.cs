using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.Entities
{
    public class Arqueo
    {
        public int ArqueoId { get; set; }
        public int UsuarioId { get; set; }
        public int CantidadDe1 { get; set; }
        public int CantidadDe5 { get; set; }
        public int CantidadDe10 { get; set; }
        public int CantidadDe20 { get; set; }
        public decimal CierreCaja { get; set; }
        public decimal TotalApertura { get; set; }
        public decimal FinalDia { get; set; }
        public decimal TotalVentaDelDia { get; set; }
        public decimal TotalSobrante { get; set; }
        public decimal TotalFaltante { get; set; }
        public DateTime FechaArqueo { get; set; }
    }
}

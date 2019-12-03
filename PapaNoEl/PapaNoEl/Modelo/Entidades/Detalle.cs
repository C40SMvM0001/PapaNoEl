using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Modelo.Entidades
{
    public class Detalle
    {
        public decimal cantidad { get; set; }
        public decimal subtotal { get; set; }
        public int idProducto { get; set; }
        public int idVenta { get; set; }        
    }
}

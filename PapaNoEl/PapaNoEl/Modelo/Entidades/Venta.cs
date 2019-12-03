using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Modelo.Entidades
{
    class Venta
    {
        public int idventa { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public int idcliente { get; set; }
        public string cuenta { get; set; }
    }
}

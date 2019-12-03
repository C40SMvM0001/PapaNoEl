using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Modelo.Entidades
{
    class Venta
    {
        public string idventa { get; set; }
        public string fecha { get; set; }
        public string total { get; set; }
        public string idcliente { get; set; }
        public string cuenta { get; set; }
    }
}

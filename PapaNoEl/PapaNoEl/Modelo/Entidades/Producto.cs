using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Modelo.Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }        
        public decimal precio { get; set; }
        public int stock { get; set; }
        
    }
}

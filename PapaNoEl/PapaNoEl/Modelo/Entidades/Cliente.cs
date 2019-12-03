using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Modelo.Entidades
{
    public class Cliente
    {
        public int cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string ci { get; set; }
        public string tipoEmpresa { get; set; }        
    }
}

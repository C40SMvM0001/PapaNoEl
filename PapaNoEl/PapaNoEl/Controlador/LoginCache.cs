using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    public static class LoginCache
    {
        public static string cuenta { get; set; }
        public static string clave { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string rol { get; set; }
    }
}

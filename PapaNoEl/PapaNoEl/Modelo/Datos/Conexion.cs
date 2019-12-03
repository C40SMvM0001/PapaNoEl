using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PapaNoEl.Modelo.Datos
{
    public class Conexion
    {
        private readonly string conexion;
        public Conexion()
        {
            conexion = ConfigurationManager.ConnectionStrings["connbddPapaNoEl"].ToString();
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }
    }
}

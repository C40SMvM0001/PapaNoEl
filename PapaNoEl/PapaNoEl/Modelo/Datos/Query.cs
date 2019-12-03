using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PapaNoEl.Modelo.Datos
{
    public class Query:Conexion
    {
        protected List<SqlParameter> parametros;

        protected int EjectuarNonQuery(string comandoSql)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = comandoSql;
                    comando.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    int resultado = comando.ExecuteNonQuery();
                    parametros.Clear();
                    return resultado;
                }
            }
        }

        protected DataTable EjecutarLectura(string comandoSql)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = comandoSql;
                    comando.CommandType = CommandType.Text;
                    SqlDataReader reader = comando.ExecuteReader();
                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                }
            }
        }

        protected DataTable EjecutarLecturaParametros(string comandoSql)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = comandoSql;
                    comando.CommandType = CommandType.Text;
                    foreach (SqlParameter item in parametros)
                    {
                        comando.Parameters.Add(item);
                    }
                    SqlDataReader reader = comando.ExecuteReader();
                    int resultado = comando.ExecuteNonQuery();                    
                    
                    parametros.Clear();

                    using (var tabla = new DataTable())
                    {
                        tabla.Load(reader);
                        reader.Dispose();
                        return tabla;
                    }
                    
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PapaNoEl.Modelo.Entidades;
using System.Data;

namespace PapaNoEl.Modelo.Datos
{
    class ClienteD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        private string actualizar;
        private string eliminar;

        public ClienteD()
        {
            seleccionarTodo = "select * from Cliente";
            insertar = "insert into Cliente values(@nombre,@apellido,@ci,@tipoempresa)";
            actualizar = "update Cliente set Nombre=@nombre,Apellido=@apellido,Ci=@ci,TipoEmpresa=@tipoempresa where Ci=@ci";
            eliminar = "delete from Cliente where Ci=@ci";
        }

        public int Adicionar(Cliente entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@apellido", entidad.apellido));
            parametros.Add(new SqlParameter("@ci", entidad.ci));
            parametros.Add(new SqlParameter("@tipoempresa", entidad.tipoempresa));
            return EjectuarNonQuery(insertar);
        }

        public int Editar(Cliente entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@apellido", entidad.apellido));
            parametros.Add(new SqlParameter("@ci", entidad.ci));
            parametros.Add(new SqlParameter("@tipoempresa", entidad.tipoempresa));
            return EjectuarNonQuery(actualizar);
        }

        public int Eliminar(string id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@ci", id));
            return EjectuarNonQuery(eliminar);
        }

        public List<Usuario> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaUsuarios = new List<Usuario>();
            foreach (DataRow item in tabla.Rows)
            {
                listaUsuarios.Add(new Usuario
                {
                    cuenta = item[0].ToString(),
                    clave = item[1].ToString(),
                    nombre = item[2].ToString(),
                    apellido = item[3].ToString(),
                    rol = item[4].ToString()
                });
            }
            return listaUsuarios;
        }
    }
}

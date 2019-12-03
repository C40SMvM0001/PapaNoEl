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
    public class ClienteD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        private string actualizar;
        private string eliminar;
        private string seleccionarTodoFiltro;

        public ClienteD()
        {
            seleccionarTodo = "select * from Clientes";
            insertar = "insert into Clientes values(@nombre,@apellido,@ci,@tipoempresa)";
            actualizar = "update Clientes set Nombre=@nombre,Apellido=@apellido,Ci=@ci,TipoEmpresa=@tipoempresa where Ci=@ci";
            eliminar = "delete from Clientes where Ci=@ci";
            seleccionarTodoFiltro = "select * from Clientes where Ci like @clave +'%' ";
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

        public List<Cliente> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaCliente = new List<Cliente>();
            foreach (DataRow item in tabla.Rows)
            {
                listaCliente.Add(new Cliente
                {
                    idcliente= item[0].ToString(),
                    nombre = item[1].ToString(),
                    apellido = item[2].ToString(),
                    ci = item[3].ToString(),
                    tipoempresa = item[4].ToString(),
                });
            }
            return listaCliente;
        }
        public List<Cliente> ObtenerTodo(string clave)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@clave", clave));

            var tabla = EjecutarLecturaParametros(seleccionarTodoFiltro);
            var listaCliente = new List<Cliente>();
            foreach (DataRow item in tabla.Rows)
            {
                listaCliente.Add(new Cliente
                {
                    idcliente = item[0].ToString(),
                    nombre = item[1].ToString(),
                    apellido = item[2].ToString(),
                    ci = item[3].ToString(),
                    tipoempresa = item[4].ToString(),
                });
            }
            return listaCliente;
        }
    }
}

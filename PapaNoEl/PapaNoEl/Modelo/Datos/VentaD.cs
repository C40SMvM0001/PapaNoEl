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
    class VentaD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        //private string actualizar;
        //private string eliminar;

        public VentaD()
        {
            seleccionarTodo = "select * from Ventas";
            insertar = "insert into Ventas values(@fecha,@total,@idcliente,@cuenta)";
            //actualizar = "update Ventas set Nombre=@nombre,Apellido=@apellido,Ci=@ci,TipoEmpresa=@tipoempresa where Ci=@ci";
            //eliminar = "delete from Ventas where Ci=@ci";
        }

        public int Adicionar(Venta entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@fecha", entidad.fecha));
            parametros.Add(new SqlParameter("@total", entidad.total));
            parametros.Add(new SqlParameter("@idcliente", entidad.idcliente));
            parametros.Add(new SqlParameter("@cuenta", entidad.cuenta));
            return EjectuarNonQuery(insertar);
        }

        //public int Editar(Cliente entidad)
        //{
        //    parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("@nombre", entidad.nombre));
        //    parametros.Add(new SqlParameter("@apellido", entidad.apellido));
        //    parametros.Add(new SqlParameter("@ci", entidad.ci));
        //    parametros.Add(new SqlParameter("@tipoempresa", entidad.tipoempresa));
        //    return EjectuarNonQuery(actualizar);
        //}

        //public int Eliminar(string id)
        //{
        //    parametros = new List<SqlParameter>();
        //    parametros.Add(new SqlParameter("@ci", id));
        //    return EjectuarNonQuery(eliminar);
        //}

        public List<Venta> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaVenta = new List<Venta>();
            foreach (DataRow item in tabla.Rows)
            {
                listaVenta.Add(new Venta
                {
                    idventa = item[0].ToString(),
                    fecha = item[1].ToString(),
                    total = item[2].ToString(),
                    idcliente = item[3].ToString(),
                    cuenta = item[4].ToString()
                });
            }
            return listaVenta;
        }
    }
}

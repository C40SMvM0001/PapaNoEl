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
    public class VentaD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        private string actualizar;
        private string eliminar;
        private string obtenerId;

        public VentaD()
        {
            seleccionarTodo = "select * from Ventas";
            insertar = "insert into Ventas values(@fecha,@total,@idcliente,@cuenta)";
            actualizar = "update Ventas set Nombre=@nombre,Apellido=@apellido,Ci=@ci,TipoEmpresa=@tipoempresa where Ci=@ci";
            eliminar = "delete from Ventas where Ci=@ci";
            obtenerId = "select * from Ventas where IdVenta = (select max(IdVenta) from Ventas)";
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


        public List<Venta> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaVenta = new List<Venta>();
            foreach (DataRow item in tabla.Rows)
            {
                listaVenta.Add(new Venta
                {
                    idventa = Convert.ToInt32(item[0]),
                    fecha = Convert.ToDateTime(item[1].ToString()),
                    total = Convert.ToDecimal(item[2].ToString()),
                    idcliente = Convert.ToInt32(item[3].ToString()),
                    cuenta = item[4].ToString()
                });
            }
            return listaVenta;
        }

        public List<Venta> VerId()
        {
            var tabla = EjecutarLectura(obtenerId);
            var listaVenta = new List<Venta>();
            foreach (DataRow item in tabla.Rows)
            {
                listaVenta.Add(new Venta
                {
                    idventa = Convert.ToInt32(item[0]),
                    fecha = Convert.ToDateTime(item[1].ToString()),
                    total = Convert.ToDecimal(item[2].ToString()),
                    idcliente = Convert.ToInt32(item[3].ToString()),
                    cuenta = item[4].ToString()
                });
            }
            return listaVenta;
        }

    }
}

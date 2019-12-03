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
    public class DetalleD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        private string actualizar;
        private string eliminar;
        private string obtenerId;

        public DetalleD()
        {
            //seleccionarTodo = "select * from Ventas";
            insertar = "insert into Detalles values(@cantidad,@subtotal,@idProducto,@idVenta)";
            //actualizar = "update Ventas set Nombre=@nombre,Apellido=@apellido,Ci=@ci,TipoEmpresa=@tipoempresa where Ci=@ci";
            //eliminar = "delete from Ventas where Ci=@ci";
            //obtenerId = "select * from Ventas where IdVenta = (select max(IdVenta) from Ventas)";
        }

        public int Adicionar(Detalle entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cantidad", entidad.cantidad));
            parametros.Add(new SqlParameter("@subtotal", entidad.subtotal));
            parametros.Add(new SqlParameter("@idProducto", entidad.idProducto));
            parametros.Add(new SqlParameter("@idVenta", entidad.idVenta));
            return EjectuarNonQuery(insertar);
        }


        public List<Detalle> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaVenta = new List<Detalle>();
            foreach (DataRow item in tabla.Rows)
            {
                listaVenta.Add(new Detalle
                {
                    cantidad = Convert.ToDecimal(item[0].ToString()),
                    subtotal = Convert.ToDecimal(item[1].ToString()),
                    idProducto = Convert.ToInt32(item[2].ToString()),
                    idVenta = Convert.ToInt32(item[3].ToString())
                    
                });
            }
            return listaVenta;
        }

        
    }
}

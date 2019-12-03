using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaNoEl.Modelo.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace PapaNoEl.Modelo.Datos
{
    class ProductoD:Query
    {
        private string seleccionarTodo;
        private string insertar;
        private string actualizar;
        private string eliminar;

        public ProductoD()
        {
            seleccionarTodo = "select * from Productos";
            insertar = "insert into Productos values(@descripcion,@tipo,@precio,@stock)";
            actualizar = "update Productos set Descripcion=@descripcion,Tipo=@tipo,Precio=@precio,Stock=@stock where IdProducto=@idproducto";
            eliminar = "delete from Productos where IdProducto=@idproducto";
        }

        public int Adicionar(Producto entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@descripcion", entidad.descripcion));
            parametros.Add(new SqlParameter("@tipo", entidad.tipo));
            parametros.Add(new SqlParameter("@precio", entidad.precio));
            parametros.Add(new SqlParameter("@stock", entidad.stock));
            return EjectuarNonQuery(insertar);
        }

        public int Editar(Producto entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idproducto", entidad.idProducto));
            parametros.Add(new SqlParameter("@descripcion", entidad.descripcion));
            parametros.Add(new SqlParameter("@tipo", entidad.tipo));
            parametros.Add(new SqlParameter("@precio", entidad.precio));
            parametros.Add(new SqlParameter("@stock", entidad.stock));
            return EjectuarNonQuery(actualizar);
        }

        public int Eliminar(string id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idproducto", id));
            return EjectuarNonQuery(eliminar);
        }

        public List<Producto> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaProducto = new List<Producto>();
            foreach (DataRow item in tabla.Rows)
            {
                listaProducto.Add(new Producto
                {
                    idProducto = item[0].ToString(),
                    descripcion = item[1].ToString(),
                    tipo = item[2].ToString(),
                    precio = item[3].ToString(),
                    stock = item[4].ToString()
                });
            }
            return listaProducto;
        }
    }
}

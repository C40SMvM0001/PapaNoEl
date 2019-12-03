using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    public class ProductoC
    {
        ProductoD _db = new ProductoD();
        public bool GuardarCambios(Producto nuevoProducto)
        {
            try
            {
                Producto tblProducto = new Producto();

                tblProducto.descripcion = nuevoProducto.descripcion;
                tblProducto.tipo = nuevoProducto.tipo;
                tblProducto.precio = nuevoProducto.precio;
                tblProducto.stock = nuevoProducto.stock;
                return _db.Adicionar(tblProducto) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Modificar(Producto nuevoProducto)
        {
            try
            {
                Producto tblProducto = new Producto();

                tblProducto.descripcion = nuevoProducto.descripcion;
                tblProducto.tipo = nuevoProducto.tipo;
                tblProducto.precio = nuevoProducto.precio;
                tblProducto.stock = nuevoProducto.stock;

                return _db.Editar(tblProducto) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(string id)
        {
            try
            {
                return _db.Eliminar(id) > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Producto> MostrarDatos()
        {
            return _db.ObtenerTodo().ToList();
        }

        public List<Producto> MostrarDatos(string id)
        {
            //return _db.Usuarios.Where(x => x.NOMBRE.Contains(id)).ToList();
            return _db.ObtenerTodo(id).ToList();
        }
    }
}

using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    class VentaC
    {
        VentaD _db = new VentaD();
        public bool GuardarCambios(Venta nuevaVenta)
        {
            try
            {
                Venta tblVenta = new Venta();

                tblVenta.fecha = nuevaVenta.fecha;
                tblVenta.total = nuevaVenta.total;
                tblVenta.idcliente = nuevaVenta.idcliente;
                tblVenta.cuenta = nuevaVenta.cuenta;
                return _db.Adicionar(tblVenta) > 0;
            }
            catch
            {
                return false;
            }
        }

        //public bool Modificar(Cliente nuevoCliente)
        //{
        //    try
        //    {
        //        Cliente tblCliente = new Cliente();

        //        tblCliente.nombre = nuevoCliente.nombre;
        //        tblCliente.apellido = nuevoCliente.apellido;
        //        tblCliente.ci = nuevoCliente.ci;
        //        tblCliente.tipoempresa = nuevoCliente.tipoempresa;

        //        return _db.Editar(tblCliente) > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool Eliminar(string id)
        //{
        //    try
        //    {
        //        return _db.Eliminar(id) > 0;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        public List<Venta> MostrarDatos()
        {
            return _db.ObtenerTodo().ToList();
        }
    }
}

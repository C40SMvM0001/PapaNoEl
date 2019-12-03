using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    public class DetalleC
    {
        DetalleD _db = new DetalleD();
        public bool GuardarCambios(Detalle nuevaVenta)
        {
            try
            {
                Detalle tblVenta = new Detalle();

                tblVenta.cantidad = nuevaVenta.cantidad;
                tblVenta.subtotal = nuevaVenta.subtotal;
                tblVenta.idProducto = nuevaVenta.idProducto;
                tblVenta.idVenta = nuevaVenta.idVenta;
                return _db.Adicionar(tblVenta) > 0;
            }
            catch
            {
                return false;
            }
        }               

    }
}

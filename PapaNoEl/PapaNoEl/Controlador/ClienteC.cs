using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    public class ClienteC
    {
        ClienteD _db = new ClienteD();
        public bool GuardarCambios(Cliente nuevoCliente)
        {
            try
            {
                Cliente tblCliente = new Cliente();

                tblCliente.nombre = nuevoCliente.nombre;
                tblCliente.apellido = nuevoCliente.apellido;
                tblCliente.ci= nuevoCliente.ci;
                tblCliente.tipoempresa = nuevoCliente.tipoempresa;
                return _db.Adicionar(tblCliente) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Modificar(Cliente nuevoCliente)
        {
            try
            {
                Cliente tblCliente = new Cliente();

                tblCliente.nombre = nuevoCliente.nombre;
                tblCliente.apellido = nuevoCliente.apellido;
                tblCliente.ci = nuevoCliente.ci;
                tblCliente.tipoempresa = nuevoCliente.tipoempresa;

                return _db.Editar(tblCliente) > 0;
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

        public List<Cliente> MostrarDatos()
        {
            return _db.ObtenerTodo().ToList();
        }

        public List<Cliente> MostrarDatos(string id)
        {
            //return _db.Usuarios.Where(x => x.NOMBRE.Contains(id)).ToList();
            return _db.ObtenerTodo(id).ToList();
        }

        public int VerId()
        {
            var reg = _db.VerId().First();
            return Convert.ToInt32(reg.idcliente);
        }
    }
}

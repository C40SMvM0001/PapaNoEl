using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    class ClienteC
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

        public List<Usuario> MostrarDatos()
        {
            return _db.ObtenerTodo().ToList();
        }
    }
}

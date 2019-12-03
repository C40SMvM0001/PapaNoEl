using PapaNoEl.Modelo.Datos;
using PapaNoEl.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaNoEl.Controlador
{
    public class UsuarioC
    {
        UsuarioD _db = new UsuarioD();
        public bool GuardarCambios(Usuario nuevoUsuario)
        {
            try
            {
                Usuario tblUsuario = new Usuario();

                tblUsuario.cuenta = nuevoUsuario.cuenta;
                tblUsuario.clave = nuevoUsuario.clave;
                tblUsuario.nombre = nuevoUsuario.nombre;
                tblUsuario.apellido = nuevoUsuario.apellido;
                tblUsuario.rol = nuevoUsuario.rol;
                
                return _db.Adicionar(tblUsuario) > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Modificar(Usuario nuevoUsuario)
        {
            try
            {
                Usuario tblUsuario = new Usuario();

                tblUsuario.cuenta = nuevoUsuario.cuenta;
                tblUsuario.clave = nuevoUsuario.clave;
                tblUsuario.nombre = nuevoUsuario.nombre;
                tblUsuario.apellido = nuevoUsuario.apellido;
                tblUsuario.rol = nuevoUsuario.rol;
                                
                return _db.Editar(tblUsuario) > 0;
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

        /*public List<Usuarios> MostrarDatos(string id)
        {
            return _db.Usuarios.Where(x => x.NOMBRE.Contains(id)).ToList();
        }*/

    }
}

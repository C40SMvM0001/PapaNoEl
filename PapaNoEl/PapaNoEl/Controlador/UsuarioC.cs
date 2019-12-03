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

        /*public List<Usuario> MostrarDatos(string id)
        {
            //return _db.Usuarios.Where(x => x.NOMBRE.Contains(id)).ToList();
             return _db.Obtener(id).ToList();
        }*/

        public int Login(string cuenta, string clave)
        {
            try
            {
                // UsuarioDTO usuariodto = new UsuarioDTO();

                var res = _db.ObtenerCuenta(cuenta, clave);
                if (res != null)
                {
                    LoginCache.cuenta = res.cuenta;
                    LoginCache.clave = res.clave;
                    LoginCache.nombre = res.nombre;
                    LoginCache.apellido = res.apellido;
                    LoginCache.rol = res.rol;

                    if (res.rol.Contains("Gerente"))
                        return 1;
                    else
                        return 0;
                }
                return -1;
            }
            catch(Exception e)
            {
                return -1;
            }

        }
    }
}

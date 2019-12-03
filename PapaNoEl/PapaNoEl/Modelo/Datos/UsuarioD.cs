using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using PapaNoEl.Modelo.Entidades;
using System.Data;

namespace PapaNoEl.Modelo.Datos
{
    public class UsuarioD:Query
    {
        private string seleccionarTodo;
        private string seleccionarTodoFiltro;
        private string insertar;
        private string actualizar;
        private string eliminar;
        private string buscarCuenta;

        public UsuarioD()
        {
            seleccionarTodo = "select * from Usuarios";
            insertar = "insert into Usuarios values(@cuenta,@clave,@nombre,@apellido,@rol)";
            actualizar = "update Usuarios set Cuenta=@cuenta,Clave=@clave,Nombre=@nombre,Apellido=@apellido,Rol=@rol where Cuenta=@cuenta";
            eliminar = "delete from Usuarios where Cuenta=@cuenta";
            buscarCuenta = "select * from Usuarios where Cuenta=@cuenta and Clave=@clave";
            seleccionarTodoFiltro = "select * from Usuarios where Cuenta like @clave +'%' ";
        }

        public int Adicionar(Usuario entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cuenta", entidad.cuenta));
            parametros.Add(new SqlParameter("@clave", entidad.clave));
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@apellido", entidad.apellido));            
            parametros.Add(new SqlParameter("@rol", entidad.rol));
            return EjectuarNonQuery(insertar);
        }

        public int Editar(Usuario entidad)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cuenta", entidad.cuenta));
            parametros.Add(new SqlParameter("@clave", entidad.clave));            
            parametros.Add(new SqlParameter("@nombre", entidad.nombre));
            parametros.Add(new SqlParameter("@apellido", entidad.apellido));            
            parametros.Add(new SqlParameter("@tipoUsuario", entidad.rol));
            return EjectuarNonQuery(actualizar);
        }

        public int Eliminar(string id)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cuenta", id));
            return EjectuarNonQuery(eliminar);
        }

        public List<Usuario> ObtenerTodo()
        {
            var tabla = EjecutarLectura(seleccionarTodo);
            var listaUsuarios = new List<Usuario>();
            foreach (DataRow item in tabla.Rows)
            {
                listaUsuarios.Add(new Usuario
                {
                    cuenta = item[0].ToString(),
                    clave = item[1].ToString(),
                    nombre = item[2].ToString(),
                    apellido = item[3].ToString(),                                        
                    rol = item[4].ToString()
                });
            }
            return listaUsuarios;
        }

        public List<Usuario> ObtenerTodo(string clave)
        {
            parametros = new List<SqlParameter>();            
            parametros.Add(new SqlParameter("@clave", clave));

            var tabla = EjecutarLecturaParametros(seleccionarTodoFiltro);
            var listaUsuarios = new List<Usuario>();
            foreach (DataRow item in tabla.Rows)
            {
                listaUsuarios.Add(new Usuario
                {
                    cuenta = item[0].ToString(),
                    clave = item[1].ToString(),
                    nombre = item[2].ToString(),
                    apellido = item[3].ToString(),
                    rol = item[4].ToString()
                });
            }
            return listaUsuarios;
        }

        public Usuario ObtenerCuenta(string cuenta,string clave)
        {
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@cuenta", cuenta));
            parametros.Add(new SqlParameter("@clave", clave));

            var tabla = EjecutarLecturaParametros(buscarCuenta);
            var listaUsuarios = new Usuario();
            
            listaUsuarios.cuenta = tabla.Rows[0].ToString();
            listaUsuarios.clave = tabla.Rows[1].ToString();
            listaUsuarios.nombre = tabla.Rows[2].ToString();
            listaUsuarios.apellido = tabla.Rows[3].ToString();
            listaUsuarios.rol = tabla.Rows[4].ToString();
            
            return listaUsuarios;
        }
    }
}

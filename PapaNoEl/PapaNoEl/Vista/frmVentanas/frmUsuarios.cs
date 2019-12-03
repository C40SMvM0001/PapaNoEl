using PapaNoEl.Controlador;
using PapaNoEl.Modelo.Entidades;
using PapaNoEl.Vista.frmBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PapaNoEl.Vista.frmVentanas
{
    public partial class frmUsuarios : frmGestionar
    {

        UsuarioC _usuarioC = new UsuarioC();
        Usuario _usuario = new Usuario();

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" &&
                txtApellido.Text != "" &&
                txtCuenta.Text != "" &&
                txtClave.Text != "" &&
                cmbRol.SelectedItem.ToString() != "")
            {
                Guardar();
                MessageBox.Show("Guardado");
                Close();
            }
            else
                MessageBox.Show("Faltan datos");
        }

        public void Guardar()
        {
            //if (esNuevo)
            //{
            //    _entidadMarca.IDMARCA = Convert.ToInt32("123");   autonumerico
            _usuario.cuenta = txtCuenta.Text;
            _usuario.clave = txtClave.Text;
            _usuario.nombre = txtNombre.Text;
            _usuario.apellido = txtApellido.Text;
            _usuario.rol = cmbRol.SelectedItem.ToString();
            _usuarioC.GuardarCambios(_usuario);
            //}
            /*else
            {
                _entidadCliente.IDCLIENTE = Convert.ToInt32(_id);
                _entidadCliente.NOMBRE = nOMBRETextBox.Text.ToString();
                _entidadCliente.APELLIDO = aPELLIDOTextBox.Text.ToString();
                _entidadCliente.CI = cITextBox.Text.ToString();

                _metodosCliente.Modificar(_entidadCliente);
            }*/

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        public void CargarDatos() {
            try
            {
                dgvUsuario.DataSource = _usuarioC.MostrarDatos();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

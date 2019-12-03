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

namespace PapaNoEl
{
    public partial class frmLogin : frmVentana
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmPrincipal fm = new frmPrincipal();
            fm.Show();
        }

        private void BrnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void TxtContrasenia_Enter(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "Contraseña")
            {
                txtContrasenia.Text = "";
                txtContrasenia.ForeColor = Color.Black;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }

        private void TxtContrasenia_Leave(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == "")
            {
                txtContrasenia.Text = "Contraseña";
                txtContrasenia.ForeColor = Color.DimGray;
                txtContrasenia.UseSystemPasswordChar = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Runtime.InteropServices;
using PapaNoEl.Vista.frmVentanas;

namespace PapaNoEl.Vista.frmBase
{
    public partial class frmPrincipal : frmVentana
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        #region        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        private void AbrirFormEnPanel(object formulario)
        {
            if (this.pnlPrincipal.Controls.Count > 0)
                this.pnlPrincipal.Controls.RemoveAt(0);
            Form fm = formulario as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.pnlPrincipal.Controls.Add(fm);
            this.pnlPrincipal.Tag = fm;
            fm.Show();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmUsuarios());
        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmClientes());
        }

        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProductos());
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmVentas());
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frnReportes());
        }
    }
}

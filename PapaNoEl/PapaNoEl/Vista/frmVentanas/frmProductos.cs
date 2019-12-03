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
    public partial class frmProductos : frmGestionar
    {
        ProductoC _ProductoC = new ProductoC();
        Producto _Producto = new Producto();
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if (txtDescripcion.Text != "" &&
                cmbTipo.SelectedItem.ToString() != "" &&
                txtPrecio.Text != "" &&
                txtStock.Text != "")
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
//            _Producto.idProducto = Convert.ToInt32(txtIdProducto.Text);
            _Producto.descripcion= txtDescripcion.Text;
            _Producto.tipo = cmbTipo.SelectedItem.ToString();
            _Producto.precio = Convert.ToDecimal(txtPrecio.Text);
            _Producto.stock = Convert.ToInt32(txtStock.Text);
            _ProductoC.GuardarCambios(_Producto);
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvProducto.DataSource = _ProductoC.MostrarDatos(txtBuscar.Text);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            try
            {
                dgvProducto.DataSource = _ProductoC.MostrarDatos();
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}

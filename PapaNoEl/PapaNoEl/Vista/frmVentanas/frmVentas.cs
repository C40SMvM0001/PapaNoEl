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
    public partial class frmVentas : frmTitulo
    {

        VentaC _ventaC = new VentaC();
        ProductoC _productoC = new ProductoC();
        ClienteC _clienteC = new ClienteC();
        DetalleC _detalleC = new DetalleC();

        string _cuenta;
        int _NumBoleta;
        int _idCliente;
        int _idProducto;
        decimal _cantidad;      //verificar decimal
        decimal _subtotal;
        decimal _Total = 0;
        decimal _Efectivo = 0;
        decimal _Cambio = 0;

        public frmVentas()
        {
            InitializeComponent();
        }

        private void LblUsuario_Click(object sender, EventArgs e)
        {

        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = LoginCache.nombre + "  " + LoginCache.apellido;
            lblVenta.Text = _ventaC.ObtenerId().ToString();
            cmbProducto.DataSource = _productoC.MostrarDatos();
            cmbProducto.DisplayMember = "Descripcion";
            cmbProducto.ValueMember = "IdProducto";
            _cuenta = LoginCache.cuenta;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = Convert.ToInt32(cmbProducto.SelectedValue.ToString());
                string producto = (cmbProducto.Text.ToString());
                decimal precio = _productoC.VerPrecio(idProducto);
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                int stock = Convert.ToInt32(_productoC.VerStock(idProducto));
                decimal disponible = stock - cantidad;

                if (disponible <= 0)
                {
                    MessageBox.Show("Cantidad en stock no disponible" + "  Disponibilidad actual = " + stock);
                }
                else
                {
                    decimal subtotal = precio * (decimal)cantidad;
                    _Total += subtotal;
                    dgvVenta.Rows.Add(idProducto.ToString(), producto.ToString(), precio.ToString(), cantidad.ToString(), subtotal.ToString());
                    lblTotal.Text = _Total.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("producto inexistente");
            }
        }

        private void TxtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                _Efectivo = Convert.ToDecimal(txtEfectivo.Text.ToString());
                _Cambio = _Efectivo - _Total;
                lblCambio.Text = _Cambio.ToString();
            }
            if (txtEfectivo.Text == "")
            {
                _Efectivo = 0;
                _Cambio = _Efectivo - _Total;
                lblCambio.Text = _Cambio.ToString();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            //cliente
            Cliente cliente = new Cliente();
            cliente.nombre = txtNombre.Text.ToString();
            cliente.apellido = txtApellido.Text.ToString();
            cliente.ci = txtCi.Text.ToString();
            cliente.tipoempresa = cmbTipoEmpresa.Text.ToString();
            _clienteC.GuardarCambios(cliente);
            _idCliente = _clienteC.VerId();
            //boleta
            Venta venta = new Venta();

            venta.total = Convert.ToDecimal(lblTotal.Text.ToString());
            venta.fecha = DateTime.Now;
            venta.idcliente = _idCliente;
            venta.cuenta = _cuenta;
            _ventaC.GuardarCambios(venta);
            MessageBox.Show("Boleta guardada por " + _cuenta);
            //detalle
            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                Detalle detalle = new Detalle
                {
                    idProducto = Convert.ToInt32(row.Cells[0].Value.ToString()),
                    cantidad = Convert.ToDecimal(row.Cells[3].Value.ToString()),
                    subtotal = Convert.ToDecimal(row.Cells[4].Value.ToString()),
                    idVenta = Convert.ToInt32(lblVenta.Text)
                };
                
                _detalleC.GuardarCambios(detalle);                
            }
        }
    }
}
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class FrmSistemaDeVenta : Form
    {
        /// <summary>
        /// Firma con la que deberán cumplir todos los métodos que signifiquen algún tipo de actualización
        /// de los controles del formulario.
        /// </summary>
        private delegate void Actualizaciones();

        private DataTable tablaFactura;
        private Personas clientes;
        private Personas vendedores;

        /// <summary>
        /// Evento de actualización de controles del formulario.
        /// </summary>
        private event Actualizaciones actualizaciones;

        public FrmSistemaDeVenta()
        {
            InitializeComponent();

            // Instanciamos Vendedores y Clientes
            this.clientes = new Personas();
            this.vendedores = new Personas();

            //Personas - actualizacion
            this.actualizaciones += this.actualizarClientes;
            this.actualizaciones += this.actualizarVendedores;
            this.actualizaciones += this.actualizarCombos;
            this.actualizaciones += this.actualizarFecha;
            this.actualizaciones.Invoke();

            //Frm - Load
            this.Load += this.generarTablaFactura;
            this.Load += this.configurarDataGridView;

        }

        #region Eventos Frm-Load
        /// <summary>
        /// Genera la Tabla Factura, donde se cargaran los productos de la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void generarTablaFactura(object sender, EventArgs args)
        {
            this.tablaFactura = new DataTable("Nueva Factura");

            this.tablaFactura.Columns.Add("Cantidad");
            this.tablaFactura.Columns[0].ReadOnly = false;

            this.tablaFactura.Columns.Add("Código Producto");
            this.tablaFactura.Columns[1].ReadOnly = true;

            this.tablaFactura.Columns.Add("Nombre");
            this.tablaFactura.Columns[2].ReadOnly = true;

            this.tablaFactura.Columns.Add("Precio Unitario");
            this.tablaFactura.Columns[3].ReadOnly = true;

            this.tablaFactura.Columns.Add("Precio Total (Unitario * Cantidad)");
            this.tablaFactura.Columns[4].ReadOnly = true;
        }

        /// <summary>
        /// Configura el ancho de las columnas de la DataGridView donde se mostrará
        /// la tabla factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void configurarDataGridView(object sender, EventArgs args)
        {
            this.dataGridViewTablaFactura.DataSource = this.tablaFactura;

            int cantidadColumnas = this.dataGridViewTablaFactura.Columns.Count;
            int tamanio = this.dataGridViewTablaFactura.Width;
            int tamanioColumnas = (tamanio / cantidadColumnas) - 1;

            foreach (DataGridViewColumn columna in this.dataGridViewTablaFactura.Columns)
                columna.Width = tamanioColumnas;
        }
        #endregion

        #region Actualizaciones
        /// <summary>
        /// Actualizará la variable "clientes" con la Base de Datos.
        /// </summary>
        private void actualizarClientes()
        {
            this.clientes.actualizarMedianteBD("Clientes");
        }
        
        /// <summary>
        /// Actualizará la variables "vendedores" con la Base de Datos.
        /// </summary>
        private void actualizarVendedores()
        {
            this.vendedores.actualizarMedianteBD("Vendedores");
        }
        
        /// <summary>
        /// Actualizará los ComboBox del Form con los respectivos datos correspondientes.
        /// </summary>
        private void actualizarCombos ()
        {
            this.comboBoxCodCliente.DataSource = this.clientes.obtenerDNIs();
            this.comboBoxCodVendedor.DataSource = this.vendedores.obtenerDNIs();
        }
        
        /// <summary>
        /// Actualizará el "textBoxFecha" con la Fecha y Hora actuales.
        /// </summary>
        private void actualizarFecha ()
        {
            this.textBoxFecha.Text = DateTime.Now.ToString("g");
        }
        #endregion

        #region Barra de Herramientas
        private void toolStripMenuItemStock_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemVendedores_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemClientes_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region ComboBoxes
        /// <summary>
        /// Actualizará el nombre del Cliente en el Form según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCodCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxNombreCliente.Text = this.clientes.obtenerNombre( ((int)this.comboBoxCodCliente.SelectedItem) );
        }

        /// <summary>
        /// Actualizará el nombre del Vendedor en el Form según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCodVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBoxNombreVendedor.Text = this.vendedores.obtenerNombre( ((int)this.comboBoxCodVendedor.SelectedItem) );
        }
        #endregion

    }
}

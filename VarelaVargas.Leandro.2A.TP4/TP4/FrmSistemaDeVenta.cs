using Entidades;
using ExcepcionesEntidades;
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

/*
 * Clase 15: Exception. Listo
 * Clase 16: Test Unitarios.
 * Clase 17: Tipos Genéricos. Listo
 * Clase 18: Interfaces. Listo
 * Clase 19: Archivos y Serialización.
 * Clase 21 y 22: SQL y BD. Listo
 * Clase 23: Hilos.
 * Clase 24: Eventos. Listo
 * Clase 25: Métodos de Extensión. 
 */

namespace TP4
{
    public partial class FrmSistemaDeVenta : Form
    {
        /// <summary>
        /// Firma con la que deberán cumplir todos los métodos que signifiquen algún tipo de actualización
        /// de los controles del formulario.
        /// </summary>
        private delegate void Actualizaciones();

        /// <summary>
        /// Evento de actualización de controles del formulario.
        /// </summary>
        private event Actualizaciones actualizaciones;
        private DataTable tablaFactura;
        private Personas clientes;
        private Personas vendedores;
        private Productos<Comida> productosDeComida;
        private Productos<Limpieza> productosDeLimpieza;


        public FrmSistemaDeVenta()
        {
            InitializeComponent();

            // Instanciamos Vendedores y Clientes
            this.clientes = new Personas();
            this.vendedores = new Personas();

            // Instanciamos ProductosDeComida y ProductosDeLimpieza
            this.productosDeComida = new Productos<Comida>();
            this.productosDeLimpieza = new Productos<Limpieza>();

            //Personas - actualizacion
            this.actualizaciones += this.actualizarClientes;
            this.actualizaciones += this.actualizarVendedores;
            this.actualizaciones += this.actualizarProductos;
            this.actualizaciones += this.actualizarCombos;
            this.actualizaciones += this.actualizarFecha;
            this.actualizaciones.Invoke();

            //Frm - Load
            this.Load += this.inicializarTextBoxTotal;
            this.Load += this.generarTablaFactura;
            this.Load += this.configurarDataGridView;

        }

        #region Eventos Frm-Load
        /// <summary>
        /// Inicializa el texto TextBoxTotal como "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarTextBoxTotal(object sender, EventArgs args)
        {
            this.textBoxTotal.Text = "0";
        }

        /// <summary>
        /// Genera la Tabla Factura, donde se cargaran los productos de la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void generarTablaFactura(object sender, EventArgs args)
        {
            this.tablaFactura = new DataTable("Nueva Factura");
            this.tablaFactura.ColumnChanged += TablaFactura_ColumnChanged;

            this.tablaFactura.Columns.Add("Cantidad");
            this.tablaFactura.Columns[0].DataType = typeof(int);
            this.tablaFactura.Columns[0].ReadOnly = false;

            this.tablaFactura.Columns.Add("Código Producto");
            this.tablaFactura.Columns[1].ReadOnly = true;

            this.tablaFactura.Columns.Add("Nombre");
            this.tablaFactura.Columns[2].ReadOnly = true;

            this.tablaFactura.Columns.Add("Precio Unitario");
            this.tablaFactura.Columns[3].ReadOnly = true;

            this.tablaFactura.Columns.Add("Tipo");
            this.tablaFactura.Columns[4].ReadOnly = true;

            this.tablaFactura.Columns.Add("Precio Total (Unitario * Cantidad)");
            this.tablaFactura.Columns[5].ReadOnly = false;
        }

        /// <summary>
        /// Actualizará el precio Total y el Precio * Cantidad de la factura en el Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablaFactura_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if ( e.Column.ColumnName.Equals("Cantidad") )
            {
                float precioTotal = float.Parse(this.textBoxTotal.Text);
                int Cantidad = int.Parse(e.Row[0].ToString());
                float precio = float.Parse(e.Row[3].ToString());

                precioTotal += (precio * Cantidad);

                e.Row[5] = precio * Cantidad;
                this.textBoxTotal.Text = precioTotal.ToString();

                this.tablaFactura.AcceptChanges();
            }
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
            this.dataGridViewTablaFactura.AllowUserToAddRows = false;
            this.dataGridViewTablaFactura.MultiSelect = true;
            
            int cantidadColumnas = this.dataGridViewTablaFactura.Columns.Count;
            int tamanio = this.dataGridViewTablaFactura.Width;
            int tamanioColumnas = (tamanio / cantidadColumnas) - 9;

            foreach (DataGridViewColumn columna in this.dataGridViewTablaFactura.Columns)
                columna.Width = tamanioColumnas;
        }
        #endregion

        #region Actualizaciones
        /// <summary>
        /// Actualizará las variables de los productos con la Base de Datos.
        /// </summary>
        private void actualizarProductos()
        {
            string Tabla = "Productos";
            try
            {
                this.productosDeComida.actualizarMedianteBD(Tabla);
                this.productosDeLimpieza.actualizarMedianteBD(Tabla);
            }
            catch (ExceptionErrorActualizacionProductos ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Actualizará la variable "clientes" con la Base de Datos.
        /// </summary>
        private void actualizarClientes()
        {
            try
            {
                this.clientes.actualizarMedianteBD("Clientes");
            }
            catch (ExceptionErrorActualizacionPersonas ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.InnerException.Message);
            }
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
            List<int> idsProductos = new List<int>(this.productosDeComida.obtenerIDs());
            idsProductos.AddRange(this.productosDeLimpieza.obtenerIDs());

            this.comboBoxCodCliente.DataSource = this.clientes.obtenerDNIs();
            this.comboBoxCodVendedor.DataSource = this.vendedores.obtenerDNIs();
            this.comboBoxCodProducto.DataSource = idsProductos;
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

        /// <summary>
        /// Actualizará el nombre del Producto en el Form según corresponda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCodProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreProd = this.productosDeComida.obtenerNombre((int)this.comboBoxCodProducto.SelectedItem);

            if (nombreProd is null)
                nombreProd = this.productosDeLimpieza.obtenerNombre((int)this.comboBoxCodProducto.SelectedItem);

            this.textBoxNombreProducto.Text = nombreProd;
        }
        #endregion

        #region Botones
        /// <summary>
        /// Agregará el producto seleccionado a la factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Producto prod = this.productosDeComida.obtenerProducto((int)this.comboBoxCodProducto.SelectedItem);

            if (prod is null)
                prod = this.productosDeLimpieza.obtenerProducto((int)this.comboBoxCodProducto.SelectedItem);

            this.tablaFactura.Rows.Add(new object[] { 0, prod.ID, prod.Nombre, prod.Precio, prod.Tipo, 0 });
            this.tablaFactura.AcceptChanges();
        }

        /// <summary>
        /// Quitará las filas seleccionadas de la factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow selectedRow in this.dataGridViewTablaFactura.SelectedRows)
                this.tablaFactura.Rows[selectedRow.Index].Delete();
            
            this.tablaFactura.AcceptChanges();
        }

        private void btnConfirmarFactura_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}

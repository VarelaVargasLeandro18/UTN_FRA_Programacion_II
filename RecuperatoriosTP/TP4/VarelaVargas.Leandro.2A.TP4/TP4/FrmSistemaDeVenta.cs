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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    /// <summary>
    /// Clase 24. Eventos.
    /// </summary>
    public partial class FrmSistemaDeVenta : Form
    {
        /// <summary>
        /// Clase 24. Eventos.
        /// Firma con la que deberán cumplir todos los métodos que signifiquen algún tipo de actualización
        /// de los controles del formulario.
        /// </summary>
        private delegate void Actualizaciones();

        /// <summary>
        /// Clase 24. Eventos.
        /// Evento de actualización de controles del formulario.
        /// </summary>
        private event Actualizaciones actualizaciones;
        private DataTable tablaFactura;
        private Personas clientes;
        private Personas vendedores;
        private Productos<Comida> productosDeComida;
        private Productos<Limpieza> productosDeLimpieza;
        private Productos<Producto> productosSeleccionados;

        private FormSQL frmSQL;

        public FrmSistemaDeVenta()
        {
            InitializeComponent();

            // Instanciamos Vendedores y Clientes
            this.clientes = new Personas();
            this.vendedores = new Personas();

            // Instanciamos ProductosDeComida y ProductosDeLimpieza
            this.productosDeComida = new Productos<Comida>();
            this.productosDeLimpieza = new Productos<Limpieza>();

            //Frm - Load
            this.Load += this.generarTablaFactura;
            this.Load += this.configurarDataGridView;

            //Personas - actualizacion
            this.actualizaciones += this.actualizarTipoFactura;
            this.actualizaciones += this.actualizarClientes;
            this.actualizaciones += this.actualizarVendedores;
            this.actualizaciones += this.actualizarProductos;
            this.actualizaciones += this.actualizarCombos;
            this.actualizaciones += this.actualizarFecha;
            this.actualizaciones += this.actualizarPrecio;
            this.actualizaciones += this.actualizarProductoSeleccionados;
            this.actualizaciones.Invoke();
            this.actualizaciones += this.actualizarTabla;

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
            this.tablaFactura.ColumnChanged += TablaFactura_ColumnChanged;
            this.tablaFactura.RowDeleting += TablaFactura_RowDeleting;

            this.tablaFactura.Columns.Add("Cantidad");

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
        /// Configura el ancho de las columnas de la DataGridView donde se mostrará
        /// la tabla factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void configurarDataGridView(object sender, EventArgs args)
        {
            this.dataGridViewTablaFactura.DataSource = this.tablaFactura;
            this.dataGridViewTablaFactura.AllowUserToAddRows = false;

            this.dataGridViewTablaFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dataGridViewTablaFactura.DataError += DataGridViewTablaFactura_DataError;
        }

        /// <summary>
        /// Mostrará un MessageBox en caso de que haya algún error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewTablaFactura_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                throw e.Exception;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error: {ex.Message}\nStackTrace: {ex.StackTrace}", "ERROR DEL DATAGRIDVIEW", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cambios en Tabla
        /// <summary>
        /// Restará el precio de la fila removida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablaFactura_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            String strCantidad = e.Row[0].ToString();
            string textoPrecioTotal = this.textBoxTotal.Text.Replace('$', '0');
            int Cantidad;
            float precioTotal;
            float precio;

            if (this.tablaFactura.Rows.Count > 1)
            {
                if (int.TryParse(strCantidad, out Cantidad)
                    && float.TryParse(textoPrecioTotal, out precioTotal)
                    && float.TryParse(e.Row[3].ToString(), out precio))
                {
                    precioTotal -= (precio * Cantidad);

                    e.Row[5] = precio * Cantidad;
                    this.textBoxTotal.Text = "$" + precioTotal.ToString();

                    this.tablaFactura.AcceptChanges();
                }
            }
            else
                this.textBoxTotal.Text = "$0";

        }

        /// <summary>
        /// Actualizará el precio Total y el Precio * Cantidad de la factura en el Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TablaFactura_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            string strCantidad = e.Row[0].ToString();
            string strPrecio = e.Row[3].ToString();
            string strCodProd = e.Row[1].ToString();
            string textoPrecioTotal = this.textBoxTotal.Text.Replace('$', '0');
            int Cantidad;
            float precioTotal;
            float precio;
            int codProd;

            if ( e.Column.ColumnName.Equals("Cantidad"))
            {
                if ( int.TryParse(strCantidad, out Cantidad) 
                    && float.TryParse(textoPrecioTotal, out precioTotal)
                    && float.TryParse(strPrecio, out precio)
                    && int.TryParse(strCodProd, out codProd))
                {
                    precioTotal += (precio * Cantidad);

                    e.Row[5] = (precio * Cantidad).ToString("0.00");
                    this.textBoxTotal.Text = "$" + precioTotal.ToString("00.00");

                    this.tablaFactura.AcceptChanges();
                    this.productosSeleccionados.obtenerProducto(codProd).Cantidad = Cantidad;
                }
                else
                {
                    e.Row[0] = 0;
                }
            }
        }
        #endregion

        #region Actualizaciones
        /// <summary>
        /// Clase 24. Eventos.
        /// Permite que se invoquen actualizaciones desde otra parte.
        /// </summary>
        public void invocarActualizaciones()
        {
            this.actualizaciones.Invoke();
        }

        /// <summary>
        /// Clase 24. Eventos.
        /// Seteará el Combo 'TipoFactura' a su valor por defecto.
        /// </summary>
        private void actualizarTipoFactura()
        {
            this.comboBoxTipoFactura.SelectedIndex = 0;
        }

        /// <summary>
        /// Clase 24. Eventos.
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
        /// Clase 24. Eventos.
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
        /// Clase 24. Eventos.
        /// Actualizará la variables "vendedores" con la Base de Datos.
        /// </summary>
        private void actualizarVendedores()
        {
            try
            {
                this.vendedores.actualizarMedianteBD("Vendedores");
                this.vendedores.obtenerDNIs();
            }
            catch (ExceptionErrorActualizacionPersonas ex)
            {
                MessageBox.Show(ex.Message + " - " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Clase 24. Eventos.
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
        /// Clase 24. Eventos.
        /// Actualizará el "textBoxFecha" con la Fecha y Hora actuales.
        /// </summary>
        private void actualizarFecha ()
        {
            this.textBoxFecha.Text = DateTime.Now.ToString("d");
        }

        /// <summary>
        /// Clase 24. Eventos.
        /// Actualizará el "textBoxTotal" a 0.
        /// </summary>
        private void actualizarPrecio()
        {
            this.textBoxTotal.Text = "0";
        }

        /// <summary>
        /// Clase 24. Eventos.
        /// Actualizará la lista de productos seleccionados.
        /// </summary>
        private void actualizarProductoSeleccionados()
        {
            this.productosSeleccionados = new Productos<Producto>();
        }

        /// <summary>
        /// Clase 24. Eventos.
        /// Actualizará la tabla a su valor vacío por defecto.
        /// </summary>
        private void actualizarTabla()
        {
            this.tablaFactura.Clear();
            this.tablaFactura.AcceptChanges();
        }
        #endregion

        #region Barra de Herramientas
        /// <summary>
        /// Al hacer click en el botón Stock de la barra de herramientas se abrirá un Form para
        /// manipular su tabla en la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemStock_Click(object sender, EventArgs e)
        {
            if ( this.frmSQL is null || this.frmSQL.IsDisposed )
            {
                this.frmSQL = new FormSQL(EFormsSQL.Stock);
                this.frmSQL.Show(this);
            }
        }

        /// <summary>
        /// Al hacer click en el botón Vendedores de la barra de herramientas se abrirá un Form para
        /// manipular su tabla en la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemVendedores_Click(object sender, EventArgs e)
        {
            if (this.frmSQL is null || this.frmSQL.IsDisposed)
            {
                this.frmSQL = new FormSQL(EFormsSQL.Vendedores);
                this.frmSQL.Show(this);
            }
        }

        /// <summary>
        /// Al hacer click en el botón Vendedores de la barra de herramientas se abrirá un Form para
        /// manipular su tabla en la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemClientes_Click(object sender, EventArgs e)
        {
            if (this.frmSQL is null || this.frmSQL.IsDisposed)
            {
                this.frmSQL = new FormSQL(EFormsSQL.Clientes);
                this.frmSQL.Show(this);
            }
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

            if (this.productosSeleccionados + prod)
            {
                this.tablaFactura.Rows.Add(new object[] { 0, prod.ID, prod.Nombre, prod.Precio, prod.Tipo, 0 });
                this.tablaFactura.AcceptChanges();
            }
            
        }

        /// <summary>
        /// Quitará las filas seleccionadas de la factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if ( this.dataGridViewTablaFactura.SelectedRows.Count > 0 )
            {
                foreach (DataGridViewRow selectedRow in this.dataGridViewTablaFactura.SelectedRows)
                {
                    if ( selectedRow.Index > -1 )
                        this.tablaFactura.Rows[selectedRow.Index].Delete();
                }

                this.tablaFactura.AcceptChanges();
            }
        }
        
        /// <summary>
        /// Guardará como un Txt el archivo factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmarFactura_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            int DNICliente = (int)this.comboBoxCodCliente.SelectedItem;
            int DNIVendedor = (int)this.comboBoxCodVendedor.SelectedItem;
            char tipoFactura = char.Parse((string)this.comboBoxTipoFactura.SelectedItem);

            factura.Cliente = new Cliente(this.clientes.obtenerPersona(DNICliente));
            factura.Vendedor = new Vendedor(this.vendedores.obtenerPersona(DNIVendedor));
            factura.TipoFactura = tipoFactura;
            factura.Productos = this.productosSeleccionados;

            DialogResult rsGuardar = MessageBox.Show(factura.CustomPrintFactura(), "¿Desea guardar la factura?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            DialogResult rsActualizar;

            if (rsGuardar == DialogResult.Yes)
            {
                factura.GuardarComoTxt();
                factura.GuardarComoXml();
                this.actualizaciones.Invoke();
            }
            else
            {
                rsActualizar = MessageBox.Show("¿Quiere empezar otra factura? Los datos ingresados volverán a su estado original", "Actualizar factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rsActualizar == DialogResult.Yes)
                    this.actualizaciones.Invoke();
            }

        }
        #endregion
    }
}

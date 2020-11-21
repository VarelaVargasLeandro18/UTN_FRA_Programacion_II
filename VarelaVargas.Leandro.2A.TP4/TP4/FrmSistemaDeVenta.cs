using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP4
{
    public partial class FrmSistemaDeVenta : Form
    {
        private DataTable tablaFactura;

        public FrmSistemaDeVenta()
        {
            InitializeComponent();

            //Frm - Load
            this.Load += this.generarTablaFactura;
            this.Load += this.configurarDataGridView;

            //

        }

        #region Eventos Frm-Load
        /// <summary>
        /// Genera la Tabla Factura, donde se cargaran los productos de la venta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void generarTablaFactura (object sender, EventArgs args)
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
        public void configurarDataGridView (object sender, EventArgs args)
        {
            this.dataGridViewTablaFactura.DataSource = this.tablaFactura;
        
            int cantidadColumnas = this.dataGridViewTablaFactura.Columns.Count;
            int tamanio = this.dataGridViewTablaFactura.Width;
            int tamanioColumnas = (tamanio / cantidadColumnas) - 1;

            foreach (DataGridViewColumn columna in this.dataGridViewTablaFactura.Columns)
                columna.Width = tamanioColumnas;
        }
        #endregion



    }
}

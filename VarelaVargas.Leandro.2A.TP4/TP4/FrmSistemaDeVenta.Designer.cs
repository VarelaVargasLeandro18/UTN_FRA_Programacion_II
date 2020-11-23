using Entidades;

namespace TP4
{
    partial class FrmSistemaDeVenta
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripBarraDeHerramientasPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemStock = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemVendedores = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTipoFactura = new System.Windows.Forms.Label();
            this.comboBoxTipoFactura = new System.Windows.Forms.ComboBox();
            this.lblDNIVendedor = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.comboBoxCodVendedor = new System.Windows.Forms.ComboBox();
            this.lblDNICliente = new System.Windows.Forms.Label();
            this.comboBoxCodCliente = new System.Windows.Forms.ComboBox();
            this.textBoxNombreCliente = new System.Windows.Forms.TextBox();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblDNIProducto = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridViewTablaFactura = new System.Windows.Forms.DataGridView();
            this.comboBoxCodProducto = new System.Windows.Forms.ComboBox();
            this.btnConfirmarFactura = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelNombreVendedor = new System.Windows.Forms.Label();
            this.textBoxNombreVendedor = new System.Windows.Forms.TextBox();
            this.labelNombreProducto = new System.Windows.Forms.Label();
            this.textBoxNombreProducto = new System.Windows.Forms.TextBox();
            this.menuStripBarraDeHerramientasPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripBarraDeHerramientasPrincipal
            // 
            this.menuStripBarraDeHerramientasPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripBarraDeHerramientasPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStock,
            this.toolStripMenuItemVendedores,
            this.toolStripMenuItemClientes});
            this.menuStripBarraDeHerramientasPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuStripBarraDeHerramientasPrincipal.Name = "menuStripBarraDeHerramientasPrincipal";
            this.menuStripBarraDeHerramientasPrincipal.Size = new System.Drawing.Size(882, 28);
            this.menuStripBarraDeHerramientasPrincipal.TabIndex = 0;
            // 
            // toolStripMenuItemStock
            // 
            this.toolStripMenuItemStock.Name = "toolStripMenuItemStock";
            this.toolStripMenuItemStock.Size = new System.Drawing.Size(59, 24);
            this.toolStripMenuItemStock.Text = "Stock";
            this.toolStripMenuItemStock.Click += new System.EventHandler(this.toolStripMenuItemStock_Click);
            // 
            // toolStripMenuItemVendedores
            // 
            this.toolStripMenuItemVendedores.Name = "toolStripMenuItemVendedores";
            this.toolStripMenuItemVendedores.Size = new System.Drawing.Size(101, 24);
            this.toolStripMenuItemVendedores.Text = "Vendedores";
            this.toolStripMenuItemVendedores.Click += new System.EventHandler(this.toolStripMenuItemVendedores_Click);
            // 
            // toolStripMenuItemClientes
            // 
            this.toolStripMenuItemClientes.Name = "toolStripMenuItemClientes";
            this.toolStripMenuItemClientes.Size = new System.Drawing.Size(75, 24);
            this.toolStripMenuItemClientes.Text = "Clientes";
            this.toolStripMenuItemClientes.Click += new System.EventHandler(this.toolStripMenuItemClientes_Click);
            // 
            // lblTipoFactura
            // 
            this.lblTipoFactura.AutoSize = true;
            this.lblTipoFactura.Location = new System.Drawing.Point(14, 33);
            this.lblTipoFactura.Margin = new System.Windows.Forms.Padding(5);
            this.lblTipoFactura.Name = "lblTipoFactura";
            this.lblTipoFactura.Size = new System.Drawing.Size(108, 17);
            this.lblTipoFactura.TabIndex = 1;
            this.lblTipoFactura.Text = "Tipo de Factura";
            // 
            // comboBoxTipoFactura
            // 
            this.comboBoxTipoFactura.AutoCompleteCustomSource.AddRange(new string[] {
            "A",
            "B"});
            this.comboBoxTipoFactura.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTipoFactura.DisplayMember = "0";
            this.comboBoxTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoFactura.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxTipoFactura.Items.AddRange(new object[] {
            "A",
            "B"});
            this.comboBoxTipoFactura.Location = new System.Drawing.Point(132, 33);
            this.comboBoxTipoFactura.Margin = new System.Windows.Forms.Padding(5);
            this.comboBoxTipoFactura.Name = "comboBoxTipoFactura";
            this.comboBoxTipoFactura.Size = new System.Drawing.Size(56, 24);
            this.comboBoxTipoFactura.TabIndex = 2;
            // 
            // lblDNIVendedor
            // 
            this.lblDNIVendedor.AutoSize = true;
            this.lblDNIVendedor.Location = new System.Drawing.Point(320, 33);
            this.lblDNIVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.lblDNIVendedor.Name = "lblDNIVendedor";
            this.lblDNIVendedor.Size = new System.Drawing.Size(117, 17);
            this.lblDNIVendedor.TabIndex = 3;
            this.lblDNIVendedor.Text = "DNI de Vendedor";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(645, 91);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.Location = new System.Drawing.Point(698, 89);
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.ReadOnly = true;
            this.textBoxFecha.Size = new System.Drawing.Size(146, 22);
            this.textBoxFecha.TabIndex = 6;
            // 
            // comboBoxCodVendedor
            // 
            this.comboBoxCodVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodVendedor.FormattingEnabled = true;
            this.comboBoxCodVendedor.Location = new System.Drawing.Point(457, 30);
            this.comboBoxCodVendedor.Name = "comboBoxCodVendedor";
            this.comboBoxCodVendedor.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCodVendedor.TabIndex = 7;
            this.comboBoxCodVendedor.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodVendedor_SelectedIndexChanged);
            // 
            // lblDNICliente
            // 
            this.lblDNICliente.AutoSize = true;
            this.lblDNICliente.Location = new System.Drawing.Point(17, 88);
            this.lblDNICliente.Name = "lblDNICliente";
            this.lblDNICliente.Size = new System.Drawing.Size(98, 17);
            this.lblDNICliente.TabIndex = 8;
            this.lblDNICliente.Text = "DNI de Cliente";
            // 
            // comboBoxCodCliente
            // 
            this.comboBoxCodCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodCliente.FormattingEnabled = true;
            this.comboBoxCodCliente.Location = new System.Drawing.Point(142, 88);
            this.comboBoxCodCliente.Name = "comboBoxCodCliente";
            this.comboBoxCodCliente.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCodCliente.TabIndex = 9;
            this.comboBoxCodCliente.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodCliente_SelectedIndexChanged);
            // 
            // textBoxNombreCliente
            // 
            this.textBoxNombreCliente.Location = new System.Drawing.Point(384, 90);
            this.textBoxNombreCliente.Name = "textBoxNombreCliente";
            this.textBoxNombreCliente.ReadOnly = true;
            this.textBoxNombreCliente.Size = new System.Drawing.Size(220, 22);
            this.textBoxNombreCliente.TabIndex = 12;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(320, 88);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(58, 17);
            this.lblNombreCliente.TabIndex = 15;
            this.lblNombreCliente.Text = "Nombre";
            // 
            // lblDNIProducto
            // 
            this.lblDNIProducto.AutoSize = true;
            this.lblDNIProducto.Location = new System.Drawing.Point(17, 143);
            this.lblDNIProducto.Name = "lblDNIProducto";
            this.lblDNIProducto.Size = new System.Drawing.Size(133, 17);
            this.lblDNIProducto.TabIndex = 17;
            this.lblDNIProducto.Text = "Código de Producto";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(793, 143);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(5);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(75, 30);
            this.btnQuitar.TabIndex = 18;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(708, 143);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(5);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 30);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dataGridViewTablaFactura
            // 
            this.dataGridViewTablaFactura.AllowUserToAddRows = false;
            this.dataGridViewTablaFactura.AllowUserToDeleteRows = false;
            this.dataGridViewTablaFactura.AllowUserToResizeColumns = false;
            this.dataGridViewTablaFactura.AllowUserToResizeRows = false;
            this.dataGridViewTablaFactura.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewTablaFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTablaFactura.Location = new System.Drawing.Point(13, 191);
            this.dataGridViewTablaFactura.MultiSelect = false;
            this.dataGridViewTablaFactura.Name = "dataGridViewTablaFactura";
            this.dataGridViewTablaFactura.RowHeadersWidth = 51;
            this.dataGridViewTablaFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTablaFactura.RowTemplate.Height = 24;
            this.dataGridViewTablaFactura.Size = new System.Drawing.Size(857, 300);
            this.dataGridViewTablaFactura.TabIndex = 20;
            // 
            // comboBoxCodProducto
            // 
            this.comboBoxCodProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodProducto.FormattingEnabled = true;
            this.comboBoxCodProducto.Location = new System.Drawing.Point(157, 143);
            this.comboBoxCodProducto.Name = "comboBoxCodProducto";
            this.comboBoxCodProducto.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCodProducto.TabIndex = 21;
            this.comboBoxCodProducto.SelectedIndexChanged += new System.EventHandler(this.comboBoxCodProducto_SelectedIndexChanged);
            // 
            // btnConfirmarFactura
            // 
            this.btnConfirmarFactura.Location = new System.Drawing.Point(12, 497);
            this.btnConfirmarFactura.Name = "btnConfirmarFactura";
            this.btnConfirmarFactura.Size = new System.Drawing.Size(87, 32);
            this.btnConfirmarFactura.TabIndex = 22;
            this.btnConfirmarFactura.Text = "Confirmar Factura";
            this.btnConfirmarFactura.UseVisualStyleBackColor = true;
            this.btnConfirmarFactura.Click += new System.EventHandler(this.btnConfirmarFactura_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(717, 497);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(40, 17);
            this.lblTotal.TabIndex = 23;
            this.lblTotal.Text = "Total";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(768, 497);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(100, 22);
            this.textBoxTotal.TabIndex = 24;
            this.textBoxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNombreVendedor
            // 
            this.labelNombreVendedor.AutoSize = true;
            this.labelNombreVendedor.Location = new System.Drawing.Point(584, 37);
            this.labelNombreVendedor.Name = "labelNombreVendedor";
            this.labelNombreVendedor.Size = new System.Drawing.Size(58, 17);
            this.labelNombreVendedor.TabIndex = 26;
            this.labelNombreVendedor.Text = "Nombre";
            // 
            // textBoxNombreVendedor
            // 
            this.textBoxNombreVendedor.Location = new System.Drawing.Point(648, 37);
            this.textBoxNombreVendedor.Name = "textBoxNombreVendedor";
            this.textBoxNombreVendedor.ReadOnly = true;
            this.textBoxNombreVendedor.Size = new System.Drawing.Size(220, 22);
            this.textBoxNombreVendedor.TabIndex = 25;
            // 
            // labelNombreProducto
            // 
            this.labelNombreProducto.AutoSize = true;
            this.labelNombreProducto.Location = new System.Drawing.Point(320, 143);
            this.labelNombreProducto.Name = "labelNombreProducto";
            this.labelNombreProducto.Size = new System.Drawing.Size(58, 17);
            this.labelNombreProducto.TabIndex = 27;
            this.labelNombreProducto.Text = "Nombre";
            // 
            // textBoxNombreProducto
            // 
            this.textBoxNombreProducto.Location = new System.Drawing.Point(384, 145);
            this.textBoxNombreProducto.Name = "textBoxNombreProducto";
            this.textBoxNombreProducto.ReadOnly = true;
            this.textBoxNombreProducto.Size = new System.Drawing.Size(220, 22);
            this.textBoxNombreProducto.TabIndex = 28;
            // 
            // FrmSistemaDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 541);
            this.Controls.Add(this.textBoxNombreProducto);
            this.Controls.Add(this.labelNombreProducto);
            this.Controls.Add(this.labelNombreVendedor);
            this.Controls.Add(this.textBoxNombreVendedor);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnConfirmarFactura);
            this.Controls.Add(this.comboBoxCodProducto);
            this.Controls.Add(this.dataGridViewTablaFactura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblDNIProducto);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.textBoxNombreCliente);
            this.Controls.Add(this.comboBoxCodCliente);
            this.Controls.Add(this.lblDNICliente);
            this.Controls.Add(this.comboBoxCodVendedor);
            this.Controls.Add(this.textBoxFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblDNIVendedor);
            this.Controls.Add(this.comboBoxTipoFactura);
            this.Controls.Add(this.lblTipoFactura);
            this.Controls.Add(this.menuStripBarraDeHerramientasPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStripBarraDeHerramientasPrincipal;
            this.MaximizeBox = false;
            this.Name = "FrmSistemaDeVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIstema De Venta";
            this.menuStripBarraDeHerramientasPrincipal.ResumeLayout(false);
            this.menuStripBarraDeHerramientasPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTablaFactura)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripBarraDeHerramientasPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStock;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemVendedores;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClientes;
        private System.Windows.Forms.Label lblTipoFactura;
        private System.Windows.Forms.ComboBox comboBoxTipoFactura;
        private System.Windows.Forms.Label lblDNIVendedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.ComboBox comboBoxCodVendedor;
        private System.Windows.Forms.Label lblDNICliente;
        private System.Windows.Forms.ComboBox comboBoxCodCliente;
        private System.Windows.Forms.TextBox textBoxNombreCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblDNIProducto;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridViewTablaFactura;
        private System.Windows.Forms.ComboBox comboBoxCodProducto;
        private System.Windows.Forms.Button btnConfirmarFactura;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelNombreVendedor;
        private System.Windows.Forms.TextBox textBoxNombreVendedor;
        private System.Windows.Forms.Label labelNombreProducto;
        private System.Windows.Forms.TextBox textBoxNombreProducto;
    }
}


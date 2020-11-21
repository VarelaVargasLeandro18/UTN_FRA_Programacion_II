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
            this.lblCodVendedor = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxCodVendedor = new System.Windows.Forms.ComboBox();
            this.lblCodCliente = new System.Windows.Forms.Label();
            this.comboBoxCodCliente = new System.Windows.Forms.ComboBox();
            this.lblDNI = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxDireccion = new System.Windows.Forms.TextBox();
            this.textBoxCodProducto = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCodProducto = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dataGridViewTablaFactura = new System.Windows.Forms.DataGridView();
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
            this.menuStripBarraDeHerramientasPrincipal.Size = new System.Drawing.Size(882, 30);
            this.menuStripBarraDeHerramientasPrincipal.TabIndex = 0;
            // 
            // toolStripMenuItemStock
            // 
            this.toolStripMenuItemStock.Name = "toolStripMenuItemStock";
            this.toolStripMenuItemStock.Size = new System.Drawing.Size(59, 24);
            this.toolStripMenuItemStock.Text = "Stock";
            // 
            // toolStripMenuItemVendedores
            // 
            this.toolStripMenuItemVendedores.Name = "toolStripMenuItemVendedores";
            this.toolStripMenuItemVendedores.Size = new System.Drawing.Size(101, 24);
            this.toolStripMenuItemVendedores.Text = "Vendedores";
            // 
            // toolStripMenuItemClientes
            // 
            this.toolStripMenuItemClientes.Name = "toolStripMenuItemClientes";
            this.toolStripMenuItemClientes.Size = new System.Drawing.Size(75, 24);
            this.toolStripMenuItemClientes.Text = "Clientes";
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
            // lblCodVendedor
            // 
            this.lblCodVendedor.AutoSize = true;
            this.lblCodVendedor.Location = new System.Drawing.Point(320, 33);
            this.lblCodVendedor.Margin = new System.Windows.Forms.Padding(5);
            this.lblCodVendedor.Name = "lblCodVendedor";
            this.lblCodVendedor.Size = new System.Drawing.Size(138, 17);
            this.lblCodVendedor.TabIndex = 3;
            this.lblCodVendedor.Text = "Código de Vendedor";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(717, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 17);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(770, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 6;
            // 
            // comboBoxCodVendedor
            // 
            this.comboBoxCodVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodVendedor.FormattingEnabled = true;
            this.comboBoxCodVendedor.Location = new System.Drawing.Point(457, 30);
            this.comboBoxCodVendedor.Name = "comboBoxCodVendedor";
            this.comboBoxCodVendedor.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCodVendedor.TabIndex = 7;
            // 
            // lblCodCliente
            // 
            this.lblCodCliente.AutoSize = true;
            this.lblCodCliente.Location = new System.Drawing.Point(17, 88);
            this.lblCodCliente.Name = "lblCodCliente";
            this.lblCodCliente.Size = new System.Drawing.Size(119, 17);
            this.lblCodCliente.TabIndex = 8;
            this.lblCodCliente.Text = "Código de Cliente";
            // 
            // comboBoxCodCliente
            // 
            this.comboBoxCodCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCodCliente.FormattingEnabled = true;
            this.comboBoxCodCliente.Location = new System.Drawing.Point(142, 88);
            this.comboBoxCodCliente.Name = "comboBoxCodCliente";
            this.comboBoxCodCliente.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCodCliente.TabIndex = 9;
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Location = new System.Drawing.Point(310, 88);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(31, 17);
            this.lblDNI.TabIndex = 10;
            this.lblDNI.Text = "DNI";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(348, 88);
            this.textBox2.MaxLength = 8;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 11;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(541, 85);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.ReadOnly = true;
            this.textBoxNombre.Size = new System.Drawing.Size(116, 22);
            this.textBoxNombre.TabIndex = 12;
            // 
            // textBoxDireccion
            // 
            this.textBoxDireccion.Location = new System.Drawing.Point(756, 85);
            this.textBoxDireccion.Name = "textBoxDireccion";
            this.textBoxDireccion.ReadOnly = true;
            this.textBoxDireccion.Size = new System.Drawing.Size(114, 22);
            this.textBoxDireccion.TabIndex = 13;
            // 
            // textBoxCodProducto
            // 
            this.textBoxCodProducto.Location = new System.Drawing.Point(156, 143);
            this.textBoxCodProducto.Name = "textBoxCodProducto";
            this.textBoxCodProducto.Size = new System.Drawing.Size(100, 22);
            this.textBoxCodProducto.TabIndex = 14;
            this.textBoxCodProducto.TextChanged += new System.EventHandler(this.textBoxCodProducto_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(477, 85);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(58, 17);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(683, 85);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(67, 17);
            this.lblDireccion.TabIndex = 16;
            this.lblDireccion.Text = "Dirección";
            // 
            // lblCodProducto
            // 
            this.lblCodProducto.AutoSize = true;
            this.lblCodProducto.Location = new System.Drawing.Point(17, 143);
            this.lblCodProducto.Name = "lblCodProducto";
            this.lblCodProducto.Size = new System.Drawing.Size(133, 17);
            this.lblCodProducto.TabIndex = 17;
            this.lblCodProducto.Text = "Código de Producto";
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
            this.dataGridViewTablaFactura.RowHeadersVisible = false;
            this.dataGridViewTablaFactura.RowHeadersWidth = 51;
            this.dataGridViewTablaFactura.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewTablaFactura.RowTemplate.Height = 24;
            this.dataGridViewTablaFactura.Size = new System.Drawing.Size(855, 300);
            this.dataGridViewTablaFactura.TabIndex = 20;
            // 
            // FrmSistemaDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 503);
            this.Controls.Add(this.dataGridViewTablaFactura);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.lblCodProducto);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.textBoxCodProducto);
            this.Controls.Add(this.textBoxDireccion);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.comboBoxCodCliente);
            this.Controls.Add(this.lblCodCliente);
            this.Controls.Add(this.comboBoxCodVendedor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCodVendedor);
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
        private System.Windows.Forms.Label lblCodVendedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxCodVendedor;
        private System.Windows.Forms.Label lblCodCliente;
        private System.Windows.Forms.ComboBox comboBoxCodCliente;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDireccion;
        private System.Windows.Forms.TextBox textBoxCodProducto;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCodProducto;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dataGridViewTablaFactura;
    }
}


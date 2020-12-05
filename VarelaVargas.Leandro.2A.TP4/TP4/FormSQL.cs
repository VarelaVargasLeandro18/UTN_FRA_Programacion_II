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
    public partial class FormSQL : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private SqlConnection conn;
        private EFormsSQL tipo;

        private FormSQL()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Configura el Form según el tipo que se especifique.
        /// </summary>
        /// <param name="tipoForm"></param>
        public FormSQL (EFormsSQL tipoForm)
            : this()
        {
            this.tipo = tipoForm;

            this.Load += this.inicializarConnection;
            this.Load += this.inicializarDataGridView;

            switch (this.tipo)
            {
                case EFormsSQL.Stock:
                    this.Text = "Form Stock";
                    this.Load += this.inicializarDataTableStock;
                    this.Load += this.inicializarDataAdapterStock;
                    break;

                case EFormsSQL.Vendedores:
                    this.Text = "Form Vendedores";
                    this.Load += this.inicializarDataTablePersonas;
                    this.Load += this.inicializarDataAdapterPersonas;
                    break;

                default:
                    this.Text = "Form Clientes";
                    this.Load += this.inicializarDataTablePersonas;
                    this.Load += this.inicializarDataAdapterPersonas;
                    break;
            }

            this.Load += this.llenarDatosEnDataTable;
        }

        #region Frm - Load
        /// <summary>
        /// Inicializa la conexión con la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarConnection(object sender, EventArgs args)
        {
            this.conn = new SqlConnection(Properties.Settings.Default.BDConn);
        }

        /// <summary>
        /// Configura el DataGridView para que las columnas llenen el tamaño del mismo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarDataGridView (object sender, EventArgs args)
        {
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.DataError += DataGridView_DataError;
        }

        /// <summary>
        /// Manejará errores del DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                throw e.Exception;
            }
            catch (System.Data.ReadOnlyException ex)
            {
                MessageBox.Show(this, "Un DNI que ya se encuentra en la BD no se puede modificar!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"ERROR: {ex.Message}\nStackTrace: {ex.StackTrace}", "ERROR EN DATAGRIDVIEW", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Tabla - Stock
        /// <summary>
        /// Inicializa el DataTable con los nombres de las columnas que corresponden para el Stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarDataTableStock(object sender, EventArgs args)
        {
            this.dataTable = new DataTable("Stock");
            this.dataTable.Columns.Add("Id");
            this.dataTable.Columns["Id"].AutoIncrement = true;
            this.dataTable.Columns["Id"].ReadOnly = true;
            this.dataTable.Columns.Add("Nombre");
            this.dataTable.Columns.Add("Tipo");
            this.dataTable.Columns.Add("Precio");
        }

        /// <summary>
        /// Inicializa el DataAdapter con los comandos necesarios para la tabla Productos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarDataAdapterStock(object sender, EventArgs args)
        {
            string SelectCommand = "SELECT * FROM Productos;";
            string InsertCommand = "INSERT INTO Productos VALUES (@id, @nombre, @precio, @tipo);";
            string DeleteCommand = "DELETE FROM Productos WHERE id = @id;";
            string UpdateCommand = "UPDATE Productos SET Nombre = @nombre, Precio = @precio, Tipo = @tipo WHERE id = @id;";

            this.dataAdapter = new SqlDataAdapter();

            //Configurar Select Command.
            this.dataAdapter.SelectCommand = new SqlCommand(SelectCommand, this.conn);
            
            //Configurar Insert Command
            this.dataAdapter.InsertCommand = new SqlCommand(InsertCommand, this.conn);
            SqlParameter id = new SqlParameter("id", SqlDbType.Int, 8, "Id");
            SqlParameter nombre = new SqlParameter("nombre", SqlDbType.VarChar, 50, "Nombre");
            SqlParameter precio = new SqlParameter("precio", SqlDbType.Float, 8, "Precio");
            SqlParameter tipo = new SqlParameter("tipo", SqlDbType.VarChar, 50, "Tipo");
            this.dataAdapter.InsertCommand.Parameters.Add(id);
            this.dataAdapter.InsertCommand.Parameters.Add(nombre);
            this.dataAdapter.InsertCommand.Parameters.Add(precio);
            this.dataAdapter.InsertCommand.Parameters.Add(tipo);

            //Configurar Delete Command
            this.dataAdapter.DeleteCommand = new SqlCommand(DeleteCommand, this.conn);
            id = new SqlParameter("id", SqlDbType.Int, 8, "Id");
            this.dataAdapter.DeleteCommand.Parameters.Add(id);

            //Configurar Update Command
            this.dataAdapter.UpdateCommand = new SqlCommand(UpdateCommand, this.conn);
            id = new SqlParameter("id", SqlDbType.Int, 8, "Id");
            nombre = new SqlParameter("nombre", SqlDbType.VarChar, 50, "Nombre");
            precio = new SqlParameter("precio", SqlDbType.Float, 8, "Precio");
            tipo = new SqlParameter("tipo", SqlDbType.VarChar, 50, "Tipo");
            this.dataAdapter.UpdateCommand.Parameters.Add(id);
            this.dataAdapter.UpdateCommand.Parameters.Add(nombre);
            this.dataAdapter.UpdateCommand.Parameters.Add(precio);
            this.dataAdapter.UpdateCommand.Parameters.Add(tipo);
        }
        #endregion

        #region Tabla - Persona
        /// <summary>
        /// Inicializa el DataTable con los nombres de las columnas que corresponden para Clientes o Vendedores
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarDataTablePersonas(object sender, EventArgs args)
        {
            this.dataTable = new DataTable("Personas");
            this.dataTable.Columns.Add("DNI");
            this.dataTable.ColumnChanging += DataTable_ColumnChanging;
            this.dataTable.Columns.Add("Nombre");
        }

        /// <summary>
        /// En caso de que se quiera modificar la columna DNI, la hará de solo lectura para que lance un error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState != DataRowState.Detached)
                this.dataTable.Columns["DNI"].ReadOnly = true;
            else
                this.dataTable.Columns["DNI"].ReadOnly = false;
        }

        /// <summary>
        /// Inicializa el DataAdapter con los comandos necesarios para la tabla Clientes o Vendedores según corresponda
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void inicializarDataAdapterPersonas(object sender, EventArgs args)
        {
            string Tabla;

            if (this.tipo == EFormsSQL.Clientes)
                Tabla = "Clientes";
            else
                Tabla = "Vendedores";

            string SelectCommand = $"SELECT * FROM {Tabla};";
            string InsertCommand = $"INSERT INTO {Tabla} VALUES (@DNI, @Nombre);";
            string DeleteCommand = $"DELETE FROM {Tabla} WHERE DNI = @DNI;";
            string UpdateCommand = $"UPDATE {Tabla} SET Nombre = @Nombre WHERE DNI = @DNI;";

            this.dataAdapter = new SqlDataAdapter();

            this.dataAdapter.SelectCommand = new SqlCommand(SelectCommand, this.conn);

            SqlParameter DNI = new SqlParameter("DNI", SqlDbType.Int, 8, "DNI");
            SqlParameter Nombre = new SqlParameter("Nombre", SqlDbType.VarChar, 50, "Nombre");
            this.dataAdapter.InsertCommand = new SqlCommand(InsertCommand, this.conn);
            this.dataAdapter.InsertCommand.Parameters.Add(DNI);
            this.dataAdapter.InsertCommand.Parameters.Add(Nombre);

            DNI = new SqlParameter("DNI", SqlDbType.Int, 8, "DNI");
            this.dataAdapter.DeleteCommand = new SqlCommand(DeleteCommand, this.conn);
            this.dataAdapter.DeleteCommand.Parameters.Add(DNI);

            DNI = new SqlParameter("DNI", SqlDbType.Int, 8, "DNI");
            Nombre = new SqlParameter("Nombre", SqlDbType.VarChar, 50, "Nombre");
            this.dataAdapter.UpdateCommand = new SqlCommand(UpdateCommand, this.conn);
            this.dataAdapter.UpdateCommand.Parameters.Add(DNI);
            this.dataAdapter.UpdateCommand.Parameters.Add(Nombre);
        }
        #endregion

        /// <summary>
        /// Llena los datos del DataTable.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void llenarDatosEnDataTable(object sender, EventArgs args)
        { 
            this.dataAdapter.Fill(this.dataTable);
            this.dataGridView.DataSource = this.dataTable;
        }
        #endregion

        /// <summary>
        /// Al hacer click en el botón de Confirmar se hará un Update de la BD.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            DialogResult confirmarCambios = MessageBox.Show(this, "¿Está seguro?", "Confirmar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmarCambios == DialogResult.Yes)
            {
                try
                {
                    this.dataAdapter.Update(this.dataTable);
                    this.dataTable.Rows.Clear();
                    this.dataAdapter.Fill(this.dataTable);
                    ((FrmSistemaDeVenta)this.Owner).invocarActualizaciones();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message,"Error de " + ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}

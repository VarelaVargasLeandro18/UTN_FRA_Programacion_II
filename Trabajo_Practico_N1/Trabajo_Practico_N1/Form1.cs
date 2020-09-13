using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Entidades;

namespace Trabajo_Practico_N1
{
    public partial class FormCalculadora : Form
    {

        private Double Operar(String numero1, String numero2, String operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = this.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();

            if (this.cmbOperador.SelectedIndex == -1)
                this.cmbOperador.SelectedIndex = 0;

        }

        private void Limpiar()
        {

            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperador.SelectedIndex = -1;

        }

        public FormCalculadora()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = this.numConversor.DecimalBinario(this.lblResultado.Text);
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = this.numConversor.BinarioDecimal(this.lblResultado.Text);
        }
    }
}

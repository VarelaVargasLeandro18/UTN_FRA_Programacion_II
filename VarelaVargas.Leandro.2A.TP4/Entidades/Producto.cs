using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    [XmlInclude(typeof(Comida))]
    [XmlInclude(typeof(Limpieza))]
    public abstract class Producto
    {
        private int id;
        private string nombre;
        private float precio;
        private int cantidad;

        public Producto()
        { }

        #region Propiedades
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                Regex soloLetras = new Regex(@"[\w ]+");

                if (soloLetras.IsMatch(value))
                    this.nombre = value;

            }
        }

        public float Precio
        {
            get { return this.precio; }
            set { this.precio = value; }
        }
        
        public int Cantidad
        {
            get { return this.cantidad; }
            set { this.cantidad = value; }
        }

        public abstract string Tipo
        {
            get;
        }
        #endregion

        public override string ToString()
        {
            float precioTotal = this.cantidad * this.precio;
            StringBuilder strBuilder = new StringBuilder("PRODUCTO: ")
                .AppendLine($"ID: {this.id}, Nombre: {this.nombre}, Precio: {this.precio}, Cantidad: {this.cantidad}, Total Producto: {precioTotal}");
            
            return strBuilder.ToString();
        }

    }
}
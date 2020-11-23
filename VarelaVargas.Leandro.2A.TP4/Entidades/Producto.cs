using System;
using System.Text.RegularExpressions;

namespace Entidades
{
    [Serializable]
    public abstract class Producto
    {
        private int id;
        private string nombre;
        private float precio;
        private int cantidad;

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
        
    }
}
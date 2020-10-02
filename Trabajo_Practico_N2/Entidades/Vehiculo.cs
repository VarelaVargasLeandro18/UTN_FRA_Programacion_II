using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }

        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        
        EMarca marca;
        string chasis;
        ConsoleColor color;

        /// <summary>
        /// Constructor que utilizarán las clases que hereden de Vehículo
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Datos del vehículo en formato String</returns>
        public virtual string Mostrar()
        {
            return ((string)this);
        }

        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("CHASIS: {0}\r\n", p.chasis);
            sb.AppendFormat("MARCA : {0}\r\n", p.marca.ToString());
            sb.AppendFormat("COLOR : {0}\r\n", p.color.ToString());
            sb.AppendFormat("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar</param>
        /// <param name="v2">Segundo vehículo a comparar</param>
        /// <returns>Devuelven 'true' si los chasis son iguales.</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Primer vehículo a comparar</param>
        /// <param name="v2">Segundo vehículo a comparar</param>
        /// <returns>Devuelve 'true' si los chasis son distintos</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }
    }
}

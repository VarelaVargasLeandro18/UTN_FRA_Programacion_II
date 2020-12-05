using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Runtime.CompilerServices;

namespace Entidades
{

    public class Sedan : Vehiculo
    {

        #region Atributos
        public enum ETipo { CuatroPuertas, CincoPuertas }
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.CuatroPuertas;
        }

        public Sedan (EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis, marca, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedades-Override
        /// <summary>
        /// Sedan son 'Mediano'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos-Override
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine(((string)this));
            sb.AppendFormat("TAMAÑO : {0}\n", this.Tamanio);
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {

        #region Constructor
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region Propiedades-Override
        /// <summary>
        /// SUV son 'Grande'
        /// </summary>
        public override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Métodos-Override
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SUV");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    
    }
}

using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public class Alumno : Universitario
    {
        
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #region Constructor
        
        #endregion

        protected override string ParticiparEnClase()
        {
            throw new NotImplementedException();
        }

    }
}

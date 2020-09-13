using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        public static Double Operar(Numero num1, Numero num2, String operador)
        {
            Char cOperador = ( String.IsNullOrEmpty(operador) ) ? ' ' : operador.ToCharArray()[0];
            operador = Calculadora.ValidarOperador(cOperador);
            cOperador = operador.ToCharArray()[0];

            switch ( cOperador )
            {

                case '-':
                    return num1 - num2;

                case '*':
                    return num1 * num2;

                case '/':
                    return num1 / num2;

                default:
                    return num1 + num2;

            }

        }

        private static String ValidarOperador(Char operador)
        {
            return ( operador == '-' || operador == '/' || operador == '*') ? operador.ToString() : '+'.ToString();
        }

    }
}

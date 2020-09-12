using System;

namespace Entidades
{
    public class Numero
    {

        private Double numero;
        public String SetNumero
        {
            set
            {

                this.numero = this.ValidarNumero(value);

            }

        }

        public Numero() 
        {
            this.numero = 0.0;
        }

        public Numero ( Double numero )
        {
            this.SetNumero = numero.ToString();
        }

        public Numero ( String strNumero )
        {
            this.SetNumero = strNumero;
        }

        public String BinarioDecimal ( String binario )
        {



        }

        public String DecimalBinario ( double numero )
        {



        }

        public String DecimalBinario ( String numero )
        {



        }

        private bool EsBinario ( String binario )
        {



        }

        public static Double operator -( Numero n1, Numero n2 )
        {



        }

        public static Double operator *( Numero n1, Numero n2 )
        {



        }

        public static Double operator /( Numero n1, Numero n2 )
        {



        }

        public static Double operator +( Numero n1, Numero n2 )
        {



        }

        private Double ValidarNumero ( String sNumero )
        {

            Double toRet;

            toRet = ( !String.IsNullOrEmpty(sNumero) && Double.TryParse(sNumero, out toRet) ) ? toRet : 0.0;

            return toRet;

        }

    }
}

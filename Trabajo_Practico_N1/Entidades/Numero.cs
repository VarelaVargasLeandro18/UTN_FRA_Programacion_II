using System;
using System.Linq;


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

        public String BinarioDecimal(String binario)
        {

            Int64 aDecimal = 0;

            if (this.EsBinario(binario))
            {

                for ( Int32 i = binario.ToCharArray().Length; i > 0; i-- )
                {

                    Int32 elevado = binario.ToCharArray().Length - i;

                    Char charBinario = binario.ToCharArray()[i - 1];

                    aDecimal += ( Int32.Parse( charBinario.ToString() ) * (Int64)Math.Pow ( 2, elevado ) );

                }

            }
            else
                return "Valor Inválido";

            return aDecimal.ToString();

        }

        public String DecimalBinario(Double numero)
        {
            return this.DecimalBinario(numero.ToString());
        }

        public String DecimalBinario(String numero)
        {

            String aBinario = "";
            Char[] arrBinario;
            Int64 auxINumero;
            Int64 iBit;

            if (String.IsNullOrEmpty(numero) || numero == "0")
                return "0";
            
            if ( Int64.TryParse(numero, out auxINumero) && (numero.ElementAt(0) != '-') )
            {

                while ( auxINumero > 0 )
                {

                    iBit = auxINumero % 2;
                    aBinario += iBit;
                    auxINumero /= 2;
                
                }

            }
            else
                return "Valor Inválido";

            arrBinario = aBinario.ToCharArray();
            Array.Reverse(arrBinario);

            return new String (arrBinario);

        }
        
        private bool EsBinario ( String binario )
        {

            Boolean isBinary = true;

            foreach ( Char charBinario in binario.ToCharArray() )
            {

                if ( !(charBinario == '0' || charBinario == '1') )
                {

                    isBinary = false;
                    break;

                }


            }

            return isBinary;

        }

        public static Double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static Double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static Double operator /(Numero n1, Numero n2)
        {

            if (n2.numero == 0.0)
                return Double.MinValue;

            return n1.numero / n2.numero;

        }

        public static Double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public Double ValidarNumero ( String sNumero )
        {

            Double toRet;

            toRet = ( !String.IsNullOrEmpty(sNumero) && Double.TryParse(sNumero, out toRet) ) ? toRet : 0.0;

            return toRet;

        }

    }
}

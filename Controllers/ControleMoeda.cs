using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public static class ControleMoeda
    {
        public static string Moeda(this int valor)
        {
            return valor.ToString("C2");
        }
        public static int ToNumber(this string valor)
        {


            Char[] valoresNumericos = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',' };
            string valorRetorno = "";
            foreach (var item in valor)
            {
                if (valoresNumericos.Contains(item))
                    valorRetorno += item;
            }

            if (valorRetorno.Length > 0)
            {

                return Convert.ToInt32(valorRetorno);
            }
            else
            {
                return 0;
            }
        }
    }
}

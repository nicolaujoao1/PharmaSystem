using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
   public static class UpdateQuantidadeVennda
    {
       public static void updateQuantidadeVenda(int quant, int id, int valor)
       {
           //--------------------------------------------------------------------------------
           var query = "UPDATE tbVenda SET Quantidade =@quant, Valor_Pago=@valor WHERE ID_Venda=@idvenda";
           //--------------------------------------------------------------------------------
           List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@quant", quant),
                    new ControllerBD.SQLParametro("@idvenda",  id),
                    new ControllerBD.SQLParametro("@valor",  valor)
                };
           //--------------------------------------------------------------------------------
           var bd = new ControllerBD();
           bd.EXECUTE_NON_QUERY(query, parametro);
       }
    }
}

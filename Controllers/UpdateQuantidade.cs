using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public static class UpdateQuantidade
    {
        public static void UpdateQuantidadeProduto(int quant, int id)
        {
            //--------------------------------------------------------------------------------
            var query = "UPDATE tbProduto SET Quantidade_Entrada =@quant WHERE id=@idproduto";
            //--------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@quant", quant),
                    new ControllerBD.SQLParametro("@idproduto",  id)
                };
            //--------------------------------------------------------------------------------
            var bd = new ControllerBD();
            bd.EXECUTE_NON_QUERY(query, parametro);
        }
    }
}

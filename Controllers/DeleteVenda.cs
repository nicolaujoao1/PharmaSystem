using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
   public static class DeleteVenda
    {
       public static void deleteVenda(int id)
       {
           //------------------------------------------------------------------------------
           var query = "DELETE FROM tbVenda WHERE ID_Venda=@idvenda";
           //------------------------------------------------------------------------------
           List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idvenda",  id)
                };
           //------------------------------------------------------------------------------
           var bd1 = new ControllerBD();
           bd1.EXECUTE_NON_QUERY(query, parametro);
       }
    }
}

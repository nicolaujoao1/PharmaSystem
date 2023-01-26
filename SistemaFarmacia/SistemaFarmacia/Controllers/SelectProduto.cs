using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
  public static  class SelectProduto
    {
      public static int selectPreco(int id)
      {
          //------------------------------------------------------------------------------
          var query1 = "SELECT Preco_Unitario FROM tbProduto WHERE id=@idproduto";
          //------------------------------------------------------------------------------
          List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  id)
                };
          //------------------------------------------------------------------------------
          var bd1 = new ControllerBD();
          return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
      }
    }
}

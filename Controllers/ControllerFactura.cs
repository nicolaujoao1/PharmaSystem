using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
   public  class ControllerFactura: ModelFactura
    {
       public void InsertFactura()
       {
           try
           {
               ////--------------------------------------------------------------------------------------
               string query = "INSERT INTO tbFactura VALUES(@codigoFactura)";
               ////--------------------------------------------------------------------------------------
               List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
            {
                new ControllerBD.SQLParametro("@codigoFactura", this.CODIGO_FACTURA),
            };
               //--------------------------------------------------------------------------------------
               new ControllerBD().EXECUTE_NON_QUERY(query, parametro);

           }
           catch (Exception)
           {
               throw;
           }
       }

       public  int NumeroFactura()
       {
           //------------------------------------------------------------------------------
           var query1 = "select Max(id) from tbFactura";
           //------------------------------------------------------------------------------
          
           //------------------------------------------------------------------------------
           var bd1 = new ControllerBD();
            int valor=Convert.ToInt32(bd1.EXECUTE_READER(query1).Rows[0][0]);
            return valor;
    
       }
    }
}

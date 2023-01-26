using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public static class SelectQuantidade
    {
        public static int QuantidadeDisponivel(int id)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Quantidade_Entrada FROM tbProduto WHERE id=@idproduto";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  id)
                };
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
        }
        public static int QuantidadeDisponivel(string produto)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Quantidade_Entrada FROM tbProduto WHERE Nome_Medicamento=@idproduto";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  produto)
                };
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
        }
        public static int QuantidadeDisponivelBarra(string cod)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Quantidade_Entrada FROM tbProduto WHERE Codigo_Barra=@idproduto";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  cod)
                };
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
        }

        public static int QuantidadeMinimaBarra(string cod)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Quantidade_Minima FROM tbProduto WHERE Codigo_Barra=@idproduto";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  cod)
                };
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
        }
        public static int QuantMinima(string produto)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Quantidade_Minima FROM tbProduto WHERE Nome_Medicamento=@idproduto";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idproduto",  produto)
                };
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro1).Rows[0][0]);
        }
    }
}

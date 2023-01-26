using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class SelectHistoricoVenda
    {
        public static DataTable CarregarDadosHistoricos(int id)
        {
            try
            {
                //Console.WriteLine(DateTime.Now.ToShortDateString());
                var query = "SELECT V.Nome_Cliente AS Cliente,V.Quantidade,V.Valor_Pago,F.Nome AS Funcionario,V.Tipo_Pagamento ,V.Data_Venda FROM tbVenda AS V INNER JOIN tbFuncionario AS F ON F.id=V.ID_Funcionario WHERE V.Data_Venda=@data";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                   new ControllerBD.SQLParametro("@data",  DateTime.Now.ToShortDateString()),
                    new ControllerBD.SQLParametro("@id", id)
                };


                return new ControllerBD().EXECUTE_READER(query, parametro1);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        
       public static DataTable CarregarDadosHistoricosGeral()
        {
            try
            {
                //Console.WriteLine(DateTime.Now.ToShortDateString());
                var query = "SELECT P.Nome_Medicamento,V.Quantidade,V.Valor_Pago,V.Nome_Cliente AS Cliente,V.Tipo_Pagamento ,V.Data_Venda FROM tbVenda AS V inner Join tbProduto as P on P.id=V.ID_Produto WHERE V.Data_Venda=@data";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                   new ControllerBD.SQLParametro("@data",  DateTime.Now.ToShortDateString())
                  
                };


                return new ControllerBD().EXECUTE_READER(query, parametro1);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public static DataTable CarregarDadosHistoricos()
        {
            try
            {
                //Console.WriteLine(DateTime.Now.ToShortDateString());
                var query = "SELECT P.Nome_Medicamento,V.Quantidade,V.Valor_Pago, V.Nome_Cliente,V.Data_Venda,V.Tipo_Pagamento,P.Preco_Unitario FROM tbVenda AS V INNER JOIN tbProduto AS P ON P.id=V.ID_Produto WHERE V.Data_Venda=@data";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                   new ControllerBD.SQLParametro("@data",  DateTime.Now.ToShortDateString())
                    
                };


                return new ControllerBD().EXECUTE_READER(query, parametro1);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public static DataTable CarregarDadosHistoricos(string inicio, string fim)
        {
            try
            {
                //Console.WriteLine(DateTime.Now.ToShortDateString());
                var query = "SELECT P.Nome_Medicamento,V.Quantidade,V.Valor_Pago,V.Nome_Cliente AS Cliente,V.Tipo_Pagamento ,V.Data_Venda FROM tbVenda AS V inner Join tbProduto as P on P.id=V.ID_Produto WHERE V.Data_Venda>=@data  AND V.Data_Venda<=@data1";
                     
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                   new ControllerBD.SQLParametro("@data",  Convert.ToDateTime(inicio).ToShortDateString()),
                    new ControllerBD.SQLParametro("@data1",  Convert.ToDateTime(fim).ToShortDateString())
                    
                };


                return new ControllerBD().EXECUTE_READER(query, parametro1);
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
    }
}

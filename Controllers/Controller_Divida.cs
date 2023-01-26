using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
   public  class Controller_Divida:ModelDivida 
    {
       public void InsertDivida()
       {
           ////--------------------------------------------------------------------------------------
           string query = "INSERT INTO tbDividas(Nome,Valor_Total,Data_Registrada)";
           query += "VALUES(@nome,@valor,@data)";
           ////--------------------------------------------------------------------------------------
           List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                            {
                   
                                new ControllerBD.SQLParametro("@nome", this.NOME),
                                new ControllerBD.SQLParametro("@valor", this.VALOR_TOTAL),
                                new ControllerBD.SQLParametro("@data", this.DATA_REGISTRADA)
                               
                                
               
                            };
           //--------------------------------------------------------------------------------------
           new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
       }

       public DataTable SelectDivida()
       {
           //------------------------------------------------------------------------------
           var query1 = "SELECT d.Nome_Cliente, p.Nome_Medicamento,d.Quantidade,d.Preco,d.Valor_Pagar,d.Codigo,d.Data_Venda from tbDividas as d inner join tbProduto as p on p.id=d.id";
           //------------------------------------------------------------------------------
           
           //------------------------------------------------------------------------------
           return new ControllerBD().EXECUTE_READER(query1);
       }


       public DataTable SelectDadosDivida()
       {
           //------------------------------------------------------------------------------
           var query1 = "SELECT p.Nome_Medicamento,d.Quantidade,d.Valor_Pagar,d.Codigo,d.Data_Venda from tbDividas as d inner join tbProduto as p on p.id=d.id";
           //------------------------------------------------------------------------------

           //------------------------------------------------------------------------------
           return new ControllerBD().EXECUTE_READER(query1);
       }
       public DataTable SelectDadosDividaVenda( int codigo)
       {
           //------------------------------------------------------------------------------
           var query1 = "SELECT d.ID_Produto,p.Nome_Medicamento,d.Quantidade,d.Valor_Pagar from tbDividas as d inner join tbProduto as p on p.id=d.id where d.Codigo=@codigo";
           //------------------------------------------------------------------------------
           List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                            {
                   
                                new ControllerBD.SQLParametro("@codigo",codigo),
                              
                            };
           //------------------------------------------------------------------------------
           return new ControllerBD().EXECUTE_READER(query1,parametro);
       }
    }
}

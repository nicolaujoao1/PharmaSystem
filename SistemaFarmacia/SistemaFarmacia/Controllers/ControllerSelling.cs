using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerSelling:ModelSelling
    {
        public string DadosVendaDiaria(int Func)
        {
            var query = "SELECT SUM(V.Quantidade),SUM(V.Valor_Pago) FROM tbVenda AS V INNER JOIN tbFuncionario AS F ON V.ID_Funcionario=F.id WHERE V.Data_Venda=@Data AND V.ID_Funcionario=@idFunc";
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@data", DateTime.Now.ToShortDateString()),
                    new ControllerBD.SQLParametro("@idFunc", Func),
                };
             var dadosFinais= new ControllerBD().EXECUTE_READER(query,parametro);
             var dados= dadosFinais.Rows[0][0].ToString();
             var valores = new string[2];
             if (dados == string.Empty)
             {
                 valores[0] = "0";
                 valores[1] = "0";
             }
             else
             {
                 valores[0] = dadosFinais.Rows[0][0].ToString();
                 valores[1] = dadosFinais.Rows[0][1].ToString();
             }
             var smsFinal = string.Format("Dados Gerais\nQuantidade de Produtos vendidos: {0}\nTotal Vendido: {1:c}", valores[0],ControleMoeda.Moeda(Convert.ToInt32(valores[1])));
            return smsFinal.ToString();
        }
        public static string NumeroFacturaCorrente()
        {
            var query1 = "SELECT MAX(ID_Venda) FROM tbVenda";
            return new ControllerBD().EXECUTE_READER(query1).Rows[0][0].ToString();
        }
        public int MaxFactura()
        {
            var query = "select MAX(ID_Venda) maximo from tbVenda";
            var res = (new ControllerBD().EXECUTE_READER(query).Rows[0][0]).ToString();

            if (res == string.Empty)
                return 1;
            else
                return Convert.ToInt32(res)+1;
            
        }
        public void SaveSelling(int idProd, int IdFunc, int quant, string VALORPAGO, string tipoPagamento)
        {
            this.ID_PRODUTO = idProd;
            this.ID_FUNCIONARIO = IdFunc;
            this.QUANTIDADE_VENDA = quant;
            this.VALOR_PAGAR =Convert.ToDouble(VALORPAGO);

            if (tipoPagamento.Equals(string.Empty)) this.TIPO_PAGAMENTO = "Pronto Pagamento";
            else this.TIPO_PAGAMENTO = tipoPagamento;
            //----------------------------------------------------------------------------------------------------------------
            var query = "INSERT INTO tbVenda(ID_Produto,ID_Funcionario,Nome_Cliente,Quantidade,Valor_Pago,Data_Venda,Hora_Venda,Tipo_Pagamento)"
                            + " VALUES(@idprod,@idFunc,@nome,@quant,@valor,@data,@hora,@pagamento)";
            //----------------------------------------------------------------------------------------------------------------
            
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@idprod", this.ID_PRODUTO),
                    new ControllerBD.SQLParametro("@idFunc", this.ID_FUNCIONARIO),
                    new ControllerBD.SQLParametro("@nome", this.NOME_CLIENTE),
                    new ControllerBD.SQLParametro("@quant", this.QUANTIDADE_VENDA),
                    new ControllerBD.SQLParametro("@valor", this.VALOR_PAGAR),
                    new ControllerBD.SQLParametro("@data", DateTime.Now.ToShortDateString()),
                    new ControllerBD.SQLParametro("@hora", DateTime.Now.ToShortTimeString()),
                    new ControllerBD.SQLParametro("@pagamento", this.TIPO_PAGAMENTO),
                    //new ControllerBD.SQLParametro("@numFact", this.MaxFactura())
                };
        
            //----------------------------------------------------------------------------------------------------------------
            (new ControllerBD()).EXECUTE_NON_QUERY(query, parametro);
        }
    }
}

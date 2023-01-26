using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerProduct:ModelProduct
    {
        public int TotalValorPagar { get; private set; }
        public int QuantDesejada { get; set; }
         public void InsertProduct(){

                 try
                 {

                   
                     if (QuantidadeInserir()==0)
                     {
                         Analizar();
                         
                     }
                     else
                     if(QuantidadeInserir()<this.QUANTIDADE_OUTRO)return;
                     else
                        
                     {
                         if (ListarQuantidadeLinhas(this.NOME_MEDICAMENTO) > 0 )
                         {
                             var query = "UPDATE tbProduto SET Quantidade_Entrada=@quant, Data_Validade=@data WHERE Nome_Medicamento=@Nome";
                             //--------------------------------------------------------------------------------
                             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                                { 
                               
                                    new ControllerBD.SQLParametro("@Nome", this.NOME_MEDICAMENTO),
                                    new ControllerBD.SQLParametro("@quant",  this.QUANTIDADE_ACRESCENTAR),
                                    new ControllerBD.SQLParametro("@data",  this.DATA_VALIDADE)
                                };
                             //--------------------------------------------------------------------------------
                             new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
                         }
                         else
                         {
                             ////--------------------------------------------------------------------------------------
                             string query = "INSERT INTO tbProduto(ID_Funcionario,Nome_Medicamento,Descricao,Data_Validade,Codigo_Platileira,Quantidade_Entrada,Quantidade_Minima,Preco_Unitario,Unidade,Origem,Codigo_Barra)";
                             query += "VALUES(@id_funcionario,@nome_medicamento,@descricao,@data_validade,@codigo_platileira,@quantidade_entrada,@quantMinima,@preco_unitario,@unidade,@origem,@codigo_barra)";
                             ////--------------------------------------------------------------------------------------
                             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                            {
                   
                                new ControllerBD.SQLParametro("@id_funcionario", this.ID_FUNCIONARIO),
                                new ControllerBD.SQLParametro("@nome_medicamento", this.NOME_MEDICAMENTO),
                                new ControllerBD.SQLParametro("@descricao", this.DESCRICAO),
                                new ControllerBD.SQLParametro("@data_validade", this.DATA_VALIDADE),
                                new ControllerBD.SQLParametro("@codigo_platileira", this.CODIGO_PLATILEIRA),
                                new ControllerBD.SQLParametro("@quantidade_entrada", this.QUANTIDADE_ENTRADA),
                                new ControllerBD.SQLParametro("@quantMinima", this.QUANTIDADE_MINIMA),
                                new ControllerBD.SQLParametro("@preco_unitario", this.PRECO_UNITARIO),
                                new ControllerBD.SQLParametro("@unidade", this.UNIDADE),
                                new ControllerBD.SQLParametro("@origem", this.ORIGEM),
                                new ControllerBD.SQLParametro("@codigo_barra", this.CODIGO_BARRA)
               
                            };
                             //--------------------------------------------------------------------------------------
                             new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
                         }
                     }
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         
         
         }
         public void DeleteProduct(){
             try
             {
                 //------------------------------------------------------------------------------
                 var query = "DELETE FROM tbProduto WHERE Nome_Medicamento=@nom";
                 //------------------------------------------------------------------------------
                 List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  this.NOME_MEDICAMENTO)
                };
                 //------------------------------------------------------------------------------

               new  ControllerBD().EXECUTE_NON_QUERY(query, parametro);
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         }
         public void UpdateProduct(string nameProd){
             try
             {
                 //--------------------------------------------------------------------------------
                 var query = "UPDATE tbProduto SET Nome_Medicamento =@nome, Descricao=@descr,Data_Validade=@data,Codigo_Platileira=@codPlat,Quantidade_Entrada=@quant,Quantidade_Minima=@quantMinima,Preco_Unitario=@preco,Unidade=@unidade,Origem=@origem,Codigo_Barra=@codbar WHERE Nome_Medicamento=@nomeCod";
                 //--------------------------------------------------------------------------------
                 List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nomeCod",  nameProd),
                    new ControllerBD.SQLParametro("@Nome", this.NOME_MEDICAMENTO),
                    new ControllerBD.SQLParametro("@descr",  this.DESCRICAO),
                    new ControllerBD.SQLParametro("@data",  this.DATA_VALIDADE),
                    new ControllerBD.SQLParametro("@codPlat",  this.CODIGO_PLATILEIRA),
                    new ControllerBD.SQLParametro("@quant",  this.QUANTIDADE_ENTRADA),
                    new ControllerBD.SQLParametro("@quantMinima", this.QUANTIDADE_MINIMA),
                    new ControllerBD.SQLParametro("@preco",  this.PRECO_UNITARIO),
                    new ControllerBD.SQLParametro("@unidade",  this.UNIDADE),
                    new ControllerBD.SQLParametro("@origem",  this.ORIGEM),
                    new ControllerBD.SQLParametro("@codbar",  this.CODIGO_BARRA)
                   
                };
                 //--------------------------------------------------------------------------------
                 new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
         }
         public DataTable SearchProduct(string nameSelect) {
             //------------------------------------------------------------------------------
             var query1 = "SELECT * FROM tbProduto WHERE Nome_Medicamento=@nom";
             //------------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  nameSelect)
                };
             //------------------------------------------------------------------------------
             return new ControllerBD().EXECUTE_READER(query1, parametro1);
         }
         public List<string> SelectProducts() {
             //------------------------------------------------------------------------------
             var query = "SELECT Nome_Medicamento FROM tbProduto";
             //------------------------------------------------------------------------------
             var bd1 = new ControllerBD();
             DataTable dados = bd1.EXECUTE_READER(query);
             List<string> names = new List<string>();
             foreach (DataRow Items in dados.Rows)
             {
                 names.Add(Items.Field<string>("Nome_Medicamento"));
             }
             return names;
         }
         public DataTable ListarProdutosArmazem()
         {
             var query1 = "SELECT Nome_Medicamento as Medicamento,Quantidade_Entrada as Quantidade,Data_Validade  as Validade,Preco_Unitario as Preço FROM tbProduto where Quantidade_Entrada>0";
             return new ControllerBD().EXECUTE_READER(query1);
         }
         public DataTable ListarStorePorNome()
         {
             //------------------------------------------------------------------------------
             var query1 = "SELECT Nome_Medicamento as Medicamento,Quantidade_Entrada as Quantidade,Data_Validade  as Validade,Preco_Unitario as Preço FROM tbProduto WHERE Nome_Medicamento Like @nom";
             //------------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", string.Format("%{0}%",this.NOME_MEDICAMENTO))
                };
             var bd1 = new ControllerBD();
             return bd1.EXECUTE_READER(query1, parametro);
         }
         public int ListarQuantidadeLinhas(string nome)
         {
             //------------------------------------------------------------------------------
             var query1 = "SELECT * FROM tbProduto WHERE Nome_Medicamento=@nom";
             //------------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", nome)
                };
             var bd1 = new ControllerBD();
             return bd1.EXECUTE_READER(query1, parametro).Rows.Count;
         }
         //=======================================================
         public void Analizar()
         {
             #region pegar a quantidade anterior
                        int d = QuantidadeInserir();
                         d += QUANTIDADE_OUTRO;
                         if (d < this.QUANTIDADE_OUTRO) return;
                         else
                         {
                             if (ListarQuantidadeLinhas(this.NOME_MEDICAMENTO) > 0)
                             {
                                 var query = "UPDATE tbProduto SET Quantidade_Entrada=@quant WHERE Nome_Medicamento=@Nome";
                                 //--------------------------------------------------------------------------------
                                 List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                                { 
                               
                                    new ControllerBD.SQLParametro("@Nome", this.NOME_MEDICAMENTO),
                                    new ControllerBD.SQLParametro("@quant",  this.QUANTIDADE_ACRESCENTAR)
                                };
                                 //--------------------------------------------------------------------------------
                                 new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
                             }
                             else
                             {
                                 ////--------------------------------------------------------------------------------------
                                 string query = "INSERT INTO tbProduto(ID_Funcionario,Nome_Medicamento,Descricao,Data_Validade,Codigo_Platileira,Quantidade_Entrada,Quantidade_Minima,Preco_Unitario,Unidade,Origem,Codigo_Barra)";
                                 query += "VALUES(@id_funcionario,@nome_medicamento,@descricao,@data_validade,@codigo_platileira,@quantidade_entrada,@quantMinima,@preco_unitario,@unidade,@origem,@codigo_barra)";
                                 ////--------------------------------------------------------------------------------------
                                 List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                            {
                   
                                new ControllerBD.SQLParametro("@id_funcionario", this.ID_FUNCIONARIO),
                                new ControllerBD.SQLParametro("@nome_medicamento", this.NOME_MEDICAMENTO),
                                new ControllerBD.SQLParametro("@descricao", this.DESCRICAO),
                                new ControllerBD.SQLParametro("@data_validade", this.DATA_VALIDADE),
                                new ControllerBD.SQLParametro("@codigo_platileira", this.CODIGO_PLATILEIRA),
                                new ControllerBD.SQLParametro("@quantidade_entrada", this.QUANTIDADE_ENTRADA),
                                new ControllerBD.SQLParametro("@quantMinima", this.QUANTIDADE_MINIMA),
                                new ControllerBD.SQLParametro("@preco_unitario", this.PRECO_UNITARIO),
                                new ControllerBD.SQLParametro("@unidade", this.UNIDADE),
                                new ControllerBD.SQLParametro("@origem", this.ORIGEM),
                                new ControllerBD.SQLParametro("@codigo_barra", this.CODIGO_BARRA)
               
                            };
                                 //--------------------------------------------------------------------------------------
                                 new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
                             }
                         }
             #endregion
         }
        //========================================================
         public int QuantidadeInserir() {
             //------------------------------------------------------------------------------
             
             var query1 = "SELECT Quantidade_Entrada FROM tbArmazem WHERE Nome_Medicamento=@nom";
             //------------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", this.NOME_MEDICAMENTO)
                };
             var bd1 = new ControllerBD();
             return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro).Rows[0][0]);
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
         public int QuantidadeExiste(string _nomeMedicamento)
         {
             //------------------------------------------------------------------------------
             var query1 = "SELECT Quantidade_Entrada FROM tbProduto WHERE Nome_Medicamento=@nom";
             //------------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", _nomeMedicamento)
                };
             var bd1 = new ControllerBD();
             return Convert.ToInt32(bd1.EXECUTE_READER(query1, parametro).Rows[0][0]);
         }
         public List<string> ListarProdutos()
         {
             #region LISTAR O PRODUTOS DISPONIVEIS A VENDA
             List<string> dadosFinal = new List<string>();
             //======================================================================================
             string query = "SELECT  * FROM tbProduto";
             //======================================================================================
             ControllerBD login = new ControllerBD();
             DataTable tbLogin = login.EXECUTE_READER(query);
             //======================================================================================
             var Dados = from dado in tbLogin.AsEnumerable()
                         select new { NomeMedicamento = dado.Field<string>("Nome_Medicamento") };
             //======================================================================================
             foreach (var valor in Dados)
             {
                 dadosFinal.Add(valor.NomeMedicamento.ToString());
             }
             //======================================================================================
             return dadosFinal;
             #endregion
         }
         public List<string> ListarPorNome()
         {
             #region LISTAR O PRODUTOS DISPONIVEIS A VENDA
             List<string> dadosFinal = new List<string>();
             //======================================================================================
             string query = "SELECT  Nome_Medicamento FROM tbProduto";
             //======================================================================================
             ControllerBD login = new ControllerBD();
             DataTable tbLogin = login.EXECUTE_READER(query);
             //======================================================================================
             var Dados = from dado in tbLogin.AsEnumerable()
                         select new { NomeMedicamento = dado.Field<string>("Nome_Medicamento") };
             //======================================================================================
             foreach (var valor in Dados)
             {
                 dadosFinal.Add(valor.NomeMedicamento.ToString());
             }
             //======================================================================================
             return dadosFinal;
             #endregion
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
         public List<string> ListarProdutos(string produto,int qtd)
         {
             this.NOME_MEDICAMENTO = produto;
             string query = "SELECT  * FROM tbProduto WHERE Nome_Medicamento=@nome";
             //======================================================================================
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() { new ControllerBD.SQLParametro("@nome", this.NOME_MEDICAMENTO) };
             //======================================================================================
             ControllerBD login = new ControllerBD();
             DataTable tbLogin = login.EXECUTE_READER(query, parametro);
             //======================================================================================
             var Dados = from dado in tbLogin.AsEnumerable()
                         select new
                         {
                             ID = dado.Field<int>("id"),
                             NomeMedicamento = dado.Field<string>("Nome_Medicamento"),
                             Preco = dado.Field<int>("Preco_Unitario"),
                             Unidade = dado.Field<string>("Unidade")
                         };
             List<string> lista = new List<string>();

             foreach (var item in Dados)
             {
                 lista.Add(item.ID.ToString());
                 lista.Add(item.NomeMedicamento);
                 if (qtd == 0) lista.Add("1");
                 else lista.Add("" + qtd);
                 lista.Add(item.Preco.ToString());
                 lista.Add(item.Unidade);
             }
             return lista;
             //======================================================================================
         }
         public string CalcularTroco(string valorPagar,double valor1)
         {


             int pl = 0;
             double valor = Convert.ToDouble(valorPagar);
             if (valor1 <= valor)
                 return pl.ToString("C2");
             else
                 return (valor1 - valor).ToString("C2");


         }
         public  DataTable AdicionarProduto(string codigobarra)
         {
            //======================================================================================
            string query = "SELECT  * FROM tbProduto WHERE Codigo_Barra=@cod";
            this.CODIGO_BARRA = codigobarra;
            //======================================================================================
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() { new ControllerBD.SQLParametro("@cod", this.CODIGO_BARRA) };
            //======================================================================================
            ControllerBD login = new ControllerBD();
            return login.EXECUTE_READER(query, parametro);
         }
    }
}

using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerStore:ModelStore
    {
        public void InsertStore(){
            try
            {
                ////--------------------------------------------------------------------------------------
                string query = "INSERT INTO tbArmazem(ID_Funcionario,Nome_Medicamento,Descricao,Data_Validade,Codigo_Platileira,Quantidade_Entrada,Quantidade_Minima,Preco_Unitario,Unidade,Origem,Codigo_Barra)";
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeleteStore(){
            try
            {
                //------------------------------------------------------------------------------
                var query = "DELETE FROM tbArmazem WHERE Nome_Medicamento=@nom";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  this.NOME_MEDICAMENTO)
                };
                //------------------------------------------------------------------------------

                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateStore(string nameSelect)
        {
            try
            {
                //--------------------------------------------------------------------------------
                var query = "UPDATE tbArmazem SET Nome_Medicamento =@nome, Descricao=@descr,Data_Validade=@data,Codigo_Platileira=@codPlat,Quantidade_Entrada=@quant,Quantidade_Minima=@quantMinima,Preco_Unitario=@preco,Unidade=@unidade,Origem=@origem,Codigo_Barra=@codbar WHERE Nome_Medicamento=@nomeCod";
                //--------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nomeCod",  nameSelect),
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
        public DataTable SelectStore(string nameSelect) {
            //------------------------------------------------------------------------------
            var query1 = "SELECT * FROM tbArmazem WHERE Nome_Medicamento=@nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  nameSelect)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query1, parametro1);
        }
        public DataTable SearchProduct(string nameSelect)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT * FROM tbArmazem WHERE Nome_Medicamento=@nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  nameSelect)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query1, parametro1);
        }
        public DataTable SearchBarCode(string nameSelect)
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT * FROM tbArmazem WHERE Codigo_Barra=@nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  nameSelect)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query1, parametro1);
        }
        public List<string> SelectStores() {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Nome_Medicamento FROM tbArmazem";
            //------------------------------------------------------------------------------
            var bd1 = new ControllerBD();
            DataTable dados = bd1.EXECUTE_READER(query1);
            List<string> nomes = new List<string>();
            foreach (DataRow Items in dados.Rows)
            {
                nomes.Add(Items.Field<string>("Nome_Medicamento"));
            }
            return nomes;
        }
        public DataTable ListarProdutosArmazem()
        {
               var query1 = "SELECT Nome_Medicamento as Medicamento,Quantidade_Entrada as Quantidade,Data_Validade  as Validade,Preco_Unitario as Preço FROM tbArmazem WHERE Quantidade_Entrada>0";
               return new ControllerBD().EXECUTE_READER(query1);
            
        }
        public DataTable ListarProdutosArmazem(string nome)
        {
                var query1 = "SELECT *FROM tbArmazem WHERE Nome_Medicamento=@nom";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  nome)
                };
                //------------------------------------------------------------------------------
                return new ControllerBD().EXECUTE_READER(query1, parametro);
           
        }
        public void DisponibilizarProduto(string nome,int qtdArmazem,int qtdDisponibilizar) {
            try
            {
                if (qtdDisponibilizar > qtdArmazem) return;
                int qtdAdicionar = qtdArmazem - qtdDisponibilizar;
                //--------------------------------------------------------------------------------
                var query = "UPDATE tbArmazem SET Quantidade_Entrada=@quant WHERE Nome_Medicamento=@nomeCod";
                //--------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                   
                    new ControllerBD.SQLParametro("@quant", qtdAdicionar),
                    new ControllerBD.SQLParametro("@nomeCod", nome)
                };
                //--------------------------------------------------------------------------------
                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public DataTable ListarStorePorNome()
        {
            //------------------------------------------------------------------------------
            var query1 = "SELECT Nome_Medicamento as Medicamento,Quantidade_Entrada as Quantidade,Data_Validade  as Validade,Preco_Unitario as Preço FROM tbArmazem WHERE Nome_Medicamento Like @nom AND Quantidade_Entrada>0";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", string.Format("%{0}%",this.NOME_MEDICAMENTO))
                };
            var bd1 = new ControllerBD();
            return bd1.EXECUTE_READER(query1, parametro);
        }
        public DataTable listarPorNomeProdutosVendidos()
        
      {

          var query = "SELECT P.id AS ID,P.Nome_Medicamento AS Medicamento,V.Nome_Cliente AS Cliente,V.Quantidade,V.Valor_Pago ,V.Data_Venda,V.ID_Venda  FROM tbVenda AS V INNER JOIN tbProduto AS P ON P.id=V.ID_Produto WHERE P.Nome_Medicamento Like @nom and  V.Data_Venda=@data";
          //------------------------------------------------------------------------------
          List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom", string.Format("%{0}%",this.NOME_MEDICAMENTO)),
                     new ControllerBD.SQLParametro("@data",  DateTime.Now.ToShortDateString())
                };


          return new ControllerBD().EXECUTE_READER(query, parametro1);

      }
        
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
   public class SelectDevolucao
    {
        public static DataTable CarregarDados(int id)
        {
            try
            {
                Console.WriteLine(DateTime.Now.ToShortDateString());
                var query = "SELECT P.id AS ID,P.Nome_Medicamento AS Medicamento,P.Preco_Unitario AS Preco,V.Nome_Cliente AS Cliente,V.Quantidade,V.Valor_Pago ,V.Data_Venda,V.ID_Venda  FROM tbVenda AS V INNER JOIN tbProduto AS P ON P.id=V.ID_Produto WHERE V.Data_Venda=@data  AND V.ID_Funcionario=@id";
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
        public static void Devolver(int indexSelect, int QuantExiste, int IDProduto, int IDVenda, int ValorPago, int QuantVendida )
        {
            try
            {
                //---------------------------------------------------------------------------------------------

                //int indexSelect = dgv.CurrentRow.Index;
                //int QuantExiste = Convert.ToInt32(dgv.Rows[indexSelect].Cells[3].Value);
                //int IDProduto = Convert.ToInt32(dgv.Rows[indexSelect].Cells[0].Value);
                //int IDVenda = Convert.ToInt32(dgv.Rows[indexSelect].Cells[6].Value);
                //int ValorPago = Convert.ToInt32(dgv.Rows[indexSelect].Cells[4].Value);
                //int QuantVendida = QuantidadeVenda.QuantidadeProdVenda(IDVenda);
                //---------------------------------------------------------------------------------------------
                if (QuantExiste == QuantVendida)
                {
                    UpdateQuantidade.UpdateQuantidadeProduto(QuantExiste + SelectQuantidade.QuantidadeDisponivel(IDProduto), IDProduto);
                    DeleteVenda.deleteVenda(IDVenda);
                    //dgv.Rows.RemoveAt(indexSelect);
                }
                //---------------------------------------------------------------------------------------------
                else
                {
                    int valorfinalProduto = QuantExiste + SelectQuantidade.QuantidadeDisponivel(IDProduto);
                    int valorfinalVenda = QuantVendida - QuantExiste;
                    UpdateQuantidade.UpdateQuantidadeProduto(valorfinalProduto, IDProduto);
                    UpdateQuantidadeVennda.updateQuantidadeVenda(valorfinalVenda, IDVenda, ValorPago);
                }
            }
            catch (Exception )
            {
                //new frmMessageBox(ex.Message, "Aviso").ShowDialog();
            }
        }

        //public static void Calculo(DataGridView dgv)
        //{
        //    try
        //    {
        //        int indexSelect = dgv.CurrentRow.Index;
        //        int ID = Convert.ToInt32(dgv.Rows[indexSelect].Cells[0].Value);
        //        int valor = Convert.ToInt32(dgv.Rows[indexSelect].Cells[3].Value);
        //        dgv.Rows[indexSelect].Cells[4].Value = valor * SelectPreco.selectPreco(ID);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
      
    }
}


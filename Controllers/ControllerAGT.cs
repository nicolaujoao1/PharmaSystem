using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerAGT : ModelAGT
    {
        public void InsertAGT()
        {
            try
            {
                ////--------------------------------------------------------------------------------------
                string query = "INSERT INTO tbAGT VALUES(@nome,@endereco,@data_nascimento,@sexo,@telefone,@email,@numerobi)";
                ////--------------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
            {
                new ControllerBD.SQLParametro("@nome", this.Regime),
                new ControllerBD.SQLParametro("@endereco", this.Pais),
                new ControllerBD.SQLParametro("@data_nascimento", this.Imposto),
                new ControllerBD.SQLParametro("@sexo", this.DescricaoImposto),
                new ControllerBD.SQLParametro("@telefone", this.Taxa),
                new ControllerBD.SQLParametro("@email", this.Motivo),
                new ControllerBD.SQLParametro("@numerobi", this.MotivoDescricao) 
            };
                //--------------------------------------------------------------------------------------
                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<string> CarregarDadosAGT()
        {
            List<string> n = new List<string>();


            //Console.WriteLine(DateTime.Now.ToShortDateString());
            var query = "SELECT Imposto from  tbAGT";
            //------------------------------------------------------------------------------
            var Dados = new ControllerBD().EXECUTE_READER(query);
            foreach (DataRow item in Dados.Rows)
                n.Add(item[0].ToString());
            return n;

        }
        public void UpdateImposto(string imposto)
        {
            //--------------------------------------------------------------------------------
            var query = "UPDATE tbAGT  SET Regime=@regime, Pais=@pais, Imposto=@imposto, DescricaoImposto=@descricaoImposto, Taxa=@taxa, Motivo=@motivo ,DescricaoMotivo=@descricaomotivo WHERE Imposto=@imposto";
            //--------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@regime", this.Regime),
                    new ControllerBD.SQLParametro("@pais",  this.Pais),
                    new ControllerBD.SQLParametro("@imposto",imposto),
                    new ControllerBD.SQLParametro("@descricaoImposto",this.DescricaoImposto),
                    new ControllerBD.SQLParametro("@taxa", this.Taxa),
                    new ControllerBD.SQLParametro("@motivo", this.Motivo),
                    new ControllerBD.SQLParametro("@descricaomotivo",this.MotivoDescricao)
                };
            //--------------------------------------------------------------------------------
            var bd = new ControllerBD();
            bd.EXECUTE_NON_QUERY(query, parametro);
        }
        public DataTable CarregarDadosAGT(string imposto)
        {
            //Console.WriteLine(DateTime.Now.ToShortDateString());
            var query = "SELECT * from  tbAGT WHERE Imposto=@imposto";

            //----------------------------------------------------------------------------
             List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@imposto",imposto)
                };
            var Dados = new ControllerBD().EXECUTE_READER(query,parametro);
          
            return Dados;

        }
        public int CarregarIdAGT(string imposto)
        {
            //Console.WriteLine(DateTime.Now.ToShortDateString());
            var query = "SELECT id from  tbAGT WHERE Imposto=@imposto";

            //----------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@imposto",imposto)
                };
            var Dados = new ControllerBD().EXECUTE_READER(query, parametro);

            return Convert.ToInt32(Dados.Rows[0][0].ToString());

        }
        public string CarregarIdAGT(int imposto)
        {
            //Console.WriteLine(DateTime.Now.ToShortDateString());
            var query = "SELECT Imposto from  tbAGT WHERE id=@imposto";

            //----------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@imposto",imposto)
                };
            var Dados = new ControllerBD().EXECUTE_READER(query, parametro);

            return Dados.Rows[0][0].ToString();

        }

    }
}

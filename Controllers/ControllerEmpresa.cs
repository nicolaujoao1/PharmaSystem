using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Controllers
{
    public class ControllerEmpresa : ModelEmpresa
    {
        public void InsertEmpresa()
        {
            ////--------------------------------------------------------------------------------------
            string query = "INSERT INTO tbEmpresa(Nome_Empresa,Razao_social,Endereco_Empresa,Data_Fundacao,Email,Telefone,Numero_NIF)";
            query += "VALUES(@empresa,@razao,@endereco,@data,@email,@telefone,@numeroNIF)";
            ////--------------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                            {
                   
                                new ControllerBD.SQLParametro("@empresa", this.NOME_EMPRESA),
                                new ControllerBD.SQLParametro("@razao", this.RAZAO_SOCIAL),
                                new ControllerBD.SQLParametro("@endereco", this.ENDERECO_EMPRESA),
                                new ControllerBD.SQLParametro("@data", this.DATA_FUNDACAO),
                                new ControllerBD.SQLParametro("@email", this.EMAIL),
                                new ControllerBD.SQLParametro("@telefone", this.TELFONE),
                                new ControllerBD.SQLParametro("@numeroNIF", this.NIF)
                                
               
                            };
            //--------------------------------------------------------------------------------------
            new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
        }
        public List<string> SelectEmpresaCorrente()
        {
            var query = "SELECT * FROM tbEmpresa WHERE id=1";
            var data = new ControllerBD();
            var listData = data.EXECUTE_READER(query);
            List<string> names = new List<string>();
            foreach (DataRow Items in listData.Rows)
                names.Add(Items.Field<string>("Nome_Empresa"));
            return names;
        }
        public DataTable SearchEmpresa()
        {
            //------------------------------------------------------------------------------
            var query = "SELECT * FROM tbEmpresa WHERE Nome_Empresa=@nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  this.NOME_EMPRESA)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query, parametro1);
        }
        public void UpdateEmpresa(string nameEmpresa)
        {
            try
            {
                //--------------------------------------------------------------------------------
                var query = "UPDATE tbEmpresa SET Nome_Empresa =@nome, Razao_social=@descr,Endereco_Empresa=@data,Data_Fundacao=@codPlat,Email=@quant,Telefone=@quantMinima,Numero_NIF=@preco WHERE Nome_Empresa=@nomeCod";
                //--------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nomeCod",  nameEmpresa),
                    new ControllerBD.SQLParametro("@Nome", this.NOME_EMPRESA),
                    new ControllerBD.SQLParametro("@descr",  this.RAZAO_SOCIAL),
                    new ControllerBD.SQLParametro("@data",  this.ENDERECO_EMPRESA),
                    new ControllerBD.SQLParametro("@codPlat",  this.DATA_FUNDACAO),
                    new ControllerBD.SQLParametro("@quant",  this.EMAIL),
                    new ControllerBD.SQLParametro("@quantMinima", this.TELFONE),
                    new ControllerBD.SQLParametro("@preco",  this.NIF)
                };
                //--------------------------------------------------------------------------------
                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable ListarDadosEmpresa()
        {
            var query = "SELECT *FROM tbEmpresa WHERE id=1";
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query);
        }
    }
}

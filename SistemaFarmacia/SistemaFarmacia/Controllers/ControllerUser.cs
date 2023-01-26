using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerUser:ModelUser
    {
        public void InsertUser(){
            try
            {
                ////--------------------------------------------------------------------------------------
                string query = "INSERT INTO tbFuncionario(Nome,Endereco,Data_Nascimento,Sexo,Telefone,Email,Numero_BI,Nivel_Acesso,Usuario,Senha)";
                query += "VALUES(@nome,@endereco,@data_nascimento,@sexo,@telefone,@email,@numerobi,@nivel_acesso,@usuario,@senha)";
                ////--------------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
            {
                new ControllerBD.SQLParametro("@nome", this.NOME_COMPLETO),
                new ControllerBD.SQLParametro("@endereco", this.ENDERECO),
                new ControllerBD.SQLParametro("@data_nascimento", this.DATA_NASCIMENTO),
                new ControllerBD.SQLParametro("@sexo", this.SEXO),
                new ControllerBD.SQLParametro("@telefone", this.TELEFONE),
                new ControllerBD.SQLParametro("@email", this.EMAIL),
                new ControllerBD.SQLParametro("@numerobi", this.NUMERO_BI),
                new ControllerBD.SQLParametro("@nivel_acesso", this.NIVEL_ACESSO),
                new ControllerBD.SQLParametro("@usuario", this.USUARIO),
                new ControllerBD.SQLParametro("@senha", this.SENHA)
            };
                //--------------------------------------------------------------------------------------
               new ControllerBD().EXECUTE_NON_QUERY(query, parametro);

            }
            catch (Exception ex)
            {
                //new frmMessageBox(ex.Message, "Aviso").ShowDialog();
                Console.WriteLine(ex);
            }
        
        }
        public void DeleteUser(){
            try
            {
                //------------------------------------------------------------------------------
                var query = "DELETE FROM tbFuncionario WHERE Nome=@nom";
                //------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  this.NOME_COMPLETO)
                };
                //------------------------------------------------------------------------------
                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
            }
            catch (Exception ex)
            {
                //new frmMessageBox(ex.Message, "Aviso").ShowDialog();
                Console.WriteLine(ex.Message);
            }
        }
     
        public void UpdateUser(string nomeCod)
        {
            try
            {
                //--------------------------------------------------------------------------------
                var query = "UPDATE tbFuncionario SET Nome =@nome, Endereco=@end,Data_Nascimento=@data,Sexo=@sexo,Telefone=@telefone,Email=@email,Numero_BI=@bi,Nivel_Acesso=@nivel,Usuario=@user,Senha=@senha WHERE Nome=@nomeCod";
                //--------------------------------------------------------------------------------
                List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nomeCod",  nomeCod),
                    new ControllerBD.SQLParametro("@Nome", this.NOME_COMPLETO),
                    new ControllerBD.SQLParametro("@end",  this.ENDERECO),
                    new ControllerBD.SQLParametro("@data",  this.DATA_NASCIMENTO),
                    new ControllerBD.SQLParametro("@sexo",  this.SEXO),
                    new ControllerBD.SQLParametro("@telefone",  this.TELEFONE),
                    new ControllerBD.SQLParametro("@email",  this.EMAIL),
                    new ControllerBD.SQLParametro("@bi",  this.NUMERO_BI),
                    new ControllerBD.SQLParametro("@nivel",  this.NIVEL_ACESSO),
                    new ControllerBD.SQLParametro("@user",  this.USUARIO),
                    new ControllerBD.SQLParametro("@senha",  this.SENHA)
                };
                //--------------------------------------------------------------------------------
                new ControllerBD().EXECUTE_NON_QUERY(query, parametro);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DataTable SearchUser(){
            //------------------------------------------------------------------------------
            var query = "SELECT * FROM tbFuncionario WHERE Nome=@nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@nom",  this.NOME_COMPLETO)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query, parametro1);
        }
        public List<string> SelectUsers()
        {
            var query = "SELECT Nome,Endereco,Sexo,Telefone,Data_Nascimento FROM tbFuncionario";
            var data = new ControllerBD();
            var listData= data.EXECUTE_READER(query);
            List<string> names = new List<string>();
            foreach (DataRow Items in listData.Rows)
                names.Add(Items.Field<string>("Nome"));
            return names;
        }
        public void Logar()
        {
       
            //======================================================================================
            string query = "SELECT id,Nivel_Acesso FROM tbFuncionario WHERE Usuario=@usuario AND Senha=@senha";

            //-------------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
            {
                new ControllerBD.SQLParametro("@usuario",this.USUARIO),
                new ControllerBD.SQLParametro("@senha",this.SENHA)
            };
            //--------------------------------------------------------------------------------------
            ControllerBD login = new ControllerBD();
            DataTable tbLogin = login.EXECUTE_READER(query, parametro);
            //---------------------------------------------------------------------------------------
            var Dados = from dado in tbLogin.AsEnumerable()
                        select new { ID = dado.Field<int>("id"), Nivel = dado.Field<string>("Nivel_Acesso") };
            foreach (var dado in Dados)
            {
                this.ID_FUNCIONARIO = dado.ID;
                this.NIVEL_ACESSO = dado.Nivel;
            }
        }
        public string selectedUserActive(int id)
        {
            var query = "SELECT Nome FROM tbFuncionario WHERE id=@id";
            List<ControllerBD.SQLParametro> parametro1 = new List<ControllerBD.SQLParametro>() 
                { 
                    new ControllerBD.SQLParametro("@id",  id)
                };
            //------------------------------------------------------------------------------
            return new ControllerBD().EXECUTE_READER(query, parametro1).Rows[0][0].ToString();
        }
        public DataTable ListarFuncionarioPorNome() {
            var query = "SELECT Nome,Data_Nascimento,Sexo,Telefone,Nivel_Acesso FROM tbFuncionario WHERE Nome Like  @nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", string.Format("%{0}%",this.NOME_COMPLETO))
                };
            var bd1 = new ControllerBD();
            return bd1.EXECUTE_READER(query, parametro);
        }
        public DataTable ListarTodosFuncionarios()
        {
            var query = "SELECT Nome,Data_Nascimento,Sexo,Telefone,Nivel_Acesso FROM tbFuncionario"; 
            var bd1 = new ControllerBD();
            return bd1.EXECUTE_READER(query);
        }
        public DataTable ListarFuncionarioPorTelefone()
        {
            var query = "SELECT Nome,Data_Nascimento,Sexo,Telefone,Nivel_Acesso FROM tbFuncionario WHERE Telefone Like  @nom";
            //------------------------------------------------------------------------------
            List<ControllerBD.SQLParametro> parametro = new List<ControllerBD.SQLParametro>() 
                {
                    new ControllerBD.SQLParametro("@nom", string.Format("%{0}%",this.TELEFONE))
                };
            var bd1 = new ControllerBD();
            return bd1.EXECUTE_READER(query, parametro);
        }

    }
}

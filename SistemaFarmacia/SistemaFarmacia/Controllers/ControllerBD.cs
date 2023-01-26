using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Controllers
{
    public class ControllerBD
    {
        public class SQLParametro
        {
            public string parametro { get; set; }
            public object valor { get; set; }
            public SQLParametro(string parametro, object valor)
            {
                this.parametro = parametro;
                this.valor = valor;
            }
        }
        private const string sourceDB = @"Server=.; Database=dbFarmacia; Trusted_Connection=True";
        //private const string sourceDB = @"Server=tcp:DBServer\KambaSoft,49500; Database=dbFarmacia; User ID=kambasoft; Password=kambasoft";
        public SqlConnection ligacao;
        public SqlCommand comando;
        public SqlDataAdapter adaptador;
        public SqlConnection  ConnectDabase()
        {
            ligacao = new SqlConnection(sourceDB);
            ligacao.Open();
            return ligacao;
        }
        public DataTable EXECUTE_READER(string query, List<SQLParametro> parametro = null)
        {

            adaptador = new SqlDataAdapter(query, ConnectDabase());
            DataTable data = new DataTable();
            if (parametro != null)
            {
                foreach (SQLParametro item in parametro)
                {
                    adaptador.SelectCommand.Parameters.AddWithValue(item.parametro, item.valor);
                }

            }
            adaptador.Fill(data);
            adaptador.Dispose();
            ligacao.Dispose();
            return data;
        }
        public void EXECUTE_NON_QUERY(string query, List<SQLParametro> parametro = null)
        {
            
            comando = new SqlCommand(query, ConnectDabase());
            if (parametro != null)
            {
                foreach (SQLParametro item in parametro)
                    comando.Parameters.AddWithValue(item.parametro, item.valor);
            }
            comando.ExecuteNonQuery();
            ligacao.Dispose();
            comando.Dispose();
        }

    }
}

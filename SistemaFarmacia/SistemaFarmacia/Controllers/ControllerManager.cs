using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class ControllerManager
    {
        public DataTable ListarManager()
        {
            try
            {
                var query = "SELECT Nome,Telefone FROM tbFuncionario WHERE Nivel_Acesso='Director Técnico'";
                return new ControllerBD().EXECUTE_READER(query);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelUser
    {
        public int ID_FUNCIONARIO { get; set; }
        public string NOME_COMPLETO { get; set; }
        public string SEXO { get; set; }
        public string ENDERECO { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public string USUARIO { get; set; }
        public string SENHA { get; set; }
        public string NUMERO_BI { get; set; }
        public string NIVEL_ACESSO { get; set; }
    }
}

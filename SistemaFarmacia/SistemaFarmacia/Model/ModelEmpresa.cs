using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelEmpresa
    {
        public string NOME_EMPRESA { get; set; }
        public string RAZAO_SOCIAL { get; set; }
        public string ENDERECO_EMPRESA { get; set; }
        public DateTime DATA_FUNDACAO { get; set; }
        public string EMAIL { get; set; }
        public string TELFONE { get; set; }
        public string NIF { get; set; }
    }
}

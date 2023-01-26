using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelSelling
    {
        public int ID_FUNCIONARIO { get; set; }
        public int ID_PRODUTO { get; set; }
        public string NOME_CLIENTE { get; set; }
        public int QUANTIDADE_VENDA { get; set; }
        public double VALOR_PAGAR { get; set; }
        public string DATA_VENDA { get; set; }
        public string HORA_VENDA { get; set; }
        public string TIPO_PAGAMENTO { get; set; }
        public string NUMERO_FACTURA { get; set; }

    }
}

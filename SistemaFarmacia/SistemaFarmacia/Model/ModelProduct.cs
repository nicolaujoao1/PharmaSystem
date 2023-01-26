using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ModelProduct
    {
        public int ID_PRODUTO { get; set; }
        public string NOME_MEDICAMENTO { get; set; }
        public string DESCRICAO { get; set; }
        public DateTime DATA_VALIDADE { get; set; }
        public int QUANTIDADE_ENTRADA { get; set; }
        public int QUANTIDADE_VENDA { get; set; }
        public double PRECO_UNITARIO { get; set; }
        public string UNIDADE { get; set; }
        public int QUANTIDADE_ACRESCENTAR { get; set; }
        public int QUANTIDADE_OUTRO { get; set; }
        public string CODIGO_BARRA { get; set; }
        public int ID_FUNCIONARIO { get; set; }
        public string CODIGO_PLATILEIRA { get; set; }
        public string ORIGEM { get; set; }
        public int QUANTIDADE_MINIMA { get; set; }
      
    }
}

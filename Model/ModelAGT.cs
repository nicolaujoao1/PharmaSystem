using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ModelAGT
    {
        public int ID { get; set; }
        public string Regime { get; set; }
        public string Motivo { get; set; }
        public string MotivoDescricao { get; set; }
        public string DescricaoImposto { get; set; }
        public string Imposto { get; set; }
        public string Pais { get; set; }
        public int Taxa { get; set; }
    }
}

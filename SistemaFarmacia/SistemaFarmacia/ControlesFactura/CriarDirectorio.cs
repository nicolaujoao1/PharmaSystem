using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaFarmacia.ControlesFactura
{
    public static class CriarDirectorio
    {
        public static string CriarDirectorioRelatorioVenda()
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Relatório De Vendas";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder;
        }
        public static string CriarDiretorioRelatorioFuncionario()
        {

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Relatório Dos Funcionarios";
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            return folder;

        }
    }
}

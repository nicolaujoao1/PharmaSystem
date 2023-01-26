using Controllers;
using SistemaFarmacia.ControlesFactura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.NewForms
{
    public partial class frmRelatorios : Form
    {
        int ID_FUNCIONARIO;
        string caminhoFuncionario = "",caminhoVendas="";
        public frmRelatorios(int id=-1)
        {
            InitializeComponent();
            this.ID_FUNCIONARIO = id;
            caminhoFuncionario = CriarDirectorio.CriarDiretorioRelatorioFuncionario();
            caminhoVendas = CriarDirectorio.CriarDirectorioRelatorioVenda();
            dvgProd.DataSource = new ControllerProduct().ListarProdutosRelatorioArmazem2();
        }
        
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            RelatorioFuncionario.relatorio(caminhoFuncionario, ID_FUNCIONARIO);
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
           RelatorioVendas.ImprimirRelatorio(caminhoVendas, this.ID_FUNCIONARIO);
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           RelatorioVendas.ImprimirRelatorio(caminhoVendas, DtmInicio.Value, DtmFim.Value, this.ID_FUNCIONARIO);
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            RelatorioVendas.ImprimirRelatorioProdutos(caminhoVendas);
        }
    }
}

using Controllers;
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
    public partial class frmActualizacoes : Form
    {
        string nome = null;
        public frmActualizacoes( string name)
        {
            InitializeComponent();
            this.nome = name;
            FillFields();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmActualizacoes_Load(object sender, EventArgs e)
        {

        }

        private void FillFields()
        {
            lblProdutoSelecionado.Text = String.Format("Produto Selecionado: {0}", nome);
            var dados = new ControllerProduct();
            foreach (DataRow item in dados.SearchProduct(nome).Rows)
            {
                txtNomeProduto.Text = item[2].ToString();
                txtNovaQuantida.Text = item[8].ToString();
                txtNovoPreco.Text = item[10].ToString();
                txtcodigobarra.Text= item[14].ToString();
            }
        }

        private void btnDisponibilizar_Click(object sender, EventArgs e)
        {
            Actualizacoes();
        }

        private void Actualizacoes()
        {
            var dados = new ControllerProduct();
            dados.NOME_MEDICAMENTO = txtNomeProduto.Text;
            dados.PRECO_UNITARIO =Convert.ToInt16( txtNovoPreco.Text);
            dados.QUANTIDADE_ENTRADA =Convert.ToInt16( txtNovaQuantida.Text);
            dados.CODIGO_BARRA = txtcodigobarra.Text;
            dados.UpdateAlgunsProduto(nome);
            limparCampos();
            MessageBox.Show("Actualização feita com Sucesso!!!");

        }

        private void limparCampos()
        {
            txtNomeProduto.Text = "";
            txtNovaQuantida.Text = "";
            txtNovoPreco.Text = "";
        }
    }
}
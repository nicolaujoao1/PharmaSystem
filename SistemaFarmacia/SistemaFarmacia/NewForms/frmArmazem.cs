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
    public partial class frmArmazem : Form
    {
        int codFunc;
        
        public frmArmazem(int id=-1)
        {
            InitializeComponent();
            this.codFunc = id;
            cmbSelecioneProduto.Items.AddRange(new ControllerStore().SelectStores().ToArray());
            ListarProdutos();
            Adicionar();
            cmbImposto.Items.AddRange(new ControllerAGT().CarregarDadosAGT().ToArray());
        }

        private void cmbSelecioneProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields();
        }
        public void FillFields()
        {
            foreach (DataRow item in new ControllerStore().SearchProduct(cmbSelecioneProduto.Text).Rows)
            {
                txtNomeProduto.Text = item[2].ToString();
                txtDescricao.Text = item[3].ToString();
                DtmValidade.Text = Convert.ToDateTime(item[4].ToString()).ToShortDateString();
                txtFamilia.Text = item[5].ToString();
                txtFornecedor.Text = item[6].ToString();
                txtCodigoPrateleira.Text = item[7].ToString();
                txtQtdEntrada.Text = item[8].ToString();
                txtQtdMinima.Text = item[9].ToString();
                txtPrecoUnitario.Text = item[10].ToString();
                cmbImposto.Text =new ControllerAGT().CarregarIdAGT(int.Parse(item[11].ToString()));
                txtUnidade.Text = item[12].ToString();
                txtOrigem.Text = item[13].ToString();
                txtCodigoBarras.Text = item[14].ToString();
            }
        }
        public void ListarProdutos()
        {
            this.Refresh();
            ControllerStore store = new ControllerStore();
            dgvDisponibilizar.DataSource = store.ListarProdutosArmazem();
            ListarProdutosExpirados();
          

        }
        public void ProdutosExpirados()
        {
            
                //dvgProdutos.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                for (int i = 0; i < dgvProdutosExpirados.Rows.Count; i++)
                {
                    
                        dgvProdutosExpirados.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                        //dvgProdutos.Rows[i].ReadOnly = true;
                    
                   
                }
                
            

        }

        private void cmbSelecioneProduto_Enter(object sender, EventArgs e)
        {

        }

        private void txtSelecionePeloCodigoBarras_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (DataRow item in new ControllerStore().SearchBarCode(txtSelecionePeloCodigoBarras.Text).Rows)
                {
                    txtNomeProduto.Text = item[2].ToString();
                    txtDescricao.Text = item[3].ToString();
                    DtmValidade.Text = Convert.ToDateTime(item[4].ToString()).ToShortDateString();
                    txtFamilia.Text = item[5].ToString();
                    txtFornecedor.Text = item[6].ToString();
                    txtCodigoPrateleira.Text = item[7].ToString();
                    txtQtdEntrada.Text = item[8].ToString();
                    txtQtdMinima.Text = item[9].ToString();
                    txtPrecoUnitario.Text = item[10].ToString();
                    cmbImposto.Text  = new ControllerAGT().CarregarIdAGT(int.Parse(item[11].ToString()));
                    txtUnidade.Text = item[12].ToString();
                    txtOrigem.Text = item[13].ToString();
                    txtCodigoBarras.Text = item[14].ToString();

                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                GravarArmazem();
                CleanFields();
                MessageBox.Show("Dados cadastrados com sucesso!");
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }
        private void GravarArmazem()
        {
            var salvar = new ControllerStore();
            salvar.NOME_MEDICAMENTO = txtNomeProduto.Text;
            salvar.ID_FUNCIONARIO = this.codFunc;
            salvar.ID_AGT = new ControllerAGT().CarregarIdAGT(cmbImposto.Text);
            salvar.FAMILA = txtFamilia.Text;
            salvar.FORNECEDOR = txtFornecedor.Text;
            salvar.DESCRICAO = txtDescricao.Text;
            salvar.DATA_VALIDADE = Convert.ToDateTime(DtmValidade.Text);
            salvar.CODIGO_PLATILEIRA = txtCodigoPrateleira.Text;
            salvar.QUANTIDADE_ENTRADA = Convert.ToInt32(txtQtdEntrada.Text);
            salvar.PRECO_UNITARIO = Convert.ToInt32(txtPrecoUnitario.Text);
            salvar.UNIDADE = txtUnidade.Text;
            salvar.ORIGEM = txtOrigem.Text;
            salvar.CODIGO_BARRA = txtCodigoBarras.Text;
            salvar.QUANTIDADE_MINIMA = Convert.ToInt32(txtQtdMinima.Text);
            salvar.InsertStore();

        }

        private void CleanFields()
        {
            txtNomeProduto.Clear();
            cmbImposto.Text = "";
            txtFamilia.Clear();
            txtFornecedor.Clear();
            txtDescricao.Clear();
            DtmValidade.Value = DateTime.Now;
            txtCodigoPrateleira.Clear();
            txtCodigoBarras.Clear();
            txtQtdEntrada.Clear();
            txtQtdMinima.Clear();
            txtOrigem.Clear();
            txtUnidade.Clear();
            txtPrecoUnitario.Clear();
            cmbSelecioneProduto.Text="";
            txtSelecionePeloCodigoBarras.Clear();

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerStore prod = new ControllerStore();
                prod.NOME_MEDICAMENTO = txtNomeProduto.Text;
                prod.ID_FUNCIONARIO = this.codFunc;
                prod.ID_AGT = new ControllerAGT().CarregarIdAGT(cmbImposto.Text);
                prod.DESCRICAO = txtDescricao.Text;
                prod.FAMILA = txtFamilia.Text;
                prod.FORNECEDOR = txtFornecedor.Text;
                prod.DATA_VALIDADE = Convert.ToDateTime(DtmValidade.Text);
                prod.CODIGO_PLATILEIRA = txtCodigoPrateleira.Text;
                prod.QUANTIDADE_ENTRADA = Convert.ToInt32(txtQtdEntrada.Text);
                prod.PRECO_UNITARIO = Convert.ToInt32(txtPrecoUnitario.Text);
                prod.UNIDADE = txtUnidade.Text;
                prod.ORIGEM = txtOrigem.Text;
                prod.CODIGO_BARRA = txtCodigoBarras.Text;
                prod.QUANTIDADE_MINIMA = Convert.ToInt32(txtQtdMinima.Text);
                prod.UpdateStore(cmbSelecioneProduto.Text);
                CleanFields();
                MessageBox.Show("Dados Actualizados com sucesso!");
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var dados = new ControllerStore();
                dados.NOME_MEDICAMENTO = txtNomeProduto.Text;
                dados.DeleteStore();
                CleanFields();
                MessageBox.Show("Dados Deletados com sucesso!");
                ListarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void txtProdutoNaoDisponibilizado_TextChanged(object sender, EventArgs e)
        {
            var filtrarNome = new ControllerStore();
            filtrarNome.NOME_MEDICAMENTO = txtProdutoNaoDisponibilizado.Text;
            dgvDisponibilizar.DataSource = filtrarNome.ListarStorePorNome();
        }

        private void txtPesqProduto_TextChanged(object sender, EventArgs e)
        {
            var filtrarNome = new ControllerProduct();
            filtrarNome.NOME_MEDICAMENTO = txtPesqProduto.Text;
            dvgProdutos.DataSource = filtrarNome.ListarStorePorNome();
        }

        private void txtQuantidadeDesejada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnDisponibilizar_Click(object sender, EventArgs e)
        {
            if (txtQuantidadeDesejada.Text.Equals(""))
            {
                MessageBox.Show("insira a quantidade que deseja disponibilizar!");

            }
            else if (Convert.ToInt32(txtQuantidadeDesejada.Text)>Quantidade())
            {
                MessageBox.Show("Verifique a Quantidade que desejas Adicionar");
                return;
            }
            else
            {
                int n=QuantidadeExistente(dvgProdutos, NomeProduto());
                ControllerStore store = new ControllerStore();
                DataTable dadosCampos = store.ListarProdutosArmazem(NomeProduto());
                var prod = new ControllerProduct();
                prod.NOME_MEDICAMENTO = dadosCampos.Rows[0][2].ToString();
                prod.ID_FUNCIONARIO = Convert.ToInt32(dadosCampos.Rows[0][1].ToString());
                prod.DESCRICAO = dadosCampos.Rows[0][3].ToString();
                prod.DATA_VALIDADE = Convert.ToDateTime(dadosCampos.Rows[0][4].ToString());
                prod.FAMILA = dadosCampos.Rows[0][5].ToString();
                prod.FORNECEDOR = dadosCampos.Rows[0][6].ToString();
                prod.CODIGO_PLATILEIRA = dadosCampos.Rows[0][7].ToString();
                prod.QUANTIDADE_ENTRADA = Convert.ToInt32(txtQuantidadeDesejada.Text);
                prod.QUANTIDADE_MINIMA = Convert.ToInt32(dadosCampos.Rows[0][9].ToString());
                prod.PRECO_UNITARIO = Convert.ToInt32(dadosCampos.Rows[0][10].ToString());
                prod.ID_AGT = Convert.ToInt32(dadosCampos.Rows[0][11].ToString());
                prod.UNIDADE = dadosCampos.Rows[0][12].ToString();
                prod.ORIGEM = dadosCampos.Rows[0][13].ToString();
                prod.CODIGO_BARRA = dadosCampos.Rows[0][14].ToString();
                prod.QUANTIDADE_OUTRO = Convert.ToInt32(txtQuantidadeDesejada.Text);
                prod.QUANTIDADE_ACRESCENTAR = Convert.ToInt32(txtQuantidadeDesejada.Text) + QuantidadeExistente(dvgProdutos, NomeProduto());
                // MessageBox.Show(QuantidadeExistente(dataGridView2, NomeProduto()).ToString());
                prod.InsertProduct();
                store.DisponibilizarProduto(NomeProduto(), Quantidade(), Convert.ToInt32(txtQuantidadeDesejada.Text));
                Adicionar();
                //ReajustarQuantidade(dataGridView1, Convert.ToInt32(txtQuantidadeDesejada.Text));
                MessageBox.Show("Dados Disponibilizados!");
                this.ListarProdutos();
            }

        }
        public int Quantidade()
        {
            int index = dgvDisponibilizar.CurrentRow.Index;
            return Convert.ToInt32(dgvDisponibilizar.Rows[index].Cells[1].Value);
        }
        private int QuantidadeExistente(DataGridView dgv, string nome)
        {
            int res = -1;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                if (dgv.Rows[i].Cells[0].Value.Equals(nome))
                {
                    res = Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                    break;
                }

            }
            return res;
        }
        public string NomeProduto()
        {
            int index = dgvDisponibilizar.CurrentRow.Index;
            return dgvDisponibilizar.Rows[index].Cells[0].Value.ToString();
        }
        public void ListarProdutosExpirados()
        {
            
            dgvProdutosExpirados.DataSource = new ControllerProduct().ListarProdutosExpirados(DateTime.Now);
            ProdutosExpirados();
            lbl_quantExpirados.Text = Convert.ToString("Quantidade de Produtos Fora do Prazo de Validade "+dgvProdutosExpirados.RowCount);
        }
        public void Adicionar()
        {
            dvgProdutos.DataSource = new ControllerProduct().ListarProdutosArmazem();
            this.Refresh();


        }

        private void txtQuantidadeDesejada_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQtdEntrada_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQtdEntrada_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtQtdEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtQtdMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecoUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void frmArmazem_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void cmbSelecioneProduto_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void cmbSelecioneProduto_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < dgvProdutosExpirados.Rows.Count; i++)
            {

                dgvProdutosExpirados.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                //dvgProdutos.Rows[i].ReadOnly = true;


            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            
            Form fr = new Form();
            try
            {
                int index = dvgProdutos.CurrentRow.Index;
                using (frmActualizacoes list = new frmActualizacoes( dvgProdutos.Rows[index].Cells[0].Value.ToString()))
                {
                    fr.StartPosition = FormStartPosition.CenterScreen;
                    fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    fr.Opacity = .70d;
                    fr.BackColor = Color.Black;
                    fr.Size = new System.Drawing.Size(1028, 631);
                    // fr.WindowState = FormWindowState.Maximized;
                    fr.TopMost = true;
                    fr.Location = this.Location;
                    fr.ShowInTaskbar = false;
                    fr.Show();
                    list.Owner = fr;
                    list.ShowDialog();
                    fr.Dispose();

                }
            }
            catch (Exception) { }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
           
            
            Form fr = new Form();
            try
            {
                int index = dgvProdutosExpirados.CurrentRow.Index;
                using (frmActualizacoes list = new frmActualizacoes(dgvProdutosExpirados.Rows[index].Cells[0].Value.ToString()))
                {
                    fr.StartPosition = FormStartPosition.CenterScreen;
                    fr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    fr.Opacity = .70d;
                    fr.BackColor = Color.Black;
                    fr.Size = new System.Drawing.Size(1028, 631);
                    // fr.WindowState = FormWindowState.Maximized;
                    fr.TopMost = true;
                    fr.Location = this.Location;
                    fr.ShowInTaskbar = false;
                    fr.Show();
                    list.Owner = fr;
                    list.ShowDialog();
                    fr.Dispose();

                }
            }
            catch (Exception) { }
        }

        private void dvgProdutos_Click(object sender, EventArgs e)
        {
            dvgProdutos.Refresh();
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            dgvProdutosExpirados.Refresh();
        }

        private void dvgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbSelecioneProduto_Click(object sender, EventArgs e)
        {
           
        }

        private void cmbSelecioneProduto_MouseEnter(object sender, EventArgs e)
        {
            cmbSelecioneProduto.Items.Clear();
            cmbSelecioneProduto.Items.AddRange(new ControllerStore().SelectStores().ToArray());
        }
        }
       
    }


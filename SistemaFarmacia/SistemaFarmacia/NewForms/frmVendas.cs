using Controllers;
using SistemaFarmacia.ControlesFactura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.NewForms
{
    public partial class frmVendas : Form
    {
        ControllerSelling selling = new ControllerSelling();
        double Total = 0, totalHistorico = 0;
        int totalProdHistorico = 0;
        double totalTPA = 0;
        double totalMAO = 0;
        int codigo = 0;
        string formaPagamento = "";
        int valor1, numerofactura=0;
        //int contador = 0;
        int totalVenda = 0;
        public int ID_Func;
        public frmVendas(int id = -1)
        {
            InitializeComponent();
            PortasUSB();
            cmbSelecioneProduto.Items.AddRange(new ControllerProduct().SelectProducts().ToArray());
            this.ID_Func = id;
            lblNomeFuncionarioAct.Text = new ControllerUser().selectedUserActive(id);
            carregarDados();
            calcularTotal();
            carregarHistorico();
            calcularTotalDoHistorico();
            lbl_erro.Visible = false;
            dgvGerentes.DataSource = new ControllerManager().ListarManager();
            preencher();
            carregarDidiva();
            txtCodigoBarras.Focus();
            dvgProd.DataSource = new ControllerProduct().ListarProdutosArmazem2();

 
        }

        private void txtQuantidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                adicionarqtd();
            }
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       
        private void adicionarqtd()
        {
            try
            {
            if (txtQuantidade.Text.Equals(string.Empty)) txtQuantidade.Text = "1";
            else if (Convert.ToInt32(txtQuantidade.Text) > ControllerProduct.QuantidadeDisponivel(cmbSelecioneProduto.Text))
                {
                    MessageBox.Show("Verifique a quantidade que deseja Adicionar");
                    return;
                }
                else
                if (ControllerProduct.QuantidadeDisponivel(cmbSelecioneProduto.Text) < ControllerProduct.QuantMinima(cmbSelecioneProduto.Text))
                {
                    if (MessageBox.Show("Pergunta", "Limite do stock minimo atingido!\n\nDesejas continuar?",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (Convert.ToDouble(txValorPagar.Text) < Total)
                            adicionar();
                        return;
                    }
                    return;
                }
                else
                    adicionar();

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique o Preenchimento de campos", "Informação", MessageBoxButtons.OK);
            }
        }
      
        private void preencher()
        {
            lblDadoVenda.Text = string.Empty;
            lblDadoVenda.Text = selling.DadosVendaDiaria();
        }

        //--------------------------------------------------------------
       
        ControllerProduct dados = new ControllerProduct();
        public void AddProduct(DataGridView dgv, string produtos)
        {
            int quant = 0;
            #region CONTROLE ADICIONAR
            if (string.IsNullOrEmpty(produtos)) return;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[0].Value == null) break;

                if (produtos.Equals(dgv.Rows[i].Cells[1].Value.ToString()))
                {
                   
                    if (dados.QuantDesejada == 0)
                    {
                         
                       quant = int.Parse(dgv.Rows[i].Cells[2].Value.ToString()) + 1;
                       
                        
                    }
                    else
                        quant = int.Parse(dgv.Rows[i].Cells[2].Value.ToString()) + dados.QuantDesejada;
                       dgv.Rows[i].Cells[2].Value = quant;
                       dgv.Rows[i].Cells[4].Value = (quant*Convert.ToInt16(dgv.Rows[i].Cells[3].Value.ToString()));

                   
                    return;
                }
            }
            dgv.Rows.Add(new ControllerProduct().ListarProdutos(produtos,Convert.ToInt32(txtQuantidade.Text)).ToArray());
            #endregion
        }
        private void adicionar()
        {
            if ((txtQuantidade.Text.Equals(string.Empty)|| Convert.ToInt32(txtQuantidade.Text)==0)) dados.QuantDesejada = 0;
            else dados.QuantDesejada = Convert.ToInt32(txtQuantidade.Text);

            this.AddProduct(dgvProdutos, cmbSelecioneProduto.Text);
            lblTotal.Text = this.TotalPagar(dgvProdutos);
            if (cmbOpcaoPagamento.Text.Equals("TPA"))
            {
                txValorPagar.Text = this.TotalPagar1(dgvProdutos);
                txValorPagar.ReadOnly = true;
            }
            else
                if (cmbOpcaoPagamento.Text.Equals("Pronto Pagamento"))
                {
                    txValorPagar.ReadOnly = false;


                }
            txtQuantidade.Clear();
        }
        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            adicionarqtd();
        }

        private void txValorPagar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txValorPagar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txValorPagar.Text) || TotalPagarNumero(dgvProdutos) == 0) return;
                lblTroco.Text = new ControllerProduct().CalcularTroco(TotalPagarNumero(dgvProdutos).ToString(), Convert.ToDouble(txValorPagar.Text));
            }
            catch (Exception)
            {
            }
        }
       
        public double TotalPagarNumero(DataGridView dgv)
        {
            int valor = 0;
            if (dgv.Rows.Count < 1) valor = 0;
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    int x1 = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                    int x2 = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                    valor += x1 * x2;
                }

            }
            return (valor);
        }
        public string TotalPagar1(DataGridView dgv)
        {


            int valor = 0;
            if (dgv.Rows.Count < 1) valor = 0;
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    int x1 = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                    int x2 = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                    valor += x1 * x2;

                }
                //dados.TotalValorPagar = valor;
            }
            return string.Format("{0}", (valor).ToString());
        }
        private double valor()
        {

            double total = 0;
            for (int i = 0; i < dgvProdutos.Rows.Count; i++)
            {
                total += Convert.ToDouble(Convert.ToDouble(dgvProdutos.Rows[i].Cells[2].Value) * Convert.ToDouble(dgvProdutos.Rows[i].Cells[3].Value));
            }
            return total;
        }

        public void Adicionar()
        {

            var tbLogin = dados.AdicionarProduto(txtCodigoBarras.Text);
            lblAviso.Visible = tbLogin.Rows.Count == 0;
            if (tbLogin.Rows.Count == 0) return;
            //======================================================================================
            #region BUSCAR DADOS COM COMANDO LINQ
            var Dados = from dado in tbLogin.AsEnumerable()
                        select new
                        {
                            ID = dado.Field<int>("id"),
                            NomeMedicamento = dado.Field<string>("Nome_Medicamento"),
                            Preco = dado.Field<int>("Preco_Unitario"),
                           // Unidade = dado.Field<string>("Unidade")
                        };
            #endregion
            //======================================================================================
            List<string> lista = new List<string>();
            #region LAÇO ADICIONAR DADOS NA LISTA
            foreach (var item in Dados)
            {
                dados.ID_PRODUTO = item.ID;
                lista.Add(item.ID.ToString());
                lista.Add(item.NomeMedicamento);
                lista.Add("1");
                lista.Add(item.Preco.ToString());
                lista.Add(Convert.ToInt16(item.Preco*1).ToString());
            }
            #endregion
            //======================================================================================
            #region CONTROLE ADICIONAR

            for (int i = 0; i < dgvProdutos.Rows.Count; i++)
            {
                if (dgvProdutos.Rows[i].Cells[0].Value == null) break;
               
                if (dados.ID_PRODUTO == Convert.ToInt32(dgvProdutos.Rows[i].Cells[0].Value.ToString()))
                {
                   
                    int quant = int.Parse(dgvProdutos.Rows[i].Cells[2].Value.ToString()) + 1;
                    dgvProdutos.Rows[i].Cells[2].Value = quant;
                    dgvProdutos.Rows[i].Cells[4].Value = (quant * Convert.ToInt16(dgvProdutos.Rows[i].Cells[3].Value.ToString()));
                    return;
                }
            }
            dgvProdutos.Rows.Add(lista.ToArray());

            #endregion

        }
        private void adicionarPorCodBarra()
        {
            if (txtCodigoBarras.Text.Equals(string.Empty)) return;
            this.Adicionar();
            lblTotal.Text = this.TotalPagar(dgvProdutos);
            if (cmbOpcaoPagamento.Text.Equals("TPA"))
            {
                txValorPagar.Text = this.TotalPagar1(dgvProdutos);
                txValorPagar.ReadOnly = true;
            }
            else
                if (cmbOpcaoPagamento.Text.Equals("Pronto Pagamento"))
                {
                    txValorPagar.ReadOnly = false;
                    txtCodigoBarras.Clear();

                }

        }
        public string TotalPagar(DataGridView dgv)
        {
            int valor = 0;
            if (dgv.Rows.Count < 1) valor = 0;
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    int x1 = int.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                    int x2 = int.Parse(dgv.Rows[i].Cells[3].Value.ToString());
                    valor += x1 * x2;
                }

            }
            return string.Format("{0}", (valor).ToString("C2"));
        }
      
        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                lblProforma.Visible = false;
             
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtQuantidade.Text.Equals(string.Empty)) txtQuantidade.Text = "1";
                    else if (Convert.ToInt32(txtQuantidade.Text) > ControllerProduct.QuantidadeDisponivel(cmbSelecioneProduto.Text))
                    {
                        MessageBox.Show("Verifique a quantidade que deseja Adicionar");
                        return;
                    }
                    else { }
                    //if (ControllerProduct.QuantidadeDisponivelBarra(txtCodigoBarras.Text) < ControllerProduct.QuantidadeMinimaBarra(txtCodigoBarras.Text))
                    //{
                    //    if (MessageBox.Show("Pergunta", "Limite do stock minimo atingido!\n\nDesejas continuar?") == DialogResult.OK)
                    //    {


                    adicionarPorCodBarra();
                    txtCodigoBarras.Clear();
                    txtQuantidade.Clear();
                    //    }
                    //    return;
                    //}
                    //adicionarPorCodBarra();
                    //if (!string.IsNullOrEmpty(txValorPagar.Text))
                    //{
                    //    if (Convert.ToDouble(txValorPagar.Text) >= valor())
                    //        lblTroco.Text =(Convert.ToDouble(txValorPagar.Text) - valor()).ToString("C2");
                    //    return;
                    //}
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCodigoBarras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmbSelecioneProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                lblProforma.Visible = false;
                if (e.KeyCode == Keys.Enter)
                {
                    btnAdicionar_Click(this, EventArgs.Empty);

                    if (!string.IsNullOrEmpty(txValorPagar.Text))
                    {
                        if (Convert.ToDouble(txValorPagar.Text) >= valor())
                            lblTroco.Text = (Convert.ToDouble(txValorPagar.Text) - valor()).ToString("C2");
                        return;
                    }

                }
                txtQuantidade.Clear();

            }
            catch (Exception)
            {
            }
        }

        private void cmbOpcaoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-----------------------------------------------------------
            if (cmbOpcaoPagamento.Text.Equals("TPA"))
            {
                string valor = (this.TotalPagar1(dgvProdutos));
                if (Convert.ToDouble(valor) == 0)
                {
                    txValorPagar.ReadOnly = true;
                    txValorPagar.Text = "";
                }
                else
                    formaPagamento = "TPA";
                    txValorPagar.Text = this.TotalPagar1(dgvProdutos);
                txValorPagar.ReadOnly = true;
            }
            else
                if (cmbOpcaoPagamento.Text.Equals("Pronto Pagamento"))
                {
                    txValorPagar.ReadOnly = false;
                    formaPagamento = "Pronto Pagamento";

                }
            //-----------------------------------------------------------
        }
        public void carregarDados()
        {

            dgvDevolver.DataSource = SelectDevolucao.CarregarDados(this.ID_Func);
            dgvDevolver.Columns["ID_Venda"].Visible = false;
            dgvDevolver.Columns["ID"].Visible = false;
            dgvProdutos.Columns["ID"].Visible = false;
            dgvDevolver.Columns["Preco"].Visible = false;
           
        }
        private void LimparTodosCampos()
        {
            txtQuantidade.Clear();
            txValorPagar.Clear();
            dgvProdutos.Rows.Clear();
            txtCliente.Clear();
            txtCodigoBarras.Clear();
            cmbOpcaoPagamento.Text = "";
            cmbSelecioneProduto.Text = "";
            lblTroco.Text = ControleMoeda.Moeda(0);
            lblTotal.Text = ControleMoeda.Moeda(0);
            txtCliente.Clear();
        }
        public void calcularTotal()
        {
            if (dgvDevolver.Rows.Count < 0) return;
            totalVenda = 0;
            for (int i = 0; i < dgvDevolver.Rows.Count; i++)
            {
                totalVenda += Convert.ToUInt16(dgvDevolver.Rows[i].Cells[4].Value);

            }
            lbl_totalVenda.Text = "Total de Produtos Vendidos: " + totalVenda;
            valor1 = totalVenda;

        }
        public void carregarHistorico()
        {

            dgvHistorico.DataSource = SelectHistoricoVenda.CarregarDadosHistoricos(this.ID_Func);
        }
        public void calcularTotalDoHistorico()
        {
            if (dgvHistorico.Rows.Count < 0) return;
            totalProdHistorico = 0;
            totalHistorico = 0;
            totalTPA = 0;
            totalMAO = 0;
            for (int i = 0; i < dgvHistorico.Rows.Count; i++)
            {
                if (dgvHistorico.Rows[i].Cells[4].Value.ToString().Equals("Pronto Pagamento"))
                {
                    totalMAO += Convert.ToDouble(dgvHistorico.Rows[i].Cells[2].Value);
                }
                else
                {
                    totalTPA += Convert.ToDouble(dgvHistorico.Rows[i].Cells[2].Value);
                }
                totalProdHistorico += Convert.ToInt32(dgvHistorico.Rows[i].Cells[1].Value);
                totalHistorico += Convert.ToDouble(dgvHistorico.Rows[i].Cells[2].Value);

            }
            lbltotalpro.Text = "Total de Produtos Vendidos: " + totalProdHistorico;
            lblTotalTPA.Text =  string.Format("Total Pagamento TPA: {0:c}"  , totalTPA);
            lblTotalMao.Text = string.Format("Total Pagamento Manual: {0:c}", totalMAO);
            lbltotalpro.Text = "Total de Produtos Vendidos: " + totalProdHistorico;
            lblTotalHist.Text = string.Format("Total de Vendas: {0:c}", totalHistorico);
            valor1 = totalVenda;

        }

        public void Vender(DataGridView dgv, string nome, string totalPagar, string tipoPagamento)
        {
            selling.ID_FUNCIONARIO = this.ID_Func;
            try
            {

                DiminuirStock(dgv);
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    selling.ID_PRODUTO = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                    selling.QUANTIDADE_VENDA = Convert.ToInt32(dgv.Rows[i].Cells[2].Value);
                    selling.NOME_CLIENTE = nome;
                    int valor = Convert.ToInt32(dgv.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv.Rows[i].Cells[3].Value);


                    selling.SaveSelling(selling.ID_PRODUTO, selling.ID_FUNCIONARIO, selling.QUANTIDADE_VENDA, valor.ToString(), tipoPagamento);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }
        }

        public void Dever(DataGridView dgv, string nome, string totalPagar)
        {
            selling.ID_FUNCIONARIO = this.ID_Func;
            //try
            //{

                DateTime data = Convert.ToDateTime(DateTime.Now.ToShortDateString());
               
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    selling.ID_PRODUTO = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                    selling.QUANTIDADE_VENDA = Convert.ToInt32(dgv.Rows[i].Cells[2].Value);
                    int Preco = Convert.ToInt32(dgv.Rows[i].Cells[3].Value);
                    selling.NOME_CLIENTE = nome;
                    int valor = Convert.ToInt32(dgv.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv.Rows[i].Cells[3].Value);


                    selling.SaveDivida(selling.ID_PRODUTO, selling.ID_FUNCIONARIO, selling.QUANTIDADE_VENDA, Convert.ToInt16( valor.ToString()),codigo,data,Preco);

                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Aviso");
            //}
        }
        private void DiminuirStock(DataGridView dgv)
        {
            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value == null) break;
                    int Quant = Convert.ToInt32(dgv.Rows[i].Cells[2].Value);
                    dados.ID_PRODUTO = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                    //=================================================================================
                    dados.QUANTIDADE_ENTRADA = SelectQuantidade.QuantidadeDisponivel(dados.ID_PRODUTO) - Quant;
                    //=====================================================================================
                    UpdateQuantidade.UpdateQuantidadeProduto(dados.QUANTIDADE_ENTRADA, dados.ID_PRODUTO);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aviso", ex.Message);
            }
        }
        
        private void btnVender_Click(object sender, EventArgs e)
        {
            ControllerFactura factura = new ControllerFactura();
            try
            {

                double valorTotal = Convert.ToDouble(this.TotalPagar1(dgvProdutos));
                double valorPago = Convert.ToDouble(txValorPagar.Text);


                if ((valorPago >= valorTotal) && (valorTotal > 0))
                {
                   
                        
                        this.Vender(dgvProdutos, txtCliente.Text, this.TotalPagar1(dgvProdutos), cmbOpcaoPagamento.Text);
                        preencher();
                        if (MessageBox.Show("Venda Efectuada com sucesso!\n\nDesejas Imprimir a factura?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                        {
                           
                            carregarDados();
                            calcularTotal();
                            carregarHistorico();
                            LimparTodosCampos();
                            calcularTotalDoHistorico();
                            
                            return;
                        }
                        else
                        {
                                  // numerofactura = factura.NumeroFactura();
                                using (var pd = new System.Drawing.Printing.PrintDocument())
                                {

                                    pd.PrinterSettings.PrinterName = "POS-80C";
                                  //pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
                                    pd.PrintPage += printDocument2_PrintPage;
                                    pd.Print();
                                    
                                }
                               
                           //  timer1.Enabled = true;
                            carregarDados();
                            calcularTotal();
                            carregarHistorico();
                            calcularTotalDoHistorico();
                            LimparTodosCampos();
                        
                            
                        }


                    
                  

                }
                else
                {
                    //frmMessageBox frm = new frmMessageBox("Valor pago insuficiente para venda!", "Aviso");
                    //frm.ShowDialog();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Verifica Todos os Campos!!!");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            FacturaProForma.imprimirFactura(lblTotal.Text, e, dgvProdutos, txtCliente.Text, ID_Func);
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (cmbOpcaoPagamento.Text.Equals(""))
                formaPagamento = "Pronto Pagamento";
            FacturaProForma.imprimirFacturaPrincipal(lblTotal.Text, ControleMoeda.Moeda(Convert.ToInt32(txValorPagar.Text)), lblTroco.Text, e, dgvProdutos, txtCliente.Text, ID_Func, formaPagamento);
        }

        public  void relatorioFinal(System.Drawing.Printing.PrintPageEventArgs p)
        {
            
            RelatorioFinal.imprimirFacturaFinal(lblTotalHist.Text, lblTotalTPA.Text, lblTotalMao.Text,p , ID_Func);
        }

        public void RemoverLinha(DataGridView dgv)
        {
            try
            {
                if (dgv.Rows[0].Cells[0].Value == null) return;
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
            }
            catch (Exception)
            {
                MessageBox.Show("Não existe produtos para serem removidos!");
            }
        }
        private void Operacoes()
        {
            try
            {

                Total = 0;

                if (dgvProdutos.Rows.Count == 0)
                {
                    lblTotal.Text = lblTroco.Text = ControleMoeda.Moeda(0);
                }
                else
                {
                    lblTroco.Text = "";
                    lblTotal.Text = "";
                    for (int i = 0; i < dgvProdutos.Rows.Count; i++)
                    {
                        Total += Convert.ToDouble(Convert.ToDouble(dgvProdutos.Rows[i].Cells[2].Value) * Convert.ToDouble(dgvProdutos.Rows[i].Cells[3].Value));
                    }


                    lblTotal.Text = ControleMoeda.Moeda((int)Total);
                    if (string.IsNullOrEmpty(txValorPagar.Text))
                    {
                        lblTroco.Text = ControleMoeda.Moeda(0);
                    }
                    else
                        if (Convert.ToDouble(txValorPagar.Text) <= Total || string.IsNullOrEmpty(txValorPagar.Text))
                        {
                            lblTroco.Text = ControleMoeda.Moeda(0);
                        }


                        else
                        {

                            lblTroco.Text = string.Format("{0}", ControleMoeda.Moeda((int)(Convert.ToDouble(txValorPagar.Text) - Total)));
                        }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
                return;
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            RemoverLinha(dgvProdutos);
            Operacoes();
        }

        private void btnProforma_Click(object sender, EventArgs e)
        {
            try
            {
                lblProforma.Visible = dgvProdutos.Rows.Count == 0;
                if (dgvProdutos.Rows.Count == 0) { return; }

                if (MessageBox.Show("Desejas Visualizar apenas\nOu Imprimir factura ProForma?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var pd = new System.Drawing.Printing.PrintDocument())
                    {
                        pd.PrinterSettings.PrinterName = "POS-80C"; //POS-80C
                        pd.PrintPage += printDocument1_PrintPage;
                        pd.Print();
                    }
                    LimparTodosCampos();
                }
                else
                {
                    printPreviewDialog1.ShowDialog();
                    LimparTodosCampos();
                }
        }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            var filtrarNome = new ControllerStore();
            filtrarNome.NOME_MEDICAMENTO = txtNomeProduto.Text;
            dgvDevolver.DataSource = filtrarNome.listarPorNomeProdutosVendidos();
        }

        private void txtQuantidadeDevolver_TextChanged(object sender, EventArgs e)
        {
            //=============================================================================
            try
            {

                int indexSelect = dgvDevolver.CurrentRow.Index;

                int prodDevolver = Convert.ToInt16(txtQuantidadeDevolver.Text);
                int quantFinal;
                if ((prodDevolver <= 0) || (prodDevolver > Convert.ToInt16(dgvDevolver.Rows[indexSelect].Cells[4].Value)))
                {
                    dgvDevolver.Refresh();
                    carregarDados();
                    return;
                }

                else
                {

                    quantFinal = Convert.ToInt16(dgvDevolver.Rows[indexSelect].Cells[4].Value) - prodDevolver;

                }

                dgvDevolver.Rows[indexSelect].Cells[5].Value = Convert.ToInt16(dgvDevolver.Rows[indexSelect].Cells[2].Value) * quantFinal;

            }
            catch (Exception)
            {
                carregarDados();
            }
            //=============================================================================
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {

                int indexSelect = dgvDevolver.CurrentRow.Index;
                int quant = Convert.ToInt16(txtQuantidadeDevolver.Text);
                int IdPro = Convert.ToInt32(dgvDevolver.Rows[indexSelect].Cells[7].Value);
                int valorpago = Convert.ToInt16(dgvDevolver.Rows[indexSelect].Cells[5].Value);
                int IDVenda = Convert.ToInt32(dgvDevolver.Rows[indexSelect].Cells[0].Value);
                int quanti = Convert.ToInt16(dgvDevolver.Rows[indexSelect].Cells[4].Value);
                int quantDevolver = Convert.ToInt32(txtQuantidadeDevolver.Text);
                if ((quant <= 0) || (quant > quanti))
                {
                    lbl_erro.Visible = true;
                    //timer1.Enabled = true;
                    return;
                }
                else
                {
                    SelectDevolucao.Devolver(indexSelect, quant, IDVenda, IdPro, valorpago, quanti);
                    lbl_erro.Visible = true;
                    lbl_erro.Text = "*Devolução Efetuado com sucesso ";
                    preencher();
                    lbl_erro.ForeColor = Color.Green;
                    txtQuantidadeDevolver.Clear();
                    calcularTotal();
                    carregarDados();
                    carregarHistorico();
                    calcularTotalDoHistorico();
                    //timer1.Enabled = true;
                }
            }
            catch (Exception)
            {

                lbl_erro.Visible = true;
                //timer1.Enabled = true;
                return;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        bool ctr = false;
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow item in dgvGerentes.Rows)
            //{
            //    Enviar(lblDadoVenda.Text, item.Cells[1].Value.ToString());
            //}
            //if (ctr)
            //    MessageBox.Show("Messagem enviada com exito!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public  void enviarRelatorio()
        {
            foreach (DataGridViewRow item in dgvGerentes.Rows)
            {
                Enviar(lblDadoVenda.Text, item.Cells[1].Value.ToString());
            }
            if (ctr)
                MessageBox.Show("Conta Fechado Com Sucesso!!!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void PortasUSB()
        {

            try
            {
                cmbPortaUSB.Items.Clear();
                cmbPortaUSB.Items.AddRange(SerialPort.GetPortNames().ToArray());
                if (cmbPortaUSB.Items.Count > 0)
                    cmbPortaUSB.SelectedIndex = 0;
            }
            catch (Exception)
            {

                MessageBox.Show("Verifique se o Modem está conectado ao computador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        ControllerEmpresa DadosEmpresa = new ControllerEmpresa();

        public void Enviar(string mensagem, string telefone)
        {


            try
            {
                using (SerialPort sp = new SerialPort())
                {
                    //sp.PortName = "COM10";
                    sp.PortName = cmbPortaUSB.Text;  //Aqui é onde será passado a porta que será usada para o envio da mensagem

                    sp.Open();

                    sp.WriteLine("AT" + Environment.NewLine);
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CSCS=\"GSM\"" + Environment.NewLine);
                    Thread.Sleep(100);
                    sp.WriteLine("AT+CMGS=\"" + telefone + "\"" + Environment.NewLine);
                    Thread.Sleep(100);
                    sp.WriteLine(string.Format("{0}", DadosEmpresa.ListarDadosEmpresa().Rows[0][1].ToString()
              + Environment.NewLine + mensagem + Environment.NewLine + Char.ConvertFromUtf32(26)));
                    Thread.Sleep(100);
                    sp.Write(new byte[] { 26 }, 0, 1);
                    Thread.Sleep(100);

                    var respose = sp.ReadExisting();

                    if (respose.Contains("ERROR"))
                    {
                        MessageBox.Show("Ocorreu um erro no processo de envio");
                        ctr = false;
                        //MensErro += 1;
                    }
                    else
                    {
                        ctr = true;

                        //MensOK += 1;
                    }
                    sp.Close();

                }


            }
            catch (Exception)
            {
                MessageBox.Show("Ocorreu um erro no processo de envio");
                return;
            }

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            using (var pd = new System.Drawing.Printing.PrintDocument())
            {

                pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
                pd.PrintPage += printDocument2_PrintPage;
                pd.Print();
            }
            
            LimparTodosCampos();
                           
        }

        private void cmbSelecioneProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchProduto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            using (var pd = new System.Drawing.Printing.PrintDocument())
            {

                pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
                pd.PrintPage += printDocument2_PrintPage;
                pd.Print();
                LimparTodosCampos();
               
            }
        }

        private void txtPes_TextChanged(object sender, EventArgs e)
        {
            var filtrarNome = new ControllerProduct() ;
            filtrarNome.NOME_MEDICAMENTO = txtPes.Text;
            dvgProd.DataSource = filtrarNome.ListarStorePorNome();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
         }

        private void cmbPortaUSB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProdutos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //using (var pd = new System.Drawing.Printing.PrintDocument())
            //{

            //   // pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[1];
            //   pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
            //    pd.PrintPage += printDocument2_PrintPage;
            //    pd.Print();
            //}
            //  this.timer1.Enabled = false;
             
        }

        private void dgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int linha = dgvProdutos.CurrentRow.Index;
                if (dgvProdutos.RowCount == 0) return;
                else
                    cmbSelecioneProduto.Text = dgvProdutos.Rows[linha].Cells[1].Value.ToString();
            }
            catch (Exception)
            { }
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
 FacturaProForma.imprimirFacturaDivida(lblTotal.Text, e, dgvProdutos, txtCliente.Text, this.ID_Func,codigo);
        }

        private void printDocument3_PrintPage_1(object sender, PrintPageEventArgs e)
        {
           
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {

                double valorTotal = Convert.ToDouble(this.TotalPagar1(dgvProdutos));
               // double valorPago = Convert.ToDouble(txValorPagar.Text);
                codigo = int.Parse(String.Format("{0}{1}{2}", DateTime.Now.Second, DateTime.Now.Millisecond, DateTime.Now.Minute)); 
                    this.Dever(dgvProdutos, txtCliente.Text, this.TotalPagar1(dgvProdutos));

                    carregarDidiva();
                        
                       
                        // numerofactura = factura.NumeroFactura();
                        using (var pd = new System.Drawing.Printing.PrintDocument())
                        {

                            //pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[1];
                            pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
                            pd.PrintPage += printDocument3_PrintPage;
                            pd.Print();

                        }
                LimparTodosCampos();

            }


            
            catch (Exception)
            {
                MessageBox.Show("Verifica Todos os Campos!!!");
            }
        
        }
       
        public void carregarDidiva()
        {
            try {
               
            }
           catch(Exception ex )
            {
                MessageBox.Show("Não foi possível carrega os dados");
           }
        }
        private void btnDisponibilizar_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_2(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch(Exception ex)
            {
                MessageBox.Show("Verifica o código da factura ");
            }
            
        }

    }
}
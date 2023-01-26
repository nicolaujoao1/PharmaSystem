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
    public partial class frmEmpresa : Form
    {
        public frmEmpresa()
        {
            InitializeComponent();
            cmbSelecioneEmpresa.Items.AddRange(new ControllerEmpresa().SelectEmpresaCorrente().ToArray());
            cmbImposto.Items.AddRange(new ControllerAGT().CarregarDadosAGT().ToArray());
        }

        private void cmbSelecioneEmpresa_MouseClick(object sender, MouseEventArgs e)
        {
            cmbSelecioneEmpresa.Items.Clear();
            cmbSelecioneEmpresa.Items.AddRange(new ControllerEmpresa().SelectEmpresaCorrente().ToArray());
        }

        private void cmbSelecioneEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields();
        }
        private void FillFields()
        {
            var dados = new ControllerEmpresa();
            dados.NOME_EMPRESA = cmbSelecioneEmpresa.Text;
            foreach (DataRow item in dados.SearchEmpresa().Rows)
            {
                txtNomeEmpresa.Text = item[1].ToString();
                txtRazaoSocial.Text = item[2].ToString();
                txtEndereco.Text = item[3].ToString();
                DtmFundacao.Value = Convert.ToDateTime(item[4]);

                txtTelefone.Text = item[6].ToString();
                txtEmail.Text = item[5].ToString();
                txtNIF.Text = item[7].ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                gravarEmpresa();
                MessageBox.Show("Informação gravada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }
        private void gravarEmpresa()
        {
            var dados = new ControllerEmpresa();
            dados.NOME_EMPRESA = txtNomeEmpresa.Text;
            dados.RAZAO_SOCIAL = txtRazaoSocial.Text;
            dados.DATA_FUNDACAO = DtmFundacao.Value;
            dados.ENDERECO_EMPRESA = txtEndereco.Text;
            dados.EMAIL = txtEmail.Text;
            dados.TELFONE = txtTelefone.Text;
            dados.NIF = txtNIF.Text;
            dados.InsertEmpresa();
            LimparCampos();
        }
        private void LimparCampos()
        {
            cmbSelecioneEmpresa.Text = string.Empty;
            txtNomeEmpresa.Clear();
            txtRazaoSocial.Clear();
            DtmFundacao.Value = DateTime.Now;
            txtEndereco.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtNIF.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                ActualizarEmpresa();
                LimparCampos();
                cmbSelecioneEmpresa.Items.Clear();
                MessageBox.Show("Dados actualizados com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }
        private void ActualizarEmpresa()
        {
            var empresa = new ControllerEmpresa();
            empresa.NOME_EMPRESA = txtNomeEmpresa.Text;
            empresa.RAZAO_SOCIAL = txtRazaoSocial.Text;
            empresa.DATA_FUNDACAO = DtmFundacao.Value;
            empresa.ENDERECO_EMPRESA = txtEndereco.Text;
            empresa.EMAIL = txtEmail.Text;
            empresa.TELFONE = txtTelefone.Text;
            empresa.NIF = txtNIF.Text;
            empresa.UpdateEmpresa(cmbSelecioneEmpresa.Text);


        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomTextbox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardarImposto_Click(object sender, EventArgs e)
        {
            try
            {  
                ControllerAGT ctr = new ControllerAGT();
                ctr.Regime = txtRegime.Text;
                ctr.Pais = txtPais.Text;
                ctr.Imposto = txtImposto.Text;
                ctr.DescricaoImposto = txtDescricaoImposto.Text;
                ctr.Taxa = Convert.ToInt32(txtTaixa.Text);
                ctr.Motivo = txtMotivo.Text;
                ctr.MotivoDescricao = txtDescicaoMotivo.Text;
                ctr.InsertAGT();
                MessageBox.Show("Informação gravada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCamposAGT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
          
        }

        private void LimparCamposAGT()
        {
            txtRegime.Clear();
            txtTaixa.Clear();
            txtPais.Clear();
            txtImposto.Clear();
            txtDescricaoImposto.Clear();
            txtDescicaoMotivo.Clear();
            txtMotivo.Clear();

        }

        private void btnActualizarImposto_Click(object sender, EventArgs e)
        {
            try
            {
                ControllerAGT ctr = new ControllerAGT();
                ctr.Regime = txtRegime.Text;
                ctr.Pais = txtPais.Text;
                ctr.Imposto = txtImposto.Text;
                ctr.DescricaoImposto = txtDescricaoImposto.Text;
                ctr.Taxa = Convert.ToInt32(txtTaixa.Text);
                ctr.Motivo = txtMotivo.Text;
                ctr.MotivoDescricao = txtDescicaoMotivo.Text;
                ctr.UpdateImposto(cmbImposto.Text);
                MessageBox.Show("Informação gravada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCamposAGT();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
          
        }

        private void cmbImposto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dados = new ControllerAGT();
            foreach (DataRow item in dados.CarregarDadosAGT(cmbImposto.Text).Rows)
            {
                 txtRegime.Text=item[1].ToString();
                 txtPais.Text=item[2].ToString(); ;
                 txtImposto.Text = item[3].ToString();
                 txtDescricaoImposto.Text = item[4].ToString();
                 txtTaixa.Text = item[5].ToString();
                 txtMotivo.Text = item[6].ToString();
                 txtDescicaoMotivo.Text = item[7].ToString();
                
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmFuncionarios : Form
    {
        public frmFuncionarios()
        {
            InitializeComponent();
            cmbSelecioneFuncionario.Items.AddRange(new ControllerUser().SelectUsers().ToArray());
        }

        private void cmbSelecioneFuncionario_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillFields();
        }
        private void FillFields()
        {
            var dados = new ControllerUser();
            dados.NOME_COMPLETO = cmbSelecioneFuncionario.Text;
            foreach (DataRow item in dados.SearchUser().Rows)
            {
                txtNome.Text = item[1].ToString();
                //txtEndereco.Text = item[2].ToString();
                DtmNascimento.Value = Convert.ToDateTime(item[3]);
                cmbSexo.Text = item[4].ToString();
                txtTelefone.Text = item[5].ToString();
                txtEmail.Text = item[6].ToString();
                txtNumeroBI.Text = item[7].ToString();
                cmbNivelAcesso.Text = item[8].ToString();
                txtUsuario.Text = item[9].ToString();
                txtSenha.Text = item[10].ToString();

            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            string ano = DtmNascimento.Value.ToString();
            int idade = (DateTime.Now.Year - Convert.ToInt32(ano.Substring(6, 4)));
            if (idade < 18)
            {
                MessageBox.Show("Não Podem ser Cadastrados Funcionários Menor a 18 anos de idade!");
                LimparCampos();
                return;
            }
            else
                GravarFuncionario();
            LimparCampos();
            MessageBox.Show("Dados Cadastrados com sucesso!");
           
            dgvFuncionarios.DataSource = new ControllerUser().ListarTodosFuncionarios();
        }
        private void LimparCampos()
        {
            txtEmail.Clear();
            txtNome.Clear();
            DtmNascimento.Value = DateTime.Now;
            cmbSexo.Text="";
            txtTelefone.Clear();
            txtNumeroBI.Clear();
            cmbNivelAcesso.Text="" ;
            txtUsuario.Clear();
            txtSenha.Clear();
            cmbSelecioneFuncionario.Text="";
        }
        public void GravarFuncionario()
        {
            ControllerUser salvar = new ControllerUser();
            salvar.NOME_COMPLETO = txtNome.Text;
            salvar.ENDERECO = txtEmail.Text;
            salvar.DATA_NASCIMENTO = Convert.ToDateTime(DtmNascimento.Text);
            salvar.SEXO = cmbSexo.Text;
            salvar.TELEFONE = txtTelefone.Text;
            salvar.EMAIL = txtEmail.Text;
            salvar.NUMERO_BI = txtNumeroBI.Text;
            salvar.NIVEL_ACESSO = cmbNivelAcesso.Text;
            salvar.USUARIO = txtUsuario.Text;
            salvar.SENHA = txtSenha.Text;
            salvar.InsertUser();
            cmbSelecioneFuncionario.Refresh();
        }
        private void ActualizarFuncionario()
        {
            ControllerUser salvar = new ControllerUser();
            salvar.NOME_COMPLETO = txtNome.Text;
            salvar.ENDERECO = txtEmail.Text;
            salvar.DATA_NASCIMENTO = Convert.ToDateTime(DtmNascimento.Text);
            salvar.SEXO = cmbSexo.Text;
            salvar.TELEFONE = txtTelefone.Text;
            salvar.EMAIL = txtEmail.Text;
            salvar.NUMERO_BI = txtNumeroBI.Text;
            salvar.NIVEL_ACESSO = cmbNivelAcesso.Text;
            salvar.USUARIO = txtUsuario.Text;
            salvar.SENHA = txtSenha.Text;
            salvar.UpdateUser(cmbSelecioneFuncionario.Text);

            cmbSelecioneFuncionario.Refresh();

        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string ano = DtmNascimento.Value.ToString();
            int idade = (DateTime.Now.Year - Convert.ToInt32(ano.Substring(6, 4)));
            if (idade < 18)
            {
                MessageBox.Show("Não Podem ser Cadastrados Funcionários Menor a 18 anos de idade!");
                LimparCampos();
                return;
            }
            else
                ActualizarFuncionario();
            LimparCampos();
            MessageBox.Show("Dados Actualizados com sucesso!");
           
            dgvFuncionarios.DataSource = new ControllerUser().ListarTodosFuncionarios();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var dado = new ControllerUser();
            dado.NOME_COMPLETO = cmbSelecioneFuncionario.Text;
            dado.DeleteUser();
            LimparCampos();
            MessageBox.Show("Dados deletados com sucesso!");
       
            dgvFuncionarios.DataSource = new ControllerUser().ListarTodosFuncionarios();
        }

        private void cmbSelecioneFuncionario_Click(object sender, EventArgs e)
        {

            cmbSelecioneFuncionario.Items.Clear();
            cmbSelecioneFuncionario.Refresh();
            cmbSelecioneFuncionario.Items.AddRange(new ControllerUser().SelectUsers().ToArray());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void frmFuncionarios_Shown(object sender, EventArgs e)
        {
            dgvFuncionarios.DataSource = new ControllerUser().ListarTodosFuncionarios();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefonePesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNomePesquisa_TextChanged(object sender, EventArgs e)
        {
            var dados = new ControllerUser();
            dados.NOME_COMPLETO = txtNomePesquisa.Text;
            dgvFuncionarios.DataSource = dados.ListarFuncionarioPorNome();
        }

        private void txtTelefonePesquisa_TextChanged(object sender, EventArgs e)
        {
            var dados = new ControllerUser();
            dados.TELEFONE = txtTelefonePesquisa.Text;
            dgvFuncionarios.DataSource = dados.ListarFuncionarioPorTelefone();
        }

        private void cmbSelecioneFuncionario_EnabledChanged(object sender, EventArgs e)
        {
            cmbSelecioneFuncionario.Items.Clear();
            cmbSelecioneFuncionario.Items.AddRange(new ControllerUser().SelectUsers().ToArray());
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSenha_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtSenha.UseSystemPasswordChar = false;
        }

        private void txtSenha_MouseLeave(object sender, EventArgs e)
        {
            txtSenha.UseSystemPasswordChar = true;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
     
}

using Controllers;
using Model;
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
    public partial class frmLogin1 : Form
    {
        public frmLogin1()
        {
            InitializeComponent();
            VadidarSistema();
            
        }

        private void frmLogin1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            bunifuTransition1.ShowSync(this);
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuMetroTextbox1_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals(""))
                txtUsuario.Text = "Usuário";
        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("Usuário"))
                txtUsuario.Text = string.Empty;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {

            //if (txtSenha.Text.Equals(string.Empty))
            //{
            //    txtSenha.Text = "Palavra-passe";
            //    txtSenha.isPassword = false;
            //}
            //else
            //    txtSenha.isPassword = true;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin1_Shown(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            try
            {
                Logar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informação");
            }
        }


        private void Logar()
        {
            var dados = new ControllerUser();
            dados.USUARIO = txtUsuario.Text;
            dados.SENHA = txtSenha.Text;
            dados.Logar();
            if (new ModelLevel().NIVEL_DIRECTOR.Equals(dados.NIVEL_ACESSO))
            {
                frmSplashOriginal original = new frmSplashOriginal(dados.ID_FUNCIONARIO);
              
                original.Show();
                Form1 frm = new Form1(dados.ID_FUNCIONARIO);
                this.Hide();
            }
          
            else if (new ModelLevel().NIVEL_FUNCIONARIO.Equals(dados.NIVEL_ACESSO))
            {
                Form1 frm = new Form1(dados.ID_FUNCIONARIO);
                frmSplashOriginal original = new frmSplashOriginal(dados.ID_FUNCIONARIO);
                original.Show();
                original.b2= false;
                original.b3= false;
                original.b5 = false;
                original.b6 = false;
                original.localizacao= new Point(164, 3);
                original.localizacaoPanel4 = new Point(168, 35);

                this.Hide();
              
            }
            else
            {
                lblres.Visible = true;
                txtUsuario.Text = string.Empty;
                txtSenha.Text = string.Empty;

            }
        }



        private void btnEntrar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logar();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logar();
        }
      public  void VadidarSistema()
        {
            if (DateTime.Now.Day >= 30 && DateTime.Now.Month >= 1 && DateTime.Now.Year == 2023)
            {
                lblres.Text = "*Contacte os desenvolvidores do aplicativo!";
                lblres.Visible = true;
                btnEntrar.Enabled = false;
            }
        }
 
      
      private void txtSenha_MouseLeave(object sender, EventArgs e)
      {

          if (txtSenha.Text.Equals(string.Empty))
          {
              txtSenha.Text = "Palavra-passe";
              txtSenha.isPassword = false;
          }
          

      }

      private void txtSenha_Enter(object sender, EventArgs e)
      {
          if (txtSenha.Text.Equals("Palavra-passe"))
            {  txtSenha.Text = string.Empty;
              txtSenha.isPassword=true;
            }
      }
    }
}

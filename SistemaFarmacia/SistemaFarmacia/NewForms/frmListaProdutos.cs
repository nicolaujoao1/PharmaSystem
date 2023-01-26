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
    public partial class frmListaProdutos : Form
    {
        
        int idFuncionario = -1;
        public frmListaProdutos( int id)
        {
            InitializeComponent();
            this.idFuncionario = id;
            ListarProdutosExpirados();
        }

        private void frmListaProdutos_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            bunifuTransition1.ShowSync(this);
            
            
        }
        public void ListarProdutosExpirados()
        {

            dgvProdutosExpirados.DataSource = new ControllerProduct().ListarProdutosExpirados(DateTime.Now);
            ProdutosExpirados();
            lbl_quantExpirados.Text = Convert.ToString("Quantidade de Produtos Fora de Uso ou Perto de Expirarem:" + dgvProdutosExpirados.RowCount);
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void frmListaProdutos_MouseEnter(object sender, EventArgs e)
        {
            ProdutosExpirados();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
    }
}

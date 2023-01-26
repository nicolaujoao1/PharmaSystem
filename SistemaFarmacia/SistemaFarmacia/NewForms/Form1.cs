using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.NewForms
{
    public partial class Form1 : Form
    {
        int codigo;
        frmArmazem listar = new frmArmazem();
        public Form1(int cod = -1)
        {
            InitializeComponent();
            this.codigo = cod;
            //this.btnMaximizarMinimizar.BackgroundImage = Properties.Resources.max;
            //this.btnMaximizarMinimizar.BackgroundImageLayout = ImageLayout.Zoom;
            lblFuncionario.Text = new ControllerUser().selectedUserActive(this.codigo);
            p1.Visible = true;
            this.btMaximizar.Iconimage = Properties.Resources.max;
            label3.Text = Convert.ToString(listar.dgvProdutosExpirados.RowCount);
        }
        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(960, 532);
            panel1.Visible = false;
            panel3.Visible = false;
            addF(new frmFuncionarios(), panel1);
            bunifuTransition1.ShowSync(panel1);
            p1.Visible = false;
            p2.Visible = true;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;


        }
        public void addF(Form f, Panel g)
        {
            f.TopLevel = false;
            g.Controls.Add(f);
            g.Tag = f;
            f.Dock = DockStyle.Fill;
            f.Show();
            f.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(960, 532);
            panel1.Visible = false;
            panel3.Visible = false;
            addF(new frmArmazem(this.codigo), panel1);
            bunifuTransition1.ShowSync(panel1);
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = true;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(960, 532);
            panel3.Visible = false;


            addF(new frmVendas(this.codigo), panel1);


            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = true;
            p5.Visible = false;
            p6.Visible = false;

        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(960, 532);

            panel3.Visible = false;
            addF(new frmRelatorios(this.codigo), panel1);

            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;

            p5.Visible = true;
            p6.Visible = false;

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(960, 532);
            panel3.Visible = false;
            addF(new frmEmpresa(), panel1);
            p1.Visible = false;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = true;

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            this.panel1.Size = new System.Drawing.Size(610, 459);
            panel3.Visible = true;
            addF(new frmInicio1(), panel1);
            p1.Visible = true;
            p2.Visible = false;
            p3.Visible = false;
            p4.Visible = false;
            p5.Visible = false;
            p6.Visible = false;


        }
        bool ctr1 = true;
        private void btnMaximizarMinimizar_Click(object sender, EventArgs e)
        {
            if (ctr1)
            {

                this.Size = Screen.PrimaryScreen.WorkingArea.Size;
                this.Location = Screen.PrimaryScreen.WorkingArea.Location;
                ctr1 = false;
                this.btnMaximizarMinimizar.BackgroundImage = Properties.Resources.max;
                this.btnMaximizarMinimizar.BackgroundImageLayout = ImageLayout.Zoom;

            }
            else
            {

                this.Size = new Size(1316, 689);
                this.WindowState = FormWindowState.Normal;
                this.Location = new Point(25, 19);
                this.btnMaximizarMinimizar.BackgroundImage = Properties.Resources.min;
                this.btnMaximizarMinimizar.BackgroundImageLayout = ImageLayout.Zoom;
                ctr1 = true;
            }
        }

        private void btnTerminarSessao_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Desejas Terminar Sessão?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                new frmLogin1().Show();
                this.Hide();
            }
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Fechar a Conta do Dia?", "Pergunta", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    new frmVendas(this.codigo).enviarRelatorio();
                    imprimirFactura();
                    Application.Exit();

                }
                else

                    Application.Exit();
            }
            catch (Exception)
            {
            }
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            //if (ctr1)
            //{

            //    this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            //    this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            //    ctr1 = false;
            //    this.btMaximizar.Iconimage = Properties.Resources.min;
            //    //this.btMaximizar.Iconimage = ImageLayout.Zoom;

            //}
            //else
            //{

            //    this.Size = new Size(1316, 689);
            //    this.WindowState = FormWindowState.Normal;
            //    this.Location = new Point(25, 19);
            //    this.btMaximizar.Iconimage = Properties.Resources.max;
            //    //this.btMaximizar.BackgroundImageLayout = ImageLayout.Zoom;
            //    ctr1 = true;
            //}
        }
        public void imprimirFactura()
        {
            using (var pd = new System.Drawing.Printing.PrintDocument())
            {

                pd.PrinterSettings.PrinterName = "POS-80C";
                //pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[PrinterSettings.InstalledPrinters.Count - 1];
                pd.PrintPage += printDocument1_PrintPage;
                pd.Print();

            }
        }
        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = string.Concat("   ", DateTime.Now.ToLongTimeString(), "\n", DateTime.Now.ToShortDateString());
        }

        private void bunifuFlatButton10_Click_1(object sender, EventArgs e)
        {
            //frmDesenvolvedor dv = new frmDesenvolvedor();
            //dv.ShowDialog();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void controlExpiracao1_Load(object sender, EventArgs e)
        {

        }

        private void lblVisualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form fr = new Form();
            try
            {
                using (frmListaProdutos list = new frmListaProdutos(this.codigo))
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

        private void lblFechar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = false;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
           
        }








        private void panel4_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            frmVendas venda = new frmVendas(this.codigo);
            venda.relatorioFinal(e);
        }
    }
}
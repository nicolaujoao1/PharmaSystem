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
    public partial class frmSplashOriginal : Form
    {
        frmArmazem arm = new frmArmazem();
        int idFuncionario = -1;
        public bool b2 = true;
        public bool b3 = true;
        public bool b4 = true;
        public bool b5 = true;
        public bool b6 = true;
        public bool devolver = true;
        public Point localizacao= new Point(499, 2);
        public Point localizacaoPanel4 = new Point(508, 35);
        public frmSplashOriginal( int idFunc)
        {
            InitializeComponent();
            this.idFuncionario = idFunc;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                bunifuCircleProgressbar1.Value++;
                if (bunifuCircleProgressbar1.Value == 100)
                {
                    Form1 frm = new Form1(this.idFuncionario);
                    if (arm.dgvProdutosExpirados.RowCount > 0)
                    {
                        
                        frm.Show();
                        frm.panel4.Visible = true;
                        timer1.Enabled = false;
                        this.Hide();
                    }
                    else
                    {
                        frm.Show();
                        frm.panel4.Visible = false;
                        timer1.Enabled = false;
                        this.Hide();
                    }
                    frm.bunifuFlatButton2.Visible =this.b2;
                    frm.bunifuFlatButton3.Visible = this.b3;
                    frm.bunifuFlatButton4.Visible = this.b4;
                    frm.bunifuFlatButton5.Visible = this.b5;
                    frm.bunifuFlatButton6.Visible = this.b6;
                    frm.bunifuFlatButton4.Location = this.localizacao;
                    frm.p4.Location = this.localizacaoPanel4;
                }
                
            }catch(Exception ){
                MessageBox.Show("erro");
            }



        }

        private void frmSplashOriginal_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            bunifuTransition1.ShowSync(this);
        }

        
    }
}

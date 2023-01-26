using Controllers;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.ControlesFactura
{
    public class FacturaProForma
    {

        public static void imprimirFactura(string valor,System.Drawing.Printing.PrintPageEventArgs p, DataGridView dgv, string nomeCliente, int ID)
        {
            ModelEmpresa empr = new ModelEmpresa();
            ControllerEmpresa DadosEmpresa = new ControllerEmpresa();
            DataTable empresa = DadosEmpresa.ListarDadosEmpresa();
            empr.NOME_EMPRESA = empresa.Rows[0][1].ToString();
            empr.ENDERECO_EMPRESA = empresa.Rows[0][3].ToString();
            empr.TELFONE = empresa.Rows[0][6].ToString();
            empr.NIF = empresa.Rows[0][7].ToString();
            //BuscaEmpresaFactura fact = new BuscaEmpresaFactura();
            //fact.BuscaDadosEmpresa();
            string nome = new ControllerUser().selectedUserActive(ID);
            //ControleVenda controleVenda = new ControleVenda();
            string obg = "Obrigado", desejo = "Rápidas Melhoras!";
            StringFormat formato4 = new StringFormat();
            formato4.Alignment = StringAlignment.Center;
            StringFormat formato5 = new StringFormat();
            formato5.Alignment = StringAlignment.Near;
            formato5.LineAlignment = StringAlignment.Far;
            formato4.LineAlignment = StringAlignment.Center;
            #region FORMATOS
            //-------------------------------------------------------------------------
            StringFormat formato1 = new StringFormat();
            formato1.Alignment = StringAlignment.Center;
            formato1.LineAlignment = StringAlignment.Center;
            //-------------------------------------------------------------------------
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Near;
            StringFormat formato3 = new StringFormat();
            formato3.Alignment = StringAlignment.Near;
            formato3.LineAlignment = StringAlignment.Center;

            //-------------------------------------------------------------------------
            StringFormat formato2 = new StringFormat();
            formato2.Alignment = StringAlignment.Near;
            formato2.LineAlignment = StringAlignment.Far;
            #endregion
          
            int eixoX = 35, eixoY =40;
            //Componente de acesso a graficos
            Graphics graphics = p.Graphics;
            ComponentesFactura.minhaPen1.DashStyle = DashStyle.Solid;
            //Desenhar textos e graficos
            graphics.DrawString(String.Format("       FARMÁCIA\n   {0}", empr.NOME_EMPRESA), ComponentesFactura.bold, Brushes.Black, 28, 10);
            eixoY += 0;
            graphics.DrawString(String.Format("Data:{0} / Hora:{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Endereço:{0}", empr.ENDERECO_EMPRESA), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Telefone:{0}", empr.TELFONE), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("NIF:{0}", empr.NIF), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 3;
            graphics.DrawRectangle(ComponentesFactura.minhaPen1, ComponentesFactura.rect);
            graphics.DrawString("FACTURA PRO-FORMA", new Font("Courier", 11, FontStyle.Italic | FontStyle.Bold), new SolidBrush(Color.Black), ComponentesFactura.rect1, formato);
            graphics.DrawString("==========================", ComponentesFactura.bold1, new SolidBrush(Color.Black), ComponentesFactura.rect1, formato4);
            eixoY = 160;
            graphics.DrawString(String.Format("Cliente:{0}", "Indiferente"), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawString("Produto     Quant  Preço  Total", ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            //=================================================================================================
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                Rectangle rect = new Rectangle(eixoX, eixoY, 105, 25);//105; 25
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, rect);
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 105, eixoY, 45, 20));
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 157, eixoY, 57, 20));
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[1].Value.ToString()), ComponentesFactura.regularItens, new SolidBrush(Color.Black), rect, formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[2].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 80, eixoY, 45, 20), formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[3].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 110, eixoY, 57, 20), formato3);//158
                graphics.DrawString(String.Format("{0}", Convert.ToInt32(dgv.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv.Rows[i].Cells[3].Value)), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 145, eixoY, 45, 20), formato3);//135
                eixoY += 25;
            }
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            //graphics.DrawString(String.Format("Valor Pago:  {0}", valorPago), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            //eixoY += 20;
            //graphics.DrawString(String.Format("Troco:           {0}", valor), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            //eixoY += 20;
            graphics.DrawString(String.Format("TOTAL:       {0}", valor), ComponentesFactura.bold3, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            graphics.DrawString(String.Format("Atendente:"), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            graphics.DrawString(String.Format("                  {0}", nome), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX, eixoY, 200, 40));
            graphics.DrawString(String.Format("{0}\n{1}", obg, desejo), ComponentesFactura.bold3, new SolidBrush(Color.Black), new Rectangle(eixoX, eixoY, 200, 40), formato4);
            eixoY += 35;
            SolidBrush s = new SolidBrush(Color.White);
            Rectangle recte = new Rectangle(10, eixoY, 255, 30);
            SolidBrush ss = new SolidBrush(Color.White);
            graphics.FillRectangle(s, recte);
            graphics.DrawString("Processado por computador...\nKambaSoft: 921979783", ComponentesFactura.bold3, ss, 10, eixoY);
            // graphics.DrawString(("Processado por computador...\nKambaSoft"), ComponentesFactura.bold3, new SolidBrush(Color.Red),recte , formato4);
            //(s,eixoX,eixoY,206,30);
            


        }
        public static void imprimirFacturaPrincipal(string valorTotal,string valorPago, string valorTroco, System.Drawing.Printing.PrintPageEventArgs p, DataGridView dgv, string nomeCliente, int ID,string formapagamento)
        {
            ModelEmpresa empr = new ModelEmpresa();
            ControllerFactura fact = new ControllerFactura();
            ControllerEmpresa DadosEmpresa = new ControllerEmpresa();
            DataTable empresa = DadosEmpresa.ListarDadosEmpresa();

            empr.NOME_EMPRESA = empresa.Rows[0][1].ToString();
            empr.ENDERECO_EMPRESA = empresa.Rows[0][3].ToString();
            empr.TELFONE = empresa.Rows[0][6].ToString();
            empr.NIF = empresa.Rows[0][7].ToString();
            //BuscaEmpresaFactura fact = new BuscaEmpresaFactura();
            //fact.BuscaDadosEmpresa();
            string nome = new ControllerUser().selectedUserActive(ID);
            //ControleVenda controleVenda = new ControleVenda();
            string obg = "Obrigado", desejo = "Rápidas Melhoras!";
            #region FORMATOS
            //-------------------------------------------------------------------------
            StringFormat formato1 = new StringFormat();
            formato1.Alignment = StringAlignment.Near;
            formato1.LineAlignment = StringAlignment.Center;
            //-------------------------------------------------------------------------
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Near;
            StringFormat formato3 = new StringFormat();
            formato3.Alignment = StringAlignment.Near;  //near
            formato3.LineAlignment = StringAlignment.Center;// center

            //-------------------------------------------------------------------------
            StringFormat formato2 = new StringFormat();
            formato2.Alignment = StringAlignment.Center;
            formato2.LineAlignment = StringAlignment.Near;

            StringFormat formato4 = new StringFormat();
            formato4.Alignment = StringAlignment.Center;
            formato4.LineAlignment = StringAlignment.Center;

            StringFormat formato5 = new StringFormat();
            formato5.Alignment = StringAlignment.Near;
            formato5.LineAlignment = StringAlignment.Far;
            #endregion
            int eixoX = 35, eixoY =40;//30,70
            //Componente de acesso a graficos
            Graphics graphics = p.Graphics;
            ComponentesFactura.minhaPen1.DashStyle = DashStyle.Solid;
            //Desenhar textos e graficos
            graphics.DrawString(String.Format("       FARMÁCIA\n   {0}", empr.NOME_EMPRESA), ComponentesFactura.bold, Brushes.Black, 28,5);//10
            eixoY += 0;
            graphics.DrawString(String.Format("Data:{0} / Hora:{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Endereço:{0}", empr.ENDERECO_EMPRESA), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Telefone:{0}", empr.TELFONE), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("NIF:{0}", empr.NIF), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 3;//9
            graphics.DrawRectangle(ComponentesFactura.minhaPen1, ComponentesFactura.rect);
            graphics.DrawString("FACTURA DE VENDA", new Font("Courier", 11, FontStyle.Italic | FontStyle.Bold), new SolidBrush(Color.Black), ComponentesFactura.rect1, formato);
            graphics.DrawString("==========================", ComponentesFactura.bold1, new SolidBrush(Color.Black), ComponentesFactura.rect1, formato4);
            eixoY = 160;//240
            graphics.DrawString(String.Format("Cliente:{0}",nomeCliente), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawString(String.Format("Pagamento:{0}", formapagamento), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawString("Produto     Quant  Preço  Total", ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            //=================================================================================================
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                Rectangle rect = new Rectangle(eixoX, eixoY, 105, 25);//105; 25
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, rect);
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 105, eixoY, 45, 20));
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 157, eixoY, 57, 20));
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[1].Value.ToString()), ComponentesFactura.regularItens, new SolidBrush(Color.Black), rect, formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[2].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 80, eixoY, 45, 20), formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[3].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 110, eixoY, 57, 20), formato3);//158
                graphics.DrawString(String.Format("{0}", Convert.ToInt32(dgv.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv.Rows[i].Cells[3].Value)), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 145, eixoY, 45, 20), formato3);//135
                eixoY +=25;
            }
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);//206
            eixoY += 5;
            graphics.DrawString(String.Format("Valor Pago:  {0}", valorPago), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 17;
            graphics.DrawString(String.Format("Troco:           {0}", valorTroco), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 17;
            graphics.DrawString(String.Format("TOTAL:       {0}", valorTotal), ComponentesFactura.bold3, Brushes.Black, eixoX, eixoY);
            eixoY += 17;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            graphics.DrawString(String.Format("Atendente:"), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            graphics.DrawString(String.Format("                  {0}", nome), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;

            graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX, eixoY, 200, 40));
            graphics.DrawString(String.Format("{0}\n{1}", obg, desejo), ComponentesFactura.bold3, new SolidBrush(Color.Black), new Rectangle(eixoX, eixoY, 200, 40), formato4);
            eixoY += 35;
            SolidBrush s = new SolidBrush(Color.White);
            Rectangle recte= new Rectangle(10, eixoY, 255, 30);
            SolidBrush ss = new SolidBrush(Color.White);
            graphics.FillRectangle(s, recte);
            graphics.DrawString("Processado por computador...\nKambaSoft: 921979783",ComponentesFactura.bold3,ss,10,eixoY);
           // graphics.DrawString(("Processado por computador...\nKambaSoft"), ComponentesFactura.bold3, new SolidBrush(Color.Red),recte , formato4);
           //(s,eixoX,eixoY,206,30);
            
        }

        public static void imprimirFacturaDivida(string valorTotal, System.Drawing.Printing.PrintPageEventArgs p, DataGridView dgv, string nomeCliente, int ID, int codigo)
        {
            ModelEmpresa empr = new ModelEmpresa();
            ControllerFactura fact = new ControllerFactura();
            ControllerEmpresa DadosEmpresa = new ControllerEmpresa();
            DataTable empresa = DadosEmpresa.ListarDadosEmpresa();

            empr.NOME_EMPRESA = empresa.Rows[0][1].ToString();
            empr.ENDERECO_EMPRESA = empresa.Rows[0][3].ToString();
            empr.TELFONE = empresa.Rows[0][6].ToString();
            empr.NIF = empresa.Rows[0][7].ToString();
            //BuscaEmpresaFactura fact = new BuscaEmpresaFactura();
            //fact.BuscaDadosEmpresa();
           
            string nome = new ControllerUser().selectedUserActive(ID);
            //ControleVenda controleVenda = new ControleVenda();
            string obg = "Obrigado", desejo = "Rápidas Melhoras!";
            #region FORMATOS
            //-------------------------------------------------------------------------
            StringFormat formato1 = new StringFormat();
            formato1.Alignment = StringAlignment.Near;
            formato1.LineAlignment = StringAlignment.Center;
            //-------------------------------------------------------------------------
            StringFormat formato = new StringFormat();
            formato.Alignment = StringAlignment.Center;
            formato.LineAlignment = StringAlignment.Near;
            StringFormat formato3 = new StringFormat();
            formato3.Alignment = StringAlignment.Near;  //near
            formato3.LineAlignment = StringAlignment.Center;// center

            //-------------------------------------------------------------------------
            StringFormat formato2 = new StringFormat();
            formato2.Alignment = StringAlignment.Center;
            formato2.LineAlignment = StringAlignment.Near;

            StringFormat formato4 = new StringFormat();
            formato4.Alignment = StringAlignment.Center;
            formato4.LineAlignment = StringAlignment.Center;

            StringFormat formato5 = new StringFormat();
            formato5.Alignment = StringAlignment.Near;
            formato5.LineAlignment = StringAlignment.Far;
            Image imagem = Image.FromFile(Application.StartupPath + @"\Logotipo.jpg");
            int largura = imagem.Width / 4;
            int altura = imagem.Height / 4;
            #endregion
            int eixoX = 35, eixoY = 70;//30,70
            //Componente de acesso a graficos
            Graphics graphics = p.Graphics;
            ComponentesFactura.minhaPen1.DashStyle = DashStyle.Solid;
            //Desenhar textos e graficos
            graphics.DrawString(String.Format("       FARMÁCIA\n   {0}", empr.NOME_EMPRESA), ComponentesFactura.bold, Brushes.Black, 28, 10);
            eixoY += 25;
            graphics.DrawImage(imagem, new Rectangle(53, 40, largura, altura), new Rectangle(0, 0, imagem.Width, imagem.Height), GraphicsUnit.Pixel);
            eixoY += 0;
            graphics.DrawString(String.Format(" Código Factura:{0}", codigo), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Data:{0}", DateTime.Now.ToShortDateString()), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Endereço:{0}", empr.ENDERECO_EMPRESA), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("Telefone:{0}", empr.TELFONE), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;
            graphics.DrawString(String.Format("NIF:{0}", empr.NIF), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 9;
            graphics.DrawRectangle(ComponentesFactura.minhaPen1, ComponentesFactura.rect);
            graphics.DrawString("FACTURA DE DIVIDA", new Font("Courier", 11, FontStyle.Italic | FontStyle.Bold), new SolidBrush(Color.Black), ComponentesFactura.rect1, formato);
            graphics.DrawString("==========================", ComponentesFactura.bold1, new SolidBrush(Color.Black), ComponentesFactura.rect1, formato4);
            graphics.DrawString(String.Format("Hora:{0}", DateTime.Now.ToShortTimeString()), ComponentesFactura.bold1, new SolidBrush(Color.Black), ComponentesFactura.rect1, formato5);
            eixoY = 240;
            graphics.DrawString(String.Format("Cliente:{0}", nomeCliente), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawString("Produto     Quant  Preço  Total", ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 20;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            //=================================================================================================
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                Rectangle rect = new Rectangle(eixoX, eixoY, 105, 25);//105; 25
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, rect);
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 105, eixoY, 45, 20));
                graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX + 157, eixoY, 57, 20));
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[1].Value.ToString()), ComponentesFactura.regularItens, new SolidBrush(Color.Black), rect, formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[2].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 80, eixoY, 45, 20), formato3);
                graphics.DrawString(String.Format("{0}", dgv.Rows[i].Cells[3].Value), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 110, eixoY, 57, 20), formato3);//158
                graphics.DrawString(String.Format("{0}", Convert.ToInt32(dgv.Rows[i].Cells[2].Value) * Convert.ToInt32(dgv.Rows[i].Cells[3].Value)), ComponentesFactura.regularItens, new SolidBrush(Color.Black), new Rectangle(eixoX + 145, eixoY, 45, 20), formato3);//135
                eixoY += 25;
            }
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);//206
            eixoY += 5;
            graphics.DrawString(String.Format("TOTAL A PAGAR:       {0}", valorTotal), ComponentesFactura.bold3, Brushes.Black, eixoX, eixoY);
            eixoY += 17;
            graphics.DrawLine(ComponentesFactura.minhaPen1, eixoX, eixoY, eixoX + 206, eixoY);
            eixoY += 5;
            graphics.DrawString(String.Format("Atendente:"), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            graphics.DrawString(String.Format("                  {0}", nome), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
            eixoY += 15;

            graphics.DrawRectangle(ComponentesFactura.minhaPen3, new Rectangle(eixoX, eixoY, 200, 40));
            graphics.DrawString(String.Format("{0}\n{1}", obg, desejo), ComponentesFactura.bold3, new SolidBrush(Color.Black), new Rectangle(eixoX, eixoY, 200, 40), formato4);
            eixoY += 35;
            SolidBrush s = new SolidBrush(Color.Black);
            Rectangle recte = new Rectangle(10, eixoY, 255, 30);
            SolidBrush ss = new SolidBrush(Color.White);
            graphics.FillRectangle(s, recte);
            graphics.DrawString("Processado por computador...\nKambaSoft: 921979783", ComponentesFactura.bold3, ss, 10, eixoY);
            // graphics.DrawString(("Processado por computador...\nKambaSoft"), ComponentesFactura.bold3, new SolidBrush(Color.Red),recte , formato4);
            //(s,eixoX,eixoY,206,30);

        }








    }
}

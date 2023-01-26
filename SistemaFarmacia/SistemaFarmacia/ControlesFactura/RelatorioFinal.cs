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
   public  class RelatorioFinal
    {
       public static void imprimirFacturaFinal(string valorFinal, string valorTPA, string valorManual, System.Drawing.Printing.PrintPageEventArgs p, int ID)
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

           graphics.DrawString(String.Format("Data:{0}/{1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString()), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 15;
           graphics.DrawString(String.Format("Endereço:{0}", empr.ENDERECO_EMPRESA), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 15;
           graphics.DrawString(String.Format("Telefone:{0}", empr.TELFONE), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 15;
           graphics.DrawString(String.Format("NIF:{0}", empr.NIF), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 9;
           graphics.DrawRectangle(ComponentesFactura.minhaPen1, ComponentesFactura.rect);
           graphics.DrawString("RELATÓRIO FINAL", new Font("Courier", 11, FontStyle.Italic | FontStyle.Bold), new SolidBrush(Color.Black), ComponentesFactura.rect1, formato);
           graphics.DrawString("==========================", ComponentesFactura.bold1, new SolidBrush(Color.Black), ComponentesFactura.rect1, formato4);
           eixoY = 220;
           eixoY += 15;
           graphics.DrawString(String.Format("{0}", valorTPA), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 20;
           graphics.DrawString(String.Format("{0}", valorManual), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 20;
           graphics.DrawString(String.Format("{0}", valorFinal), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           
           eixoY += 20;
           //=================================================================================================
           
           
           graphics.DrawString(String.Format("Funcionário:"), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           graphics.DrawString(String.Format("                     {0}", nome), ComponentesFactura.bold1, Brushes.Black, eixoX, eixoY);
           eixoY += 15;

       }

    }
}

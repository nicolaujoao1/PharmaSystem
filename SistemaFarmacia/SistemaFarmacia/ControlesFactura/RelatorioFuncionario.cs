using Controllers;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFarmacia.ControlesFactura
{
    public static class RelatorioFuncionario
    {
        public static void relatorio(string caminho, int ID)
        {
          try
          {
              
                ModelEmpresa empr = new ModelEmpresa();
                ControllerEmpresa DadosEmpresa = new ControllerEmpresa();
                DataTable empresa = DadosEmpresa.ListarDadosEmpresa();
                empr.NOME_EMPRESA = empresa.Rows[0][1].ToString();
                empr.ENDERECO_EMPRESA = empresa.Rows[0][3].ToString();
                empr.TELFONE = empresa.Rows[0][6].ToString();
                empr.NIF = empresa.Rows[0][7].ToString();
                var dados = new ControllerUser().ListarTodosFuncionarios();
                int sum = 0;

                //-----------------------------------------------------------------------------------------------------------
                SaveFileDialog file = new SaveFileDialog();
                file.InitialDirectory = caminho;
                file.Filter = "Documentos (*.PDF)|*.pdf";
                if (file.ShowDialog() == DialogResult.Cancel) return;
                // string caminho = file.FileName;

                //-----------------------------------------------------------------------------------------------------------
                FileStream steam = new FileStream(file.FileName, FileMode.Create);

                //-----------------------------------------------------------------------------------------------------------
                Document doc = new Document(PageSize.A4);
                PdfWriter wr = PdfWriter.GetInstance(doc, steam);
                //-----------------------------------------------------------------------------------------------------------
                Paragraph hp0 = new Paragraph(string.Format("NOME EMPRESA:{0}\n", empr.NOME_EMPRESA.ToUpper()), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                Paragraph hp1 = new Paragraph(string.Format("ENDEREÇO:{0}\n", empr.ENDERECO_EMPRESA.ToUpper()), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                Paragraph hp2 = new Paragraph(string.Format("TELEFONE:{0}\n", empr.TELFONE.ToUpper()), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                Paragraph hp3 = new Paragraph(string.Format("NIF:{0}\n", empr.NIF.ToUpper()), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                hp0.Alignment = Element.ALIGN_LEFT;
                hp1.Alignment = Element.ALIGN_LEFT;
                hp2.Alignment = Element.ALIGN_LEFT;
                
                hp0.Add(String.Format("Data:{0}", DateTime.Now.ToShortDateString()));
                Paragraph hp = new Paragraph("______________________________________________________________\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                hp.Alignment = Element.ALIGN_CENTER;
                Paragraph hp4 = new Paragraph("RELATÓRIO DOS FUNCIONÁRIOS INTERNOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Regular));
                hp4.Alignment = Element.ALIGN_CENTER;
                Paragraph hp5 = new Paragraph(String.Format("\n\n\t\t\t\t\t\t\tDIRECTOR GERAL:{0}\n\n", new ControllerUser().selectedUserActive(ID)), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, (int)System.Drawing.FontStyle.Bold));
                hp5.Alignment = Element.ALIGN_LEFT;
                //-----------------------------------------------------------------------------------------------------------
                PdfPTable tabela = new PdfPTable(5);
                tabela.HorizontalAlignment = Element.ALIGN_CENTER;

                tabela.DefaultCell.FixedHeight = 25;
                PdfPCell celula = new PdfPCell(new Phrase("Nome Completo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula.BackgroundColor = BaseColor.CYAN.Darker();
                celula.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula);
                PdfPCell celula1 = new PdfPCell(new Phrase("Data de Nascimento", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula1.BackgroundColor = BaseColor.CYAN.Darker();
                celula1.BorderColor = BaseColor.CYAN.Brighter();
                celula1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.AddCell(celula1);
                PdfPCell celula2 = new PdfPCell(new Phrase("Sexo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));

                //-----------------------------------------------------------------------------------------------------------
                celula2.BackgroundColor = BaseColor.CYAN.Darker();
                celula2.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula2);
                PdfPCell celula3 = new PdfPCell(new Phrase("Telefone", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula3.BackgroundColor = BaseColor.CYAN.Darker();
                celula3.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula3);
                PdfPCell celula4 = new PdfPCell(new Phrase("Cargo", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula4.BackgroundColor = BaseColor.CYAN.Darker();
                celula4.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula4);
                //-----------------------------------------------------------------------------------------------------------
                foreach (DataRow colunas in dados.Rows)
                {
                    
                    PdfPCell celula5 = new PdfPCell(new Phrase(colunas[0].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula5.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula5);
                    PdfPCell celula6 = new PdfPCell(new Phrase(Convert.ToDateTime(colunas[1].ToString()).ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula6.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula6);
                    PdfPCell celula7 = new PdfPCell(new Phrase(colunas[2].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula7.HorizontalAlignment = Element.ALIGN_CENTER;
                    sum++;
                    tabela.AddCell(celula7);
                    PdfPCell celula8 = new PdfPCell(new Phrase(colunas[3].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));

                    celula8.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula8);
                    PdfPCell celula9 = new PdfPCell(new Phrase(string.Format("{0}", colunas[4].ToString()), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula9.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula9);
                }

                PdfPCell celulaFinal = new PdfPCell(new Phrase(string.Format("TOTAL DE FUNCIONÁRIOS:{0}", sum), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 13, (int)FontStyle.Bold)));
                celulaFinal.Colspan = 5;
                celulaFinal.HorizontalAlignment = Element.ALIGN_LEFT;
                celulaFinal.FixedHeight = 32;
                tabela.AddCell(celulaFinal);

                doc.Open();
                doc.Add(hp0);
                doc.Add(hp);
                doc.Add(hp1);
                doc.Add(hp2);
                doc.Add(hp3);
                doc.Add(hp4);
                doc.Add(hp5);
                doc.Add(tabela);




                doc.Close();

                System.Diagnostics.Process.Start(file.FileName);
              }
            catch (Exception ex)
             {
                 MessageBox.Show(ex.Message, "Aviso");
             }

        }
    }
}

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
   public  class RelatorioVendas
    {
        //------------------------------------------------------------------------------------------
        public static void ImprimirRelatorio(string caminho, int ID)
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
                int sum = 0, quant = 0;
                DataTable Dados = SelectHistoricoVenda.CarregarDadosHistoricosGeral();
                //-----------------------------------------------------------------------------------------------------------
                SaveFileDialog file = new SaveFileDialog();
                file.InitialDirectory = caminho;
                file.Filter = "Documentos (*.PDF)|*.pdf";
                if (file.ShowDialog() == DialogResult.Cancel) return;


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
                hp3.Alignment = Element.ALIGN_LEFT;

                hp0.Alignment = Element.ALIGN_LEFT;
                hp0.Add(String.Format("Data:{0}", DateTime.Now.ToShortDateString()));
                Paragraph hp = new Paragraph("______________________________________________________________\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                hp.Alignment = Element.ALIGN_CENTER;
                Paragraph hp4 = new Paragraph("RELATÓRIO DE VENDAS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Regular));
                hp4.Alignment = Element.ALIGN_CENTER;
                Paragraph hp5 = new Paragraph(String.Format("\n\n\t\t\t\t\t\t\tDIRECTOR GERAL:{0}\n\n", new ControllerUser().selectedUserActive(ID)), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, (int)System.Drawing.FontStyle.Bold));
                hp5.Alignment = Element.ALIGN_LEFT;
                //-----------------------------------------------------------------------------------------------------------
                PdfPTable tabela = new PdfPTable(6);
                tabela.HorizontalAlignment = Element.ALIGN_CENTER;

                tabela.DefaultCell.FixedHeight = 25;
                PdfPCell celula = new PdfPCell(new Phrase("Produto", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula.BackgroundColor = BaseColor.CYAN.Darker();
                celula.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula);
                PdfPCell celula1 = new PdfPCell(new Phrase("Quantidade", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula1.BackgroundColor = BaseColor.CYAN.Darker();
                celula1.BorderColor = BaseColor.CYAN.Brighter();
                celula1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.AddCell(celula1);
                PdfPCell celula2 = new PdfPCell(new Phrase("Valor Pago", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));

                //-----------------------------------------------------------------------------------------------------------
                celula2.BackgroundColor = BaseColor.CYAN.Darker();
                celula2.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula2);
                PdfPCell celula3 = new PdfPCell(new Phrase("Cliente", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula3.BackgroundColor = BaseColor.CYAN.Darker();
                celula3.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula3);
                PdfPCell celula4 = new PdfPCell(new Phrase("Data Emissão", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula4.BackgroundColor = BaseColor.CYAN.Darker();
                celula4.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula4);
                PdfPCell celula60 = new PdfPCell(new Phrase("Tipo Pagamento", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula60.BackgroundColor = BaseColor.CYAN.Darker();
                celula60.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula60);
                //-----------------------------------------------------------------------------------------------------------
                foreach (DataRow colunas in Dados.Rows)
                {
                    PdfPCell celula5 = new PdfPCell(new Phrase(colunas[0].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula5.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula5);
                    PdfPCell celula6 = new PdfPCell(new Phrase(colunas[1].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula6.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula6);
                    quant += Convert.ToInt32(colunas[1].ToString());
                    PdfPCell celula7 = new PdfPCell(new Phrase(colunas[2].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula7.HorizontalAlignment = Element.ALIGN_CENTER;
                    sum += Convert.ToInt32(colunas[2]);
                    tabela.AddCell(celula7);
                    PdfPCell celula8 = new PdfPCell(new Phrase(colunas[3].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula8.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula8);
                    PdfPCell celula9 = new PdfPCell(new Phrase(Convert.ToDateTime(colunas[5].ToString()).ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula9.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula9);
                    PdfPCell celula80 = new PdfPCell(new Phrase(colunas[4].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula80.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula80);
                }

                PdfPCell celulaFinal = new PdfPCell(new Phrase(string.Format("Total de Vendas:{0}\nQuantidade de Produtos Vendidos:{1}", sum.ToString("C2"), quant), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 13, (int)FontStyle.Bold)));
                celulaFinal.Colspan = 6;
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
        public static void ImprimirRelatorioProdutos(string caminho)
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
                int sum = 0, quant = 0;
                DataTable Dados = new ControllerProduct().ListarProdutosRelatorioFinal();
                //-----------------------------------------------------------------------------------------------------------
                SaveFileDialog file = new SaveFileDialog();
                file.InitialDirectory = caminho;
                file.Filter = "Documentos (*.PDF)|*.pdf";
                if (file.ShowDialog() == DialogResult.Cancel) return;


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
                hp3.Alignment = Element.ALIGN_LEFT;

                hp0.Alignment = Element.ALIGN_LEFT;
                hp0.Add(String.Format("Data:{0}", DateTime.Now.ToShortDateString()));
                Paragraph hp = new Paragraph("______________________________________________________________\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                hp.Alignment = Element.ALIGN_CENTER;
                Paragraph hp4 = new Paragraph("TABELA DE PREÇOS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
                hp4.Alignment = Element.ALIGN_CENTER;
               
                //-----------------------------------------------------------------------------------------------------------
                PdfPTable tabela = new PdfPTable(3);
                tabela.HorizontalAlignment = Element.ALIGN_CENTER;

                tabela.DefaultCell.FixedHeight = 22;
                PdfPCell celula = new PdfPCell(new Phrase("Produto", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula.BackgroundColor = BaseColor.CYAN.Darker();
                celula.BorderColor = BaseColor.CYAN.Brighter();
                tabela.AddCell(celula);
                PdfPCell celula1 = new PdfPCell(new Phrase("Preço", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula1.BackgroundColor = BaseColor.CYAN.Darker();
                celula1.BorderColor = BaseColor.CYAN.Brighter();
                celula1.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.AddCell(celula1);

                PdfPCell celula2 = new PdfPCell(new Phrase("Preço Opcional", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
                //-----------------------------------------------------------------------------------------------------------
                celula2.BackgroundColor = BaseColor.CYAN.Darker();
                celula2.BorderColor = BaseColor.CYAN.Brighter();
                celula2.HorizontalAlignment = Element.ALIGN_CENTER;
                tabela.AddCell(celula2);
               
                //-----------------------------------------------------------------------------------------------------------
                foreach (DataRow colunas in Dados.Rows)
                {
                    PdfPCell celula5 = new PdfPCell(new Phrase(colunas[0].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula5.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula5);
                    PdfPCell celula6 = new PdfPCell(new Phrase(Convert.ToDouble(colunas[1]).ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula6.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula6);
                    tabela.AddCell(string.Empty);
                   
                }

               
                doc.Open();
                doc.Add(hp0);
                doc.Add(hp);
                doc.Add(hp1);
                doc.Add(hp2);
                doc.Add(hp3);
                doc.Add(hp4);

                doc.Add(tabela);




                doc.Close();

                System.Diagnostics.Process.Start(file.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso");
            }

        }
        //======================================================================================
        public static void ImprimirRelatorio(string caminho, DateTime inicio, DateTime fim, int ID)
        {
            //try
            //{
            ModelEmpresa empr = new ModelEmpresa();
            ControllerEmpresa DadosEmpresa = new ControllerEmpresa();
            DataTable empresa = DadosEmpresa.ListarDadosEmpresa();
            empr.NOME_EMPRESA = empresa.Rows[0][1].ToString();
            empr.ENDERECO_EMPRESA = empresa.Rows[0][3].ToString();
            empr.TELFONE = empresa.Rows[0][6].ToString();
            empr.NIF = empresa.Rows[0][7].ToString();
            int sum = 0, quant = 0;
            DataTable Dados = SelectHistoricoVenda.CarregarDadosHistoricos(inicio.ToShortDateString(), fim.ToShortDateString());
            int data1 = inicio.Month;
            int data2 = fim.Month;
            //-----------------------------------------------------------------------------------------------------------
            SaveFileDialog file = new SaveFileDialog();
            file.InitialDirectory = caminho;
            file.Filter = "Documentos (*.PDF)|*.pdf";
            if (file.ShowDialog() == DialogResult.Cancel) return;


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
            hp3.Alignment = Element.ALIGN_LEFT;

            hp0.Alignment = Element.ALIGN_LEFT;
            hp0.Add(String.Format("Data:{0}", DateTime.Now.ToShortDateString()));
            Paragraph hp = new Paragraph("______________________________________________________________\n\n", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Bold));
            hp.Alignment = Element.ALIGN_CENTER;
            Paragraph hp4 = new Paragraph("RELATÓRIO DE VENDAS", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 14, (int)System.Drawing.FontStyle.Regular));
            hp4.Alignment = Element.ALIGN_CENTER;
            Paragraph hp5 = new Paragraph(String.Format("\n\n\t\t\t\t\t\t\tDIRECTOR GERAL:{0}\n\n", new ControllerUser().selectedUserActive(ID)), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, (int)System.Drawing.FontStyle.Bold));
            hp5.Alignment = Element.ALIGN_LEFT;
            //-----------------------------------------------------------------------------------------------------------
            PdfPTable tabela = new PdfPTable(6);
            tabela.HorizontalAlignment = Element.ALIGN_CENTER;

            tabela.DefaultCell.FixedHeight = 25;
            PdfPCell celula = new PdfPCell(new Phrase("Produto", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
            //-----------------------------------------------------------------------------------------------------------
            celula.BackgroundColor = BaseColor.CYAN.Darker();
            celula.BorderColor = BaseColor.CYAN.Brighter();
            tabela.AddCell(celula);
            PdfPCell celula1 = new PdfPCell(new Phrase("Quantidade", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
            //-----------------------------------------------------------------------------------------------------------
            celula1.BackgroundColor = BaseColor.CYAN.Darker();
            celula1.BorderColor = BaseColor.CYAN.Brighter();
            celula1.HorizontalAlignment = Element.ALIGN_CENTER;
            tabela.AddCell(celula1);
            PdfPCell celula2 = new PdfPCell(new Phrase("Valor Pago", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));

            //-----------------------------------------------------------------------------------------------------------
            celula2.BackgroundColor = BaseColor.CYAN.Darker();
            celula2.BorderColor = BaseColor.CYAN.Brighter();
            tabela.AddCell(celula2);
            PdfPCell celula3 = new PdfPCell(new Phrase("Cliente", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
            //-----------------------------------------------------------------------------------------------------------
            celula3.BackgroundColor = BaseColor.CYAN.Darker();
            celula3.BorderColor = BaseColor.CYAN.Brighter();
            tabela.AddCell(celula3);
            PdfPCell celula4 = new PdfPCell(new Phrase("Data Emissão", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
            //-----------------------------------------------------------------------------------------------------------
            celula4.BackgroundColor = BaseColor.CYAN.Darker();
            celula4.BorderColor = BaseColor.CYAN.Brighter();
            tabela.AddCell(celula4);
            PdfPCell celula60 = new PdfPCell(new Phrase("Tipo Pagamento", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Bold)));
            //-----------------------------------------------------------------------------------------------------------
            celula60.BackgroundColor = BaseColor.CYAN.Darker();
            celula60.BorderColor = BaseColor.CYAN.Brighter();
            tabela.AddCell(celula60);
            //-----------------------------------------------------------------------------------------------------------
            foreach (DataRow colunas in Dados.Rows)
            {
                if (((Convert.ToDateTime(colunas[5].ToString()).Month) < data1) || ((Convert.ToDateTime(colunas[5].ToString()).Month) > data2))
                {

                }
                else
                {
                    PdfPCell celula5 = new PdfPCell(new Phrase(colunas[0].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula5.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula5);
                    PdfPCell celula6 = new PdfPCell(new Phrase(colunas[1].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula6.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula6);
                    quant += Convert.ToInt32(colunas[1].ToString());
                    PdfPCell celula7 = new PdfPCell(new Phrase(colunas[2].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula7.HorizontalAlignment = Element.ALIGN_CENTER;
                    sum += Convert.ToInt32(colunas[2]);
                    tabela.AddCell(celula7);
                    PdfPCell celula8 = new PdfPCell(new Phrase(colunas[3].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula8.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula8);
                    PdfPCell celula9 = new PdfPCell(new Phrase(Convert.ToDateTime(colunas[5].ToString()).ToShortDateString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula9.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula9);
                    PdfPCell celula80 = new PdfPCell(new Phrase(colunas[4].ToString(), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 11, (int)FontStyle.Regular)));
                    celula80.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabela.AddCell(celula80);
                }
            }

            PdfPCell celulaFinal = new PdfPCell(new Phrase(string.Format("Total de Vendas:{0}\nQuantidade de Produtos Vendidos:{1}", sum.ToString("C2"), quant), new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 13, (int)FontStyle.Bold)));
            celulaFinal.Colspan = 6;
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
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Aviso");
            //}

        }
    }
}

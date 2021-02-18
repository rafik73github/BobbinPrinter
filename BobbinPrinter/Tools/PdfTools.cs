using System.Windows;
using BobbinPrinter.SQL;
using BobbinPrinter.Models;
using BobbinPrinter.Tools;
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using System.Collections.Generic;
using System;
using iText.IO.Font;
using iText.Kernel.Font;
using System.Diagnostics;
using System.IO;
namespace BobbinPrinter.Tools
{
    class PdfTools
    {
        private static readonly string PDF_FILE_NAME = "PRINTS\\bobbins_list.pdf";
        public static bool GenerateAndSavePdfToPrint(List<YarnPrintListModel> yarnPrintListModelList)
        {
            if (!FileTools.IsFileLocked(new FileInfo(PDF_FILE_NAME)))
            {
                List<YarnPrintListModel> source = yarnPrintListModelList;

                PdfWriter writer = new PdfWriter(PDF_FILE_NAME);
                PdfDocument pdf = new PdfDocument(writer);
                pdf.SetDefaultPageSize(PageSize.A4);
                Document document = new Document(pdf);
                document.SetMargins(48, 24, 48, 24);
                string fontProgram = @"C:\Windows\Fonts\Arial.ttf";

                PdfFont font = PdfFontFactory.CreateFont(fontProgram, PdfEncodings.IDENTITY_H, true);
                document.SetFont(font);


                Table table = new Table(3, false);

                foreach (var o in source)
                {

                    for (int i = 0; i < o.YarnBobbinAmount; i++)
                    {
                        Cell cell = new Cell(1, 1)
                              .SetBackgroundColor(ColorConstants.WHITE)
                              .SetBorder(new SolidBorder(ColorConstants.WHITE, 1))
                              .SetWidth(200)
                              .SetHeight(26);

                        Paragraph colorName = new Paragraph(o.YarnColor);
                        colorName.SetTextAlignment(TextAlignment.LEFT);
                        colorName.SetFontSize(8);

                        Paragraph p = new Paragraph("L: " + o.YarnLot);

                        p.Add(new Tab());
                        p.AddTabStops(new TabStop(160, TabAlignment.RIGHT));
                        p.Add(o.YarnSize);
                        p.SetFontSize(8);

                        cell.Add(colorName);
                        cell.Add(p);

                        table.AddCell(cell);
                    }
                }

                document.Add(table);
                document.Close();
                Process.Start(PDF_FILE_NAME);
            }
            else
            {
                MessageBox.Show("PDF Z WYDRUKIEM JEST OTWARTY !\nZAMKNIJ GO BY WYGENEROWAĆ KOLEJNY");
                return false;
            }
            return true;
        }
    }
}

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using BobbinPrinter.SQL;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using TextAlignment = iText.Layout.Properties.TextAlignment;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy YarnPrintPanel.xaml
    /// </summary>
    public partial class YarnPrintPanel : Window
    {
        
        public YarnPrintPanel()
        {
            InitializeComponent();

            SelectYarnToPrintComboBox.ItemsSource = new SQLYarns().GetAllYarns();

        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            this.Hide();
            mW.Show();
        }

        private void YarnListExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void AddYarnToPrintListButton_Click(object sender, RoutedEventArgs e)
        {
            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter("demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4);
            Document document = new Document(pdf);
            document.SetMargins(48, 24, 48, 24);
            

            /*
            Paragraph header = new Paragraph("HEADER")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);

            Paragraph subheader = new Paragraph("SUB HEADER")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFontSize(15);
            document.Add(subheader);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);
            */
            Table table = new Table(3, false);
           
            int number = 1;

            for (int i = 0; i < 72; i++)
            {
                Cell cell = new Cell(1, 1)
                      .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.WHITE)
                      .SetBorder(new SolidBorder(ColorConstants.WHITE, 1))
                      .SetWidth(200)
                      .SetHeight(26);
                
                //.Add(new Paragraph(number.ToString()));
                Paragraph colorName = new Paragraph("CZARNY-MEL.");
                colorName.SetTextAlignment(TextAlignment.LEFT);
                colorName.SetFontSize(8);

                Paragraph p = new Paragraph("L: 22/21");

                p.Add(new Tab());
                p.AddTabStops(new TabStop(160, TabAlignment.RIGHT));
                p.Add("1/15");

                //yarnLot.SetTextAlignment(TextAlignment.LEFT);
                p.SetFontSize(8);

                

                
                cell.Add(colorName);
                cell.Add(p);
                

                number++;
                table.AddCell(cell);
            }
            

            document.Add(table);

            document.Close();
            Process.Start("demo.pdf");


        }

        public Cell getCell(String text, TextAlignment alignment)
        {
            Cell cell = new Cell().Add(new Paragraph(text));
            cell.SetPadding(0);
            cell.SetTextAlignment(alignment);
            cell.SetBorder(Border.NO_BORDER);
            return cell;
        }
    }
}

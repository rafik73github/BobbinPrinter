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

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy YarnPrintPanel.xaml
    /// </summary>
    public partial class YarnPrintPanel : Window
    {
        List<YarnPrintListModel> yarnPrintListModelList = new List<YarnPrintListModel>();
        public YarnPrintPanel()
        {
            InitializeComponent();

            SelectYarnToPrintComboBox.ItemsSource = new SQLYarns().GetAllYarns();
            YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
            AddYarnBobbinAmountToPrintTextBox.PreviewTextInput += Validate.OnlyNumberValidatinTextBox;

        }

        

        private void AddYarnToPrintListButton_Click(object sender, RoutedEventArgs e)
        {
            
            string addYarnLotToPrintTextBoxString = AddYarnLotToPrintTextBox.Text.Trim().ToUpper();
            
            YarnsModel yarnsModel = SelectYarnToPrintComboBox.SelectedItem as YarnsModel;

            if (yarnsModel == null)
            {
                MessageBox.Show("WYBIERZ KOLOR Z LISTY");
            }
            else if (addYarnLotToPrintTextBoxString.Equals(""))
            {
                MessageBox.Show("WPISZ LOT PRZĘDZY");
            }
            else if (AddYarnBobbinAmountToPrintTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("WPISZ LICZBĘ SZPULEK");
            }
            else
            {
                int addYarnBobbinAmountToPrintTextBoxInt = Convert.ToInt32(AddYarnBobbinAmountToPrintTextBox.Text.Trim());
                yarnPrintListModelList.Add(new YarnPrintListModel(yarnsModel.YarnColor, addYarnLotToPrintTextBoxString, addYarnBobbinAmountToPrintTextBoxInt, yarnsModel.YarnSizeString));
                YarnsToPrintListView.ItemsSource = null;
                YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
                SelectYarnToPrintComboBox.SelectedItem = null;
                AddYarnLotToPrintTextBox.Text = "";
                AddYarnBobbinAmountToPrintTextBox.Text = "";
            }

        }

        private void GenerateAndSavePdfToPrint(List<YarnPrintListModel> yarnPrintListModelList)
        {
            List<YarnPrintListModel> source = yarnPrintListModelList;
            int listCount = source.Count;

            PdfWriter writer = new PdfWriter("demo.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4);
            Document document = new Document(pdf);
            document.SetMargins(48, 24, 48, 24);
            


            Table table = new Table(3, false);

            foreach (var o in source)
            {
                
                for (int i = 0; i < o.YarnBobbinAmount; i++)
                {
                    Cell cell = new Cell(1, 1)
                          .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.WHITE)
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
            //Process.Start("demo.pdf");
        }

        private void GenerateAndSavePdfToPrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (yarnPrintListModelList.Count == 0)
            {
                MessageBox.Show("LISTA WYDRUKU JEST PUSTA !");
            }
            else
            {
                GenerateAndSavePdfToPrint(yarnPrintListModelList);
                yarnPrintListModelList = null;
                YarnsToPrintListView.ItemsSource = null;
                YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
            }
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
    }
}

using System.Windows;
using BobbinPrinter.SQL;
using BobbinPrinter.Models;
using BobbinPrinter.Tools;
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
            AddYarnBobbinInPackageCountToPrintTextBox.PreviewTextInput += Validate.OnlyNumberValidatinTextBox;

            SelectYarnToPrintComboBox.Focus();


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
            else if (AddYarnBobbinInPackageCountToPrintTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("WPISZ LICZBĘ SZPULEK W PACZCE");
            }
            else if (AddYarnBobbinAmountToPrintTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("WPISZ LICZBĘ PACZEK");
            }
            else if (AddYarnBobbinAmountToPrintTextBox.Text.Trim().Equals("0"))
            {
                MessageBox.Show("WPISZ LICZBĘ SZPULEK WIĘKSZĄ OD ZERA");
            }
            else
            {
                int addYarnBobbinAmountToPrintTextBoxInt = Convert.ToInt32(AddYarnBobbinAmountToPrintTextBox.Text.Trim());
                addYarnBobbinAmountToPrintTextBoxInt = addYarnBobbinAmountToPrintTextBoxInt * Convert.ToInt32(AddYarnBobbinInPackageCountToPrintTextBox.Text);
                yarnPrintListModelList.Add(new YarnPrintListModel(yarnsModel.YarnColor,
                    addYarnLotToPrintTextBoxString,
                    Convert.ToInt32(AddYarnBobbinInPackageCountToPrintTextBox.Text),
                    addYarnBobbinAmountToPrintTextBoxInt,
                    yarnsModel.YarnSizeString,
                    yarnsModel.YarnMakerString
                    ));
                YarnsToPrintListView.ItemsSource = null;
                YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
                SelectYarnToPrintComboBox.SelectedItem = null;
                AddYarnLotToPrintTextBox.Text = "";
                AddYarnBobbinAmountToPrintTextBox.Text = "";
                AddYarnBobbinInPackageCountToPrintTextBox.Text = "";
                SelectYarnToPrintComboBox.Focus();
            }

        }

        

        private void AddYarnToPrintClearListButton_Click(object sender, RoutedEventArgs e)
        {
            yarnPrintListModelList.Clear();
            YarnsToPrintListView.ItemsSource = null;
            YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
        }

        private void GenerateAndSavePdfToPrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (yarnPrintListModelList.Count == 0)
            {
                MessageBox.Show("LISTA WYDRUKU JEST PUSTA !");
            }
            else
            {
                if (PdfTools.GenerateAndSavePdfToPrint(yarnPrintListModelList))
                {
                    yarnPrintListModelList.Clear();
                    YarnsToPrintListView.ItemsSource = null;
                    YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
                    
                }
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

        private void SelectYarnToPrintComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            YarnsModel yarnsModel = SelectYarnToPrintComboBox.SelectedItem as YarnsModel;
            if (yarnsModel != null)
            {
                AddYarnBobbinInPackageCountToPrintTextBox.Text = yarnsModel.YarnBobbinInPackageCount.ToString();
            }
        }
    }
}

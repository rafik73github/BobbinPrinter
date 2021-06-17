using System.Windows;
using BobbinPrinter.SQL;
using BobbinPrinter.Models;
using BobbinPrinter.Tools;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Linq;
using System.Diagnostics;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy YarnPrintPanel.xaml
    /// </summary>
    public partial class YarnPrintPanel : Window
    {
        readonly List<YarnPrintListModel> yarnPrintListModelList = new List<YarnPrintListModel>();
        readonly List<YarnsModel> test = new SQLYarns().GetAllYarns();
        public YarnPrintPanel()
        {
            InitializeComponent();

            //SelectYarnToPrintComboBox.ItemsSource = new SQLYarns().GetAllYarns();
            SelectYarnToPrintComboBox.ItemsSource = test;
            YarnsToPrintListView.ItemsSource = yarnPrintListModelList;
            AddYarnBobbinAmountToPrintTextBox.PreviewTextInput += Validate.OnlyNumberValidatinTextBox;
            AddYarnBobbinInPackageCountToPrintTextBox.PreviewTextInput += Validate.OnlyNumberValidatinTextBox;

            //SelectYarnToPrintComboBox.Focus();


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = from item in test
                                   where item.YarnColor.ToLower().Contains(comboBox.Text.ToLower())
                                   select item;
            comboBox.IsDropDownOpen = true;
        }

        private void AddYarnToPrintListButton_Click(object sender, RoutedEventArgs e)
        {
            string addYarnLotToPrintTextBoxString = AddYarnLotToPrintTextBox.Text.Trim().ToUpper();


            if (!(SelectYarnToPrintComboBox.SelectedItem is YarnsModel yarnsModel))
            {
                MessageBox.Show(Texts.GET_COLOR_FROM_LIST);
            }
            else if (addYarnLotToPrintTextBoxString.Equals(""))
            {
                MessageBox.Show(Texts.ENTRY_YARN_LOT);
            }
            else if (AddYarnBobbinInPackageCountToPrintTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show(Texts.ENTRY_NUMBER_OF_BOBBINS_IN_PACK);
            }
            else if (AddYarnBobbinAmountToPrintTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show(Texts.ENTRY_NUMBER_OF_PACKS);
            }
            else if (AddYarnBobbinAmountToPrintTextBox.Text.Trim().Equals("0"))
            {
                MessageBox.Show(Texts.ENTRY_NUMBER_OF_BOBBINS_BIGGEST_THAN_ZERO);
            }
            else
            {
                int addYarnBobbinAmountToPrintTextBoxInt = Convert.ToInt32(AddYarnBobbinAmountToPrintTextBox.Text.Trim());
                //addYarnBobbinAmountToPrintTextBoxInt = addYarnBobbinAmountToPrintTextBoxInt * Convert.ToInt32(AddYarnBobbinInPackageCountToPrintTextBox.Text);
                addYarnBobbinAmountToPrintTextBoxInt *= Convert.ToInt32(AddYarnBobbinInPackageCountToPrintTextBox.Text);
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
                MessageBox.Show(Texts.PRINT_LIST_IS_EMPTY);
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
            try
            {
                MainWindow mW = new MainWindow();
                Hide();
                mW.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("COŚ POSZŁO NIE TAK: " + ex.Message, "BŁĄD APLIKACJI", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenPrintFolderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("PRINTS");
            }
            catch(Exception ex)
            {
                MessageBox.Show("COŚ POSZŁO NIE TAK: " + ex.Message, "BŁĄD APLIKACJI", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void YarnListExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SelectYarnToPrintComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectYarnToPrintComboBox.SelectedItem is YarnsModel yarnsModel)
            {
                AddYarnBobbinInPackageCountToPrintTextBox.Text = yarnsModel.YarnBobbinInPackageCount.ToString();
            }
            AddYarnLotToPrintTextBox.Focus();
        }

        private void AddYarnLotToPrintTextBox_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddYarnBobbinAmountToPrintTextBox.Focus();
            }
        }

        private void AddYarnBobbinAmountToPrintTextBox_OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddYarnToPrintListButton.Focus();
            }
        }
    }
}

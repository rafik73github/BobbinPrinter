using System.Windows;
using BobbinPrinter.SQL;
using BobbinPrinter.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using BobbinPrinter.Tools;
using System.Windows.Input;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy YarnList.xaml
    /// </summary>
    public partial class YarnList : Window
    {
        private string addMakerTextBoxText;
        private string addTypeTextBoxText;
        private string addSizeTextBoxText;
        readonly List<YarnsModel> test = new SQLYarns().GetAllYarns();
        public YarnList()
        {
            InitializeComponent();
            
            SelectYarnMakerComboBox.ItemsSource = new SQLYarnmakers().GetAllYarnmakers();
            SelectYarnTypeComboBox.ItemsSource = new SQLYarntypes().GetAllYarntypes();
            SelectYarnSizeComboBox.ItemsSource = new SQLYarnsizes().GetAllYarnsizes();
            
            comboBox.ItemsSource = test;
            YarnsListView.ItemsSource = new SQLYarns().GetAllYarns();
            

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = from item in test
                               where item.YarnColor.ToLower().Trim().Contains(comboBox.Text.ToLower().Trim())
                               select item;
            comboBox.IsDropDownOpen = true;
        }

        private void MyComboBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            foreach (YarnsModel i in comboBox.Items)
            {
                if (i.ToString().ToUpper().Contains(e.Text.ToUpper()))
                {
                    comboBox.SelectedItem = i;
                    break;
                }
            }
            e.Handled = true;
        }

        private void AddMakerButton_Click(object sender, RoutedEventArgs e)
        {
            addMakerTextBoxText = AddMakerTextBox.Text;
            if(addMakerTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ\n PRODUCENTA PRZĘDZY",Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if(new SQLYarnmakers().IsYarnmakerExist(addMakerTextBoxText))
                {
                    AddMakerTextBox.Text = "";
                    MessageBox.Show("TAKI PRODUCENT PRZĘDZY\n JUŻ ISTNIEJE!", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarnmakers().AddYarnmaker(new YarnmakersModel(addMakerTextBoxText.ToUpper(), false));
                    AddMakerTextBox.Text = "";
                    MessageBox.Show(Texts.ADDED, "", MessageBoxButton.OK, MessageBoxImage.Information);

                    SelectYarnMakerComboBox.ItemsSource = null;
                    SelectYarnMakerComboBox.ItemsSource = new SQLYarnmakers().GetAllYarnmakers();
                }
            }
        }

       
        private void AddTypeButton_Click(object sender, RoutedEventArgs e)
        {
            addTypeTextBoxText = AddTypeTextBox.Text;
            if (addTypeTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ\n TYPU PRZĘDZY", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarntypes().IsYarntypeExist(addTypeTextBoxText))
                {
                    AddTypeTextBox.Text = "";
                    MessageBox.Show("TAKI TYP PRZĘDZY\n JUŻ ISTNIEJE!", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarntypes().AddYarntype(new YarntypesModel(addTypeTextBoxText.ToUpper(), false));
                    AddTypeTextBox.Text = "";
                    MessageBox.Show(Texts.ADDED, "", MessageBoxButton.OK, MessageBoxImage.Information);

                    SelectYarnTypeComboBox.ItemsSource = null;
                    SelectYarnTypeComboBox.ItemsSource = new SQLYarntypes().GetAllYarntypes();
                }
            }
        }

        private void AddSizeButton_Click(object sender, RoutedEventArgs e)
        {
            addSizeTextBoxText = AddSizeTextBox.Text;
            if (addSizeTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ\n GRUBOŚCI PRZĘDZY", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarnsizes().IsYarnsizeExist(addSizeTextBoxText))
                {
                    AddSizeTextBox.Text = "";
                    MessageBox.Show("TAKA GRUBOŚĆ PRZĘDZY\n JUŻ ISTNIEJE!", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarnsizes().AddYarnsize(new YarnsizesModel(addSizeTextBoxText.ToUpper(), false));
                    AddSizeTextBox.Text = "";
                    MessageBox.Show(Texts.ADDED, "", MessageBoxButton.OK, MessageBoxImage.Information);

                    SelectYarnSizeComboBox.ItemsSource = null;
                    SelectYarnSizeComboBox.ItemsSource = new SQLYarnsizes().GetAllYarnsizes();
                }
            }
        }

        private void AddYarnButton_Click(object sender, RoutedEventArgs e)
        {
           
            
            YarnmakersModel yarnmakersModel = SelectYarnMakerComboBox.SelectedItem as YarnmakersModel;
            YarntypesModel yarntypesModel = SelectYarnTypeComboBox.SelectedItem as YarntypesModel;
            YarnsizesModel yarnsizesModel = SelectYarnSizeComboBox.SelectedItem as YarnsizesModel;
            string addColorNameTextBoxText = AddColorNameTextBox.Text.Trim().ToUpper();



            if (SelectYarnMakerComboBox.SelectedItem == null || SelectYarnTypeComboBox.SelectedItem == null 
                || SelectYarnSizeComboBox.SelectedItem == null 
                || addColorNameTextBoxText.Equals("")
                || AddBobbinInPackageTextBox.Text.Trim().Equals(""))
            {
                MessageBox.Show("UZUPEŁNIJ WSZYSTKIE DANE", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarns().IsYarnExist(yarnmakersModel.YarnmakerId, yarntypesModel.YarntypeId,yarnsizesModel.YarnsizeId,addColorNameTextBoxText, Convert.ToInt32(AddBobbinInPackageTextBox.Text)))
                {
                    MessageBox.Show("TAKA PRZĘDZA\n JUŻ ISTNIEJE!", Texts.ENTRY_RECORD_ERROR, MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    AddColorNameTextBox.Text = "";
                    

                }
                else
                {
                    int addBobbinInPackageTextBoxText = Convert.ToInt32(AddBobbinInPackageTextBox.Text);
                    new SQLYarns().AddYarn(new YarnsModel(yarnmakersModel.YarnmakerId, yarntypesModel.YarntypeId, yarnsizesModel.YarnsizeId, addColorNameTextBoxText, addBobbinInPackageTextBoxText, false));
                    AddColorNameTextBox.Text = "";
                    YarnsListView.ItemsSource = null;
                    YarnsListView.ItemsSource = new SQLYarns().GetAllYarns();

                    MessageBox.Show(Texts.ADDED, "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            
        }

        
        private void BackToPrintButton_Click(object sender, RoutedEventArgs e)
        {
            YarnPrintPanel yarnPrintPanelWindow = new YarnPrintPanel();
            Hide();
            yarnPrintPanelWindow.Show();
        }

        private void YarnListExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       
    }
}

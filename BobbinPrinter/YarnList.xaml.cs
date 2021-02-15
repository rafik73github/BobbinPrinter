using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy YarnList.xaml
    /// </summary>
    public partial class YarnList : Window
    {
        XMLTools xmlTools = new XMLTools();
        private string addMakerTextBoxText;
        private string addTypeTextBoxText;
        private string addSizeTextBoxText;
        public YarnList()
        {
            InitializeComponent();
            
            SelectYarnMakerComboBox.ItemsSource = new SQLYarnmakers().GetAllYarnmakers();
            SelectYarnTypeComboBox.ItemsSource = new SQLYarntypes().GetAllYarntypes();
            SelectYarnSizeComboBox.ItemsSource = new SQLYarnsizes().GetAllYarnsizes();
            YarnsListView.ItemsSource = new SQLYarns().GetAllYarns();
            

        }

       

        private void AddMakerButton_Click(object sender, RoutedEventArgs e)
        {
            addMakerTextBoxText = AddMakerTextBox.Text;
            if(addMakerTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ\n PRODUCENTA PRZĘDZY","BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if(new SQLYarnmakers().IsYarnmakerExist(addMakerTextBoxText))
                {
                    AddMakerTextBox.Text = "";
                    MessageBox.Show("TAKI PRODUCENT PRZĘDZY\n JUŻ ISTNIEJE!", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarnmakers().AddYarnmaker(new YarnmakersModel(addMakerTextBoxText.ToUpper(), false));
                    AddMakerTextBox.Text = "";
                    MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);

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
                MessageBox.Show("NIE WPISAŁEŚ\n TYPU PRZĘDZY", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarntypes().IsYarntypeExist(addTypeTextBoxText))
                {
                    AddTypeTextBox.Text = "";
                    MessageBox.Show("TAKI TYP PRZĘDZY\n JUŻ ISTNIEJE!", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarntypes().AddYarntype(new YarntypesModel(addTypeTextBoxText.ToUpper(), false));
                    AddTypeTextBox.Text = "";
                    MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);

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
                MessageBox.Show("NIE WPISAŁEŚ\n GRUBOŚCI PRZĘDZY", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarnsizes().IsYarnsizeExist(addSizeTextBoxText))
                {
                    AddSizeTextBox.Text = "";
                    MessageBox.Show("TAKA GRUBOŚĆ PRZĘDZY\n JUŻ ISTNIEJE!", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    new SQLYarnsizes().AddYarnsize(new YarnsizesModel(addSizeTextBoxText.ToUpper(), false));
                    AddSizeTextBox.Text = "";
                    MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);

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



            if (SelectYarnMakerComboBox.SelectedItem == null || SelectYarnTypeComboBox.SelectedItem == null || SelectYarnSizeComboBox.SelectedItem == null || addColorNameTextBoxText.Equals(""))
            {
                MessageBox.Show("UZUPEŁNIJ WSZYSTKIE DANE", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (new SQLYarns().IsYarnExist(yarnmakersModel.YarnmakerId, yarntypesModel.YarntypeId,yarnsizesModel.YarnsizeId,addColorNameTextBoxText))
                {
                    MessageBox.Show("TAKA PRZĘDZA\n JUŻ ISTNIEJE!", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    AddColorNameTextBox.Text = "";
                    

                }
                else
                {
                    new SQLYarns().AddYarn(new YarnsModel(yarnmakersModel.YarnmakerId, yarntypesModel.YarntypeId, yarnsizesModel.YarnsizeId, addColorNameTextBoxText, false));
                    AddColorNameTextBox.Text = "";
                    YarnsListView.ItemsSource = null;
                    YarnsListView.ItemsSource = new SQLYarns().GetAllYarns();

                    MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);
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

       
    }
}

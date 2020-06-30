using System;
using System.Collections.Generic;
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
            
            List<Makers> lM = xmlTools.XMLToSelectYarnMakerComboBox();
            foreach (var recordLM in lM)
            {
                SelectYarnMakerComboBox.Items.Add(recordLM.MakersString);
            }

            List<Types> lT = xmlTools.XMLToSelectYarnTypeComboBox();
            foreach (var recordLT in lT)
            {
                SelectYarnTypeComboBox.Items.Add(recordLT.TypesString);
            }

            List<Sizes> lS = xmlTools.XMLToSelectYarnSizeComboBox();
            foreach (var recordLS in lS)
            {
                SelectYarnSizeComboBox.Items.Add(recordLS.SizesString);
            }

           
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
                xmlTools.XMLAddMaker(addMakerTextBoxText.Trim().ToUpper());
                AddMakerTextBox.Text = "";
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);
                                
                    SelectYarnMakerComboBox.Items.Add(addMakerTextBoxText.Trim().ToUpper());
               
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
                xmlTools.XMLAddType(addTypeTextBoxText.Trim().ToUpper());
                AddTypeTextBox.Text = "";
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectYarnTypeComboBox.Items.Add(addTypeTextBoxText.Trim().ToUpper());

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
                xmlTools.XMLAddSize(addSizeTextBoxText.Trim().ToUpper());
                AddSizeTextBox.Text = "";
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);

                SelectYarnSizeComboBox.Items.Add(addSizeTextBoxText.Trim().ToUpper());

            }
        }

        private void AddYarnButton_Click(object sender, RoutedEventArgs e)
        {
            string selectYarnMakerComboBoxText = SelectYarnMakerComboBox.Text;
            string selectYarnTypeComboBoxText = SelectYarnTypeComboBox.Text;
            string selectYarnSizeComboBoxText = SelectYarnSizeComboBox.Text;
            string addColorNameTextBoxText = AddColorNameTextBox.Text;

            if (selectYarnMakerComboBoxText.Equals("") || selectYarnTypeComboBoxText.Equals("") || selectYarnSizeComboBoxText.Equals("") || addColorNameTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("UZUPEŁNIJ WSZYSTKIE DANE", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                xmlTools.XMLAddYarn(selectYarnMakerComboBoxText.ToUpper(), selectYarnTypeComboBoxText.ToUpper(), selectYarnSizeComboBoxText.ToUpper(), addColorNameTextBoxText.ToUpper());
                AddColorNameTextBox.Text = "";
                SelectYarnMakerComboBox.SelectedIndex = -1;
                SelectYarnTypeComboBox.SelectedIndex = -1;
                SelectYarnSizeComboBox.SelectedIndex = -1;
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);
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

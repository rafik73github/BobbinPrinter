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
        private string addMakerNameTextBoxText;
        public YarnList()
        {
            InitializeComponent();
            
            List<Makers> lM = xmlTools.XMLToSelectYarnMakerComboBox();
            foreach (var record in lM)
            {
                SelectYarnMakerComboBox.Items.Add(record.MakersString);
            }
        }

        private void YarnListExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            this.Hide();
            mW.Show();
        }

        private void AddMakerNameButton_Click(object sender, RoutedEventArgs e)
        {
            addMakerNameTextBoxText = AddMakerNameTextBox.Text;
            if(addMakerNameTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ PRODUCENTA\n I TYPU PRZĘDZY","BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                xmlTools.XMLAddElementMaker(addMakerNameTextBoxText.Trim().ToUpper());
                AddMakerNameTextBox.Text = "";
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);
                                
                    SelectYarnMakerComboBox.Items.Add(addMakerNameTextBoxText.Trim().ToUpper());
               
            }
        }

        private void AddColorNameButton_Click(object sender, RoutedEventArgs e)
        {
            string selectYarnMakerComboBoxText = SelectYarnMakerComboBox.Text;
            string addColorNameTextBoxText = AddColorNameTextBox.Text;

            if (selectYarnMakerComboBoxText.Equals("") || addColorNameTextBoxText.Trim().Equals(""))
            {
                MessageBox.Show("NIE WPISAŁEŚ\n KOLORU PRZĘDZY", "BŁAD DODAWANIA WPISU", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                xmlTools.XMLAddElementYarn(selectYarnMakerComboBoxText.ToUpper(), addColorNameTextBoxText.ToUpper());
                AddColorNameTextBox.Text = "";
                SelectYarnMakerComboBox.SelectedIndex = -1;
                MessageBox.Show("DODANO", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

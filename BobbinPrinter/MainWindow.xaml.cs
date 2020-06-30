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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XMLTools xmlTools = new XMLTools();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddPrintButton_Click(object sender, RoutedEventArgs e)
        {
            //xmlTools.XMLAddElementTextill("Frafil","A100 32/2","Nero");
            xmlTools.XMLAddMaker("Frafil");
        }

        private void YarnListButton_Click(object sender, RoutedEventArgs e)
        {
            YarnList yL = new YarnList();
            this.Hide();
            yL.Show();
        }

        private void MainMenuExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}

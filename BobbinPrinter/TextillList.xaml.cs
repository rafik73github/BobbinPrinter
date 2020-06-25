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
    /// Logika interakcji dla klasy TextillList.xaml
    /// </summary>
    public partial class TextillList : Window
    {
        public TextillList()
        {
            InitializeComponent();
        }

        private void TextillListExitProgramButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BackToMainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            this.Hide();
            mW.Show();
        }
    }
}

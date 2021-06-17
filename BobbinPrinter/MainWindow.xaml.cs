using System.Windows;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            AddPrintButton.Focus();
        }

        private void AddPrintButton_Click(object sender, RoutedEventArgs e)
        {
            YarnPrintPanel yPP = new YarnPrintPanel();
            Hide();
            yPP.Show();
        }

        private void YarnListButton_Click(object sender, RoutedEventArgs e)
        {
            YarnList yL = new YarnList();
            Hide();
            yL.Show();
        }

        private void MainMenuExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}

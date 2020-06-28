using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        XMLTools xTools = new XMLTools();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if(File.Exists("yarns.xml"))
            {
                OpenMainWindow();
            }
            else
            {
                xTools.XMLcreate();
                OpenMainWindow();
            }
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}

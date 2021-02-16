﻿using System.Windows;
using BobbinPrinter.SQL;

namespace BobbinPrinter
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        //XMLTools xTools = new XMLTools();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            /*
            if(File.Exists("yarns.xml"))
            {
                OpenMainWindow();
            }
            else
            {
                xTools.XMLcreate();
                OpenMainWindow();
            }
            */
            new SQLYarnmakers().CreateTableYarnmakers();
            new SQLYarntypes().CreateTableYarntypes();
            new SQLYarnsizes().CreateTableYarnsizes();
            new SQLYarns().CreateTableYarns();
            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

    }
}

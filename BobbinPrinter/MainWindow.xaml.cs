﻿using System;
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
            xmlTools.XMLchange();
        }

        private void TextillListButton_Click(object sender, RoutedEventArgs e)
        {
            TextillList tL = new TextillList();
            this.Hide();
            tL.Show();
        }

        private void MainMenuExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
    }
}

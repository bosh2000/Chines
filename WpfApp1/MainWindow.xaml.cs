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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDictionaryLoad;
        private bool isLineLoad;
        private string DictionaryFileName;
        private string LineFileName;
        public MainWindow()
        {
            InitializeComponent();
            DictionaryFileName = "E:\\dictionary.csv";
            LineFileName = "E:\\titles.csv";
            ProcessButton_Click(this, null);
        }

        private void DictionarySelectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StringLineSelectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

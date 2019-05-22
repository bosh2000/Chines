using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDictionaryLoad;
        private bool isLineLoad;
        private string DictionaryFileName = string.Empty;
        private string LineFileName = string.Empty;
        private Vertex tree;

        public MainWindow()
        {
            InitializeComponent();
            DictionaryFileName = "E:\\dictionary.csv";
            LineFileName = "E:\\titles.csv";
            DictionarySelectLabel.Content = DictionaryFileName;
            LineSelectLabel.Content = LineFileName;
            Logger.Init(LogTextArea, Dispatcher);

           // ProcessButton_Click(this, null);
        }

        private void DictionarySelectButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void StringLineSelectButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private async void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (DictionaryFileName == string.Empty) { Logger.Error("Не выбран файл словаря."); return; }
            if (LineFileName == string.Empty) { Logger.Error("Не выбран файл со строками разбора"); return; }
            try
            {
                Dictionary dictionary = new Dictionary(tree);
                dictionary.LoadDictionary(DictionaryFileName);
                Lines lines = new Lines();
                lines.LoadLines(LineFileName);
                await Task.Run(() =>
                {
                    new Translate(tree, lines).ProccessTranslate();
                });
            } catch (ChinaExceptions exp)
            {
                Logger.Error(exp.Message);
            }
        }
        
    }
}
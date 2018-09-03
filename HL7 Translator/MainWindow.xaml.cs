using System.Windows;

namespace HL7_Translator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            MainFrame.Content = new HomePage();
        }

       
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SettingsPage();
        }
    }
}

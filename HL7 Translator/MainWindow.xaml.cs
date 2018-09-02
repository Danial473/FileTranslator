using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;

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
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            string defaultPath = string.Empty;
            if (ConfigurationManager.AppSettings.AllKeys.Contains("DefaultPath"))
                defaultPath = ConfigurationManager.AppSettings["DefaultPath"];

            if (!string.IsNullOrEmpty(defaultPath))
                openFileDialog.InitialDirectory = defaultPath;

            if (openFileDialog.ShowDialog() == true)
            {
                var HL7Content = File.ReadAllText(openFileDialog.FileName);

                var fileProcessor = new HL7FileProcessor();
                fileProcessor.ProcessContent(HL7Content, BatchDateTextBox.Text, BatchNumberTextBox.Text);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

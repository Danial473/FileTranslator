using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using HL7_Translator.Properties;

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

            var defaultPath = Settings.Default["DefaultPath"].ToString();

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

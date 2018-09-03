using System.IO;
using System.Windows;
using System.Windows.Controls;
using HL7_Translator.Properties;
using Microsoft.Win32;

namespace HL7_Translator
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(BatchDateTextBox.Text))
            {
                System.Windows.MessageBox.Show("Please enter batch date first", "", MessageBoxButton.OK);
                BatchDateTextBox.Focus();
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            var defaultPath = Settings.Default["FileSourceDefaultPath"].ToString();

            if (!string.IsNullOrEmpty(defaultPath))
                openFileDialog.InitialDirectory = defaultPath;

            if (openFileDialog.ShowDialog() == true)
            {
                var HL7Content = File.ReadAllText(openFileDialog.FileName);

                var fileProcessor = new HL7FileProcessor();
                fileProcessor.ProcessContent(HL7Content, BatchDateTextBox.Text, BatchNumberTextBox.Text);

                System.Windows.MessageBox.Show("Translation process completed", "", MessageBoxButton.OK);

            }
        }
    }
}

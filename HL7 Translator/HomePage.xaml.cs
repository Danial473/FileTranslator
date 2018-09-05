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
            if (string.IsNullOrEmpty(BatchDatePicker.Text))
            {
                System.Windows.MessageBox.Show("Please enter batch date", "", MessageBoxButton.OK);
                BatchDatePicker.Focus();
                return;
            }

            if(BatchNumberComboBox.SelectedItem == null)
            {
                System.Windows.MessageBox.Show("Please choose batch number", "", MessageBoxButton.OK);
                BatchNumberComboBox.Focus();
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();

            var defaultPath = Settings.Default["FileSourceDefaultPath"].ToString();

            if (!string.IsNullOrEmpty(defaultPath))
                openFileDialog.InitialDirectory = defaultPath;

            if (openFileDialog.ShowDialog() == true)
            {
                var HL7Content = File.ReadAllText(openFileDialog.FileName);

                string month = BatchDatePicker.DisplayDate.Month < 10 ? $"0{BatchDatePicker.DisplayDate.Month}" : BatchDatePicker.DisplayDate.Month.ToString();
                string day = BatchDatePicker.DisplayDate.Day < 10 ? $"0{BatchDatePicker.DisplayDate.Day}" : BatchDatePicker.DisplayDate.Day.ToString();

                var fileProcessor = new HL7FileProcessor();
                fileProcessor.ProcessContent(HL7Content, $"{month}{day}", BatchNumberComboBox.Text);

                System.Windows.MessageBox.Show("Translation process completed", "", MessageBoxButton.OK);

            }
        }
    }
}

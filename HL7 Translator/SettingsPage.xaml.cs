using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HL7_Translator.Properties;
using System.Windows.Forms;

namespace HL7_Translator
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();

            DestinationTextBox.Text = Settings.Default.FileDestinationDefaultPath;
            SourceTextBox.Text = Settings.Default.FileSourceDefaultPath;
            SplitterTextBox.Text = Settings.Default.FileSplitterString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string destination = DestinationTextBox.Text.Trim();
            Settings.Default.FileDestinationDefaultPath = destination.Last() == '\\' ? destination.Remove(destination.Length - 1, 1) : destination;

            string source = SourceTextBox.Text.Trim();
            Settings.Default.FileSourceDefaultPath = source.Last() == '\\' ? source.Remove(source.Length - 1, 1) : source;

            Settings.Default.FileSplitterString = SplitterTextBox.Text.Trim();

            Settings.Default.Save();

            if (System.Windows.MessageBox.Show("Settings successfully saved!", "", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                this.NavigationService.GoBack();
            }
        }

        private void DestinationChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Settings.Default.FileDestinationDefaultPath;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                DestinationTextBox.Text = dialog.SelectedPath;
            }
        }

        private void SourceChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Settings.Default.FileSourceDefaultPath;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SourceTextBox.Text = dialog.SelectedPath;
            }
        }

        private void SplitterChooserBtn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Settings.Default.FileSplitterString;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SplitterTextBox.Text = dialog.SelectedPath;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}

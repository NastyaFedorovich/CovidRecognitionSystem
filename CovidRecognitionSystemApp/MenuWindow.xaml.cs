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
using System.Windows.Shapes;

namespace CovidRecognitionSystemApp
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void TrackingDataButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Visible;
            TreatmentPanel.Visibility = Visibility.Hidden;
            PreventionPanel.Visibility = Visibility.Hidden;
        }

        private void TreatmentButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Hidden;
            TreatmentPanel.Visibility = Visibility.Visible;
            PreventionPanel.Visibility = Visibility.Hidden;
        }

        private void PreventionButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Hidden;
            TreatmentPanel.Visibility = Visibility.Hidden;
            PreventionPanel.Visibility = Visibility.Visible;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void StartDiagnosticButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Visible;
            TrackingDataPanel.Visibility = Visibility.Hidden;
            TreatmentPanel.Visibility = Visibility.Hidden;
            PreventionPanel.Visibility = Visibility.Hidden;
        }
    }
}

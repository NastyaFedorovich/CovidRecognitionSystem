using CovidRecognitionSystem.DAL.Repositories;
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
        private int _questionIndex;
        private QuestionRepository _questionRepository;
        private List<RadioButton> _currentButtons;

        public MenuWindow()
        {
            InitializeComponent();

            _questionIndex = 0;
            _questionRepository = new QuestionRepository();
            _currentButtons = new List<RadioButton>();
        }

        private void TrackingDataButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Visible;
            TreatmentPanel.Visibility = Visibility.Hidden;
            PreventionPanel.Visibility = Visibility.Hidden;
            FonImg.Visibility = Visibility.Hidden;
        }

        private void TreatmentButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Hidden;
            TreatmentPanel.Visibility = Visibility.Visible;
            PreventionPanel.Visibility = Visibility.Hidden;
            FonImg.Visibility = Visibility.Hidden;
        }

        private void PreventionButton_Click(object sender, RoutedEventArgs e)
        {
            StartDiagnosticPanel.Visibility = Visibility.Hidden;
            TrackingDataPanel.Visibility = Visibility.Hidden;
            TreatmentPanel.Visibility = Visibility.Hidden;
            PreventionPanel.Visibility = Visibility.Visible;
            FonImg.Visibility = Visibility.Hidden;
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
            FonImg.Visibility = Visibility.Hidden;

            _questionIndex = 0;

            ViewQuestion();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_questionIndex == _questionRepository.Questions.Count - 1)
                {
                    NextButton.Content = "Результат";
                    GetResultFromBtn();
                }
                else if (_questionIndex == _questionRepository.Questions.Count)
                {
                    GetResultFromBtn();

                    NextButton.Visibility = Visibility.Hidden;
                    QuestionText.Text = "";
                    RadioButtonsPanel.Children.Clear();

                    CovidChanceLabel.Content = $"Вероятность ковида: {_questionRepository.GetCovidChance()}%";
                    GrippeChanceLabel.Content = $"Вероятность гриппа: {_questionRepository.GetGrippeChance()}%";
                    OrviChanceLabel.Content = $"Вероятность ОРВИ: {_questionRepository.GetOrviChance()}%";

                    CovidChanceLabel.Visibility = Visibility.Visible;
                    GrippeChanceLabel.Visibility = Visibility.Visible;
                    OrviChanceLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    GetResultFromBtn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
        }

        private void ViewQuestion()
        {
            RadioButtonsPanel.Children.Clear();
            _currentButtons.Clear();

            QuestionText.Text = _questionRepository.Questions[_questionIndex].Title;

            foreach (var key in _questionRepository.Questions[_questionIndex].AnsverPercentsPair.Keys)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = key;
                radioButton.VerticalContentAlignment = VerticalAlignment.Center;

                RadioButtonsPanel.Children.Add(radioButton);
                _currentButtons.Add(radioButton);
            }

            _questionIndex++;
        }

        private void GetResultFromBtn()
        {
            bool isAnyBtnChecked = false;

            foreach (RadioButton radioButton in _currentButtons)
            {
                if (radioButton.IsChecked == true)
                {
                    _questionRepository.SetBalls(_questionIndex - 1, radioButton.Content.ToString());
                    isAnyBtnChecked = true;
                    break;
                }
            }

            if (!isAnyBtnChecked) MessageBox.Show("Вариант ответа не выбран", "Ошибка!");
            else
            {
                if (_questionIndex != _questionRepository.Questions.Count) ViewQuestion();
            }
        }
    }
}

using CovidRecognitionSystem.DAL;
using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
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
        public Patient CurrentPatient;
        public Disease _computerDiagnosis;

        QuestionRepository _questionRepository;
        IUnitOfWork _unitOfWork;

        private List<RadioButton> _currentButtons;

        public bool IsPatientExists = false;

        public MenuWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _questionIndex = 0;
            _questionRepository = new QuestionRepository();
            _unitOfWork = unitOfWork;

            _currentButtons = new List<RadioButton>();

            foreach (Disease disease in Enum.GetValues(typeof(Disease)))
                DiseasesComboBox.Items.Add(Service.GetDiseaseName(disease));

            foreach (PatientStatus status in Enum.GetValues(typeof(PatientStatus)))
                PatientStatusComboBox.Items.Add(Service.GetPatientStatusName(status));
        }

        private void TrackingDataButton_Click(object sender, RoutedEventArgs e)
        {
            EnterPatientWindow enterPatientWindow = new EnterPatientWindow(_unitOfWork, this, true);
            if (enterPatientWindow.ShowDialog() == true)
            {
                StartDiagnosticPanel.Visibility = Visibility.Hidden;
                TrackingDataPanel.Visibility = Visibility.Visible;
                TreatmentPanel.Visibility = Visibility.Hidden;
                PreventionPanel.Visibility = Visibility.Hidden;
                FonImg.Visibility = Visibility.Hidden;
            }
        }

        public void AddTrackingData()
        {
            try
            {
                SickLeave sickLeave = _unitOfWork.SickLeaveRepository.GetAll().FirstOrDefault(s => s.PatientId == CurrentPatient.Id);
                Diagnosis diagnosis = _unitOfWork.DiagnosisRepository.GetAll().FirstOrDefault(d => d.SickLeaveId == sickLeave.Id);

                FioLabel.Content = $"ФИО пациента: {CurrentPatient.Surname} {CurrentPatient.Name} {CurrentPatient.MiddleName}";
                BirthDateLabel.Content = $"Дата рождения: {CurrentPatient.BirthDate.ToString("d")}";
                DoctorDiagnosisLabel.Content = $"Диагноз доктора: {Service.GetDiseaseName(diagnosis.DoctorDiagnosis)}";
                ComputerDiagnosisLabel.Content = $"Диагноз компьютера: {Service.GetDiseaseName(diagnosis.ComputerDiagnosis)}";
                PatientConditionLabel.Content = $"Нынешнее состояние пациента: {Service.GetPatientStatusName(sickLeave.PatientStatus)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            _unitOfWork.AuthManager.SignOut();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void StartDiagnosticButton_Click(object sender, RoutedEventArgs e)
        {
            EnterPatientWindow enterPatientWindow = new EnterPatientWindow(_unitOfWork, this);
            if (enterPatientWindow.ShowDialog() == true)
            {
                StartDiagnosticPanel.Visibility = Visibility.Visible;
                TrackingDataPanel.Visibility = Visibility.Hidden;
                TreatmentPanel.Visibility = Visibility.Hidden;
                PreventionPanel.Visibility = Visibility.Hidden;
                FonImg.Visibility = Visibility.Hidden;

                AddDoctorDiagnosisButton.IsEnabled = true;
                NextButton.Visibility = Visibility.Visible;

                CovidChanceLabel.Visibility = Visibility.Hidden;
                GrippeChanceLabel.Visibility = Visibility.Hidden;
                OrviChanceLabel.Visibility = Visibility.Hidden;
                SetComputerDiagnosisLabel.Visibility = Visibility.Hidden;
                SetDoctorDiagnosisLabel.Visibility = Visibility.Hidden;
                DiseasesComboBox.Visibility = Visibility.Hidden;
                AddDoctorDiagnosisButton.Visibility = Visibility.Hidden;

                _questionIndex = 0;

                ViewQuestion();
            }
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

                    _computerDiagnosis = _questionRepository.GetDiagnosis();

                    CovidChanceLabel.Content = $"Вероятность ковида: {_questionRepository.GetCovidChance()}%";
                    GrippeChanceLabel.Content = $"Вероятность гриппа: {_questionRepository.GetGrippeChance()}%";
                    OrviChanceLabel.Content = $"Вероятность ОРВИ: {_questionRepository.GetOrviChance()}%";
                    SetComputerDiagnosisLabel.Content = $"Диагноз компьютера: {Service.GetDiseaseName(_computerDiagnosis)}";
                    SetDoctorDiagnosisLabel.Content = $"Диагноз врача: ";

                    CovidChanceLabel.Visibility = Visibility.Visible;
                    GrippeChanceLabel.Visibility = Visibility.Visible;
                    OrviChanceLabel.Visibility = Visibility.Visible;
                    SetComputerDiagnosisLabel.Visibility = Visibility.Visible;
                    SetDoctorDiagnosisLabel.Visibility = Visibility.Visible;
                    DiseasesComboBox.Visibility = Visibility.Visible;
                    AddDoctorDiagnosisButton.Visibility = Visibility.Visible;
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

        private void SaveCommentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DoctorCommentTextBox.Text == "")
                    throw new Exception("Комментарий не должен быть пустым!");

                _unitOfWork.CommentRepository.Create(new DoctorComment
                {
                    DoctorId = _unitOfWork.AuthManager.GetSignedInUser().Id,
                    PatientId = CurrentPatient.Id,
                    CommentDateTime = DateTime.Now,
                    Text = DoctorCommentTextBox.Text,
                });

                MessageBox.Show("Комментарий добавлен!");
                DoctorCommentTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddDoctorDiagnosisButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DiseasesComboBox.SelectedItem == null)
                    throw new Exception("Выберите заболевание!");

                if (IsPatientExists)
                {
                    _unitOfWork.DiagnosisRepository.Create(new Diagnosis
                    {
                        SickLeaveId = _unitOfWork.SickLeaveRepository.GetAll().FirstOrDefault(s => s.PatientId == CurrentPatient.Id).Id,
                        ComputerDiagnosis = _computerDiagnosis,
                        DoctorDiagnosis = Service.GetDiseaseFromStr(DiseasesComboBox.SelectedItem.ToString()),
                        Date = DateTime.Now
                    });
                }
                else
                {
                    _unitOfWork.SickLeaveRepository.Create(new SickLeave
                    {
                        PatientId = CurrentPatient.Id,
                        PatientStatus = PatientStatus.Ill
                    });
                    _unitOfWork.DiagnosisRepository.Create(new Diagnosis
                    {
                        SickLeaveId = _unitOfWork.SickLeaveRepository.GetAll().FirstOrDefault(s => s.PatientId == CurrentPatient.Id).Id,
                        ComputerDiagnosis = _computerDiagnosis,
                        DoctorDiagnosis = Service.GetDiseaseFromStr(DiseasesComboBox.SelectedItem.ToString()),
                        Date = DateTime.Now
                    });
                }

                MessageBox.Show("Диагноз сохранён!");
                AddDoctorDiagnosisButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeConditionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PatientStatusComboBox.SelectedItem == null)
                    throw new Exception("Выберите статус пациента!");

                SickLeave sickLeave = _unitOfWork.SickLeaveRepository.GetAll().FirstOrDefault(s => s.PatientId == CurrentPatient.Id);

                if (sickLeave.PatientStatus == PatientStatus.Dead)
                    if (MessageBox.Show("Вы уверены, что хотите изменить статус мёртвого пациента?", "Внимание!", MessageBoxButton.OKCancel) != MessageBoxResult.OK)
                        return;

                sickLeave.PatientStatus = Service.GetPatientStatusFromStr(PatientStatusComboBox.SelectedItem.ToString());

                _unitOfWork.SickLeaveRepository.Update(sickLeave);

                MessageBox.Show("Статус изменён!");
                PatientConditionLabel.Content = $"Нынешнее состояние пациента: {Service.GetPatientStatusName(sickLeave.PatientStatus)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

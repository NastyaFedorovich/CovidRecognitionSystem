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
    /// Логика взаимодействия для EnterPatientWindow.xaml
    /// </summary>
    public partial class EnterPatientWindow : Window
    {
        IUnitOfWork _unitOfWork;

        MenuWindow _owner;
        bool _isTraking;

        public EnterPatientWindow(IUnitOfWork unitOfWork, MenuWindow owner, bool isTraking = false)
        {
            InitializeComponent();
            
            _unitOfWork = unitOfWork;
            _owner = owner;
            _isTraking = isTraking;

            if (isTraking)
            {
                ButtonsPanel.Visibility = Visibility.Hidden;
                ExistsPatientPanel.Visibility = Visibility.Visible;
            }
        }

        private void NewPatientButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonsPanel.Visibility = Visibility.Hidden;
            NewPatientPanel.Visibility = Visibility.Visible;
        }

        private void ExistsPatientButton_Click(object sender, RoutedEventArgs e)
        {
            ButtonsPanel.Visibility = Visibility.Hidden;
            ExistsPatientPanel.Visibility = Visibility.Visible;
        }

        private void NewStartDiagnosticButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NewPatientSurnameTextBox.Text == "" || NewPatientNameTextBox.Text == "" || NewPatientMiddleNameTextBox.Text == ""
                    || NewPatientBirthDateTextBox.Text == "" || PatientAddressTextBox.Text == "")
                    throw new Exception("Все поля должны быть заполнены!");

                if (!DateTime.TryParse(NewPatientBirthDateTextBox.Text, out DateTime birthDate))
                    throw new Exception("Дата рождения не соответствует нужному формату!");

                Patient patient = new Patient
                {
                    Surname = NewPatientSurnameTextBox.Text,
                    Name = NewPatientNameTextBox.Text,
                    MiddleName = NewPatientMiddleNameTextBox.Text,
                    BirthDate = birthDate,
                    Address = PatientAddressTextBox.Text
                };

                _unitOfWork.PatientRepository.Create(patient);

                _owner.CurrentPatient = patient;
                _owner.IsPatientExists = false;

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExistsStartDiagnosticButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ExistsPatientSurnameTextBox.Text == "" || ExistsPatientNameTextBox.Text == "" 
                    || ExistsPatientMiddleNameTextBox.Text == "" || ExistsPatientBirthDateTextBox.Text == "")
                    throw new Exception("Все поля должны быть заполнены!");

                if (!DateTime.TryParse(ExistsPatientBirthDateTextBox.Text, out DateTime birthDate))
                    throw new Exception("Дата рождения не соответствует нужному формату!");

                Patient patient = _unitOfWork.PatientRepository.GetAll().FirstOrDefault(p =>
                    p.Surname == ExistsPatientSurnameTextBox.Text &&
                    p.Name == ExistsPatientNameTextBox.Text &&
                    p.MiddleName == ExistsPatientMiddleNameTextBox.Text &&
                    p.BirthDate == birthDate);

                _owner.CurrentPatient = patient;

                if (patient == null) throw new Exception("Пациент не найден!");

                if (_isTraking)
                {
                    _owner.AddTrackingData();
                }
                else
                {
                    if (_unitOfWork.SickLeaveRepository.GetAll().FirstOrDefault(s => s.PatientId == patient.Id).PatientStatus == PatientStatus.Dead)
                    {
                        MessageBox.Show("Переобследование невозможно по причине смерти пациента");
                        return;
                    }
                }

                _owner.IsPatientExists = true;
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

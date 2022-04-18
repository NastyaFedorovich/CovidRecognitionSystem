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
    /// Логика взаимодействия для SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        private readonly IDoctorRepository _doctorRepository;

        public SignUpWindow()
        {
            _doctorRepository = new DoctorRepository(new AppDbContext());
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            var fullName = FullNameTB.Text;
            var login = LoginTB.Text;
            var password = PasswordTB.Text;

            if (_doctorRepository.GetAll().FirstOrDefault(doctor => doctor.Login.Equals(login)) != null)
            {
                MessageBox.Show("Пользователь с таким логином уже существует");
            }
            else
            {
                _doctorRepository.Create(new Doctor { FullName = fullName, Login = login, Password = password });

                var window = new SignInWindow();
                window.Show();
                Close();
            }
        }
    }
}

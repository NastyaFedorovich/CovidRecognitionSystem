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
        private readonly IUnitOfWork _unitOfWork;

        public SignUpWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _unitOfWork.DoctorRepository.Create(new Doctor
                {
                    FullName = FullNameTB.Text,
                    Login = LoginTB.Text,
                    Password = PasswordTB.Text
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

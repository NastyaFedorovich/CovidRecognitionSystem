using CovidRecognitionSystem.DAL;
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
    /// Логика взаимодействия для SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public SignInWindow(IUnitOfWork unitOfWork)
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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _unitOfWork.AuthManager.SignIn(LoginTB.Text, PasswordTB.Text);

                MenuWindow menuWindow = new MenuWindow(_unitOfWork);
                menuWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

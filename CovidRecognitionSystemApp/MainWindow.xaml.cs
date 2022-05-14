using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CovidRecognitionSystem.DAL;
using CovidRecognitionSystem.DAL.Repositories;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;

namespace CovidRecognitionSystemApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                AppDbContext dbContext = new AppDbContext();
                _unitOfWork = new UnitOfWork(dbContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignInWindow signInWindow = new SignInWindow(_unitOfWork);
            signInWindow.Show();

            Close();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow(_unitOfWork);
            signUpWindow.Show();

            Close();
        }
    }
}

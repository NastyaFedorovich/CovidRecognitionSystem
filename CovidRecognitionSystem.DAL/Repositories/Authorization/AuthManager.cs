using CovidRecognitionSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Authorization
{
    public class AuthManager : IAuthManager
    {
        private Doctor _signedInUser;

        private readonly AppDbContext _dbContext;
        private readonly DoctorRepository _doctorRepository;

        public AuthManager(AppDbContext dbContext, DoctorRepository doctorRepository)
        {
            _dbContext = dbContext;
            _doctorRepository = doctorRepository;
        }

        public Doctor GetSignedInUser() => _signedInUser;

        public void SignIn(string login, string password)
        {
            _signedInUser = _doctorRepository.GetAll().FirstOrDefault(doctor => doctor.Login.Equals(login) && doctor.Password.Equals(password));

            if (_signedInUser == null) throw new Exception("Неверный логин или пароль!");
        }

        public void SignOut() => _signedInUser = null;
    }
}

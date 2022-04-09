using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private AppDbContext _dbContext;

        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Doctor Create(Doctor entity)
        {
            _dbContext.Doctors.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Doctor entity)
        {
            var findDoctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == entity.Id);
            if (findDoctor != null)
            {
                _dbContext.Doctors.Remove(findDoctor);
                _dbContext.SaveChanges();
            }
        }

        public List<Doctor> GetAll()
        {
            return _dbContext.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _dbContext.Doctors.First(d => d.Id == id);
        }

        public void Update(Doctor entity)
        {
            var findDoctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == entity.Id);

            if (findDoctor != null)
            {
                findDoctor.FullName = entity.FullName;
                findDoctor.Login = entity.Login;
                findDoctor.Password = entity.Password;

                _dbContext.Doctors.Update(findDoctor);
                _dbContext.SaveChanges();
            }
        }
    }
}

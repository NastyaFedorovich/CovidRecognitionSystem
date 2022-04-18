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
        /// <summary>
        /// Doctor Repository
        /// </summary>
        /// <param name="dbContext"></param>
        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Create Doctor
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Doctor Create(Doctor entity)
        {
            _dbContext.Doctors.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Delete Doctor
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Doctor entity)
        {
            var findDoctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == entity.Id);
            if (findDoctor != null)
            {
                _dbContext.Doctors.Remove(findDoctor);
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Get Doctors
        /// </summary>
        /// <returns></returns>
        public List<Doctor> GetAll()
        {
            return _dbContext.Doctors.ToList();
        }
        /// <summary>
        /// Get By Id Doctor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Doctor GetById(int id)
        {
            return _dbContext.Doctors.First(d => d.Id == id);
        }
        /// <summary>
        /// Update Doctor
        /// </summary>
        /// <param name="entity"></param>
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

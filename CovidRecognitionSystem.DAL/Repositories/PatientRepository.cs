using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private AppDbContext _dbContext;
        /// <summary>
        /// Patient Repository
        /// </summary>
        /// <param name="dbContext"></param>
        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Create Patient
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Patient Create(Patient entity)
        {
            _dbContext.Patients.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Delete Patient
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Patient entity)
        {
            var findPatient = _dbContext.Patients.FirstOrDefault(p => p.Id == entity.Id);
            if (findPatient != null)
            {
                _dbContext.Patients.Remove(findPatient);
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Get Patient
        /// </summary>
        /// <returns></returns>
        public List<Patient> GetAll()
        {
            return _dbContext.Patients.ToList();
        }
        /// <summary>
        ///  Get By Id Patient
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Patient GetById(int id)
        {
            return _dbContext.Patients.First(p => p.Id == id);
        }
        /// <summary>
        /// Get By Surname Patient
        /// </summary>
        /// <param name="surname"></param>
        /// <returns></returns>
        public Patient GetBySurname(string surname)
        {
            return _dbContext.Patients.First(p => p.Surname == surname);
        }
        /// <summary>
        /// Update Patient
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Patient entity)
        {
            var findPatient = _dbContext.Patients.FirstOrDefault(p => p.Id == entity.Id);

            if (findPatient != null)
            {
                findPatient.Address = entity.Address;
                findPatient.Surname = entity.Surname;
                findPatient.BirthDate = entity.BirthDate;
                findPatient.MiddleName = entity.MiddleName;
                findPatient.Name = entity.Name;

                _dbContext.Patients.Update(findPatient);
                _dbContext.SaveChanges();
            }
        }
    }
}

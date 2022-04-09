using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private AppDbContext _dbContext;

        public PatientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Patient Create(Patient entity)
        {
            _dbContext.Patients.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(Patient entity)
        {
            var findPatient = _dbContext.Patients.FirstOrDefault(p => p.Id == entity.Id);
            if (findPatient != null)
            {
                _dbContext.Patients.Remove(findPatient);
                _dbContext.SaveChanges();
            }
        }

        public List<Patient> GetAll()
        {
            return _dbContext.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _dbContext.Patients.First(p => p.Id == id);
        }

        public Patient GetBySurname(string surname)
        {
            return _dbContext.Patients.First(p => p.Surname == surname);
        }

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

using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private PatientDatabaseContext _databaseContext;

        public PatientRepository(PatientDatabaseContext patientDatabase)
        {
            _databaseContext = patientDatabase;
        }

        public Patient Create(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }

        public void Delete(Patient patient)
        {
            var findPatient = _databaseContext.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (findPatient != null) 
            {
                _databaseContext.Patients.Remove(findPatient);
                _databaseContext.SaveChanges();
            }
        }

        public List<Patient> GetAll()
        {
            return _databaseContext.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _databaseContext.Patients.First(p => p.Id == id);
        }

        public Patient GetBySurname(string surname)
        {
            return _databaseContext.Patients.First(p => p.Surname == surname);
        }

        public void Update(Patient patient)
        {
            var findPatient = _databaseContext.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (findPatient != null)
            {
                findPatient.Address = patient.Address;
                findPatient.Surname = patient.Surname;
                findPatient.DateTime = patient.DateTime;
                findPatient.MiddleName = patient.MiddleName;
                findPatient.Name = patient.Name;

                _databaseContext.Patients.Update(findPatient);
                _databaseContext.SaveChanges();
            }
        }
    }
}

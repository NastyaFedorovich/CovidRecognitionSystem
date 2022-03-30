using CovidRecognitionSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        public Patient Create(Patient patient);

        public Patient GetById(int id);

        public Patient GetBySurname(string surname);

        public List<Patient> GetAll();

        public void Update(Patient patient);

        public void Delete(Patient patient);
    }
}

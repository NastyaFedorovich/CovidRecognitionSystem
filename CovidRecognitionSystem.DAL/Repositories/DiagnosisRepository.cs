using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class DiagnosisRepository : IDiagnosisRepository
    {
        private AppDbContext _dbContext;
        /// <summary>
        /// Diagnosis Repository
        /// </summary>
        /// <param name="dbContext"></param>
        public DiagnosisRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        ///  Diagnosis Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Diagnosis Create(Diagnosis entity)
        {
            _dbContext.Diagnosis.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// Delete Diagnosis
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(Diagnosis entity)
        {
            var findDiagnosis = _dbContext.Diagnosis.FirstOrDefault(d => d.Id == entity.Id);
            if (findDiagnosis != null)
            {
                _dbContext.Diagnosis.Remove(findDiagnosis);
                _dbContext.SaveChanges();
            }
        }
        /// <summary>
        /// Get Diagnosis
        /// </summary>
        /// <returns></returns>
        public List<Diagnosis> GetAll()
        {
            return _dbContext.Diagnosis.ToList();
        }
        /// <summary>
        /// Get By Id Diagnosis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Diagnosis GetById(int id)
        {
            return _dbContext.Diagnosis.First(d => d.Id == id);
        }
        /// <summary>
        /// Update Diagnosis
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Diagnosis entity)
        {
            var findDiagnosis = _dbContext.Diagnosis.FirstOrDefault(d => d.Id == entity.Id);

            if (findDiagnosis != null)
            {
                findDiagnosis.SickLeaveId = entity.SickLeaveId;
                findDiagnosis.ComputerDiagnosis = entity.ComputerDiagnosis;
                findDiagnosis.DoctorDiagnosis = entity.DoctorDiagnosis;
                findDiagnosis.Date = entity.Date;

                _dbContext.Diagnosis.Update(findDiagnosis);
                _dbContext.SaveChanges();
            }
        }
    }
}

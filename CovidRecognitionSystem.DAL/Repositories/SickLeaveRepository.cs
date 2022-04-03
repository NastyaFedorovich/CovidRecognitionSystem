using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class SickLeaveRepository : ISickLeaveRepository
    {
        private AppDbContext _dbContext;

        public SickLeaveRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SickLeave Create(SickLeave entity)
        {
            _dbContext.SickLeaves.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(SickLeave entity)
        {
            var findSickLeave = _dbContext.SickLeaves.FirstOrDefault(sl => sl.Id == entity.Id);
            if (findSickLeave != null)
            {
                _dbContext.SickLeaves.Remove(findSickLeave);
                _dbContext.SaveChanges();
            }
        }

        public List<SickLeave> GetAll()
        {
            return _dbContext.SickLeaves.ToList();
        }

        public SickLeave GetById(int id)
        {
            return _dbContext.SickLeaves.First(d => d.Id == id);
        }

        public void Update(SickLeave entity)
        {
            var findSickLeave = _dbContext.SickLeaves.FirstOrDefault(sl => sl.Id == entity.Id);

            if (findSickLeave != null)
            {
                findSickLeave.PatientId = entity.PatientId;

                _dbContext.SickLeaves.Update(findSickLeave);
                _dbContext.SaveChanges();
            }
        }
    }
}

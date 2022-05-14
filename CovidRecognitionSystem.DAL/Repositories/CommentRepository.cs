using CovidRecognitionSystem.DAL.Models;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DoctorComment Create(DoctorComment entity)
        {
            _dbContext.DoctorComments.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public void Delete(DoctorComment entity)
        {
            var findComment = _dbContext.DoctorComments.FirstOrDefault(dc => dc.Id == entity.Id); 
            if (findComment != null)
            {
                _dbContext.DoctorComments.Remove(findComment);
                _dbContext.SaveChanges();
            }
        }

        public List<DoctorComment> GetAll()
        {
            return _dbContext.DoctorComments.ToList();
        }

        public DoctorComment GetById(int id)
        {
            return _dbContext.DoctorComments.First(d => d.Id == id);
        }

        public void Update(DoctorComment entity)
        {
            var findComment = _dbContext.DoctorComments.FirstOrDefault(d => d.Id == entity.Id);

            if (findComment != null)
            {
                findComment.DoctorId = entity.DoctorId;
                findComment.PatientId = entity.PatientId;
                findComment.Text = entity.Text; 
                findComment.CommentDateTime = entity.CommentDateTime;

                _dbContext.DoctorComments.Update(findComment);
                _dbContext.SaveChanges();
            }
        }
    }
}

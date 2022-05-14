using CovidRecognitionSystem.DAL.Repositories.Authorization;
using CovidRecognitionSystem.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICommentRepository CommentRepository { get; }

        public IDiagnosisRepository DiagnosisRepository { get; }

        public IDoctorRepository DoctorRepository { get; }

        public IPatientRepository PatientRepository { get; }

        public ISickLeaveRepository SickLeaveRepository { get; }

        public IAuthManager AuthManager { get; }

        public UnitOfWork(AppDbContext dbContext)
        {
            CommentRepository = new CommentRepository(dbContext);
            DoctorRepository = new DoctorRepository(dbContext);
            DiagnosisRepository = new DiagnosisRepository(dbContext);
            PatientRepository = new PatientRepository(dbContext);
            SickLeaveRepository = new SickLeaveRepository(dbContext);
            AuthManager = new AuthManager(dbContext, (DoctorRepository)DoctorRepository);
        }
    }
}

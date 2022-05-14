using CovidRecognitionSystem.DAL.Repositories.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICommentRepository CommentRepository { get; }
        IDiagnosisRepository DiagnosisRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        IPatientRepository PatientRepository { get; }
        ISickLeaveRepository SickLeaveRepository { get; }
        IAuthManager AuthManager { get; }
    }
}

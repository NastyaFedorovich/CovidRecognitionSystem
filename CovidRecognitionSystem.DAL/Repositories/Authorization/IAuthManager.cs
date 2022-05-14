using CovidRecognitionSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Authorization
{
    public interface IAuthManager
    {
        void SignIn(string login, string password);
        void SignOut();
        Doctor GetSignedInUser();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);

        T GetById(int id);

        List<T> GetAll();

        void Update(T entity);

        void Delete(T entity);
    }
}

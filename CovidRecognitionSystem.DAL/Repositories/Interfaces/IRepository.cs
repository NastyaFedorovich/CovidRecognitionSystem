using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidRecognitionSystem.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class // тип Т это куча объектов моделей: докторов пациентов и т.д.
    {
        T Create(T entity); //сущностями

        T GetById(int id); //объекты типа т

        List<T> GetAll();

        void Update(T entity);

        void Delete(T entity);
    }
}

using System.Collections.Generic;

namespace Estacionamiento.Service
{
   public interface IService<T>
    {
        bool  Save(T entity);
        bool  Update(T entity);

        bool  Delete(int id);


        IEnumerable<T> GetAll();

        T Get(int id);
    }
}
using System.Collections.Generic;

namespace DAL.Repository
{
   public interface IRepository<T>
    {
        IList<T> GetList();

        bool Insert(T Entity);

        bool Update(T Entity);

        bool Delete(int Id);

        T Get(int Id);
    }
}

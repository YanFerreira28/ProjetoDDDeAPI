using System.Collections.Generic;

namespace SISControler.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        #region[Interfaces]

        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert(T obj);

        void Delete(int id);

        void Update(T obj);

        void Commit();

        #endregion
    }
}

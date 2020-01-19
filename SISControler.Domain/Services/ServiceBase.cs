using System.Collections.Generic;
using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Contracts.Services;

namespace SISControler.Domain.Services
{
    public class ServiceBase<T> : IServiceBase<T> where T : class
    {
        #region[Parametros] 

        public readonly IRepositoryBase<T> _repository;

        #endregion

        #region[Construtor]

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public void Commit()
        {
            this._repository.Commit();
        }

        #endregion

        public void Delete(int id)
        {
            this._repository.Delete(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this._repository.GetAll();
        }

        public T GetById(int id)
        {
            return this._repository.GetById(id);
        }

        public void Insert(T obj)
        {
            this._repository.Insert(obj);
        }

        public void Update(T obj)
        {
            this._repository.Update(obj);
        }
    }
}

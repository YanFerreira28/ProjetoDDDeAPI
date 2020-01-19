using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SISControler.Domain.Contracts.Repositories;
using SISControler.Infrastructure.Data;

namespace SISControler.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        #region[Propriedades]

        public readonly DataContext _context;

        #endregion

        #region[Contrutor]

        public RepositoryBase(DataContext contexto)
        {
            _context = contexto;
        }

        #endregion

        #region[Metodos]

        public void Insert(T obj)
        {
            this._context.Set<T>().Add(obj);
        }

        public void Delete(int id)
        {
            var del =this._context.Set<T>().Find(id);
            if(del != null)
            {
                this._context.Entry(del).State = EntityState.Deleted;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return this._context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return this._context.Set<T>().Find(id);
        }

        public void Update(T obj)
        {
            this._context.Entry(obj).State = EntityState.Modified;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }

        #endregion
    }
}

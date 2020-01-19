using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Entities;
using SISControler.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISControler.Infrastructure.Repository
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUser
    {
        #region[Parametros]

        public readonly DataContext _dataContext;

        #endregion

        #region[Construtor]

        public RepositoryUsuario(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        #endregion


        #region[Metodos]

        public Usuario ValidaUsuario(string Nome, string Senha)
        {
            return _context.Set<Usuario>().Where(c => c.nome == Nome && c.senha == Senha).FirstOrDefault();
        }

        #endregion
    }
}

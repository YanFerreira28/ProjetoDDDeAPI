using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Entities;
using SISControler.Infrastructure.Data;

namespace SISControler.Infrastructure.Repository
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryClient
    {
        public readonly DataContext _SisContext;

        public RepositoryCliente(DataContext siscontext) : base(siscontext)
        {
            _SisContext = siscontext;
        }
    }
}

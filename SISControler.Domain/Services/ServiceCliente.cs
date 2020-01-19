using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Entities;

namespace SISControler.Domain.Services
{
    public class ServiceCliente : ServiceBase<Cliente>
    {
        #region[Parametros]

        public readonly IRepositoryClient _repositoryCliente;

        #endregion

        #region[Construtor]

        public ServiceCliente(IRepositoryClient repositoryCliente):base(repositoryCliente)
        {
            _repositoryCliente = repositoryCliente;
        }

        #endregion
    }
}

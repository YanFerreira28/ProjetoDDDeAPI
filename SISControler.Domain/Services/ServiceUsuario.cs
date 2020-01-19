using SISControler.Domain.Contracts.Repositories;
using SISControler.Domain.Contracts.Services;
using SISControler.Domain.Entities;

namespace SISControler.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario> , IServiceUsuario
    {
        #region[Parametros]

        public readonly IRepositoryUser _repositoryUser;

        #endregion

        #region[Construtor]

        public ServiceUsuario(IRepositoryUser repositoryUser) :base(repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        #endregion

        #region[Metodos]

        public Usuario ValidaUsuario(string nome, string senha)
        {
            return this._repositoryUser.ValidaUsuario(nome, senha);
        }

        #endregion
    }
}

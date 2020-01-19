using SISControler.Domain.Entities;

namespace SISControler.Domain.Contracts.Repositories
{
    #region[Interfaces]

    public interface IRepositoryUser : IRepositoryBase<Usuario>
    {
        Usuario ValidaUsuario(string nome, string senha);
    }

    #endregion
}

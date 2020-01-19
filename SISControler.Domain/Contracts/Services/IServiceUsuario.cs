using SISControler.Domain.Entities;

namespace SISControler.Domain.Contracts.Services
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        Usuario ValidaUsuario(string nome, string senha);
    }
}
